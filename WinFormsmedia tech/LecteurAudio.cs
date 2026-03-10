using NAudio.Wave;
using NLayer.NAudioSupport;
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
        // --- NAudio ---
        private IWavePlayer outputDevice;
        private WaveStream audioFile;
        private System.Windows.Forms.Timer _positionTimer;

        // --- Données ---
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

            // --- Labels artiste / titre ---
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

            // --- Temps ---
            lbl_TempsCourant.ForeColor = C_TEXT_LIGHT;
            lbl_TempsCourant.Font = new Font("Segoe UI", 9f);
            lbl_TempsCourant.BackColor = Color.Transparent;
            lbl_TempsCourant.Text = "00:00";

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

        private void SetRoundedRegion(Control ctrl, int radius)
        {
            ctrl.Region = RoundedRegion(ctrl.Width, ctrl.Height, radius);
        }

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
        //  AUDIO
        // =====================================================================
        private void InitializeAudio()
        {
            Load += (s, e) => CenterLayout();
            Resize += (s, e) => CenterLayout();

            _positionTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _positionTimer.Tick += PositionTimer_Tick;

            this.FormClosing += LecteurAudio_FormClosing;

            progressBar.MouseClick += ProgressBar_Seek;
        }

        /// <summary>
        /// Point d'entrée principal — appelé depuis PageArticleForm
        /// </summary>
        public async void LoadAndPlay(string url,
                                      string titre = "Titre inconnu",
                                      string artiste = "Artiste inconnu",
                                      string imageUrl = "")
        {
            // ✅ Afficher les métadonnées immédiatement
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
                ClearMediaData();

                if (Uri.TryCreate(url, UriKind.Absolute, out var uri) &&
                   (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
                {
                    _isLoading = true;
                    using var client = new HttpClient();
                    using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    _audioData = await response.Content.ReadAsByteArrayAsync();
                    _audioExtension = Path.GetExtension(uri.AbsolutePath).ToLowerInvariant();
                    _isLoading = false;
                    PrepareAndPlayMemory();
                }
                else
                {
                    _tempFilePath = url;
                    PrepareAndPlayFile();
                }
            }
            catch (Exception ex)
            {
                _isLoading = false;
                MessageBox.Show("Erreur de chargement audio : " + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrepareAndPlayMemory()
        {
            if (_audioData == null) return;
            try
            {
                CleanupAudioDevice();
                var ms = new MemoryStream(_audioData);
                audioFile = _audioExtension == ".wav"
                    ? (WaveStream)new WaveFileReader(ms)
                    : new Mp3FileReaderBase(ms, wf => new Mp3FrameDecompressor(wf));
                StartPlayback();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible de lire le flux.\n{ex.Message}");
            }
        }

        private void PrepareAndPlayFile()
        {
            if (string.IsNullOrEmpty(_tempFilePath) || !File.Exists(_tempFilePath)) return;
            try
            {
                CleanupAudioDevice();
                string ext = Path.GetExtension(_tempFilePath).ToLowerInvariant();
                audioFile = ext == ".wav"
                    ? (WaveStream)new WaveFileReader(_tempFilePath)
                    : ext == ".mp3"
                        ? new Mp3FileReaderBase(_tempFilePath, wf => new Mp3FrameDecompressor(wf))
                        : (WaveStream)new MediaFoundationReader(_tempFilePath);
                StartPlayback();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible d'ouvrir le fichier.\n{ex.Message}");
            }
        }

        private void StartPlayback()
        {
            if (audioFile == null) return;
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
            progressBar.Maximum = Math.Max(1, (int)audioFile.TotalTime.TotalSeconds);
            lbl_Duree.Text = audioFile.TotalTime.ToString(@"mm\:ss");
            _positionTimer.Start();
            BtnPlayPause.Text = "⏸";
        }

        private void PositionTimer_Tick(object sender, EventArgs e)
        {
            if (audioFile == null) return;
            try
            {
                int pos = (int)audioFile.CurrentTime.TotalSeconds;
                lbl_TempsCourant.Text = audioFile.CurrentTime.ToString(@"mm\:ss");
                if (pos <= progressBar.Maximum)
                    progressBar.Value = pos;
            }
            catch { }
        }

        private void ProgressBar_Seek(object sender, MouseEventArgs e)
        {
            if (audioFile == null || progressBar.Maximum == 0) return;
            double ratio = (double)e.X / progressBar.Width;
            double seconds = ratio * audioFile.TotalTime.TotalSeconds;
            audioFile.CurrentTime = TimeSpan.FromSeconds(
                Math.Max(0, Math.Min(seconds, audioFile.TotalTime.TotalSeconds)));
            progressBar.Value = (int)audioFile.CurrentTime.TotalSeconds;
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (_isLoading) { MessageBox.Show("Chargement en cours, veuillez patienter…"); return; }

            if (outputDevice != null && audioFile != null)
            {
                if (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    outputDevice.Pause();
                    BtnPlayPause.Text = "▶";
                    _positionTimer.Stop();
                }
                else
                {
                    outputDevice.Play();
                    BtnPlayPause.Text = "⏸";
                    _positionTimer.Start();
                }
                return;
            }

            if (_audioData != null) PrepareAndPlayMemory();
            else if (!string.IsNullOrEmpty(_tempFilePath)) PrepareAndPlayFile();
            else MessageBox.Show("Aucun fichier audio chargé.");
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            CleanupAudioDevice();
            lbl_TempsCourant.Text = "00:00";
            progressBar.Value = 0;
            BtnPlayPause.Text = "▶";
        }

        private void CleanupAudioDevice()
        {
            _positionTimer?.Stop();
            outputDevice?.Stop();
            outputDevice?.Dispose();
            outputDevice = null;
            audioFile?.Dispose();
            audioFile = null;
        }

        private void ClearMediaData()
        {
            CleanupAudioDevice();
            _audioData = null;
            _tempFilePath = null;
            _audioExtension = null;
            lbl_TempsCourant.Text = "00:00";
            lbl_Duree.Text = "00:00";
            progressBar.Value = 0;
        }

        private void LecteurAudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearMediaData();
            _positionTimer?.Dispose();
        }

        private void lbl_TempsCourant_Click(object sender, EventArgs e) { }

        private void progressBar_Click(object sender, EventArgs e) { }
    }
}