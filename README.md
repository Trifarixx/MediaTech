<<<<<<< HEAD
# 📚 Média-Tech
=======
# # 📚 Média-Tech
>>>>>>> ba2e56176490b882526f541ae5fbf4f789cc57e0

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
<<<<<<< HEAD
* **IDE :** Visual Studio 2019 ou 2022.
* **Base de données :** Microsoft SQL Server (Express ou LocalDB).
=======
* **IDE :** Visual Studio 2022 ou 2026.
* **Base de données :** Microsoft SQL Server.
>>>>>>> ba2e56176490b882526f541ae5fbf4f789cc57e0
* **Framework :** .NET Framework 4.7.2 ou supérieur (ou .NET 6/8 selon la configuration du projet).

## ⚙️ Installation et Configuration

### 1. Cloner le projet
```bash
git clone https://github.com/Zainabe10/MediaTech.git
```
### 2. Installation des dépendances (NuGet)
Le projet utilise plusieurs paquets externes. Visual Studio devrait les restaurer automatiquement, mais si ce n'est pas le cas, exécutez ces commandes dans la Console du Gestionnaire de package :
<<<<<<< HEAD
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
=======
** Install-Package LibVLCSharp.WinForms
** Install-Package VideoLAN.LibVLC.Windows
** Install-Package LivVLCSharp
** Install-Package NAudio
** Install-Package YoutubeExplode
** Install-Package System.Data.SqlClient
** Install-Package IronPDF
** Install-Package Microsoft.Data.SqlClient
** Install-Package PdfiumViewer
** Install-Package syncfusion.pdfviewer.windows
>>>>>>> ba2e56176490b882526f541ae5fbf4f789cc57e0

### 3. 📦 Architecture & Technologies
Langage : C#

UI : Windows Forms (.NET)

BDD : SQL Server (ADO.NET via Microsoft.Data.SqlClient)

Bibliothèques majeures :

LibVLCSharp : Moteur de lecture vidéo robuste.

YoutubeExplode : Extraction de métadonnées et flux YouTube.

NAudio : Gestion audio bas niveau.

<<<<<<< HEAD
### 4. Installation SQL SERVER 

1. Configuration Réseau du Serveur SQL
=======
### 3.5 Installer la bonne police d'écriture
Se rendre sur le lien suivant : https://fonts.google.com/specimen/DM+Sans
- Cliquez sur Get Font puis download all.
- Déziper le fichier dans vos téléchargements, cliquez sur vos 2 fichier (DMSans-Italic-VariableFont_opsz,wght.ttf et DMSans-VariableFont_opsz,wght.ttf) et cliquez sur installer.
- Si la police d'écriture n'est pas appliquée quand le projet sera actif, relancer le PC.

### 4. Installation SQL SERVER 

## 1. Installation & Configuration Réseau du Serveur SQL
Se rendre sur le site https://www.microsoft.com/fr-fr/sql-server/sql-server-downloads et installer la version "SQL Server 2025 Express"

Cliquez sur l'installation Basique de SQL Server

À la fin de l'installation cliquez sur installer SSMS.

Pour compléter l'installation relancez le PC

Ensuite se rendre sur votre Visual Studio Installer, cliquez sur modifier la version 2022, scrollez tout en bas dans la section "Autres Ensembles d'Outils" et Cliquez sur le package d'installation "Stockage et Traitement des données" puis Modifier pour installer.

>>>>>>> ba2e56176490b882526f541ae5fbf4f789cc57e0
Cette étape permet de rendre la base de données accessible sur le réseau.

Ouvrir le Gestionnaire de configuration :

<<<<<<< HEAD
Lancez une invite de commande (cmd) et tapez SQLServerManager16.msc.

=======
Lancez une invite de commande (cmd) et tapez 
```bash
SQLServerManager17.msc.
```
>>>>>>> ba2e56176490b882526f541ae5fbf4f789cc57e0
Activer TCP/IP :

Allez dans Configuration du réseau SQL Server > Protocoles pour SQLEXPRESS.

Faites un clic droit sur TCP/IP et choisissez Activer (Enable).

Configurer le Port 1433 :

Double-cliquez sur TCP/IP et allez dans l'onglet Adresses IP.

Descendez tout en bas à la section IPAll.

Définissez le Port TCP à 1433.

Service SQL Browser :

