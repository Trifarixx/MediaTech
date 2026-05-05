using System;
using System.Windows.Forms;

namespace WinFormsmedia_tech
{
    public partial class ConnexionForm : Form
    {
        private MediaTechRepository repo;

        // Ces trois propriétés stockent les infos du membre qui vient de se connecter.
        public int IdMembreConnecte { get; private set; }
        public string NomMembre { get; private set; }
        public string PrenomMembre { get; private set; }

        public ConnexionForm()
        {
            InitializeComponent();
            repo = new MediaTechRepository();       // Initialise l'accès à la base de données

            // Configurer directement dans le constructeur
            if (dataGridView1 != null)
                dataGridView1.Visible = false;

            // Remplace les caractères tapés par des "●" pour masquer le mot de passe
            textBoxMdp.PasswordChar = '●';

            buttonValider.Click += ButtonValider_Click;
            this.Load += ConnexionForm_Load;
        }

        // ============================================================
        //  ConnexionForm_Load — Appelé quand la fenêtre finit de se charger
        //  On y fait des configurations supplémentaires.
        // ============================================================
        private void ConnexionForm_Load(object sender, EventArgs e)
        {
            // Quand on clique sur le lien "Inscription" → appelle LinkLabelInscription_LinkClicked
            linkLabelInscription.LinkClicked += LinkLabelInscription_LinkClicked;
            // Masquer le DataGridView
            if (dataGridView1 != null)
                dataGridView1.Visible = false;

            // Double sécurité : on re-configure le masquage du mot de passe
            textBoxMdp.PasswordChar = '●';
        }

        // ============================================================
        //  ButtonValider_Click — Clic sur le bouton "Valider"
        //  Vérifie les champs, tente la connexion, redirige si succès.
        // ============================================================
        private void ButtonValider_Click(object sender, EventArgs e)
        {
            // Récupère ce que l'utilisateur a tapé
            // .Trim() supprime les espaces en début et fin de texte
            string email = textBoxEmail.Text.Trim();
            string motDePasse = textBoxMdp.Text;

            // --- Validation : vérifie que les champs ne sont pas vides ---

            if (string.IsNullOrWhiteSpace(email))
            {
                // IsNullOrWhiteSpace = vrai si le texte est vide ou ne contient que des espaces
                MessageBox.Show("Veuillez entrer votre email.", "Champ requis",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();       // Place le curseur dans le champ email
                return;
            }

            if (string.IsNullOrWhiteSpace(motDePasse))
            {
                MessageBox.Show("Veuillez entrer votre mot de passe.", "Champ requis",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxMdp.Focus();
                return;
            }

            // --- Tentative de connexion en base de données ---
            // ConnecterMembre retourne l'ID du membre si le mot de passe est bon, 0 sinon.
            // "out string nom" = la méthode va remplir ces variables à notre place
            int idMembre = repo.ConnecterMembre(email, motDePasse, out string nom, out string prenom, out string message);

            if (idMembre > 0)   // idMembre > 0 = connexion réussie
            {
                // On stocke les infos du membre dans nos propriétés
                IdMembreConnecte = idMembre;
                NomMembre = nom;
                PrenomMembre = prenom;

                MessageBox.Show($"Bienvenue {prenom} {nom} !\n\nVous êtes maintenant connecté.",
                    "Connexion réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // DialogResult.OK = signal pour dire "la fenêtre s'est fermée avec succès"
                // Utile si quelqu'un a ouvert ConnexionForm avec ShowDialog()
                this.DialogResult = DialogResult.OK;

                // --- Ouvre ou récupère la fenêtre d'accueil ---

                // Cherche si une fenêtre "AccueilForm" est déjà ouverte
                AccueilForm accueilForm = Application.OpenForms["AccueilForm"] as AccueilForm;

                if (accueilForm == null)    // Pas encore ouverte → on la crée
                {
                    accueilForm = new AccueilForm();
                    accueilForm.Show();
                }

                // Met à jour les infos de l'utilisateur sur la page d'accueil
                accueilForm.IdMembreConnecte = idMembre;
                accueilForm.NomMembreConnecte = nom;
                accueilForm.PrenomMembreConnecte = prenom;
                accueilForm.Text = $"Média-Tech - Connecté: {prenom} {nom}";    // Titre de la fenêtre
                accueilForm.MettreAJourEtatConnexion(); // Méthode qui rafraîchit l'affichage

                if (!accueilForm.Visible) accueilForm.Visible = true;
                accueilForm.BringToFront(); // Passe l'accueil au premier plan

                this.Hide();    // Cache la fenêtre de connexion (sans la fermer)

                // Quand l'accueil est fermé → on quitte complètement l'application
                accueilForm.FormClosed += (s, args) => Application.Exit();
            }
            else
            {
                // --- Échec de connexion ---
                // "message" contient l'explication (ex : "Mot de passe incorrect")
                MessageBox.Show(message, "Erreur de connexion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // On efface le mot de passe pour que l'utilisateur retape
                textBoxMdp.Clear();
                textBoxMdp.Focus();
            }
        }

        // ============================================================
        //  LinkLabelInscription_LinkClicked
        //  Appelé quand l'utilisateur clique sur le lien "S'inscrire".
        //  On ouvre le formulaire d'inscription et on cache celui-ci.
        // ============================================================
        private void LinkLabelInscription_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InscriptionForm inscriptionForm = new InscriptionForm();
            inscriptionForm.Show(); // Ouvre la fenêtre d'inscription

            // Cache la fenêtre de connexion
            this.Hide();

            // Quand la fenêtre d'inscription se ferme → on réaffiche la connexion
            inscriptionForm.FormClosed += (s, args) => this.Show();
        }
    }
}