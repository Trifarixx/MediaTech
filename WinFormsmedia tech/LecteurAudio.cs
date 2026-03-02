using NAudio.Wave;
using NLayer;
using NLayer.NAudioSupport;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsmedia_tech
{
    public partial class LecteurAudio : Form
    {
        private IWavePlayer outputDevice;
        private WaveStream audioFile;
        private string _tempFilePath;
        private System.Windows.Forms.Timer _positionTimer;

        // Nouveaux champs pour le streaming en mémoire
        private Stream _audioStream;
        private string _audioExtension;
        private bool _isLoading;

        public LecteurAudio()
        {
            InitializeComponent();
            InitializeAudio();
        }

        private void InitializeAudio()
        {
            // On utilise les boutons et le panel du Designer (on ne crée plus de nouveaux boutons)
            // On centre les contrôles sous FondPanel au chargement
            Load += (s, e) =>
            {
                CenterControlsUnderImage();
            };

            // Timer pour mettre à jour l'avancement
            _positionTimer = new System.Windows.Forms.Timer { Interval = 500 };
            _positionTimer.Tick += PositionTimer_Tick;

            this.FormClosing += LecteurAudio_FormClosing;
        }

        private void CenterControlsUnderImage()
        {
            try
            {
                // centre horizontal
                int centerX = FondPanel.Left + FondPanel.Width / 2;

                // place BtnPlayPause et BtnStop sous l'image
                BtnPlayPause.Top = FondPanel.Bottom + 10;
                BtnStop.Top = BtnPlayPause.Top;

                BtnPlayPause.Left = centerX - BtnPlayPause.Width - 8;
                BtnStop.Left = centerX + 8;

                // labels de temps sous les boutons
                lbl_TempsCourant.Top = BtnPlayPause.Bottom + 8;
                // garde null-check si le designer n'a pas le label
                if (lbl_Duree != null)
                    lbl_Duree.Top = lbl_TempsCourant.Top;

                lbl_TempsCourant.Left = centerX - 50;
                if (lbl_Duree != null)
                    lbl_Duree.Left = centerX + 10;
            }
            catch
            {
                // en cas de layout non prêt, ignorer
            }
        }

        /// <summary>
        /// Charge et lance la lecture d'une ressource audio.
        /// Si l'URL est HTTP(S), on télécharge en mémoire (pas sur disque).
        /// </summary>
        /// <param name="url">URL HTTP(S) ou chemin local</param>
        public async void LoadAndPlay(string url)
        {
            try
            {
                // URL distante -> télécharger en mémoire (pas sur disque)
                if (Uri.TryCreate(url, UriKind.Absolute, out var uri)
                    && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
                {
                    _isLoading = true;
                    using var client = new HttpClient();
                    using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();

                    // Copier dans un MemoryStream seekable
                    var ms = new MemoryStream();
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        await stream.CopyToAsync(ms);
                    }
                    ms.Position = 0;

                    // conserver le stream et l'extension pour lecture ultérieure
                    // si PrepareAndPlayStream échoue, on peut afficher l'erreur mais garder le stream pour essais
                    _audioStream?.Dispose();
                    _audioStream = ms;
                    _audioExtension = Path.GetExtension(uri.AbsolutePath);

                    _isLoading = false;

                    // tenter de préparer et jouer immédiatement
                    PrepareAndPlayStream(_audioStream, _audioExtension);
                }
                else
                {
                    // chemin local (inchangé)
                    _tempFilePath = url;
                    PrepareAndPlayFile(_tempFilePath);
                }
            }
            catch (Exception ex)
            {
                _isLoading = false;
                MessageBox.Show("Erreur de lecture audio : " + ex.Message);
            }
        }

        private void PrepareAndPlayStream(Stream stream, string extension)
        {
            try
            {
                // Dispose previous
                outputDevice?.Stop();
                outputDevice?.Dispose();
                outputDevice = null;
                audioFile?.Dispose();
                audioFile = null;

                string ext = (extension ?? "").ToLowerInvariant();
                Exception lastEx = null;

                try
                {
                    // s'assurer que le stream est seekable et positionné au début
                    if (stream.CanSeek) stream.Position = 0;

                    if (ext == ".wav")
                    {
                        // WaveFileReader accepte un Stream seekable
                        audioFile = new WaveFileReader(stream);
                    }
                    else
                    {
                        // Essayer Mp3 via NLayer (constructeur prenant Stream)
                        // Mp3FileReader prendra en charge le stream en mémoire
                        audioFile = new Mp3FileReader(stream);
                    }
                }
                catch (Exception ex)
                {
                    lastEx = ex;
                    // Ne pas disposer du stream ici : on le conserve dans _audioStream pour réessais éventuels
                }

                if (audioFile == null)
                {
                    string details = $"Impossible d'ouvrir le flux audio.\nExtension: {ext}\nErreur: {lastEx?.Message}";
                    MessageBox.Show(details, "Erreur de lecture audio");
                    return;
                }

                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();

                // démarrer timer et mettre à jour labels si présents
                if (lbl_Duree != null)
                    lbl_Duree.Text = audioFile.TotalTime.ToString(@"mm\:ss");
                _positionTimer.Start();
                BtnPlayPause.Text = "Pause";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la préparation de la lecture : " + ex.Message);
            }
        }

        private void PrepareAndPlayFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    MessageBox.Show("Fichier introuvable : " + path);
                    return;
                }

                // Dispose previous
                outputDevice?.Stop();
                outputDevice?.Dispose();
                outputDevice = null;
                audioFile?.Dispose();
                audioFile = null;

                string ext = Path.GetExtension(path).ToLowerInvariant();
                Exception lastEx = null;

                try
                {
                    if (ext == ".mp3")
                        audioFile = new Mp3FileReader(path);
                    else if (ext == ".wav")
                        audioFile = new WaveFileReader(path);
                    else
                        throw new InvalidOperationException("Format non supporté : " + ext);
                }
                catch (Exception ex)
                {
                    lastEx = ex;
                    // tentative de secours avec Media Foundation si disponible
                    try
                    {
                        var mf = new MediaFoundationReader(path);
                        audioFile = mf;
                    }
                    catch (Exception mfEx)
                    {
                        lastEx = mfEx;
                    }
                }

                if (audioFile == null)
                {
                    string details = $"Impossible d'ouvrir le fichier audio.\nChemin: {path}\nExtension: {ext}\nErreur: {lastEx?.Message}";
                    MessageBox.Show(details, "Erreur de lecture audio");
                    return;
                }

                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();

                if (lbl_Duree != null)
                    lbl_Duree.Text = audioFile.TotalTime.ToString(@"mm\:ss");
                _positionTimer.Start();
                BtnPlayPause.Text = "Pause";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la préparation de la lecture : " + ex.Message);
            }
        }

        private async Task DownloadToFileAsync(string url, string destinationPath)
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            using var stream = await response.Content.ReadAsStreamAsync();
            using var fs = File.Create(destinationPath);
            await stream.CopyToAsync(fs);
        }

        private void PositionTimer_Tick(object? sender, EventArgs e)
        {
            if (audioFile != null)
            {
                try
                {
                    lbl_TempsCourant.Text = audioFile.CurrentTime.ToString(@"mm\:ss");
                    if (lbl_Duree != null)
                        lbl_Duree.Text = audioFile.TotalTime.ToString(@"mm\:ss");
                }
                catch
                {
                    // ignore pendant les transitions
                }
            }
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (outputDevice == null || audioFile == null)
                {
                    // si aucun fichier chargé, tente de charger le fichier temporaire
                    if (_isLoading)
                    {
                        MessageBox.Show("Chargement en cours, veuillez patienter...");
                        return;
                    }

                    // si on a un stream en mémoire fourni par la page Article, l'utiliser
                    if (_audioStream != null)
                    {
                        PrepareAndPlayStream(_audioStream, _audioExtension);
                        return;
                    }

                    if (!string.IsNullOrEmpty(_tempFilePath) && File.Exists(_tempFilePath))
                    {
                        PrepareAndPlayFile(_tempFilePath);
                        return;
                    }
                    MessageBox.Show("Aucun fichier audio chargé.");
                    return;
                }

                // toggle play/pause
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
                outputDevice?.Stop();
                outputDevice?.Dispose();
                outputDevice = null;

                audioFile?.Dispose();
                audioFile = null;

                _positionTimer.Stop();

                // libérer le stream en mémoire si présent
                try
                {
                    _audioStream?.Dispose();
                }
                catch { }
                finally
                {
                    _audioStream = null;
                    _audioExtension = null;
                }

                _tempFilePath = null;

                // remettre labels
                lbl_TempsCourant.Text = "00:00";
                if (lbl_Duree != null)
                    lbl_Duree.Text = "00:00";
                BtnPlayPause.Text = "Play";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'arrêt : " + ex.Message);
            }
        }

        private void LecteurAudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _positionTimer?.Stop();
                _positionTimer?.Dispose();
            }
            catch { }
            BtnStop_Click(sender, EventArgs.Empty);
        }

        private void lbl_TempsCourant_Click(object sender, EventArgs e)
        {

        }
    }
}