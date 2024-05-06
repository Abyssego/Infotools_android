Documentation technique - Application de gestion de rendez-vous, pour les commerciaux

Introduction
Cette documentation technique décrit l'architecture et les fonctionnalités de l'application de gestion de rendez-vous développée pour l'entreprise InfoTools. L'application permet aux utilisateurs de saisir, modifier, et supprimer des rendez-vous, ainsi que de consulter la liste des rendez-vous enregistrés.

ATTENTION :
L’application possède une clase Bdd.cs pour faire le lien, et est en théorie fonctionnel, mais une erreur de connexion est émise et malgré des recherches et des tests divers, je n’ai trouvé aucune solution qui marchait dans mon cas, c’est pour cela qui sera possible de la modifié, mais impossible de la testé en cas réel, enfin, c’est pour cela qu’un jeu de teste est intégré dans l’application au début de MainPage.xaml.cs et LoginPage.xaml.cs, merci de votre compréhension.

Architecture
Langage et plateforme
L'application est développée en C# avec le framework .NET MAUI (Multi-platform App UI) pour permettre une exécution sur différentes plateformes telles que Android, iOS, et Windows.

Structure du projet
Le projet est organisé selon la structure suivante :
- **MainPage.xaml**: Fichier XAML contenant la définition de l'interface utilisateur principale.
- **MainPage.xaml.cs**: Code-behind de la page principale contenant la logique métier de l'application.
- **Bdd.cs**: Classe de gestion de la base de données, comprenant les méthodes d'accès aux données.
- **LoginPage.xaml**: Code-behind de la page de connexion contenant la logique de connexion de l'application.
- **LoginPage.xam l.cs**: Classe de la connexion, comprenant les méthodes de connexion.
- **Modèles (Identification.cs, Commercial.cs, RendezVous.cs)** : Définit les structures de données pour les différents entités de l'application.

Fonctionnalités

Ajout de rendez-vous
Les utilisateurs peuvent ajouter de nouveaux rendez-vous en saisissant les informations requises dans les champs dédiés de l'interface utilisateur et en appuyant sur le bouton "Ajouter rendez-vous". Les données saisies sont ensuite enregistrées dans la base de données.

Modification de rendez-vous
Les utilisateurs peuvent modifier des rendez-vous existants en sélectionnant un rendez-vous dans la liste affichée et en appuyant sur le bouton "Modifier rendez-vous". 

Suppression de rendez-vous
Les utilisateurs peuvent supprimer des rendez-vous existants en sélectionnant un rendez-vous dans la liste affichée et en appuyant sur le bouton "Supprimer rendez-vous". Une confirmation est demandée avant la suppression définitive.

Consultation de la liste des rendez-vous
La liste des rendez-vous enregistrés est affichée dans une vue de liste. Les rendez-vous sont triés par ordre décroissant de leur numéro d'identification.

Utilisation de la base de données

Structure de la base de données
La base de données utilisée est une base de données relationnelle SQL. Elle comprend une table `RendezVous` contenant les informations relatives aux rendez-vous, telles que le nom, le prénom, l'email, etc.

Accès aux données
La classe `Bdd` fournit des méthodes pour accéder aux données de la base de données :
- `SelectRendezVous()`: Récupère la liste des rendez-vous enregistrés.
- `InsertRendezVous()`: Insère un nouveau rendez-vous dans la base de données.
- `DeleteRendezVous()`: Supprime un rendez-vous de la base de données.

Conclusion
L'application de gestion de rendez-vous développée pour InfoTools offre une interface conviviale pour saisir, modifier, et supprimer des rendez-vous. Elle repose sur une architecture robuste et utilise une base de données SQL pour stocker les données de manière sécurisée et fiable.

