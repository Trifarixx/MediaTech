using LibVLCSharp.Shared;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace WinFormsmedia_tech
{
    public partial class LecteurVideoForm : Form
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;

        // Timers
        private System.Windows.Forms.Timer timerInactivite;
        private System.Windows.Forms.Timer timerSurveillanceSouris;
        private Point dernierePositionSouris;
        private const int DELAI_INACTIVITE = 3000;

        // Variable pour fluidifier la barre
        private bool isDragging = false;

        public LecteurVideoForm()
        {
            InitializeComponent();

            // Initialisation des Timers
            timerInactivite = new System.Windows.Forms.Timer();
            timerInactivite.Interval = DELAI_INACTIVITE;
            timerInactivite.Tick += TimerInactivite_Tick;

            timerSurveillanceSouris = new System.Windows.Forms.Timer();
            timerSurveillanceSouris.Interval = 100;
            timerSurveillanceSouris.Tick += TimerSurveillanceSouris_Tick;

            this.Load += LecteurVideoForm_Load;
            this.FormClosed += LecteurVideoForm_FormClosed;
        }

        private void LecteurVideoForm_Load(object sender, EventArgs e)
        {
            // 1. Initialisation VLC
            // (Note: Core.Initialize() doit être dans Program.cs, mais on peut le rappeler ici par sécurité)
            try { Core.Initialize(); } catch { }

            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);

            if (videoView1 != null)
                videoView1.MediaPlayer = _mediaPlayer;

            // 2. Correction de l'Affichage (SUPPRESSION DE LA TRANSPARENCE BUGUÉE)
            // On s'assure juste que le panel est visible et en bas
            if (panelControls != null)
            {
                panelControls.Dock = DockStyle.Bottom;
                panelControls.BringToFront(); // Le met au premier plan
                panelControls.BackColor = Color.FromArgb(40, 40, 40); // Gris foncé opaque (plus stable)
            }

            // 3. Abonnements VLC
            _mediaPlayer.Playing += (s, args) => UpdateInterfaceState();
            _mediaPlayer.Paused += (s, args) => UpdateInterfaceState();
            _mediaPlayer.Stopped += (s, args) => UpdateInterfaceState();
            _mediaPlayer.EndReached += (s, args) => {
                Invoke(new Action(() => this.Close())); // Ferme à la fin
            };

            // Événements de temps (Barre et Labels)
            _mediaPlayer.LengthChanged += MediaPlayer_LengthChanged;
            _mediaPlayer.TimeChanged += MediaPlayer_TimeChanged;

            // 4. Abonnements Interface
            if (btn_PlayPause != null) btn_PlayPause.Click += BtnPlayPause_Click;
            if (btn_Stop != null) btn_Stop.Click += BtnStop_Click;

            // Gestion de la TrackBar
            if (trackBarVideo != null)
            {
                trackBarVideo.MouseDown += (s, args) => isDragging = true;
                trackBarVideo.MouseUp += (s, args) =>
                {
                    if (_mediaPlayer.IsSeekable)
                    {
                        // On change le temps de la vidéo selon la position de la barre
                        _mediaPlayer.Time = (long)trackBarVideo.Value;
                    }
                    isDragging = false;
                };
                // Sécurité : si on lâche la souris en dehors de la barre
                trackBarVideo.MouseLeave += (s, args) => isDragging = false;
            }

            // Démarrage surveillance
            dernierePositionSouris = Cursor.Position;
            timerSurveillanceSouris.Start();
            AfficherInterface();
        }

        // --- GESTION DU TEMPS ET DE LA BARRE ---

        private void MediaPlayer_LengthChanged(object sender, MediaPlayerLengthChangedEventArgs e)
        {
            // Définit la durée totale (une seule fois au début)
            Invoke(new Action(() =>
            {
                if (trackBarVideo != null)
                {
                    trackBarVideo.Minimum = 0;
                    // On cast en int (attention aux vidéos > 24 jours, mais peu probable ici)
                    trackBarVideo.Maximum = (int)e.Length;
                }

                if (lblTempsTotal != null)
                    lblTempsTotal.Text = TimeSpan.FromMilliseconds(e.Length).ToString(@"mm\:ss");
            }));
        }

        private void MediaPlayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            // Met à jour la barre et le temps courant (plusieurs fois par seconde)
            if (isDragging) return; // On ne touche pas si l'utilisateur glisse la barre

            // On utilise BeginInvoke pour ne pas bloquer VLC
            BeginInvoke(new Action(() =>
            {
                if (trackBarVideo != null && e.Time <= trackBarVideo.Maximum)
                {
                    trackBarVideo.Value = (int)e.Time;
                }

                if (lblTempsCourant != null)
                    lblTempsCourant.Text = TimeSpan.FromMilliseconds(e.Time).ToString(@"mm\:ss");
            }));
        }

        private void UpdateInterfaceState()
        {
            Invoke(new Action(() =>
            {
                if (btn_PlayPause != null)
                {
                    if (_mediaPlayer.IsPlaying)
                        btn_PlayPause.Image = Properties.Resources.Pause; // Vérifiez le nom de l'image !
                    else
                        btn_PlayPause.Image = Properties.Resources.Play;  // Vérifiez le nom de l'image !
                }
            }));
        }

        // --- CHARGEMENT YOUTUBE & FICHIER ---

        public async void LoadMedia(string mediaPath)
        {
            if (!this.Visible) this.Show();

            string urlVideo = mediaPath;
            string urlAudio = null;

            if (mediaPath.Contains("youtube.com") || mediaPath.Contains("youtu.be"))
            {
                try
                {
                    var youtube = new YoutubeClient();
                    var streamManifest = await youtube.Videos.Streams.GetManifestAsync(mediaPath);

                    // Récupération flux vidéo (MP4 préféré)
                    var videoStreamInfo = streamManifest
                        .GetVideoOnlyStreams()
                        .Where(s => s.Container == YoutubeExplode.Videos.Streams.Container.Mp4)
                        .GetWithHighestVideoQuality();

                    // Récupération flux audio
                    var audioStreamInfo = streamManifest
                        .GetAudioOnlyStreams()
                        .GetWithHighestBitrate();

                    if (videoStreamInfo != null && audioStreamInfo != null)
                    {
                        urlVideo = videoStreamInfo.Url;
                        urlAudio = audioStreamInfo.Url;
                        var videoInfo = await youtube.Videos.GetAsync(mediaPath);
                        this.Text = videoInfo.Title;
                    }
                    else
                    {
                        // Fallback : flux mixte
                        var muxed = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                        if (muxed != null) urlVideo = muxed.Url;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur YouTube : " + ex.Message);
                    // On essaie quand même avec le lien d'origine au cas où VLC gère
                }
            }

            using (var media = new Media(_libVLC, new Uri(urlVideo)))
            {
                if (!string.IsNullOrEmpty(urlAudio))
                {
                    media.AddSlave(MediaSlaveType.Audio, 0, urlAudio);
                }
                _mediaPlayer.Play(media);
            }
        }

        // --- BOUTONS & INTERFACE ---

        private void BtnPlayPause_Click(object sender, EventArgs e)
        {
            if (_mediaPlayer.IsPlaying) _mediaPlayer.Pause();
            else _mediaPlayer.Play();
            AfficherInterface();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            _mediaPlayer.Stop();
            this.Close();
        }

        private void TimerSurveillanceSouris_Tick(object sender, EventArgs e)
        {
            Point positionActuelle = Cursor.Position;
            if (positionActuelle != dernierePositionSouris)
            {
                dernierePositionSouris = positionActuelle;
                AfficherInterface();
            }
        }

        private void AfficherInterface()
        {
            if (panelControls != null && !panelControls.Visible)
            {
                panelControls.Visible = true;
                Cursor.Show();
            }
            timerInactivite.Stop();
            timerInactivite.Start();
        }

        private void TimerInactivite_Tick(object sender, EventArgs e)
        {
            if (_mediaPlayer.IsPlaying && panelControls != null)
            {
                panelControls.Visible = false;
                // Cache le curseur seulement s'il est au-dessus de la fenêtre
                if (this.Bounds.Contains(Cursor.Position))
                {
                    Cursor.Hide();
                }
            }
            timerInactivite.Stop();
        }

        private void LecteurVideoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerInactivite.Stop();
            timerSurveillanceSouris.Stop();
            Cursor.Show();

            // Nettoyage important
            _mediaPlayer.Stop();
            _mediaPlayer.Dispose();
            _libVLC.Dispose();
        }
    }
}