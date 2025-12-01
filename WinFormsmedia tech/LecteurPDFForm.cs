using PdfiumViewer;
using IronPdf;
using System.Windows.Forms;
using System.Drawing;
using System;


namespace WinFormsmedia_tech
{
    public partial class LecteurPdfForm : Form
    {
        private Panel panelpdfViewer;
        private PdfiumViewer.PdfViewer pdfViewer;
        public LecteurPdfForm()
        {
            InitializeComponent();
            InitializepdfViewer();
            this.WindowState = FormWindowState.Maximized;
        }
        public LecteurPdfForm(string cheminFichierPdf) : this()
        {
            LoadPDF(cheminFichierPdf);
        }
        private void InitializepdfViewer()
        {
            panelpdfViewer = new Panel();
            panelpdfViewer.Dock = DockStyle.Fill;
            this.Controls.Add(panelViewer);

            pdfViewer = new PdfiumViewer.PdfViewer();
            pdfViewer.Dock = DockStyle.Fill;
            panelViewer.Controls.Add(pdfViewer);


        }
        public void LoadPDF(string cheminFichierPdf)
        {
            try
            {
                var document = PdfiumViewer.PdfDocument.Load("fichier.pdf");
                pdfViewer.Document = document;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du PDF : " + ex.Message);
            }
        }

    }
}
