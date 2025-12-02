using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace WinFormsmedia_tech
{
    internal class MediaTechRepository
    {
        string connectionString = @"Server=172.16.119.32,1433;Database=MediaTech;User Id=flav;Password=chpuk;Encrypt=False;";
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
                    ISNULL(STRING_AGG(cat.nom_categorie, ', '), 'Non catégorisé') AS categories
                FROM Contenu c
                LEFT JOIN à a ON c.id = a.id
                LEFT JOIN Categorie cat ON a.id_1 = cat.id
                GROUP BY c.id, c.titre, c.auteur, c.editeur, c.date_publication, c.quantite
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
    }
}