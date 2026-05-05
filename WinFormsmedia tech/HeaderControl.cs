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
            comboProfil.Items.Add("Gérer mon profil");  // Index 0
            comboProfil.Items.Add("Se déconnecter");    // Index 1
            comboProfil.DropDownStyle = ComboBoxStyle.DropDownList;

            //  AJOUT : état initial correct
            comboProfil.Visible = false;
            btn_LogProfil.Visible = false;
            Se_Connecter.Visible = true;
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                if (parentForm is AccueilForm)
                {
                    return;
                }
                else
                {
                    parentForm.Close();
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
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string searchText = textBox1.Text;
                MessageBox.Show("Recherche pour: " + searchText);
            }
        }

        private void btnSeConnecter_Click(object sender, EventArgs e)
        {
            ConnexionForm connexionForm = new ConnexionForm();

            if (connexionForm.ShowDialog() == DialogResult.OK)
            {
                if (connexionForm.IdMembreConnecte != 0)
                {
                    btn_LogProfil.Visible = true;
                    Se_Connecter.Visible = false;
                    comboProfil.Visible = false; // : caché, s'ouvre au clic sur btn_LogProfil
                }
                else
                {
                    btn_LogProfil.Visible = false;
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
            //  on affiche le combo et on ouvre la liste, sans ouvrir ProfilForm directement
            comboProfil.Visible = true;
            comboProfil.Focus();
            comboProfil.DroppedDown = true;
        }

        private void comboProfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboProfil.SelectedIndex)
            {
                case 0: // index 0 = "Gérer mon profil"
                    comboProfil.Visible = false;
                    using (ProfilForm profilForm = new ProfilForm())
                    {
                        profilForm.ShowDialog();
                    }
                    break;

                case 1: //: index 1 = "Se déconnecter"
                    btn_LogProfil.Visible = false;
                    comboProfil.Visible = false;
                    Se_Connecter.Visible = true;

                    MessageBox.Show(
                        "Vous avez été déconnecté avec succès",
                        "Déconnexion",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    break;
            }

            // : -1 au lieu de 0 pour éviter de re-déclencher l'événement
            comboProfil.SelectedIndex = -1;
        }
    }
}