Assurez-vous que le service SQL Server Browser est activé. S'il est grisé, changez le mode de lancement en "Automatique" dans les propriétés, puis activez-le.

<<<<<<< HEAD
Redémarrage :

Redémarrez le service SQL Server pour appliquer les changements.

2. Configuration de la Sécurité & Pare-feu
=======

## 2. Configuration de la Sécurité & Pare-feu
>>>>>>> ba2e56176490b882526f541ae5fbf4f789cc57e0
Pare-feu Windows :

Créez une règle entrante pour autoriser les communications TCP sur le port 1433.

<<<<<<< HEAD
=======
Nouvelle règle -> Port -> TCP port spécifiques 1433 -> Autoriser la connexion -> laisser tout cocher -> [nom] -> Terminer

>>>>>>> ba2e56176490b882526f541ae5fbf4f789cc57e0
Activer l'Authentification Mixte (SSMS) :

Dans SQL Server Management Studio (SSMS), faites un clic droit sur le Serveur > Propriétés.

Allez dans l'onglet Sécurité (Security).

Cochez SQL Server and Windows Authentication mode (Mixed Mode) et cliquez sur OK.

<<<<<<< HEAD

Important : Redémarrez le service SQL Server (via services.msc ou le Configuration Manager).

3. Gestion des Utilisateurs
=======
Important : Redémarrez le service SQL Server (via services.msc ou le Configuration Manager).

IMPORTANT : si l'étape précédente ne fonctionne pas : 

## 1. Identifier l'utilisateur
Ouvrir une invite de commandes (`cmd`) en tant qu'administrateur et taper :

```cmd
whoami
```

## 2. Redémarrer en mode "Mono-Utilisateur"
Arrêter le service et le relancer avec l'option /m pour autoriser la maintenance.

```cmd
net stop MSSQL$SQLEXPRESS
net start MSSQL$SQLEXPRESS /m
```
## 3. Connexion via SQLCMD
Se connecter au serveur en ligne de commande. L'option -C est obligatoire pour ignorer les erreurs de certificat SSL (ODBC Driver 18).

```cmd
sqlcmd -S .\SQLEXPRESS -E -C
```
Si l'invite 1> s'affiche, la connexion est réussie.

## 4. Attribution des droits (Attention à la syntaxe)
Exécuter les commandes suivantes une par une. IMPORTANT : Remplacez [DOMAINE\UTILISATEUR] par votre résultat de l'étape 1. Les crochets [] sont obligatoires.

```cmd
CREATE LOGIN [DOMAINE\UTILISATEUR] FROM WINDOWS;
GO
ALTER SERVER ROLE sysadmin ADD MEMBER [DOMAINE\UTILISATEUR];
GO
EXIT
```

## 5. Retour au mode normal
Redémarrer le service en mode standard pour permettre la connexion via SSMS.

```cmd
net stop MSSQL$SQLEXPRESS
net start MSSQL$SQLEXPRESS
```
## 6. Vérification
- Ouvrir SSMS.
- Se connecter en Authentification Windows.
- Tester Server and Windows Authentication mode (Mixed Mode) et cliquez sur OK

## 3. Gestion des Utilisateurs
>>>>>>> ba2e56176490b882526f541ae5fbf4f789cc57e0
Création d'un utilisateur dédié pour l'application.

Dans SSMS, dépliez le dossier Sécurité, puis clic droit sur Connexions > Nouvelle connexion.

Créez l'utilisateur (Exemple : User yohan, Mot de passe yohan1234).

<<<<<<< HEAD
Dans les rôles du serveur ou mappage de l'utilisateur, attribuez le droit db_owner si nécessaire pour chaque base concernée.

4. Connexion au Serveur (Côté Client)
=======
Dans les rôles du serveur ou mappage de l'utilisateur, attribuez le droit db_owner si nécessaire pour la base concernée quand elle sera créer.

## 4. Connexion au Serveur (Côté Client)
>>>>>>> ba2e56176490b882526f541ae5fbf4f789cc57e0
Pour se connecter au serveur depuis un poste distant :


Nom du serveur : Adresse_IP_du_LAN,1433 (La virgule est importante pour spécifier le port).


Authentification : Choisir Authentification SQL Server.

Identifiants : Utilisez le login et mot de passe créés précédemment.

<<<<<<< HEAD
5. Un petit jeu de données à insérer dans la bases de données :

