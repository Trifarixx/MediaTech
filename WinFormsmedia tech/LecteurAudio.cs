using NAudio.Wave;                  // NAudio : bibliothèque externe pour lire de l'audio
using NLayer.NAudioSupport;         // NLayer : décodeur MP3 compatible NAudio
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace WinFormsmedia_tech
{
    public partial class LecteurAudio : Form
    {
        // --- Lecture audio (NAudio) ---
        private IWavePlayer outputDevice;
        private WaveStream audioFile;
        private System.Windows.Forms.Timer _positionTimer;

        // --- Données du morceau en cours---
        private string _tempFilePath;
        private byte[] _audioData;
        private string _audioExtension;
        private bool _isLoading;

        // --- Charte graphique ---
        private static readonly Color C_BG = Color.FromArgb(245, 247, 250); // fond clair
        private static readonly Color C_PANEL = Color.FromArgb(75, 86, 93);    // #4b565d
        private static readonly Color C_ACCENT = Color.FromArgb(61, 173, 213);  // #3dadd5
        private static readonly Color C_GREEN = Color.FromArgb(75, 181, 121);  // #4bb579
        private static readonly Color C_RED = Color.FromArgb(228, 116, 112); // #e47470
        private static readonly Color C_YELLOW = Color.FromArgb(234, 192, 88);  // #eac058
        private static readonly Color C_WHITE = Color.White;
        private static readonly Color C_TEXT_LIGHT = Color.FromArgb(200, 220, 230);
        private static readonly Color C_PANEL_DARK = Color.FromArgb(55, 65, 72);

        public LecteurAudio()
        {
            InitializeComponent();
            ApplyStyle();
            InitializeAudio();
        }

        // =====================================================================
        //  STYLE
        // =====================================================================
        private void ApplyStyle()
        {
            // Formulaire plein écran
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = C_BG;
            this.ForeColor = Color.FromArgb(50, 60, 70);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = "Lecteur Audio — MediaTech";
            this.Font = new Font("Segoe UI", 9f);

            // --- PlayerPanel ---
            PlayerPanel.BackColor = C_PANEL;
            PlayerPanel.Size = new Size(800, 950);
            SetRoundedRegion(PlayerPanel, 24);

            // --- Pochette ---
            PictureBoxCover.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxCover.BackColor = C_PANEL_DARK;
            PictureBoxCover.Size = new Size(640, 640);
            SetRoundedRegion(PictureBoxCover, 16);

            // --- Label artiste / titre ---
            lbl_Artiste.ForeColor = C_ACCENT;
            lbl_Artiste.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            lbl_Artiste.BackColor = Color.Transparent;
            lbl_Artiste.AutoSize = true;
            lbl_Artiste.Text = "Artiste";

            lbl_Titre.ForeColor = C_WHITE;
            lbl_Titre.Font = new Font("Segoe UI", 16f, FontStyle.Bold);
            lbl_Titre.BackColor = Color.Transparent;
            lbl_Titre.AutoSize = true;
            lbl_Titre.Text = "Titre du morceau";

            // --- Temps écoulé ---
            lbl_TempsCourant.ForeColor = C_TEXT_LIGHT;
            lbl_TempsCourant.Font = new Font("Segoe UI", 9f);
            lbl_TempsCourant.BackColor = Color.Transparent;
            lbl_TempsCourant.Text = "00:00";

            // --- Label Durée totale ---
            lbl_Duree.ForeColor = C_TEXT_LIGHT;
            lbl_Duree.Font = new Font("Segoe UI", 9f);
            lbl_Duree.BackColor = Color.Transparent;
            lbl_Duree.Text = "00:00";

            // --- TrackBar ---
            progressBar.Minimum = 0;
            progressBar.Maximum = 1000;
            progressBar.Value = 0;
            //progressBar.TickStyle = TickStyle.None;
            progressBar.AutoSize = false;
            progressBar.Height = 12;
            progressBar.BackColor = C_PANEL;

            // --- Bouton Play/Pause : grand, vert, carré arrondi ---
            BtnPlayPause.Text = "▶";
            BtnPlayPause.Font = new Font("Segoe UI Symbol", 18f);
            BtnPlayPause.Size = new Size(72, 72);
            BtnPlayPause.BackColor = C_GREEN;
            BtnPlayPause.ForeColor = C_WHITE;
            BtnPlayPause.FlatStyle = FlatStyle.Flat;
            BtnPlayPause.FlatAppearance.BorderSize = 0;
            BtnPlayPause.Cursor = Cursors.Hand;
            BtnPlayPause.TextAlign = ContentAlignment.MiddleCenter;
            // Arrondi léger (pas circulaire → pas de rognage)
            BtnPlayPause.Region = RoundedRegion(72, 72, 36);

            // --- Bouton Stop/Restart : plus petit, bleu ---
            BtnStop.Text = "↺";
            BtnStop.Font = new Font("Segoe UI Symbol", 15f);
            BtnStop.Size = new Size(54, 54);
            BtnStop.BackColor = C_ACCENT;
            BtnStop.ForeColor = C_WHITE;
            BtnStop.FlatStyle = FlatStyle.Flat;
            BtnStop.FlatAppearance.BorderSize = 0;
            BtnStop.Cursor = Cursors.Hand;
            BtnStop.TextAlign = ContentAlignment.MiddleCenter;
            BtnStop.Region = RoundedRegion(54, 54, 27);

            // Hover
            AddHover(BtnPlayPause, Color.FromArgb(95, 201, 141), C_WHITE,
                                   C_GREEN, C_WHITE);
            AddHover(BtnStop, Color.FromArgb(80, 190, 230), C_WHITE,
                                   C_ACCENT, C_WHITE);
        }

        // Crée une région arrondie pour les contrôles (boutons, panels)
        private Region RoundedRegion(int w, int h, int r)
        {
            var path = new GraphicsPath();
            path.AddArc(0, 0, r * 2, r * 2, 180, 90);
            path.AddArc(w - r * 2, 0, r * 2, r * 2, 270, 90);
            path.AddArc(w - r * 2, h - r * 2, r * 2, r * 2, 0, 90);
            path.AddArc(0, h - r * 2, r * 2, r * 2, 90, 90);
            path.CloseAllFigures();
            return new Region(path);
        }

        // Applique une région arrondie à un contrôle
        private void SetRoundedRegion(Control ctrl, int radius)
        {
            ctrl.Region = RoundedRegion(ctrl.Width, ctrl.Height, radius);
        }

        // Ajoute un effet de survol (hover) à un bouton
        private void AddHover(Button btn,
            Color hoverBack, Color hoverFore,
            Color origBack, Color origFore)
        {
            btn.MouseEnter += (s, e) => { btn.BackColor = hoverBack; btn.ForeColor = hoverFore; };
            btn.MouseLeave += (s, e) => { btn.BackColor = origBack; btn.ForeColor = origFore; };
        }

        // =====================================================================
        //  LAYOUT
        // =====================================================================
        private void CenterLayout()
        {
            // Centrer le panel dans le formulaire
            PlayerPanel.Left = (this.ClientSize.Width - PlayerPanel.Width) / 2;
            PlayerPanel.Top = (this.ClientSize.Height - PlayerPanel.Height) / 2;

            int cx = PlayerPanel.Width / 2;
            int margin = 30;

            // Pochette
            PictureBoxCover.Left = cx - PictureBoxCover.Width / 2;
            PictureBoxCover.Top = margin;

            // Titre & artiste (avec recalcul AutoSize)
            lbl_Titre.Left = cx - lbl_Titre.PreferredWidth / 2;
            lbl_Artiste.Left = cx - lbl_Artiste.PreferredWidth / 2;
            lbl_Titre.Top = PictureBoxCover.Bottom + 18;
            lbl_Artiste.Top = lbl_Titre.Bottom + 4;

            // Barre de progression
            int barW = PlayerPanel.Width - margin * 2;
            progressBar.Width = barW;
            progressBar.Left = margin;
            progressBar.Top = lbl_Artiste.Bottom + 20;

            // Labels temps
            lbl_TempsCourant.Left = margin;
            lbl_TempsCourant.Top = progressBar.Bottom + 4;
            lbl_Duree.Left = margin + barW - lbl_Duree.PreferredWidth;
            lbl_Duree.Top = progressBar.Bottom + 4;

            // Boutons centrés
            int btnY = lbl_TempsCourant.Bottom + 20;
            int totalW = BtnPlayPause.Width + 20 + BtnStop.Width;
            int startX = cx - totalW / 2;

            BtnPlayPause.Left = startX;
            BtnPlayPause.Top = btnY;
            BtnStop.Left = BtnPlayPause.Right + 20;
            BtnStop.Top = btnY + (BtnPlayPause.Height - BtnStop.Height) / 2;
        }

        // =====================================================================
        //  AUDIO INITIALISATION
        // =====================================================================
        private void InitializeAudio()
        {
            // Recentrer le layout à l'ouverture et à chaque redimensionnement
            Load += (s, e) => CenterLayout();
            Resize += (s, e) => CenterLayout();

            // Timer pour mettre à jour la position de lecture toutes les 500ms
            _positionTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _positionTimer.Tick += PositionTimer_Tick;

            // Nettoyer les ressources audio à la fermeture du formulaire
            this.FormClosing += LecteurAudio_FormClosing;

            //Clic sur la barre de progression → déplace la lecture
            progressBar.MouseClick += ProgressBar_Seek;
        }

        /// <summary>
        /// Point d'entrée principal — Appelé depuis une autre page (PageArticleForm) quand l'utilisateur veut écouter un CD.
        /// </summary>
        public async void LoadAndPlay(string url,
                                      string titre = "Titre inconnu",
                                      string artiste = "Artiste inconnu",
                                      string imageUrl = "")
        {
            // ✅ Afficher les métadonnées (le titre et l'artiste) immédiatement (avant même le chargement)
            lbl_Titre.Text = titre;
            lbl_Artiste.Text = artiste;
            CenterLayout();

            // ✅ Charger la pochette
            if (!string.IsNullOrEmpty(imageUrl))
            {
                try { PictureBoxCover.LoadAsync(imageUrl); }
                catch { PictureBoxCover.BackColor = C_PANEL_DARK; }
            }

            try
            {
                ClearMediaData();   // Réinitialise tout avant de charger un nouveau morceau

                // Vérifie si l'URL est un lien internet (http ou https)
                if (Uri.TryCreate(url, UriKind.Absolute, out var uri) &&
                   (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
                {
                    // ---- CAS 1 : FICHIER DISTANT (internet) ----
                    _isLoading = true;
                    using var client = new HttpClient();        // Client HTTP pour télécharger
                    using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);  // Envoie la requête
                    response.EnsureSuccessStatusCode();     // Lève une erreur si le serveur renvoie une erreur
                    _audioData = await response.Content.ReadAsByteArrayAsync();     // Télécharge le contenu en mémoire
                    _audioExtension = Path.GetExtension(uri.AbsolutePath).ToLowerInvariant();
                    _isLoading = false;
                    PrepareAndPlayMemory();     // Lance la lecture depuis la mémoire
                }
                else
                {
                    // ---- CAS 2 : FICHIER LOCAL (sur le disque) ----
                    _tempFilePath = url;
                    PrepareAndPlayFile();       // Lance la lecture depuis le fichier
                }
            }
            catch (Exception ex)
            {
                _isLoading = false;
                // Affiche une fenêtre d'erreur si le chargement a échoué
                MessageBox.Show("Erreur de chargement audio : " + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ============================================================
        //  PrepareAndPlayMemory — Lecture depuis la RAM (fichier distant)
        //  Les données sont dans _audioData (tableau d'octets).
        // ============================================================
        private void PrepareAndPlayMemory()
        {
            if (_audioData == null) return;
            try
            {
                CleanupAudioDevice();       // Arrête et libère la lecture précédente
                // Crée un flux mémoire à partir du tableau d'octets
                var ms = new MemoryStream(_audioData);
                // Choisit le bon décodeur selon l'extension
                audioFile = _audioExtension == ".wav"
                    ? (WaveStream)new WaveFileReader(ms)        // WAV : décodeur simple
                    : new Mp3FileReaderBase(ms, wf => new Mp3FrameDecompressor(wf));        // MP3 : décodeur NLayer
                StartPlayback();        // Lance la lecture
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible de lire le flux.\n{ex.Message}");
            }
        }

        // ============================================================
        //  PrepareAndPlayFile — Lecture depuis un fichier local
        // ============================================================
        private void PrepareAndPlayFile()
        {
            // Vérifie que le chemin existe bien sur le disque
            if (string.IsNullOrEmpty(_tempFilePath) || !File.Exists(_tempFilePath)) return;
            try
            {
                CleanupAudioDevice();       // Arrête la lecture précédente
                string ext = Path.GetExtension(_tempFilePath).ToLowerInvariant();
                // Choisit le décodeur selon le format
                audioFile = ext == ".wav"
                    ? (WaveStream)new WaveFileReader(_tempFilePath)     // WAV
                    : ext == ".mp3"
                        ? new Mp3FileReaderBase(_tempFilePath, wf => new Mp3FrameDecompressor(wf))      // MP3
                        : (WaveStream)new MediaFoundationReader(_tempFilePath);
                StartPlayback();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible d'ouvrir le fichier.\n{ex.Message}");
            }
        }

        // ============================================================
        //  StartPlayback — Lance concrètement la lecture audio
        //  Appelé après que audioFile est prêt.
        // ============================================================
        private void StartPlayback()
        {
            if (audioFile == null) return;      // Sécurité
            outputDevice = new WaveOutEvent();      // Crée le périphérique de sortie son
            outputDevice.Init(audioFile);       // Connecte le flux audio au périphérique
            outputDevice.Play();                // Lance la lecture
            // Met à jour la barre de progression avec la durée réelle du morceau
            progressBar.Maximum = Math.Max(1, (int)audioFile.TotalTime.TotalSeconds);
            lbl_Duree.Text = audioFile.TotalTime.ToString(@"mm\:ss");
            _positionTimer.Start();     // Démarre la minuterie de mise à jour
            BtnPlayPause.Text = "⏸";   // Change le bouton en "Pause"
        }

        // ============================================================
        //  PositionTimer_Tick — Appelé toutes les 500ms par la minuterie
        //  Met à jour l'affichage du temps et de la barre.
        // ============================================================
        private void PositionTimer_Tick(object sender, EventArgs e)
        {
            if (audioFile == null) return;
            try
            {
                int pos = (int)audioFile.CurrentTime.TotalSeconds;      // Position actuelle en secondes
                lbl_TempsCourant.Text = audioFile.CurrentTime.ToString(@"mm\:ss");
                // Met à jour la barre seulement si la valeur est dans les limites
                if (pos <= progressBar.Maximum)
                    progressBar.Value = pos;
            }
            catch { }
        }

        // ============================================================
        //  ProgressBar_Seek — Déplacement dans le morceau
        //  Appelé quand l'utilisateur clique sur la barre de progression.
        // ============================================================
        private void ProgressBar_Seek(object sender, MouseEventArgs e)
        {
            if (audioFile == null || progressBar.Maximum == 0) return;
            // Calcule le ratio : où a-t-on cliqué sur la barre ?
            double ratio = (double)e.X / progressBar.Width;
            // Convertit le ratio en secondes
            double seconds = ratio * audioFile.TotalTime.TotalSeconds;
            // Déplace la tête de lecture (Math.Max/Min pour rester dans les bornes)
            audioFile.CurrentTime = TimeSpan.FromSeconds(
                Math.Max(0, Math.Min(seconds, audioFile.TotalTime.TotalSeconds)));
            // Met à jour la barre visuellement
            progressBar.Value = (int)audioFile.CurrentTime.TotalSeconds;
        }

        // ============================================================
        //  BtnPlay_Click — Clic sur le bouton Play/Pause
        // ============================================================
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            // Si le fichier est encore en cours de téléchargement → on attend
            if (_isLoading) { MessageBox.Show("Chargement en cours, veuillez patienter…"); return; }

            // Si un périphérique et un flux audio sont déjà en place
            if (outputDevice != null && audioFile != null)
            {
                if (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    // === EN TRAIN DE JOUER → on met en pause ===
                    outputDevice.Pause();
                    BtnPlayPause.Text = "▶";
                    _positionTimer.Stop();
                }
                else
                {
                    // === EN PAUSE → on relance ===
                    outputDevice.Play();
                    BtnPlayPause.Text = "⏸";
                    _positionTimer.Start();
                }
                return;
            }

            // Si pas de périphérique actif mais des données disponibles → recrée la lecture
            if (_audioData != null) PrepareAndPlayMemory();
            else if (!string.IsNullOrEmpty(_tempFilePath)) PrepareAndPlayFile();
            else MessageBox.Show("Aucun fichier audio chargé.");
        }

        // ============================================================
        //  BtnStop_Click — Clic sur le bouton Stop/Redémarrer
        //  Arrête tout et remet à zéro.
        // ============================================================
        private void BtnStop_Click(object sender, EventArgs e)
        {
            CleanupAudioDevice();                  // Arrête et libère le son
            lbl_TempsCourant.Text = "00:00";        // Remet le chrono à zéro
            progressBar.Value = 0;                  // Remet la barre au début
            BtnPlayPause.Text = "▶";                // Remet le symbole "Lecture"
        }

        // ============================================================
        //  CleanupAudioDevice — Arrête et libère le périphérique audio
        //  Appelé avant chaque nouveau chargement et à la fermeture.
        // ============================================================
        private void CleanupAudioDevice()
        {
            _positionTimer?.Stop();     // Arrête la minuterie (le "?" évite un crash si null)
            outputDevice?.Stop();       // Arrête la lecture
            outputDevice?.Dispose();       // Libère la mémoire du périphérique
            outputDevice = null;        // Remet à null pour éviter une double utilisation
            audioFile?.Dispose();       // Libère la mémoire du flux audio
            audioFile = null;
        }

        // ============================================================
        //  ClearMediaData — Remet TOUT à zéro (données + affichage)
        //  Appelé avant de charger un nouveau morceau.
        // ============================================================
        private void ClearMediaData()
        {
            CleanupAudioDevice();           // Arrête le son en cours
            _audioData = null;              // Efface les données téléchargées
            _tempFilePath = null;           // Efface le chemin local
            _audioExtension = null;         // Efface l'extension

            // Remet l'affichage à zéro
            lbl_TempsCourant.Text = "00:00";
            lbl_Duree.Text = "00:00";
            progressBar.Value = 0;
        }

        // ============================================================
        //  LecteurAudio_FormClosing — Appelé quand on ferme la fenêtre
        //  Nettoie tout pour éviter les fuites mémoire.
        // ============================================================
        private void LecteurAudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearMediaData();               // Arrête l'audio et libère les données
            _positionTimer?.Dispose();      // Supprime la minuterie définitivement
        }

        // ============================================================
        //  Méthodes vides — gestionnaires d'événements non utilisés
        //  Ils existent parce qu'un événement y est abonné dans le designer,
        //  mais aucun comportement n'a encore été codé dedans.
        // ============================================================
        private void lbl_TempsCourant_Click(object sender, EventArgs e) { }

        private void progressBar_Click(object sender, EventArgs e) { }
    }
}