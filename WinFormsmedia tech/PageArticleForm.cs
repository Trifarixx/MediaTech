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

            if (panelLivre != null) panelLivre.Visible = false;
            if (panelAudio != null) panelAudio.Visible = false;
            if (panelVideo != null) panelVideo.Visible = false;

            if (nbPages.HasValue && nbPages.Value > 0)
            {
                // C'est un LIVRE
                if (panelLivre != null) panelLivre.Visible = true;
                lbl_NbPages.Text = $"{nbPages} pages";
            }
            else if (dureeCd.HasValue && dureeCd.Value > 0)
            {
                // C'est un CD
                if (panelAudio != null) panelAudio.Visible = true;

                string labelPiste = nbMorceaux > 1 ? "Pistes" : "Piste";
                lbl_Pistes.Text = $"{nbMorceaux} {labelPiste}";

                lbl_DureeAudio.Text = $"{dureeCd} min";
            }
            else if (dureeDvd.HasValue && dureeDvd.Value > 0)
            {
                // C'est un DVD
                if (panelVideo != null) panelVideo.Visible = true;
                lbl_DureeVideo.Text = $"{dureeDvd} min";
            }
        }
    }

}

    