=======
### 4. Création de la base de donnée avec requète SQL complète
Clique droit sur Bases de données -> Nouvelle bases de données -> mettre un nom à votre base puis créer 
Collez la requète pour créer les tables : 
```bash
CREATE TABLE Contenu(
   id INT,
   titre VARCHAR(50),
   auteur VARCHAR(50),
   editeur VARCHAR(50),
   date_publication DATE,
   quantite INT,
   image_url VARCHAR(MAX),
   url_fichier VARCHAR(MAX),
   PRIMARY KEY(id)
);
CREATE TABLE CD_Audio(
   id INT,
   nombre_morceau INT NOT NULL,
   durée INT NOT NULL,
   titre_album VARCHAR(50),
   id_1 INT NOT NULL,
   PRIMARY KEY(id),
   UNIQUE(id_1),
   FOREIGN KEY(id_1) REFERENCES Contenu(id)
); 
CREATE TABLE Livres(
   id VARCHAR(50),
   nombre_page INT,
   id_1 INT NOT NULL,
   PRIMARY KEY(id),
   UNIQUE(id_1),
   FOREIGN KEY(id_1) REFERENCES Contenu(id)
); 
CREATE TABLE DVD(
   id VARCHAR(50),
   duree INT,
   id_1 INT NOT NULL,
   PRIMARY KEY(id),
   UNIQUE(id_1),
   FOREIGN KEY(id_1) REFERENCES Contenu(id)
);
CREATE TABLE Categorie(
   id VARCHAR(50),
   nom_categorie VARCHAR(50),
   description VARCHAR(50),
   type_contenu VARCHAR(50),
   PRIMARY KEY(id)
); 
CREATE TABLE Avis(
   id VARCHAR(50),
   titre VARCHAR(50),
   commentaire VARCHAR(50),
   note INT,
   id_1 INT NOT NULL,
   PRIMARY KEY(id),
   FOREIGN KEY(id_1) REFERENCES Contenu(id)
);
CREATE TABLE Membre(
   id INT,
   nom VARCHAR(50),
   prenom VARCHAR(50),
   email VARCHAR(50),
   date_inscription DATE,
   id_1 VARCHAR(50) NOT NULL,
   PRIMARY KEY(id),
   FOREIGN KEY(id_1) REFERENCES Avis(id)
);
CREATE TABLE Notification(
   id VARCHAR(50),
   message VARCHAR(50),
   date_envoi DATETIME,
   type_notification VARCHAR(50),
   id_1 INT NOT NULL,
   PRIMARY KEY(id),
   FOREIGN KEY(id_1) REFERENCES Membre(id)
);
CREATE TABLE Emprunt(
   id INT,
   date_emprunt DATE,
   date_retour DATETIME,
   id_1 INT NOT NULL,
   id_2 INT NOT NULL,
   PRIMARY KEY(id),
   FOREIGN KEY(id_1) REFERENCES Membre(id),
   FOREIGN KEY(id_2) REFERENCES Contenu(id)
);
CREATE TABLE à(
   id INT,
   id_1 VARCHAR(50),
   PRIMARY KEY(id, id_1),
   FOREIGN KEY(id) REFERENCES Contenu(id),
   FOREIGN KEY(id_1) REFERENCES Categorie(id)
); 
CREATE TABLE Asso_6(
   id INT,
   id_1 VARCHAR(50),
   PRIMARY KEY(id, id_1),
   FOREIGN KEY(id) REFERENCES Contenu(id),
   FOREIGN KEY(id_1) REFERENCES Notification(id)
);
```

