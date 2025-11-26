using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsmedia_tech
{
    public partial class PageArticleForm : Form
    {
        private string _urlFichier;
        private string _typeMedia;
        public PageArticleForm()
        {
            InitializeComponent();
        }
        public void ChargerDonnees(string titre, string auteur, string editeur, string categories,
                                   string date, string urlFichier, string imageUrl,
                                   int? nbPages, int nbMorceaux, int? dureeCd, int? dureeDvd)
        {

            _urlFichier = urlFichier;


            if (lbl_Titre != null) lbl_Titre.Text = "Titre : " + titre;
            if (lbl_auteur != null) lbl_auteur.Text = "Auteur : " + auteur;
            if (lbl_Editeur != null) lbl_Editeur.Text = "Éditeur : " + editeur;
            if (lbl_date != null) lbl_date.Text = "Publié le : " + date;
            if (lbl_Categorie != null) lbl_Categorie.Text = "Catégories : " + categories;

            // gestion de l'image
            ChargerImage(imageUrl);

            if (panelLivre != null) panelLivre.Visible = false;
            if (panelAudio != null) panelAudio.Visible = false;
            if (panelVideo != null) panelVideo.Visible = false;


            // 1/ C'est un LIVRE (si nbPages existe et > 0)
            if (nbPages.HasValue && nbPages.Value > 0)
            {
                if (panelLivre != null)
                {
                    panelLivre.Visible = true;
                    if (lbl_NbPages != null) lbl_NbPages.Text = $"{nbPages} pages";
                }
            }
            // 2/ C'est un DVD (si dureeDvd existe et > 0)
            else if (dureeDvd.HasValue && dureeDvd.Value > 0)
            {
                if (panelVideo != null)
                {
                    panelVideo.Visible = true;
                    if (lbl_DureeVideo != null) lbl_DureeVideo.Text = $"Durée : {dureeDvd} min";
                }
            }
            // 3/ C'est un CD / MUSIQUE 
            else
            {
                if (panelAudio != null)
                {
                    panelAudio.Visible = true;

                    // Gestion singulier/pluriel pour les pistes
                    string textePiste = nbMorceaux > 1 ? "Morceaux" : "Piste (Single)";
                    if (lbl_Pistes != null) lbl_Pistes.Text = $"{nbMorceaux} {textePiste}";

                    // Affichage de la durée si dispo
                    if (lbl_DureeAudio != null)
                    {
                        lbl_DureeAudio.Text = (dureeCd.HasValue && dureeCd > 0)
                            ? $"Durée : {dureeCd} min"
                            : "";
                    }
                }
            }

            if (nbPages.HasValue && nbPages.Value > 0)
            {
                _typeMedia = "Livre";
                // ... afficher panelLivre ...
            }
            else if (dureeDvd.HasValue && dureeDvd.Value > 0)
            {
                _typeMedia = "Video";
                // ... afficher panelVideo ...
            }
            else
            {
                _typeMedia = "Audio";
                // ... afficher panelAudio ...
            }

        }

        private void ChargerImage(string imageUrl)
        {
            PictureBox pic = this.Controls["pictureBoxAffiche"] as PictureBox;
            if (pic != null)
            {
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    try
                    {
                        // C'est ici que l'image se charge depuis l'URL Web
                        pic.Load(imageUrl);
                    }
                    catch
                    {
                        // Si l'URL est invalide ou l'image introuvable
                        pic.Image = Properties.Resources.affiche__1_;
                    }
                }
                else
                {
                    pic.Image = Properties.Resources.affiche__1_;
                }
            }
        }


        private void Emprunter_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_urlFichier))
            {
                MessageBox.Show("Le fichier numérique n'est pas disponible pour ce contenu.", "Indisponible");
                return;
            }

            try
            {
                switch (_typeMedia)
                {
                    case "Video":
                    case "Audio":
                        // Ouvre le lecteur VLC
                        LecteurVideoForm lecteur = new LecteurVideoForm();
                        lecteur.LoadMedia(_urlFichier);
                        lecteur.Show();
                        break;

                    case "Livre":
                        LecteurPDFForm lecteurL = new LecteurPDFForm();

                        // ATTENTION : Vérifiez que LecteurPDFForm a bien une méthode ChargerLivre ou LoadPdf
                        // Si votre méthode s'appelle autrement, modifiez la ligne ci-dessous :
                        //                        lecteurL.ChargerLivre(_urlFichier);

                        lecteurL.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ouverture du lecteur : " + ex.Message);
            }

        }

        private void PageArticleForm_Load(object sender, EventArgs e)
        {

        }


    }

}

    