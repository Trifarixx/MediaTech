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

        // Timers pour l'interface
        private System.Windows.Forms.Timer timerInactivite;
        private System.Windows.Forms.Timer timerSurveillanceSouris;
        private Point dernierePositionSouris;
        private const int DELAI_INACTIVITE = 3000;

        // Variable pour éviter le conflit quand l'utilisateur bouge la barre
        private bool isDragging = false;

        public LecteurVideoForm()
        {
            InitializeComponent();

            // Initialisation des Timers d'interface
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
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            videoView1.MediaPlayer = _mediaPlayer;

            // 2. Style Interface
            panelControls.Parent = videoView1; // Superposition
            panelControls.BackColor = Color.FromArgb(200, 30, 30, 30); // Fond semi-transparent
            panelControls.Dock = DockStyle.Bottom;
            panelControls.BringToFront();

            // 3. Événements VLC
            _mediaPlayer.Playing += MediaPlayer_StatusChanged;
            _mediaPlayer.Paused += MediaPlayer_StatusChanged;
            _mediaPlayer.Stopped += MediaPlayer_StatusChanged;
            _mediaPlayer.EndReached += MediaPlayer_StatusChanged;

            // --- NOUVEAUX ÉVÉNEMENTS POUR LA BARRE ---
            _mediaPlayer.LengthChanged += MediaPlayer_LengthChanged; // Durée totale connue
            _mediaPlayer.TimeChanged += MediaPlayer_TimeChanged;     // Temps qui avance

            // 4. Événements Interface
            btn_PlayPause.Click += BtnPlayPause_Click;
            btn_Stop.Click += BtnStop_Click;

            // --- GESTION DE LA TRACKBAR (SOURIS) ---
            // Quand on appuie sur la barre, on dit "Je suis en train de glisser"
            trackBarVideo.MouseDown += (s, args) => { isDragging = true; };

            // Quand on relâche, on applique le changement de temps
            trackBarVideo.MouseUp += (s, args) =>
            {
                if (_mediaPlayer.IsSeekable)
                {
                    _mediaPlayer.Time = trackBarVideo.Value; // On déplace la vidéo
                }
                isDragging = false; // On a fini de glisser
            };

            // Surveillance souris pour cacher/afficher le menu
            dernierePositionSouris = Cursor.Position;
            timerSurveillanceSouris.Start();
            AfficherInterface();
        }

        // --- GESTION DE LA BARRE DE PROGRESSION ---

        // 1. Quand la durée totale de la vidéo est détectée (au début)
        private void MediaPlayer_LengthChanged(object sender, MediaPlayerLengthChangedEventArgs e)
        {
            // Invoke car VLC est sur un autre thread
            Invoke(new Action(() =>
            {
                // On configure le maximum de la barre (en millisecondes)
                trackBarVideo.Minimum = 0;
                // Attention : TrackBar utilise des INT, donc on cast le long en int
                trackBarVideo.Maximum = (int)e.Length;

                // Affichage du temps total (ex: 03:45)
                if (lblTempsTotal != null)
                    lblTempsTotal.Text = TimeSpan.FromMilliseconds(e.Length).ToString(@"mm\:ss");
            }));
        }

        // 2. Quand le temps avance (appelé plusieurs fois par seconde)
        private void MediaPlayer_TimeChanged(object sender, MediaPlayerTimeChangedEventArgs e)
        {
            // Si l'utilisateur est en train de bouger la barre manuellement, 
            // ON NE TOUCHE PAS à la valeur pour éviter que ça saute.
            if (isDragging) return;

            Invoke(new Action(() =>
            {
                // Vérification de sécurité pour ne pas dépasser le max
                if (e.Time <= trackBarVideo.Maximum)
                {
                    trackBarVideo.Value = (int)e.Time;
                }

                // Mise à jour du label temps courant
                if (lblTempsCourant != null)
                    lblTempsCourant.Text = TimeSpan.FromMilliseconds(e.Time).ToString(@"mm\:ss");
            }));
        }


        // --- LE RESTE DU CODE (Similaire à avant) ---

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

                    var videoStreamInfo = streamManifest
                        .GetVideoOnlyStreams()
                        .Where(s => s.Container == YoutubeExplode.Videos.Streams.Container.Mp4)
                        .GetWithHighestVideoQuality();

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

            using (var media = new Media(_libVLC, new Uri(urlVideo)))
            {
                if (!string.IsNullOrEmpty(urlAudio))
                {
                    media.AddSlave(MediaSlaveType.Audio, 0, urlAudio);
                }
                _mediaPlayer.Play(media);
            }
        }

        private void MediaPlayer_StatusChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired) this.Invoke(new Action(UpdateIcons));
            else UpdateIcons();
        }

        private void UpdateIcons()
        {
            if (_mediaPlayer.IsPlaying)
                btn_PlayPause.Image = Properties.Resources.Pause; // Assurez-vous d'avoir l'image
            else
                btn_PlayPause.Image = Properties.Resources.Play;
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
            this.Close(); // Ferme et revient à l'accueil
        }

        // --- LOGIQUE AUTO-HIDE ---
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
            if (!panelControls.Visible)
            {
                panelControls.Visible = true;
                Cursor.Show();
            }
            timerInactivite.Stop();
            timerInactivite.Start();
        }

        private void TimerInactivite_Tick(object sender, EventArgs e)
        {
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