### 5. Un petit jeu de données à insérer dans la bases de données :
```bash
>>>>>>> ba2e56176490b882526f541ae5fbf4f789cc57e0
DECLARE @NewContenuID INT;
DECLARE @NewCDAudioID INT;
DECLARE @CategorieID VARCHAR(50);

-- 1. Calcul du nouvel ID Contenu
SELECT @NewContenuID = ISNULL(MAX(id), 0) + 1 FROM Contenu;

-- 2. Insertion dans Contenu
INSERT INTO Contenu (id, titre, auteur, editeur, date_publication, quantite, image_url, url_fichier)
VALUES (
    @NewContenuID, 
<<<<<<< HEAD
    LEFT('Die For You (ft. Grabbitz)', 50),      -- Titre
    'Grabbitz',                                  -- Auteur (Artiste principal)
    'Riot Games / VALORANT',                     -- Éditeur
    '2021-11-22',                                -- Date de publication
    5,                                           -- Quantité
    'https://img.youtube.com/vi/h7MYJghRWt0/maxresdefault.jpg', -- Miniature
    'https://www.youtube.com/watch?v=h7MYJghRWt0' -- Lien YouTube
);

-- 3. Insertion dans CD_Audio (Single)
=======
    LEFT('Sofia', 50),                           -- Titre
    'Clairo',                                    -- Auteur (Artiste principal)
    'Fader Label',                               -- Éditeur
    '2019-07-26',                                -- Date de publication (Sortie de l'album Immunity)
    5,                                           -- Quantité
    'https://img.youtube.com/vi/L9l8zCOwEII/maxresdefault.jpg', -- Miniature
    '\\172.16.119.32\MediaTech\Clairo - Sofia.mp3' -- Lien YouTube
);

-- 3. Insertion dans CD_Audio (Single/Morceau)
>>>>>>> ba2e56176490b882526f541ae5fbf4f789cc57e0
SELECT @NewCDAudioID = ISNULL(MAX(id), 0) + 1 FROM CD_Audio;

INSERT INTO CD_Audio (id, nombre_morceau, durée, titre_album, id_1)
VALUES (
    @NewCDAudioID,
    1,                  -- 1 Morceau
<<<<<<< HEAD
    4,                  -- Durée (3min38 arrondi à 4)
    'VALORANT Champions 2021', -- Album / Event
    @NewContenuID       -- Lien vers Contenu
);

-- 4. Liaison avec la catégorie (Priorité : Électro > Rock > Musique)
SELECT @CategorieID = id FROM Categorie WHERE nom_categorie = 'Électro';

IF @CategorieID IS NULL
    SELECT @CategorieID = id FROM Categorie WHERE nom_categorie = 'Rock';
=======
    3,                  -- Durée (3min08 arrondi à 3)
    'Immunity',         -- Album
    @NewContenuID       -- Lien vers Contenu
);

-- 4. Liaison avec la catégorie (Priorité : Pop > Indie > Musique)
SELECT @CategorieID = id FROM Categorie WHERE nom_categorie = 'Pop';

IF @CategorieID IS NULL
    SELECT @CategorieID = id FROM Categorie WHERE nom_categorie = 'Indie';
>>>>>>> ba2e56176490b882526f541ae5fbf4f789cc57e0

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

<<<<<<< HEAD
6 - modifier dans le MediaTechRepository le "connectionString" et mettre les informations par rapport a votre identifiant, mdp, nom de base de donnée et votre adresse ip (celle en 172.)
Ce qui aura pour effet d'effectuer la connexion vers la base de donnée et récupérer le clip vidéo die for you que vous pourrez visionner.

📝 Auteurs
Thomas - Lead Dev
Flavie - Dev 
Zainabe - Dev 
=======
DECLARE @NewContenuID INT;
DECLARE @NewLivreID VARCHAR(20); -- Modifié en VARCHAR pour accepter 'LIV-XXX'
DECLARE @MaxLivreNum INT;        -- Variable temporaire pour l'incrémentation
DECLARE @CategorieID VARCHAR(50);

-- 1. Calcul du nouvel ID Contenu
SELECT @NewContenuID = ISNULL(MAX(id), 0) + 1 FROM Contenu;

-- 2. Insertion dans Contenu
INSERT INTO Contenu (id, titre, auteur, editeur, date_publication, quantite, image_url, url_fichier)
VALUES (
    @NewContenuID, 
    LEFT('Le Petit Prince', 50),                 -- Titre
    'Antoine de Saint-Exupéry',                  -- Auteur
    'Gallimard',                                 -- Éditeur
    '1943-04-06',                                -- Date de publication
    5,                                           -- Quantité
    'https://m.media-amazon.com/images/I/71IF1ngy57L._AC_UF1000,1000_QL80_.jpg',
    '\\172.16.119.32\MediaTech\Le Petit Prince.pdf' 
);

-- 3. Insertion dans la table Livres
-- Extraction du numéro max (ex: on prend '001' de 'LIV-001', on le convertit en entier)
SELECT @MaxLivreNum = ISNULL(MAX(CAST(SUBSTRING(id, 5, LEN(id)) AS INT)), 0) 
FROM Livres 
WHERE id LIKE 'LIV-%';

-- Formatage du nouvel ID (ex: 'LIV-002')
SET @NewLivreID = 'LIV-' + RIGHT('000' + CAST(@MaxLivreNum + 1 AS VARCHAR), 3);

-- CORRECTION : Utilisation de @NewContenuID pour id_1
INSERT INTO Livres(id, nombre_page, id_1)
VALUES (
    @NewLivreID,
    96,                 -- Nombre de pages approximatif
    @NewContenuID       -- Lien vers la table Contenu
);

-- 4. Liaison avec la catégorie (Priorité : Conte > Littérature > Livre)
SELECT @CategorieID = id FROM Categorie WHERE nom_categorie = 'Conte';

IF @CategorieID IS NULL
    SELECT @CategorieID = id FROM Categorie WHERE nom_categorie = 'Littérature';

IF @CategorieID IS NULL
    SELECT @CategorieID = id FROM Categorie WHERE nom_categorie = 'Livre';

-- Si toujours rien, une catégorie PDF ou Texte au hasard
IF @CategorieID IS NULL
    SELECT TOP 1 @CategorieID = id FROM Categorie WHERE type_contenu = 'PDF' OR type_contenu = 'Texte';

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

DECLARE @NewContenuID INT;
DECLARE @NewDVDID VARCHAR(20);
DECLARE @MaxDVDNum INT;
DECLARE @CategorieID VARCHAR(50);

-- 1. Calcul du nouvel ID Contenu
SELECT @NewContenuID = ISNULL(MAX(id), 0) + 1 FROM Contenu;

-- 2. Insertion dans Contenu
INSERT INTO Contenu (id, titre, auteur, editeur, date_publication, quantite, image_url, url_fichier)
VALUES (
    @NewContenuID, 
    LEFT('BACKROOMS Le Film', 50),               -- Titre
    'Kane Parsons',                              -- Auteur / Réalisateur
    'A24 / FilmsActu',                           -- Éditeur / Distributeur
    '2026-04-01',                                -- Date de publication (Date de la vidéo)
    5,                                           -- Quantité
    'https://img.youtube.com/vi/CZP_r5y9HL4/maxresdefault.jpg', -- Miniature YouTube
    'https://www.youtube.com/watch?v=CZP_r5y9HL4' -- Lien YouTube
);

-- 3. Insertion dans la table spécifique au format DVD (ex: DVD_Video)
-- Extraction du numéro max (ex: on prend '001' de 'DVD-001', on le convertit en entier)
SELECT @MaxDVDNum = ISNULL(MAX(CAST(SUBSTRING(id, 5, LEN(id)) AS INT)), 0) 
FROM DVD 
WHERE id LIKE 'DVD-%';

-- Formatage du nouvel ID (ex: 'DVD-002')
SET @NewDVDID = 'DVD-' + RIGHT('000' + CAST(@MaxDVDNum + 1 AS VARCHAR), 3);

INSERT INTO DVD (id, duree, id_1)
VALUES (
    @NewDVDID,
    3,                  -- Durée (Bande-annonce de 2min32, arrondie à 3)
    @NewContenuID             -- Format vidéo (ou 'DVD', 'Blu-Ray' selon ta base)
);

-- 4. Liaison avec la catégorie (Priorité : Horreur > Science-Fiction > Film > Vidéo)
SELECT @CategorieID = id FROM Categorie WHERE nom_categorie = 'Horreur';

IF @CategorieID IS NULL
    SELECT @CategorieID = id FROM Categorie WHERE nom_categorie = 'Science-Fiction';

IF @CategorieID IS NULL
    SELECT @CategorieID = id FROM Categorie WHERE nom_categorie = 'Film';

-- Si toujours rien, une catégorie Vidéo au hasard
IF @CategorieID IS NULL
    SELECT TOP 1 @CategorieID = id FROM Categorie WHERE type_contenu = 'Vidéo';

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
```

### 6 - modifier dans le MediaTechRepository le "connectionString" et mettre les informations par rapport a votre identifiant, mdp, nom de base de donnée et votre adresse ip (celle en 172.)
Ce qui aura pour effet d'effectuer la connexion vers la base de donnée et récupérer le clip vidéo die for you que vous pourrez visionner.

📝 Auteurs
Thomas - Dev
Flavie - Dev 
Zainabe - Dev 

>>>>>>> ba2e56176490b882526f541ae5fbf4f789cc57e0
