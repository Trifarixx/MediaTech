using System;
using System.Text.RegularExpressions;   // Pour vérifier le format de l'email avec une expression régulière
using System.Windows.Forms;

namespace WinFormsmedia_tech
{
    public partial class InscriptionForm : Form
    {
        // Accès à la base de données
        private MediaTechRepository repo;

        public InscriptionForm()
        {
            InitializeComponent();
            repo = new MediaTechRepository();   // Prépare l'accès à la base

            // Quand on clique sur le bouton "Créer un compte" → appelle ButtonCreationCompte_Click
            buttonCreationCompte.Click += ButtonCreationCompte_Click;
        }

        // ============================================================
        //  InscriptionForm_Load — Quand la fenêtre finit de se charger
        // ============================================================
        private void InscriptionForm_Load(object sender, EventArgs e)
        {
            // Quand on clique sur le lien "Déjà un compte ? Se connecter"
            linkLabelConnexion.LinkClicked += LinkLabelConnexion_LinkClicked;

            // Masquer le DataGridView non utilisé
            if (dataGridView2 != null)
                dataGridView2.Visible = false;

            // Masque le mot de passe avec des "●"
            textBox2.PasswordChar = '●';
        }

        // ============================================================
        //  ButtonCreationCompte_Click — Clic sur "Créer un compte"
        //  Récupère les champs, valide, puis crée le compte.
        // ============================================================
        private void ButtonCreationCompte_Click(object sender, EventArgs e)
        {
            // Récupère ce que l'utilisateur a tapé dans chaque champ
            string nom = textBoxNom.Text.Trim();
            string prenom = textBoxPrenom.Text.Trim();
            string email = textBoxMail.Text.Trim();
            string motDePasse = textBox2.Text;

            // Vérifie que tout est valide
            // "out string messageErreur" = ValiderFormulaire remplira cette variable
            // avec l'explication si quelque chose ne va pas
            if (!ValiderFormulaire(nom, prenom, email, motDePasse, out string messageErreur))
            {
                // Affiche le message d'erreur et arrête ici
                MessageBox.Show(messageErreur, "Erreur de validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Appelle la méthode de création en base de données
            if (repo.CreerMembre(nom, prenom, email, motDePasse, out string message))
            {
                // Succès → on prévient l'utilisateur
                MessageBox.Show(message + "\n\nVous pouvez maintenant vous connecter.",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // On ouvre la fenêtre de connexion pour qu'il puisse se connecter
                ConnexionForm connexionForm = new ConnexionForm();
                connexionForm.Show();
                this.Hide(); // On cache l'inscription

                // Quand la connexion se ferme → on ferme définitivement l'inscription
                connexionForm.FormClosed += (s, args) => this.Close();
            }
            else
            {
                // Échec (ex : email déjà utilisé) → affiche l'erreur
                MessageBox.Show(message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        //  ValiderFormulaire — Vérifie tous les champs avant d'envoyer
        //
        //  Retourne : true si tout est valide, false sinon
        //  "out string message" = rempli avec l'erreur si invalide
        // ============================================================
        private bool ValiderFormulaire(string nom, string prenom, string email, string motDePasse, out string message)
        {
            message = "";       // Message vide au départ

            // --- Vérification que chaque champ est rempli ---

            if (string.IsNullOrWhiteSpace(nom))
            {
                message = "Le nom est requis.";
                textBoxNom.Focus(); // Place le curseur sur le champ problématique
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

            // --- Vérification du format de l'email ---
            // Appelle la méthode ci-dessous qui utilise une expression régulière
            if (!ValiderEmail(email))
            {
                message = "L'adresse email n'est pas valide.";
                textBoxMail.Focus();
                return false;
            }

            // --- Vérification de la longueur du mot de passe ---
            // On exige au moins 6 caractères
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

            // --- Vérification que le nom ne contient que des lettres ---
            // Regex.IsMatch = vérifie que le texte correspond à un motif
            // @"^[a-zA-ZÀ-ÿ\s\-']+$" = uniquement lettres (dont accents), espaces, tirets, apostrophes
            if (!Regex.IsMatch(prenom, @"^[a-zA-ZÀ-ÿ\s\-']+$"))
            {
                message = "Le prénom ne doit contenir que des lettres.";
                textBoxPrenom.Focus();
                return false;
            }

            // Tout est valide !
            return true;
        }

        //  Vérifie que l'email a un format correct
        private bool ValiderEmail(string email)
        {
            try
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(email);    // Retourne true si l'email correspond au motif
            }
            catch
            {
                return false;   // En cas d'erreur inattendue, on considère l'email invalide
            }
        }

        // ============================================================
        //  LinkLabelConnexion_LinkClicked
        //  Quand l'utilisateur clique sur "Déjà inscrit ? Se connecter"
        //  On ouvre la connexion et on cache l'inscription.
        // ============================================================
        private void LinkLabelConnexion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConnexionForm connexionForm = new ConnexionForm();
            connexionForm.Show();

            // On cache la fenêtre d'inscription
            this.Hide();

            // Quand la connexion se ferme → on réaffiche l'inscription
            connexionForm.FormClosed += (s, args) => this.Show();
        }
    }
}