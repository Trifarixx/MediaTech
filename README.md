# 📚 Média-Tech

![Status](https://img.shields.io/badge/Status-En_Développement-yellow) ![Platform](https://img.shields.io/badge/Platform-Windows-blue) ![Language](https://img.shields.io/badge/Language-C%23-green)

**Média-Tech** est une application de gestion de médiathèque moderne développée en C# (Windows Forms). Elle permet la gestion des emprunts, des utilisateurs, et intègre des lecteurs multimédias avancés pour la consultation directe de contenus (Livres PDF, Streaming Audio/Vidéo YouTube, etc.).

> ⚠️ **Note :** Ce projet est actuellement en cours de développement (WIP). Certaines fonctionnalités sont susceptibles d'évoluer.

## 🚀 Fonctionnalités Clés

* **Authentification Sécurisée :** Système de Connexion/Inscription avec hachage de mot de passe (PBKDF2 + Sel).
* **Catalogue Interactif :**
    * Affichage sous forme de grille moderne.
    * Filtres par catégorie (Livres, CD, DVD).
    * Recherche textuelle et tris dynamiques.
* **Lecteurs Multimédias Intégrés :**
    * **Vidéo :** Lecteur basé sur `LibVLCSharp` (VLC) supportant la 4K et les flux YouTube.
    * **Audio :** Lecteur dédié basé sur `NAudio` avec Plein écran et barre de progression.
    * **Livres :** Visionneuse PDF intégrée basé sur `IronPDF` avec possibilité de zoom et passer en mode nuit.
* **Streaming YouTube :** Extraction automatique des flux vidéo/audio via `YoutubeExplode` pour une lecture sans publicité dans l'application.

## 🛠️ Prérequis Techniques

Pour faire tourner le projet, vous avez besoin de :

* **OS :** Windows 10 ou 11 (x64 recommandé).
* **IDE :** Visual Studio 2019 ou 2022.
* **Base de données :** Microsoft SQL Server (Express ou LocalDB).
* **Framework :** .NET Framework 4.7.2 ou supérieur (ou .NET 6/8 selon la configuration du projet).

## ⚙️ Installation et Configuration

### 1. Cloner le projet
```bash
git clone https://github.com/Zainabe10/MediaTech.git
```
### 2. Installation des dépendances (NuGet)
Le projet utilise plusieurs paquets externes. Visual Studio devrait les restaurer automatiquement, mais si ce n'est pas le cas, exécutez ces commandes dans la Console du Gestionnaire de package :
Install-Package LibVLCSharp.WinForms
Install-Package VideoLAN.LibVLC.Windows
Install-Package LivVLCSharp
Install-Package NAudio
Install-Package YoutubeExplode
Install-Package System.Data.SqlClient
Install-Package IronPDF
Install-Package Microsoft.Data.SqlClient
Install-Package PdfiumViewer
Install-Package syncfusion.pdfviewer.windows

### 3. 📦 Architecture & Technologies
Langage : C#

UI : Windows Forms (.NET)

BDD : SQL Server (ADO.NET via Microsoft.Data.SqlClient)

Bibliothèques majeures :

LibVLCSharp : Moteur de lecture vidéo robuste.

YoutubeExplode : Extraction de métadonnées et flux YouTube.

NAudio : Gestion audio bas niveau.

### 4. Installation SQL SERVER 

1. Configuration Réseau du Serveur SQL
Cette étape permet de rendre la base de données accessible sur le réseau.

Ouvrir le Gestionnaire de configuration :

Lancez une invite de commande (cmd) et tapez SQLServerManager16.msc.

Activer TCP/IP :

Allez dans Configuration du réseau SQL Server > Protocoles pour SQLEXPRESS.

Faites un clic droit sur TCP/IP et choisissez Activer (Enable).

Configurer le Port 1433 :

Double-cliquez sur TCP/IP et allez dans l'onglet Adresses IP.

Descendez tout en bas à la section IPAll.

Définissez le Port TCP à 1433.

Service SQL Browser :

Assurez-vous que le service SQL Server Browser est activé. S'il est grisé, changez le mode de lancement en "Automatique" dans les propriétés, puis activez-le.

Redémarrage :

Redémarrez le service SQL Server pour appliquer les changements.

2. Configuration de la Sécurité & Pare-feu
Pare-feu Windows :

Créez une règle entrante pour autoriser les communications TCP sur le port 1433.

Activer l'Authentification Mixte (SSMS) :

Dans SQL Server Management Studio (SSMS), faites un clic droit sur le Serveur > Propriétés.

Allez dans l'onglet Sécurité (Security).

Cochez SQL Server and Windows Authentication mode (Mixed Mode) et cliquez sur OK.


Important : Redémarrez le service SQL Server (via services.msc ou le Configuration Manager).

3. Gestion des Utilisateurs
Création d'un utilisateur dédié pour l'application.

Dans SSMS, dépliez le dossier Sécurité, puis clic droit sur Connexions > Nouvelle connexion.

Créez l'utilisateur (Exemple : User yohan, Mot de passe yohan1234).

Dans les rôles du serveur ou mappage de l'utilisateur, attribuez le droit db_owner si nécessaire pour chaque base concernée.

4. Connexion au Serveur (Côté Client)
Pour se connecter au serveur depuis un poste distant :


Nom du serveur : Adresse_IP_du_LAN,1433 (La virgule est importante pour spécifier le port).


Authentification : Choisir Authentification SQL Server.

Identifiants : Utilisez le login et mot de passe créés précédemment.

5. Un petit jeu de données à insérer dans la bases de données :

DECLARE @NewContenuID INT;
DECLARE @NewCDAudioID INT;
DECLARE @CategorieID VARCHAR(50);

-- 1. Calcul du nouvel ID Contenu
SELECT @NewContenuID = ISNULL(MAX(id), 0) + 1 FROM Contenu;

-- 2. Insertion dans Contenu
INSERT INTO Contenu (id, titre, auteur, editeur, date_publication, quantite, image_url, url_fichier)
VALUES (
    @NewContenuID, 
    LEFT('Die For You (ft. Grabbitz)', 50),      -- Titre
    'Grabbitz',                                  -- Auteur (Artiste principal)
    'Riot Games / VALORANT',                     -- Éditeur
    '2021-11-22',                                -- Date de publication
    5,                                           -- Quantité
    'https://img.youtube.com/vi/h7MYJghRWt0/maxresdefault.jpg', -- Miniature
    'https://www.youtube.com/watch?v=h7MYJghRWt0' -- Lien YouTube
);

-- 3. Insertion dans CD_Audio (Single)
SELECT @NewCDAudioID = ISNULL(MAX(id), 0) + 1 FROM CD_Audio;

INSERT INTO CD_Audio (id, nombre_morceau, durée, titre_album, id_1)
VALUES (
    @NewCDAudioID,
    1,                  -- 1 Morceau
    4,                  -- Durée (3min38 arrondi à 4)
    'VALORANT Champions 2021', -- Album / Event
    @NewContenuID       -- Lien vers Contenu
);

-- 4. Liaison avec la catégorie (Priorité : Électro > Rock > Musique)
SELECT @CategorieID = id FROM Categorie WHERE nom_categorie = 'Électro';

IF @CategorieID IS NULL
    SELECT @CategorieID = id FROM Categorie WHERE nom_categorie = 'Rock';

IF @CategorieID IS NULL
    SELECT @CategorieID = id FROM Categorie WHERE nom_categorie = 'Musique';

-- Si toujours rien, une catégorie Audio au hasard
IF @CategorieID IS NULL
    SELECT TOP 1 @CategorieID = id FROM Categorie WHERE type_contenu = 'Audio';

-- Insertion du lien
IF @CategorieID IS NOT NULL
BEGIN
    INSERT INTO à (id, id_1) VALUES (@NewContenuID, @CategorieID);
    PRINT 'Ajouté avec succès dans la catégorie : ' + @CategorieID;
END
ELSE
BEGIN
    PRINT 'Ajouté sans catégorie (Aucune trouvée).';
END

6 - modifier dans le MediaTechRepository le "connectionString" et mettre les informations par rapport a votre identifiant, mdp, nom de base de donnée et votre adresse ip (celle en 172.)
Ce qui aura pour effet d'effectuer la connexion vers la base de donnée et récupérer le clip vidéo die for you que vous pourrez visionner.

📝 Auteurs
Thomas - Lead Dev
Flavie - Dev 
Zainabe - Dev 
