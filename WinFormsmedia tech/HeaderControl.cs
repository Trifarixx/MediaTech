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



        private MediaTechRepository repo;



        public HeaderControl()
        {
            InitializeComponent();
            repo = new MediaTechRepository();
            comboProfil.Items.Add("Gérer mon profil");
            comboProfil.Items.Add("Se déconnecter");

            comboProfil.DropDownStyle = ComboBoxStyle.DropDownList;





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
            ConnexionForm connexionForm = new ConnexionForm();

            // Ouvre la fenêtre en mode modal et attend la fermeture
            if (connexionForm.ShowDialog() == DialogResult.OK)
            {
                // On récupère l'ID du membre connecté
                if (connexionForm.IdMembreConnecte != 0)
                {
                    btn_LogProfil.Visible = true;    // Affiche bouton profil
                    Se_Connecter.Visible = false;   // Cache bouton connexion
                    comboProfil.Visible = true;

                }
                else
                {
                    btn_LogProfil.Visible = false;   // Cache bouton profil
                }

            }


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

        private void btnLogProfil(object sender, EventArgs e)
        {


        }

        private void comboProfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProfil.SelectedIndex == 0)
                return;

            string selection = comboProfil.SelectedItem.ToString();

            if (selection == "Gérer mon profil")
            {
                ProfilForm profilForm = new ProfilForm();
                profilForm.Show();
               

            }
            else if (selection == "Se déconnecter")
            {
                btn_LogProfil.Visible = false;   // Cache bouton profil
                Se_Connecter.Visible = true;    // Affiche bouton connexion
                comboProfil.SelectedIndex = 0; // Réinitialise la sélection

                MessageBox.Show("Vous avez été déconnecté avec succès.", "Déconnexion",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}

    



    
    



















