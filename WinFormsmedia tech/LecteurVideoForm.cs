using LibVLCSharp.Shared;
using System;
using System.Drawing;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using System.Linq;

namespace WinFormsmedia_tech
{
    public partial class LecteurVideoForm : Form
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;

        // Timer pour cacher l'interface après inactivité
        private System.Windows.Forms.Timer timerInactivite;

        // Timer pour surveiller la souris (contourne le problème de la vidéo qui bloque les événements)
        private System.Windows.Forms.Timer timerSurveillanceSouris;

        private Point dernierePositionSouris;
        private const int DELAI_INACTIVITE = 3000; // 3 secondes avant de cacher

        public LecteurVideoForm()
        {
            InitializeComponent();

            // Configuration des Timers
            timerInactivite = new System.Windows.Forms.Timer();
            timerInactivite.Interval = DELAI_INACTIVITE;
            timerInactivite.Tick += TimerInactivite_Tick;

            timerSurveillanceSouris = new System.Windows.Forms.Timer();
            timerSurveillanceSouris.Interval = 100;
            timerSurveillanceSouris.Tick += TimerSurveillanceSouris_Tick;

            this.WindowState = FormWindowState.Maximized;
            this.Load += LecteurVideoForm_Load;
            this.FormClosed += LecteurVideoForm_FormClosed;
        }

        private void LecteurVideoForm_Load(object sender, EventArgs e)
        {
            // 1. Initialiser VLC
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            videoView1.MediaPlayer = _mediaPlayer;

            // On utilise une couleur unie propre
            panelControls.BackColor = Color.FromArgb(15, 15, 15); 

            // S'assurer que le panel est bien au-dessus de la vidéo
            panelControls.BringToFront();

            // 3. Gestion des boutons
            btn_PlayPause.Click += BtnPlayPause_Click;
            btn_stop.Click += BtnStop_Click;

            // 4. Événements VLC
            _mediaPlayer.Playing += MediaPlayer_StatusChanged;
            _mediaPlayer.Paused += MediaPlayer_StatusChanged;
            _mediaPlayer.Stopped += MediaPlayer_StatusChanged;
            _mediaPlayer.EndReached += MediaPlayer_StatusChanged;

            // Démarrer la surveillance
            dernierePositionSouris = Cursor.Position;
            timerSurveillanceSouris.Start();
            AfficherInterface();
        }


        private void TimerSurveillanceSouris_Tick(object sender, EventArgs e)
        {
            // On regarde si la souris a bougé depuis la dernière fois
            Point positionActuelle = Cursor.Position;

            if (positionActuelle != dernierePositionSouris)
            {
                // Mouvement détecté !
                dernierePositionSouris = positionActuelle;
                AfficherInterface();
            }
        }

        private void AfficherInterface()
        {
            // Si le panel est déjà visible et que le timer tourne, on ne fait rien de plus que reset le timer
            if (!panelControls.Visible)
            {
                panelControls.Visible = true;
                Cursor.Show();
            }

            // On redémarre le compte à rebours pour cacher
            timerInactivite.Stop();
            timerInactivite.Start();
        }

        private void TimerInactivite_Tick(object sender, EventArgs e)
        {
            // Le temps est écoulé, on cache tout
            // Seulement si la vidéo est en train de jouer (on ne cache pas si c'est en pause)
            if (_mediaPlayer.IsPlaying)
            {
                panelControls.Visible = false;
                if (this.Bounds.Contains(this.PointToClient(Cursor.Position)))
                {
                    Cursor.Hide();
                }
            }
            timerInactivite.Stop();
        }


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

        private void MediaPlayer_StatusChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(UpdateIcons));
            }
            else
            {
                UpdateIcons();
            }
        }

        private void UpdateIcons()
        {
            if (_mediaPlayer.IsPlaying)
                btn_PlayPause.Image = Properties.Resources.Pause;
            else
                btn_PlayPause.Image = Properties.Resources.Play;
        }

        // --- CHARGEMENT ET NETTOYAGE ---

        public async void LoadMedia(string mediaPath)
        {
            if (!this.Visible) this.Show();

            string urlVideo = mediaPath;
            string urlAudio = null; // Sera rempli uniquement si c'est du YouTube HD

            if (mediaPath.Contains("youtube.com") || mediaPath.Contains("youtu.be"))
            {
                try
                {
                    var youtube = new YoutubeClient();

                    // 1. Récupérer le Manifeste (toutes les versions disponibles)
                    var streamManifest = await youtube.Videos.Streams.GetManifestAsync(mediaPath);

                    // On cherche le flux "VideoOnly" avec la plus haute qualité
                    var videoStreamInfo = streamManifest
                        .GetVideoOnlyStreams()
                        .Where(s => s.Container == YoutubeExplode.Videos.Streams.Container.Mp4).GetWithHighestVideoQuality();

                    // 3. Trouver le MEILLEUR Audio - SANS L'IMAGE
                    var audioStreamInfo = streamManifest
                        .GetAudioOnlyStreams()
                        .GetWithHighestBitrate();

                    if (videoStreamInfo != null && audioStreamInfo != null)
                    {
                        urlVideo = videoStreamInfo.Url;
                        urlAudio = audioStreamInfo.Url;

                        var videoInfo = await youtube.Videos.GetAsync(mediaPath);
                        this.Text = $"Lecture de : {videoInfo.Title}";
                    }
                    else
                    {
                        // Si on ne trouve pas de flux séparés (très rare), on se rabat sur le standard 720p
                        var muxed = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                        urlVideo = muxed.Url;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur YouTube : " + ex.Message);
                    return;
                }
            }

            // 4. Création du Média VLC
            using (var media = new Media(_libVLC, new Uri(urlVideo)))
            {
                if (!string.IsNullOrEmpty(urlAudio))
                {
                    media.AddSlave(MediaSlaveType.Audio, 0, urlAudio);
                }

                _mediaPlayer.Play(media);
            }
        }

        private void LecteurVideoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerInactivite.Stop();
            timerSurveillanceSouris.Stop();
            Cursor.Show();

            _mediaPlayer.Stop();
            _mediaPlayer.Dispose();
            _libVLC.Dispose();
        }
    }
}