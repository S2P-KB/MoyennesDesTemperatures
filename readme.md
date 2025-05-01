
# APPLICATION CONSOLE - ANALYSE DE TEMPÉRATURES


## 📋 Description
#### Ce programme en C# permet :
- la saisie de températures (avec vérification des valeurs),
- le calcul de moyennes selon différents critères (toutes, ≥ à une valeur, ≤ à une valeur, entre deux valeurs),
- l'affichage d’un graphique en console (barres verticales colorées).

*L’objectif est de pratiquer la structuration d’un projet C# avec plusieurs classes/namespaces.*


## 🧱 Structure du projet
Le code est divisé en 3 espaces de noms :

- **Program** : point d'entrée de l'application. Affiche les menus, gère les interactions avec l'utilisateur.
- **GestionDesDonnees** : contient la classe `Saisie` qui gère la saisie utilisateur et la validation des températures.
- **GestionDesCalculs** : contient la classe `Calcul` qui gère :
  - les calculs de moyennes,
  - l’affichage du graphique (en ASCII),
  - l’affichage formaté des libellés.


## 📦 Installation
#### 1. Cloner ce dépôt ou télécharger le code.
#### 2. Ouvrir le dossier dans Visual Studio Code.
#### 3. S'assurer que le SDK .NET 9 est installé (dans le terminal : saisir `dotnet --version`).

## ▶️ Utilisation
### 1. Ouvrir le projet dans IDE compatible avec le langage C# :
   - dotnet build

   - dotnet run

### 2. Suivre les instructions dans la console :
   - Saisir des températures entre -60 et 60.
   
   - Choisir une option pour afficher des moyennes selon les cas.


## ✅ Exemples de fonctionnalités
- Saisie :
```
  >>> Température n°1 (entre -60 et 60) = 12
  >>> Température n°2 (entre -60 et 60) = -29
  >>> Autre température à saisir ? (o/n) o
  >>> Température n°3 (entre -60 et 60) = -30
  >>> Autre température à saisir ? (o/n) n
  ```

- Menu :
```
 Moyenne des températures ............................... 1
 Moyenne des températures >= à une t° précise ........... 2
 Moyenne des températures <= à une t° précise ........... 3
 Moyenne des températures comprises entre 2 t° .......... 4
 Quitter ................................................ 0
 ```


## 🛠️ Prérequis
- SDK .NET 9.0.102 ou supérieur ;
- IDE compatible avec le langage **C#** et **.NET 9** ;
- Environnement de développement : Visual Studio Code 1.96.4.


## 👤 Auteur
Projet réalisé dans le cadre du BTS SIO SLAM - S2P-KB.
