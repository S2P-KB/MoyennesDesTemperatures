using System;
using System.Collections.Generic;
using GestionDesDonnees;
using GestionDesCalculs;

namespace MonProgramme
{
    class Program
    {
        static void Main(string[] args)
        {
            List<float> temperatures = new List<float>();
            string choix = "z";
            string mot = "t° précise";
            var expressions = new List<string> {"", $" >= à une {mot}", $" <= à une {mot}", $" comprises entre 2 {mot}s"};
            int longueurMaximale = expressions.Max(expression => expression.Length) + 10;

            // Demande la saisie des températures
            Saisie.SaisirTemperatures(temperatures);

            // Afficher le graphique après la saisie précédente.
            Calcul.AfficherGraphique(temperatures);

            // Menu de sélection.
            while (choix != "0")
            {
                // Afficher le menu de sélection.
                int k = 1;
                foreach (var expression in expressions)
                {
                    Calcul.Afficher(expression, longueurMaximale);
                    Console.WriteLine($" {k}");
                    k++;
                }
                Calcul.Afficher("Quitter", longueurMaximale, true);
                Console.WriteLine(" 0");

                // Réagir au choix de l'utilisateur.
                choix = Console.ReadLine()!;
                switch (choix)
                {
                    default:    // Prévenir de l'invalidité d'une saisie.
                        Console.WriteLine("\nSaisir un choix parmi ceux proposés (0,1,2,3,4).");
                        break;

                    case "1":   // Calculer la moyenne de toutes les températures réunies.
                        Console.WriteLine("Moyenne de toutes les températures = " + Calcul.Moyenne(temperatures));
                        break;

                    case "2":   // Calculer la moyenne de toutes les températures supérieures ou égales à un entier saisi.
                        float tmin = Saisie.SaisirTemperature("T° min = ");
                        Console.WriteLine("Moyenne des t° >= à " + tmin + " = " + Calcul.Moyenne(temperatures, tmin));
                        break;

                    case "3":   // Calculer la moyenne de toutes les températures inférieures ou égales à un entier saisi.
                        float tmax = Saisie.SaisirTemperature("T° max = ");
                        Console.WriteLine("Moyenne des t° <= à " + tmax + " = " + Calcul.Moyenne(temperatures, null, tmax));
                        break;

                    case "4":   // Calculer la moyenne de toutes les températures se trouvant dans une plage de deux entiers saisis.
                        float t_min = Saisie.SaisirTemperature("T° min = ");
                        float t_max = Saisie.SaisirTemperature("T° max = ");
                        Console.WriteLine("Moyenne des t° >= à " + t_min + " et <= à " + t_max + " = " + Calcul.Moyenne(temperatures, t_min, t_max));
                        break;

                    case "0":   // Quitter le programme.
                        Console.WriteLine("Fin du traitement");
                        break;
                }
            }
        }
    }
}