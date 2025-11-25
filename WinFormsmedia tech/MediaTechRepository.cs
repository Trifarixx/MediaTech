using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace WinFormsmedia_tech
{
    internal class MediaTechRepository
    {
        string connectionString = @"Server=172.16.119.32,1433;Database=MediaTech;User Id=flav;Password=chpuk;Encrypt=False;";

        private const int SaltSize = 16; // 16 octets = 128 bits
        private const int HashSize = 32; // 32 octets = 256 bits (pour SHA256)
        private const int Iterations = 10000; // Nombre d'itérations pour PBKDF2

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            // Hache le mot de passe fourni avec le *même* sel
            byte[] newHash = HashPassword(password, storedSalt);

            // Compare les deux hachages en temps constant pour éviter les attaques temporelles
            if (newHash.Length != storedHash.Length)
            {
                return false;
            }

            uint diff = (uint)newHash.Length ^ (uint)storedHash.Length;
            for (int i = 0; i < newHash.Length; i++)
            {
                diff |= (uint)(newHash[i] ^ storedHash[i]);
            }
            return diff == 0;
        }


        private byte[] HashPassword(string password, byte[] salt)
        {
            // Utilise PBKDF2 avec SHA-256
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(HashSize);
            }
        }


        // Récupérer tous les contenus avec leurs catégories
        public DataTable GetAllContenus()
        {
            string query = @"
                SELECT 
                    c.id,
                    c.titre,
                    c.auteur,
                    c.editeur,
                    c.date_publication,
                    c.quantite,
                    c.image_url,
                    c.url_fichier,
                    l.nombre_page,        
                    cd.nombre_morceau,
                    cd.durée AS duree_cd,   
                    d.duree AS duree_dvd,
                    ISNULL(STRING_AGG(cat.nom_categorie, ', '), 'Non catégorisé') AS categories
                FROM Contenu c
                LEFT JOIN Livres l ON c.id = l.id_1
                LEFT JOIN CD_Audio cd ON c.id = cd.id_1
                LEFT JOIN DVD d ON c.id = d.id_1
                LEFT JOIN à a ON c.id = a.id
                LEFT JOIN Categorie cat ON a.id_1 = cat.id
                GROUP BY c.id, c.titre, c.auteur, c.editeur, c.date_publication, c.quantite, c.image_url, c.url_fichier,
                         l.nombre_page, cd.nombre_morceau, cd.durée, d.duree
                ORDER BY c.titre";


            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Filtrer les contenus par catégorie
        public DataTable GetContenusByCategorie(string nomCategorie)
        {
            string query = @"
                SELECT 
                    c.id,
                    c.titre,
                    c.auteur,
                    c.editeur,
                    c.date_publication,
                    c.quantite,
                    STRING_AGG(cat.nom_categorie, ', ') AS categories
                FROM Contenu c
                INNER JOIN à a ON c.id = a.id
                INNER JOIN Categorie cat ON a.id_1 = cat.id
                WHERE cat.nom_categorie = @categorie
                GROUP BY c.id, c.titre, c.auteur, c.editeur, c.date_publication, c.quantite
                ORDER BY c.titre";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@categorie", nomCategorie);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Rechercher des contenus par titre, auteur ou éditeur
        public DataTable SearchContenu(string recherche)
        {
            string query = @"
                SELECT 
                    c.id,
                    c.titre,
                    c.auteur,
                    c.editeur,
                    c.date_publication,
                    c.quantite,
                    ISNULL(STRING_AGG(cat.nom_categorie, ', '), 'Non catégorisé') AS categories
                FROM Contenu c
                LEFT JOIN à a ON c.id = a.id
                LEFT JOIN Categorie cat ON a.id_1 = cat.id
                WHERE c.titre LIKE @recherche 
                   OR c.auteur LIKE @recherche 
                   OR c.editeur LIKE @recherche
                GROUP BY c.id, c.titre, c.auteur, c.editeur, c.date_publication, c.quantite
                ORDER BY c.titre";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@recherche", "%" + recherche + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Récupérer les livres uniquement
        public DataTable GetLivres()
        {
            string query = @"
                SELECT 
                    c.id,
                    c.titre,
                    c.auteur,
                    c.editeur,
                    c.date_publication,
                    c.quantite,
                    l.nombre_page,
                    ISNULL(STRING_AGG(cat.nom_categorie, ', '), 'Non catégorisé') AS categories
                FROM Contenu c
                INNER JOIN Livres l ON c.id = l.id_1
                LEFT JOIN à a ON c.id = a.id
                LEFT JOIN Categorie cat ON a.id_1 = cat.id
                GROUP BY c.id, c.titre, c.auteur, c.editeur, c.date_publication, c.quantite, l.nombre_page
                ORDER BY c.titre";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Récupérer les CD Audio uniquement
        public DataTable GetCDAudio()
        {
            string query = @"
                SELECT 
                    c.id,
                    c.titre,
                    c.auteur,
                    c.editeur,
                    c.date_publication,
                    c.quantite,
                    cd.nombre_morceau,
                    cd.durée AS duree_minutes,
                    ISNULL(STRING_AGG(cat.nom_categorie, ', '), 'Non catégorisé') AS categories
                FROM Contenu c
                INNER JOIN CD_Audio cd ON c.id = cd.id_1
                LEFT JOIN à a ON c.id = a.id
                LEFT JOIN Categorie cat ON a.id_1 = cat.id
                GROUP BY c.id, c.titre, c.auteur, c.editeur, c.date_publication, c.quantite, cd.nombre_morceau, cd.durée
                ORDER BY c.titre";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Récupérer les DVD uniquement
        public DataTable GetDVD()
        {
            string query = @"
                SELECT 
                    c.id,
                    c.titre,
                    c.auteur,
                    c.editeur,
                    c.date_publication,
                    c.quantite,
                    d.duree AS duree_minutes,
                    ISNULL(STRING_AGG(cat.nom_categorie, ', '), 'Non catégorisé') AS categories
                FROM Contenu c
                INNER JOIN DVD d ON c.id = d.id_1
                LEFT JOIN à a ON c.id = a.id
                LEFT JOIN Categorie cat ON a.id_1 = cat.id
                GROUP BY c.id, c.titre, c.auteur, c.editeur, c.date_publication, c.quantite, d.duree
                ORDER BY c.titre";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Récupérer toutes les catégories
        public DataTable GetCategories()
        {
            string query = "SELECT id, nom_categorie, description, type_contenu FROM Categorie ORDER BY nom_categorie";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Récupérer les avis pour un contenu
        public DataTable GetAvisContenu(int idContenu)
        {
            string query = @"
                SELECT 
                    a.id,
                    a.titre,
                    a.commentaire,
                    a.note,
                    m.nom,
                    m.prenom
                FROM Avis a
                LEFT JOIN Membre m ON a.id = m.id_1
                WHERE a.id_1 = @idContenu
                ORDER BY a.id DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@idContenu", idContenu);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Récupérer les emprunts d'un membre
        public DataTable GetEmpruntsMembre(int idMembre)
        {
            string query = @"
                SELECT 
                    e.id,
                    c.titre,
                    c.auteur,
                    e.date_emprunt,
                    e.date_retour,
                    CASE 
                        WHEN e.date_retour IS NULL THEN 'En cours'
                        WHEN e.date_retour < GETDATE() THEN 'En retard'
                        ELSE 'Retourné'
                    END AS statut
                FROM Emprunt e
                INNER JOIN Contenu c ON e.id_2 = c.id
                WHERE e.id_1 = @idMembre
                ORDER BY e.date_emprunt DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@idMembre", idMembre);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Ajouter un emprunt
        public bool AjouterEmprunt(int idMembre, int idContenu, DateTime dateRetourPrevue)
        {
            string query = @"
                INSERT INTO Emprunt (id, date_emprunt, date_retour, id_1, id_2)
                VALUES (
                    (SELECT ISNULL(MAX(id), 0) + 1 FROM Emprunt),
                    GETDATE(),
                    @dateRetour,
                    @idMembre,
                    @idContenu
                )";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idMembre", idMembre);
                    cmd.Parameters.AddWithValue("@idContenu", idContenu);
                    cmd.Parameters.AddWithValue("@dateRetour", dateRetourPrevue);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // Vérifier le nombre d'emprunts actifs d'un membre
        public int GetNombreEmpruntsActifs(int idMembre)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Emprunt 
                WHERE id_1 = @idMembre 
                AND (date_retour IS NULL OR date_retour > GETDATE())";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@idMembre", idMembre);
                connection.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // Vérifier la disponibilité d'un contenu
        public bool IsContenuDisponible(int idContenu)
        {
            string query = @"
                SELECT c.quantite - COUNT(e.id) AS disponible
                FROM Contenu c
                LEFT JOIN Emprunt e ON c.id = e.id_2 
                    AND (e.date_retour IS NULL OR e.date_retour > GETDATE())
                WHERE c.id = @idContenu
                GROUP BY c.quantite";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@idContenu", idContenu);
                connection.Open();
                var result = cmd.ExecuteScalar();
                return result != null && Convert.ToInt32(result) > 0;
            }
        }

        // Tester la connexion à la base de données
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // ===== GESTION DES MEMBRES =====

        // Créer un nouveau membre
        public bool CreerMembre(string nom, string prenom, string email, string motDePasse, out string message)
        {
            message = "";

            // Vérifier si l'email existe déjà
            if (EmailExiste(email))
            {
                message = "Cet email est déjà utilisé.";
                return false;
            }

            // Vérifier qu'il existe au moins un contenu dans la base
            string queryCheckContenu = "SELECT TOP 1 id FROM Contenu";
            int? premierContenuId = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(queryCheckContenu, connection))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            premierContenuId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch
            {
                message = "Erreur lors de la vérification de la base de données.";
                return false;
            }

            // Si aucun contenu n'existe, on ne peut pas créer de membre à cause de la contrainte
            if (!premierContenuId.HasValue)
            {
                message = "Impossible de créer un compte : la base de données doit contenir au moins un contenu.";
                return false;
            }

            // 1. Générer le sel et le hachage
            byte[] salt = GenerateSalt();
            byte[] hash = HashPassword(motDePasse, salt);



            // Créer d'abord un avis lié à un contenu existant
            string idAvis = Guid.NewGuid().ToString();
            string queryAvis = @"
                INSERT INTO Avis (id, titre, commentaire, note, id_1)
                VALUES (@idAvis, 'Profil créé', 'Compte membre', 0, @idContenu)";

            string queryMembre = @"
                INSERT INTO Membre (id, nom, prenom, email, date_inscription, id_1, PasswordHash, PasswordSalt)
                VALUES (
                    (SELECT ISNULL(MAX(id), 0) + 1 FROM Membre),
                    @nom,
                    @prenom,
                    @email,
                    @dateInscription,
                    @idAvis,
                    @PasswordHash, 
                    @PasswordSalt
                )";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Créer l'avis
                            using (SqlCommand cmdAvis = new SqlCommand(queryAvis, connection, transaction))
                            {
                                cmdAvis.Parameters.AddWithValue("@idAvis", idAvis);
                                cmdAvis.Parameters.AddWithValue("@idContenu", premierContenuId.Value);
                                cmdAvis.ExecuteNonQuery();
                            }

                            // Créer le membre
                            using (SqlCommand cmdMembre = new SqlCommand(queryMembre, connection, transaction))
                            {
                                cmdMembre.Parameters.AddWithValue("@nom", nom);
                                cmdMembre.Parameters.AddWithValue("@prenom", prenom);
                                cmdMembre.Parameters.AddWithValue("@email", email);
                                cmdMembre.Parameters.AddWithValue("@dateInscription", DateTime.Now.Date);
                                cmdMembre.Parameters.AddWithValue("@idAvis", idAvis);
                                cmdMembre.Parameters.AddWithValue("@PasswordHash", hash);
                                cmdMembre.Parameters.AddWithValue("@PasswordSalt", salt);
                                cmdMembre.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            message = "Compte créé avec succès !";
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = $"Erreur lors de la création du compte : {ex.Message}";
                return false;
            }
        }

        // Vérifier si un email existe déjà
        public bool EmailExiste(string email)
        {
            string query = "SELECT COUNT(*) FROM Membre WHERE email = @email";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    connection.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        // Connecter un membre (retourne l'ID du membre si succès, 0 sinon)
        public int ConnecterMembre(string email, string motDePasse, out string nom, out string prenom, out string message)
        {
            nom = "";
            prenom = "";
            message = "";

            // 1. Mettre à jour la requête (remplacer mot_de_passe par les nouvelles colonnes)
            string query = @"
                SELECT id, nom, prenom, PasswordHash, PasswordSalt
                FROM Membre 
                WHERE email = @email";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 2. Récupérer les informations
                            int id = reader.GetInt32(0);
                            nom = reader.GetString(1);
                            prenom = reader.GetString(2);

                            // Gérer les cas où les colonnes sont NULL (pour les anciens comptes)
                            if (reader.IsDBNull(3) || reader.IsDBNull(4))
                            {
                                message = "Erreur de configuration du compte (hachage manquant).";
                                return 0;
                            }

                            // LIRE EN TANT QUE byte[] (ET NON GetString)
                            byte[] storedHash = (byte[])reader["PasswordHash"];
                            byte[] storedSalt = (byte[])reader["PasswordSalt"];

                            // 3. Vérifier le mot de passe
                            if (VerifyPassword(motDePasse, storedHash, storedSalt))
                            {
                                message = "Connexion réussie !";
                                return id;
                            }
                            else
                            {
                                message = "Mot de passe incorrect.";
                                return 0;
                            }
                        }
                        else
                        {
                            message = "Email non trouvé.";
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Si vous avez encore une erreur de "cast" ici,
                // vérifiez que vos colonnes s'appellent bien PasswordHash et PasswordSalt
                message = $"Erreur de connexion : {ex.Message}";
                return 0;
            }
        }

        // Récupérer les informations d'un membre
        public DataTable GetMembreInfo(int idMembre)
        {
            string query = @"
                SELECT 
                    id,
                    nom,
                    prenom,
                    email,
                    date_inscription
                FROM Membre
                WHERE id = @idMembre";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@idMembre", idMembre);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}   