using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsmedia_tech
{
    public partial class InscriptionForm : Form
    {
        private MediaTechRepository repo;

        public InscriptionForm()
        {
            InitializeComponent();
            repo = new MediaTechRepository();
        }

        private void InscriptionForm_Load(object sender, EventArgs e)
        {
            // Ajouter les gestionnaires d'événements
            buttonCreationCompte.Click += ButtonCreationCompte_Click;
            linkLabelConnexion.LinkClicked += LinkLabelConnexion_LinkClicked;

            // Masquer le DataGridView
            if (dataGridView2 != null)
                dataGridView2.Visible = false;

            // Configurer le mot de passe
            textBox2.PasswordChar = '●';
        }

        private void ButtonCreationCompte_Click(object sender, EventArgs e)
        {
            // Récupérer les valeurs
            string nom = textBoxNom.Text.Trim();
            string prenom = textBoxPrenom.Text.Trim();
            string email = textBoxMail.Text.Trim();
            string motDePasse = textBox2.Text;

            // Validation des champs
            if (!ValiderFormulaire(nom, prenom, email, motDePasse, out string messageErreur))
            {
                MessageBox.Show(messageErreur, "Erreur de validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Créer le compte
            if (repo.CreerMembre(nom, prenom, email, motDePasse, out string message))
            {
                MessageBox.Show(message + "\n\nVous pouvez maintenant vous connecter.",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ouvrir le formulaire de connexion
                ConnexionForm connexionForm = new ConnexionForm();
                connexionForm.Show();
                this.Hide();

                connexionForm.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show(message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValiderFormulaire(string nom, string prenom, string email, string motDePasse, out string message)
        {
            message = "";

            // Vérifier que tous les champs sont remplis
            if (string.IsNullOrWhiteSpace(nom))
            {
                message = "Le nom est requis.";
                textBoxNom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(prenom))
            {
                message = "Le prénom est requis.";
                textBoxPrenom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                message = "L'email est requis.";
                textBoxMail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(motDePasse))
            {
                message = "Le mot de passe est requis.";
                textBox2.Focus();
                return false;
            }

            // Valider le format de l'email
            if (!ValiderEmail(email))
            {
                message = "L'adresse email n'est pas valide.";
                textBoxMail.Focus();
                return false;
            }

            // Valider la longueur du mot de passe
            if (motDePasse.Length < 6)
            {
                message = "Le mot de passe doit contenir au moins 6 caractères.";
                textBox2.Focus();
                return false;
            }

            // Valider que le nom et prénom ne contiennent que des lettres
            if (!Regex.IsMatch(nom, @"^[a-zA-ZÀ-ÿ\s\-']+$"))
            {
                message = "Le nom ne doit contenir que des lettres.";
                textBoxNom.Focus();
                return false;
            }

            if (!Regex.IsMatch(prenom, @"^[a-zA-ZÀ-ÿ\s\-']+$"))
            {
                message = "Le prénom ne doit contenir que des lettres.";
                textBoxPrenom.Focus();
                return false;
            }

            return true;
        }

        private bool ValiderEmail(string email)
        {
            try
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        private void LinkLabelConnexion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Ouvrir le formulaire de connexion
            ConnexionForm connexionForm = new ConnexionForm();
            connexionForm.Show();
            this.Close();
        }
    }
}