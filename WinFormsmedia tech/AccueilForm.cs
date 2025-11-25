using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace WinFormsmedia_tech
{
    public partial class AccueilForm : Form
    {
        private MediaTechRepository repo;
        private string filtreActif = "Tous";

        public int IdMembreConnecte { get; internal set; }
        public string NomMembreConnecte { get; internal set; }
        public string PrenomMembreConnecte { get; internal set; }

        public AccueilForm()
        {
            InitializeComponent();
            repo = new MediaTechRepository();
        }

        private void AccueilForm_Load(object sender, EventArgs e)
        {
            // Vérifier la connexion à la base de données
            if (!repo.TestConnection())
            {
                MessageBox.Show("Erreur de connexion à la base de données. Vérifiez votre configuration.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Charger tous les contenus au démarrage
            ChargerTousLesContenus();

            // Configurer le DataGridView
            ConfigurerDataGridView();

            // Charger les options des ComboBox
            ChargerComboBoxGenres();
            ChargerComboBoxTri();

            // Définir le bouton "Tous" comme actif par défaut
            DefinirBoutonActif(btn_filter1);

            // Mettre à jour l'état de connexion
            MettreAJourEtatConnexion();
        }

        private void ConfigurerDataGridView()
        {
            // Configurer l'apparence du DataGridView
            dataGridViewCatalogue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCatalogue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCatalogue.MultiSelect = false;
            dataGridViewCatalogue.ReadOnly = true;
            dataGridViewCatalogue.AllowUserToAddRows = false;
            dataGridViewCatalogue.RowHeadersVisible = false;

            // Adapter la taille du DataGridView
            dataGridViewCatalogue.Size = new Size(1400, 600);

            // Style alternance de lignes
            dataGridViewCatalogue.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void ChargerComboBoxGenres()
        {
            try
            {
                box_genre.Items.Clear();
                box_genre.Items.Add("Tous les genres");

                DataTable categories = repo.GetCategories();
                foreach (DataRow row in categories.Rows)
                {
                    box_genre.Items.Add(row["nom_categorie"].ToString());
                }

                box_genre.SelectedIndex = 0;
                box_genre.SelectedIndexChanged += box_genre_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des genres : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerComboBoxTri()
        {
            box_trier.Items.Clear();
            box_trier.Items.Add("Titre (A-Z)");
            box_trier.Items.Add("Titre (Z-A)");
            box_trier.Items.Add("Auteur (A-Z)");
            box_trier.Items.Add("Date de publication (récent)");
            box_trier.Items.Add("Date de publication (ancien)");
            box_trier.Items.Add("Disponibilité");

            box_trier.SelectedIndex = 0;
            box_trier.SelectedIndexChanged += box_trier_SelectedIndexChanged;
        }

        private void ChargerTousLesContenus()
        {
            try
            {
                DataTable contenus = repo.GetAllContenus();
                dataGridViewCatalogue.DataSource = contenus;

                PersonnaliserColonnes();

                filtreActif = "Tous";
                this.Text = $"Média-Tech - {contenus.Rows.Count} contenu(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des contenus : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PersonnaliserColonnes()
        {
            if (dataGridViewCatalogue.Columns.Count > 0)
            {
                // Personnaliser les en-têtes
                if (dataGridViewCatalogue.Columns.Contains("id"))
                    dataGridViewCatalogue.Columns["id"].HeaderText = "ID";

                if (dataGridViewCatalogue.Columns.Contains("titre"))
                    dataGridViewCatalogue.Columns["titre"].HeaderText = "Titre";

                if (dataGridViewCatalogue.Columns.Contains("auteur"))
                    dataGridViewCatalogue.Columns["auteur"].HeaderText = "Auteur";

                if (dataGridViewCatalogue.Columns.Contains("editeur"))
                    dataGridViewCatalogue.Columns["editeur"].HeaderText = "Éditeur";

                if (dataGridViewCatalogue.Columns.Contains("date_publication"))
                {
                    dataGridViewCatalogue.Columns["date_publication"].HeaderText = "Date de publication";
                    dataGridViewCatalogue.Columns["date_publication"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                if (dataGridViewCatalogue.Columns.Contains("quantite"))
                    dataGridViewCatalogue.Columns["quantite"].HeaderText = "Quantité";

                if (dataGridViewCatalogue.Columns.Contains("categories"))
                    dataGridViewCatalogue.Columns["categories"].HeaderText = "Catégories";

                if (dataGridViewCatalogue.Columns.Contains("nombre_page"))
                    dataGridViewCatalogue.Columns["nombre_page"].HeaderText = "Nb Pages";

                if (dataGridViewCatalogue.Columns.Contains("nombre_morceau"))
                    dataGridViewCatalogue.Columns["nombre_morceau"].HeaderText = "Nb Morceaux";

                if (dataGridViewCatalogue.Columns.Contains("duree_minutes"))
                    dataGridViewCatalogue.Columns["duree_minutes"].HeaderText = "Durée (min)";
            }
        }

        private void DefinirBoutonActif(Button boutonActif)
        {
            // Réinitialiser tous les boutons de filtre
            btn_filter1.BackColor = SystemColors.Control;
            btn_filter1.ForeColor = SystemColors.ControlText;
            btn_filter2.BackColor = SystemColors.Control;
            btn_filter2.ForeColor = SystemColors.ControlText;
            btn_filter3.BackColor = SystemColors.Control;
            btn_filter3.ForeColor = SystemColors.ControlText;
            btn_filter4.BackColor = SystemColors.Control;
            btn_filter4.ForeColor = SystemColors.ControlText;

            // Mettre en évidence le bouton actif
            boutonActif.BackColor = Color.Black;
            boutonActif.ForeColor = Color.White;
        }

        // Bouton "Tous"
        private void btn_tous(object sender, EventArgs e)
        {
            ChargerTousLesContenus();
            DefinirBoutonActif(btn_filter1);
            filtreActif = "Tous";
        }

        // Bouton "Livres"
        private void btn_livres(object sender, EventArgs e)
        {
            try
            {
                DataTable livres = repo.GetLivres();
                dataGridViewCatalogue.DataSource = livres;
                PersonnaliserColonnes();
                filtreActif = "Livres";
                DefinirBoutonActif(btn_filter2);

                this.Text = $"Média-Tech - {livres.Rows.Count} livre(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des livres : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bouton "CD Audio"
        private void btn_cd(object sender, EventArgs e)
        {
            try
            {
                DataTable cds = repo.GetCDAudio();
                dataGridViewCatalogue.DataSource = cds;
                PersonnaliserColonnes();
                filtreActif = "CD Audio";
                DefinirBoutonActif(btn_filter3);

                this.Text = $"Média-Tech - {cds.Rows.Count} CD Audio trouvé(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des CD Audio : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bouton "DVD/Blu-Ray"
        private void btn_dvd(object sender, EventArgs e)
        {
            try
            {
                DataTable dvds = repo.GetDVD();
                dataGridViewCatalogue.DataSource = dvds;
                PersonnaliserColonnes();
                filtreActif = "DVD";
                DefinirBoutonActif(btn_filter4);

                this.Text = $"Média-Tech - {dvds.Rows.Count} DVD/Blu-Ray trouvé(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des DVD : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bouton "Découvrir la Bibliothèque"
        private void btn_decouverte(object sender, EventArgs e)
        {
            // Faire défiler vers le catalogue
            dataGridViewCatalogue.Focus();
            ChargerTousLesContenus();
        }

        // Bouton "Créer un compte"
        private void btn_creer_compte(object sender, EventArgs e)
        {
            InscriptionForm inscription = new InscriptionForm();
            inscription.Show();

            this.Hide();

            inscription.FormClosed += (s, args) =>
            {
                if (Application.OpenForms["ConnexionForm"] == null && !this.Visible)
                {
                    this.Show();
                }
            };
        }

        public void MettreAJourEtatConnexion()
        {
            if (IdMembreConnecte > 0)
            {
                if (btn_compte != null)
                    btn_compte.Visible = false;
            }
            else
            {
                if (btn_compte != null)
                    btn_compte.Visible = true;
            }
        }

        // Recherche en temps réel
        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            string recherche = txtRecherche.Text.Trim();

            if (string.IsNullOrWhiteSpace(recherche))
            {
                // Si la recherche est vide, recharger selon le filtre actif
                switch (filtreActif)
                {
                    case "Livres":
                        btn_livres(sender, e);
                        break;
                    case "CD Audio":
                        btn_cd(sender, e);
                        break;
                    case "DVD":
                        btn_dvd(sender, e);
                        break;
                    default:
                        ChargerTousLesContenus();
                        break;
                }
            }
            else
            {
                RechercherContenu(recherche);
            }
        }

        private void RechercherContenu(string recherche)
        {
            try
            {
                DataTable resultats = repo.SearchContenu(recherche);
                dataGridViewCatalogue.DataSource = resultats;
                PersonnaliserColonnes();

                this.Text = $"Média-Tech - {resultats.Rows.Count} résultat(s) pour '{recherche}'";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la recherche : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tri des résultats
        private void box_trier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataGridViewCatalogue.DataSource == null)
                return;

            try
            {
                DataTable dt = (DataTable)dataGridViewCatalogue.DataSource;

                switch (box_trier.SelectedIndex)
                {
                    case 0: // Titre (A-Z)
                        dt.DefaultView.Sort = "titre ASC";
                        break;
                    case 1: // Titre (Z-A)
                        dt.DefaultView.Sort = "titre DESC";
                        break;
                    case 2: // Auteur (A-Z)
                        dt.DefaultView.Sort = "auteur ASC";
                        break;
                    case 3: // Date de publication (récent)
                        dt.DefaultView.Sort = "date_publication DESC";
                        break;
                    case 4: // Date de publication (ancien)
                        dt.DefaultView.Sort = "date_publication ASC";
                        break;
                    case 5: // Disponibilité
                        dt.DefaultView.Sort = "quantite DESC";
                        break;
                }

                dataGridViewCatalogue.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du tri : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Filtre par genre via ComboBox
        private void box_genre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (box_genre.SelectedIndex == 0) // "Tous les genres"
            {
                ChargerTousLesContenus();
            }
            else
            {
                try
                {
                    string genre = box_genre.SelectedItem.ToString();
                    DataTable resultats = repo.GetContenusByCategorie(genre);
                    dataGridViewCatalogue.DataSource = resultats;
                    PersonnaliserColonnes();

                    this.Text = $"Média-Tech - {resultats.Rows.Count} contenu(s) dans '{genre}'";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors du filtrage par genre : {ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ImageAccueil1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewCatalogue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridViewCatalogue.Rows[e.RowIndex];
                    int idContenu = Convert.ToInt32(row.Cells["id"].Value);
                    string titre = row.Cells["titre"].Value?.ToString() ?? "N/A";
                    string auteur = row.Cells["auteur"].Value?.ToString() ?? "N/A";
                    string editeur = row.Cells["editeur"].Value?.ToString() ?? "N/A";
                    string categories = row.Cells["categories"].Value?.ToString() ?? "Non catégorisé";
                    int quantite = Convert.ToInt32(row.Cells["quantite"].Value);
                    string datePubli = row.Cells["date_publication"].Value != DBNull.Value
                        ? Convert.ToDateTime(row.Cells["date_publication"].Value).ToString("dd/MM/yyyy")
                        : "N/A";

                    // Vérifier la disponibilité
                    bool disponible = repo.IsContenuDisponible(idContenu);
                    string statutDispo = disponible ? "✓ Disponible" : "✗ Non disponible";

                    string message = $"📚 DÉTAILS DU CONTENU\n\n" +
                                   $"Titre : {titre}\n" +
                                   $"Auteur : {auteur}\n" +
                                   $"Éditeur : {editeur}\n" +
                                   $"Catégories : {categories}\n" +
                                   $"Date de publication : {datePubli}\n" +
                                   $"Quantité en stock : {quantite}\n" +
                                   $"Statut : {statutDispo}";

                    MessageBox.Show(message, "Détails du contenu",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de l'affichage des détails : {ex.Message}",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void boutonLireDVD_Click(object sender, EventArgs e)
        {
            string cheminVideo = "C:\\Users\\DEBROIZE\\Downloads\\oui.mp4";
            LecteurVideoForm playerForm = new LecteurVideoForm();
            playerForm.LoadMedia(cheminVideo);
            playerForm.Show();
        }
    }

}
