using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsmedia_tech
{
    public partial class HeaderControl : UserControl
    {
        public HeaderControl()
        {
            InitializeComponent();



        }
        private void btnLogo_Click(object sender, EventArgs e)
        {
            // Trouver le formulaire parent
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                // Vérifier si le formulaire parent est de type AccueilForm
                if (parentForm is AccueilForm)
                {
                    // Si c'est déjà AccueilForm, ne rien faire
                    return;
                }
                else
                {
                    // Fermer le formulaire actuel
                    parentForm.Close();

                    // Ouvrir un nouveau formulaire AccueilForm
                    AccueilForm accueilForm = new AccueilForm();
                    accueilForm.Show();
                }
            }

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string recherche = textBox1.Text;

            if (string.IsNullOrWhiteSpace(recherche))
            {
                MessageBox.Show("Veuillez entrer un mot clé pour rechercher.");
            }
            else
            {
                MessageBox.Show("Vous avez recherché : " + recherche);
            }
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Gérer l'événement de changement de texte ici
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Empêcher le "ding" sonore
                e.SuppressKeyPress = true;

                // Récupérer le texte de la TextBox
                string searchText = textBox1.Text;

                // Afficher le texte dans une MessageBox
                MessageBox.Show("Recherche pour: " + searchText);
            }
        }

        private void btnSeConnecter_Click(object sender, EventArgs e)
        {

        }
        private void btnAccueil_Click(object sender, EventArgs e)
        {


        }
        private void btnCatalogue_Click(object sender, EventArgs e)
        {

        }
        private void btnApropos_Click(object sender, EventArgs e)
        {


        }
        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {



        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
    













