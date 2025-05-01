
# APPLICATION CONSOLE - ANALYSE DE TEMPÉRATURES
==============================================

## 📋 Description
#### Ce programme en C# permet :
- la saisie de températures (avec vérification des valeurs),
- le calcul de moyennes selon différents critères (toutes, ≥ à une valeur, ≤ à une valeur, entre deux valeurs),
- l'affichage d’un graphique en console (barres verticales colorées).

*L’objectif est de pratiquer la structuration d’un projet C# avec plusieurs classes/namespaces.*

## 🧱 Structure du projet
Le code est divisé en 3 espaces de noms :

- Program : point d'entrée de l'application. Affiche les menus, gère les interactions avec l'utilisateur.
- GestionDesDonnees : contient la classe Saisie qui gère la saisie utilisateur et la validation des températures.
- GestionDesCalculs : contient la classe Calcul qui gère :
  - les calculs de moyennes,
  - l’affichage du graphique (en ASCII),
  - l’affichage formaté des libellés.

## ▶️ Utilisation
### 1. Ouvrir le projet dans IDE acceptant le langage csharp :
   - dotnet build
   - dotnet run

### 2. Suivre les instructions dans la console :
   - Saisir des températures entre -60 et 60.
   - Choisir une option pour afficher des moyennes selon les cas.

## ✅ Exemples de fonctionnalités
- Saisie :
  Température n°1 (entre -60 et 60) = 12
  Autre température à saisir ? (o/n) o

- Menu :
 Moyenne des températures                      1
 Moyenne des températures >= à une t° précise  2
 Moyenne des températures <= à une t° précise  3
 Moyenne des températures comprises entre 2 t° 4
 Quitter...................................... 0

## 🛠️ Prérequis
-------------
- .NET 6 ou supérieur (SDK installé)
- Visual Studio, Visual Studio Code ou terminal

## 👤 Auteur
----------
Projet réalisé dans le cadre du BTS SIO SLAM - S2P-KB.
