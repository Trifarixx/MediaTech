using PdfiumViewer;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsmedia_tech
{
    public partial class LecteurPdfForm : Form
    {
        private PdfiumViewer.PdfViewer pdfViewer;
        private static readonly HttpClient httpClient = new HttpClient();

        public LecteurPdfForm()
        {
            InitializeComponent();
            InitializepdfViewer();
            this.WindowState = FormWindowState.Maximized;
        }

        public LecteurPdfForm(string urlOuCheminFichierPdf) : this()
        {
            _ = LoadPDFAsync(urlOuCheminFichierPdf);
        }

        private void InitializepdfViewer()
        {
            // Vide le Designer pour éviter tout conflit visuel
            this.Controls.Clear();

            pdfViewer = new PdfiumViewer.PdfViewer();
            pdfViewer.Dock = DockStyle.Fill;
            pdfViewer.ShowToolbar = true;
            pdfViewer.ShowBookmarks = false;


            this.Controls.Add(pdfViewer);
        }

        //Affiche le PDF à partir d'une URL ou d'un chemin local
        public async Task LoadPDFAsync(string urlOuChemin)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(urlOuChemin))
                {
                    MessageBox.Show("Aucun fichier PDF associé à cet article.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                byte[] pdfBytes;

                if (urlOuChemin.StartsWith("http://") || urlOuChemin.StartsWith("https://"))
                {
                    // Chargement depuis URL web
                    pdfBytes = await httpClient.GetByteArrayAsync(urlOuChemin);
                }
                else
                {
                    //Copie en local pour contourner les problèmes UNC
                    string tempPath = Path.Combine(Path.GetTempPath(), Path.GetFileName(urlOuChemin));
                    File.Copy(urlOuChemin, tempPath, overwrite: true);
                    pdfBytes = File.ReadAllBytes(tempPath);
                }

                var ms = new MemoryStream(pdfBytes);
                var document = PdfiumViewer.PdfDocument.Load(ms);

                // Force le rendu après chargement
                Action afficher = () =>
                {
                    pdfViewer.Document = document;

                    pdfViewer.Refresh();
                };

                if (this.InvokeRequired)
                    this.Invoke(afficher);
                else
                    afficher();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Accès refusé. Vérifiez vos permissions réseau.",
                    "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Erreur réseau : " + ex.Message,
                    "Erreur réseau", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
