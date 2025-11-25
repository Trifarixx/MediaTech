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
        public PageArticleForm()
        {
            InitializeComponent();
        }
        public void ChargerDonnees(string titre, string auteur, string editeur, string categories,
                                   string date, string imageUrl,
                                   int? nbPages, int nbMorceaux, int? dureeCd, int? dureeDvd)
        {
            if (lbl_Titre != null) lbl_Titre.Text = "Titre : " + titre;
            if (lbl_auteur != null) lbl_auteur.Text = "Auteur : " + auteur;
            if (lbl_Editeur != null) lbl_Editeur.Text = "Éditeur : " + editeur;
            if (lbl_date != null) lbl_date.Text = "Publié le : " + date;
            if (lbl_Categorie != null) lbl_Categorie.Text ="Catégories : " + categories;

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
        }

        private void ChargerImage(string url)
        {
            if (pictureBoxAffiche == null) return;

            // Remise à zéro de l'image précédente
            pictureBoxAffiche.Image = null;

            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    pictureBoxAffiche.Load(url); // Essaie de charger depuis Internet
                }
                catch
                {
                    // Si lien cassé ou erreur internet -> Image par défaut
                    pictureBoxAffiche.Image = Properties.Resources.affiche__1_;
                }
            }
            else
            {
                // Si pas d'URL -> Image par défaut
                pictureBoxAffiche.Image = Properties.Resources.affiche__1_;
            }
        }

        // Bouton Fermer (si vous en avez un)
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

    