using System;
using System.Collections.Generic;
using System.Linq;

namespace tests
{
    class Tests
    {
        /// <summary>
        /// Récupérer une liste de valeurs en vérifiant si une limite minimale ou maximale est appliquée. À partir de cette liste, comparer chaque température au choix de l'utilisateur.
        /// </summary>
        /// <param name="valeurs"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private static float? moyenne(List<float> valeurs, float? min = null, float? max = null)
        {
            List<float> valeursFiltrees = new List<float> {};
            foreach (float temperature in valeurs)
            {
                // Vérifier les conditions de filtrage selon les limites min et max
                if ((min.HasValue && temperature < min.Value) || (max.HasValue && temperature > max.Value))
                {
                    continue;
                }
                else
                {
                    valeursFiltrees.Add(temperature);
                }
            }

            // Calculer la moyenne des valeurs filtrées
            float somme = 0;
            if (valeursFiltrees.Count() == 0)
            {
                Console.WriteLine("Pas de valeur concernée");
                return null;
            }
            foreach (float valeur in valeursFiltrees)
            {
                somme += valeur;
            }
            float moyenne = somme / valeursFiltrees.Count();
            return moyenne;
        }

        /// <summary>
        /// Récupérer une expression 'text' et la compléter de petits points, selon le nombre de caractères transmis par le paramètre 'nb'.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="nb"></param>
        private static void Afficher(string text, int nb)
        {
            int nbPoints = nb - text.Length;
            string points = new string('.', Math.Max(nbPoints, 0));
            Console.Write("Moyenne des températures " + $"{text} {points}");
        }

        /// <summary>
        /// Afficher un graphique en barres normalisé des températures avec couleur selon valeur.
        /// </summary>
        /// <param name="valeurs"></param>
        private static void AfficherGraphique(List<float> valeurs)
        {
            Console.WriteLine("\nGraphique des températures :");

            if (valeurs.Count == 0)
            {
                Console.WriteLine("Aucune température à afficher.");
                return;
            }

            // Trouver la valeur absolue maximale pour normaliser les barres
            float valeurMax = valeurs.Max(val => Math.Abs(val));
            int longueurMax = 30; // Nombre maximum de symboles pour la plus grande valeur

            foreach (var valeur in valeurs)
            {
                int nbSymboles = (int)((Math.Abs(valeur) / valeurMax) * longueurMax);

                // Définir la couleur selon la valeur positive ou négative
                if (valeur < 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if(valeur > 0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (valeur == 0)
                    Console.ForegroundColor = ConsoleColor.Blue;

                // Afficher la température et sa barre
                Console.Write($"{valeur,6}°C | ");
                if(valeur == 0)
                    Console.WriteLine("- - - - -");
                else
                    Console.WriteLine(new string('█', Math.Max(nbSymboles, 0)));

                Console.ResetColor();
            }
        }

        static public void Main(string[] args)
        {
            List<float> temperatures = new List<float>();
            int x = 1;
            float temp;
            string reponse = "o";

            // Saisie des températures
            while (reponse != "n")
            {
                temp = 70;
                while (temp > 60 || temp < -60)
                {
                    Console.Write("Température n°" + x + " (entre -60 et 60) = ");
                    temp = float.Parse((Console.ReadLine()!));
                }
                temperatures.Add(temp);

                Console.Write("Autre température à saisir ? (o/n) ");
                reponse = (Console.ReadLine()!);
                x++;
            }

            string choix = "z";
            string mot = "t° précise";
            var expressions = new List<string> { "", $">= à une {mot}", $"<= à une {mot}", $"comprises entre 2 {mot}s" };
            int longueurMaximale = expressions.Max(expression => expression.Length) + 10;

            // Afficher le graphique après la saisie
            AfficherGraphique(temperatures);

            // Menu de sélection
            while (choix != "0")
            {
                int k = 1;
                foreach (var expression in expressions)
                {
                    Afficher(expression, longueurMaximale);
                    Console.WriteLine($" {k}");
                    k++;
                }

                Afficher("Quitter", longueurMaximale);
                Console.WriteLine(" 0");

                choix = (Console.ReadLine()!);
                switch (choix)
                {
                    case "1":
                        Console.WriteLine("Moyenne de toutes les températures = " + moyenne(temperatures));
                        break;

                    case "2":
                        Console.Write("T° min = ");
                        float tmin = float.Parse(Console.ReadLine()!);

                        Console.WriteLine("Moyenne des t° >= à " + tmin + " = " + moyenne(temperatures, tmin));
                        break;

                    case "3":
                        Console.Write("T° max = ");
                        float tmax = float.Parse(Console.ReadLine()!);

                        Console.WriteLine("Moyenne des t° <= à " + tmax + " = " + moyenne(temperatures, null, tmax));
                        break;

                    case "4":
                        Console.Write("T° min = ");
                        float t_min = float.Parse(Console.ReadLine()!);
                        Console.Write("T° max = ");
                        float t_max = float.Parse(Console.ReadLine()!);

                        Console.WriteLine("Moyenne des t° >= à " + t_min + " et <= à " + t_max + " = " + moyenne(temperatures, t_min, t_max));
                        break;

                    case "0":
                        Console.WriteLine("Fin du traitement");
                        break;
                }
            }
        }
    }
}