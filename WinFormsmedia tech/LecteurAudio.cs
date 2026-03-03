using NAudio.Wave;
using NLayer.NAudioSupport;
using System;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace WinFormsmedia_tech
{
    public partial class LecteurAudio : Form
    {
        private IWavePlayer outputDevice;
        private WaveStream audioFile;
        private System.Windows.Forms.Timer _positionTimer;

        // --- Variables d'état ---
        private string _tempFilePath;       // Pour les fichiers locaux
        private byte[] _audioData;          // Pour le streaming en mémoire (remplace _audioStream)
        private string _audioExtension;     // Extension (.mp3, .wav)
        private bool _isLoading;            // Indique si un téléchargement est en cours

        public LecteurAudio()
        {
            InitializeComponent();
            InitializeAudio();
        }

        private void InitializeAudio()
        {
            Load += (s, e) =>
            {
                CenterControlsUnderImage();
            };

            _positionTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _positionTimer.Tick += PositionTimer_Tick;

            this.FormClosing += LecteurAudio_FormClosing;
        }

        private void CenterControlsUnderImage()
        {
            try
            {
                int centerX = FondPanel.Left + FondPanel.Width / 2;

                BtnPlayPause.Top = FondPanel.Bottom + 10;
                BtnStop.Top = BtnPlayPause.Top;

                BtnPlayPause.Left = centerX - BtnPlayPause.Width - 8;
                BtnStop.Left = centerX + 8;

                lbl_TempsCourant.Top = BtnPlayPause.Bottom + 8;

                if (lbl_Duree != null)
                    lbl_Duree.Top = lbl_TempsCourant.Top;

                lbl_TempsCourant.Left = centerX - 50;

                if (lbl_Duree != null)
                    lbl_Duree.Left = centerX + 10;
            }
            catch
            {
                // Ignorer si le layout n'est pas prêt
            }
        }

        /// <summary>
        /// Charge et lance la lecture (HTTP en mémoire ou chemin local)
        /// </summary>
        public async void LoadAndPlay(string url)
        {
            try
            {
                // Libérer les anciennes données avant de charger une nouvelle piste
                ClearMediaData();

                if (Uri.TryCreate(url, UriKind.Absolute, out var uri) &&
                   (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
                {
                    _isLoading = true;

                    using var client = new HttpClient();
                    using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();

                    // On stocke les données dans un tableau d'octets pour pouvoir rejouer après un Stop
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
                MessageBox.Show("Erreur de chargement audio : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrepareAndPlayMemory()
        {
            if (_audioData == null) return;

            try
            {
                CleanupAudioDevice();

                // On crée un nouveau MemoryStream à partir de nos octets sauvegardés
                var ms = new MemoryStream(_audioData);

                if (_audioExtension == ".wav")
                {
                    audioFile = new WaveFileReader(ms);
                }
                else
                {
                    // Utilisation explicite de NLayer pour le MP3 en mémoire
                    audioFile = new Mp3FileReaderBase(ms, wf => new Mp3FrameDecompressor(wf));
                }

                StartPlayback();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible de lire le flux en mémoire.\nErreur: {ex.Message}", "Erreur de lecture");
            }
        }

        private void PrepareAndPlayFile()
        {
            if (string.IsNullOrEmpty(_tempFilePath) || !File.Exists(_tempFilePath))
            {
                MessageBox.Show("Fichier introuvable : " + _tempFilePath);
                return;
            }

            try
            {
                CleanupAudioDevice();

                string ext = Path.GetExtension(_tempFilePath).ToLowerInvariant();

                if (ext == ".wav")
                {
                    audioFile = new WaveFileReader(_tempFilePath);
                }
                else if (ext == ".mp3")
                {
                    // Utilisation de NLayer pour le fichier local aussi
                    audioFile = new Mp3FileReaderBase(_tempFilePath, wf => new Mp3FrameDecompressor(wf));
                }
                else
                {
                    // Fallback MediaFoundation pour les autres formats (.m4a, .aac, etc.)
                    audioFile = new MediaFoundationReader(_tempFilePath);
                }

                StartPlayback();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible d'ouvrir le fichier audio.\nErreur: {ex.Message}", "Erreur de lecture");
            }
        }

        private void StartPlayback()
        {
            if (audioFile == null) return;

            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

            if (lbl_Duree != null)
                lbl_Duree.Text = audioFile.TotalTime.ToString(@"mm\:ss");

            _positionTimer.Start();
            BtnPlayPause.Text = "Pause";
        }

        private void PositionTimer_Tick(object sender, EventArgs e)
        {
            if (audioFile != null)
            {
                try
                {
                    lbl_TempsCourant.Text = audioFile.CurrentTime.ToString(@"mm\:ss");
                }
                catch { /* Ignorer pendant les transitions */ }
            }
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isLoading)
                {
                    MessageBox.Show("Chargement en cours, veuillez patienter...");
                    return;
                }

                // Cas 1 : La lecture est en cours ou en pause
                if (outputDevice != null && audioFile != null)
                {
                    if (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        outputDevice.Pause();
                        BtnPlayPause.Text = "Play";
                        _positionTimer.Stop();
                    }
                    else
                    {
                        outputDevice.Play();
                        BtnPlayPause.Text = "Pause";
                        _positionTimer.Start();
                    }
                    return;
                }

                // Cas 2 : L'utilisateur a cliqué sur Stop précédemment, on doit recréer le lecteur
                if (_audioData != null)
                {
                    PrepareAndPlayMemory();
                }
                else if (!string.IsNullOrEmpty(_tempFilePath))
                {
                    PrepareAndPlayFile();
                }
                else
                {
                    MessageBox.Show("Aucun fichier audio n'est chargé.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la lecture : " + ex.Message);
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                // On arrête et on nettoie uniquement le lecteur (pas les données en mémoire !)
                CleanupAudioDevice();

                // Remise à zéro de l'interface
                lbl_TempsCourant.Text = "00:00";
                BtnPlayPause.Text = "Play";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'arrêt : " + ex.Message);
            }
        }

        /// <summary>
        /// Nettoie les composants audio NAudio en cours d'utilisation
        /// </summary>
        private void CleanupAudioDevice()
        {
            _positionTimer?.Stop();

            outputDevice?.Stop();
            outputDevice?.Dispose();
            outputDevice = null;

            audioFile?.Dispose();
            audioFile = null;
        }

        /// <summary>
        /// Vide complètement les données en mémoire ou le chemin local
        /// </summary>
        private void ClearMediaData()
        {
            CleanupAudioDevice();
            _audioData = null;
            _tempFilePath = null;
            _audioExtension = null;
            lbl_TempsCourant.Text = "00:00";
            if (lbl_Duree != null) lbl_Duree.Text = "00:00";
        }

        private void LecteurAudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearMediaData();
            _positionTimer?.Dispose();
        }

        private void lbl_TempsCourant_Click(object sender, EventArgs e)
        {
            // Événement conservé si lié dans le Designer
        }
    }
}