using System;
using System.Windows.Forms;

namespace WinFormsmedia_tech
{
    public partial class ConnexionForm : Form
    {
        private MediaTechRepository repo;
        public int IdMembreConnecte { get; private set; }
        public string NomMembre { get; private set; }
        public string PrenomMembre { get; private set; }

        public ConnexionForm()
        {
            InitializeComponent();
            repo = new MediaTechRepository();

            // Configurer directement dans le constructeur
            if (dataGridView1 != null)
                dataGridView1.Visible = false;

            textBoxMdp.PasswordChar = '●';

            // Ajouter les gestionnaires d'événements
            buttonValider.Click += ButtonValider_Click;
            linkLabelInscription.LinkClicked += LinkLabelInscription_LinkClicked;
            this.Load += ConnexionForm_Load;
        }

        private void ConnexionForm_Load(object sender, EventArgs e)
        {
            // Ajouter les gestionnaires d'événements
            buttonValider.Click += ButtonValider_Click;
            linkLabelInscription.LinkClicked += LinkLabelInscription_LinkClicked;

            // Masquer le DataGridView
            if (dataGridView1 != null)
                dataGridView1.Visible = false;

            // Configurer le mot de passe
            textBoxMdp.PasswordChar = '●';
        }

        private void ButtonValider_Click(object sender, EventArgs e)
        {
            // Récupérer les valeurs
            string email = textBoxEmail.Text.Trim();
            string motDePasse = textBoxMdp.Text;

            // Validation des champs
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Veuillez entrer votre email.", "Champ requis",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(motDePasse))
            {
                MessageBox.Show("Veuillez entrer votre mot de passe.", "Champ requis",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMdp.Focus();
                return;
            }

            // Tentative de connexion
            int idMembre = repo.ConnecterMembre(email, motDePasse, out string nom, out string prenom, out string message);

            if (idMembre > 0)
            {
                IdMembreConnecte = idMembre;
                NomMembre = nom;
                PrenomMembre = prenom;

                MessageBox.Show($"Bienvenue {prenom} {nom} !\n\nVous êtes maintenant connecté.",
                    "Connexion réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;


                AccueilForm accueilForm = Application.OpenForms["AccueilForm"] as AccueilForm;

                if (accueilForm == null)
                {
                    accueilForm = new AccueilForm();
                    accueilForm.Show();
                }

                // On met à jour les informations de l'utilisateur sur l'accueil
                accueilForm.IdMembreConnecte = idMembre;
                accueilForm.NomMembreConnecte = nom;
                accueilForm.PrenomMembreConnecte = prenom;
                accueilForm.Text = $"Média-Tech - Connecté: {prenom} {nom}";
                accueilForm.MettreAJourEtatConnexion();

                if (!accueilForm.Visible) accueilForm.Visible = true;
                accueilForm.BringToFront();

                this.Hide();

                accueilForm.FormClosed += (s, args) => Application.Exit();
            }
            else
            {
                // Échec de connexion
                MessageBox.Show(message, "Erreur de connexion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Effacer le mot de passe
                textBoxMdp.Clear();
                textBoxMdp.Focus();
            }
        }

        private void LinkLabelInscription_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Ouvrir le formulaire d'inscription
            InscriptionForm inscriptionForm = new InscriptionForm();
            inscriptionForm.Show();
            this.Close();
        }
    }
}