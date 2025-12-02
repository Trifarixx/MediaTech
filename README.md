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

📝 Auteurs
Thomas - Lead Dev
Flavie - Dev 
Zainabe - Dev 
