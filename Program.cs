using System;
using System.Collections.Generic;
using System.Linq;

namespace tests
{
    class Tests
    {
        /// <summary>
        /// Récupérer une liste de valeurs en vérifiant si les limites (minimale ou maximale) est respectée. 
        /// À partir de cette liste, comparer chaque température selon le choix de l'utilisateur.
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
                // Vérifier les conditions de filtrage selon les limites minimales et maximales.
                if ((min.HasValue && temperature < min.Value) || (max.HasValue && temperature > max.Value))
                {
                    continue;
                }
                else
                {
                    valeursFiltrees.Add(temperature);
                }
            }

            // Calculer la moyenne des valeurs filtrées précédemment.
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
        /// Récupérer une expression 'text' et la compléter de petits points, selon le nombre de caractères transmis par le paramètre 'nb' et en prenant compte d'une éventuelle insertion d'une chaîne de caractères.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="nb"></param>
        /// <param name="afficher_prefixe"></param>
        private static void Afficher(string text, int nb, bool afficher_prefixe = false)
        {
            string prefixe = "Moyenne des températures";
            int longueur = text.Length;
            int nbPoints = nb - longueur;
            if(afficher_prefixe)
            {
               nbPoints = nb + prefixe.Length - longueur;
            }
            string points = new string('.', Math.Max(nbPoints, 0));
            if (afficher_prefixe)
                Console.Write($"{text} {points}");
            else
                Console.Write($"Moyenne des températures{text} {points}");
        }


        /// <summary>
        /// Afficher un graphique en barres normalisées des températures, avec trois couleurs disponibles selon la valeur.
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

            // Trouver la valeur absolue maximale pour normaliser les barres.
            float valeurMax = valeurs.Max(val => Math.Abs(val));
            int longueurMax = 30; // Nombre maximum de symboles pour la plus grande valeur.

            foreach (var valeur in valeurs)
            {
                int nbSymboles = (int)((Math.Abs(valeur) / valeurMax) * longueurMax);

                // Définir la couleur selon la norme suivante :
                //  • Rouge pour une valeur négative ;
                //  • Verte pour une valeur positive ;
                //  • Bleue pour une valeur nulle ;
                if (valeur < 0)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if(valeur > 0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (valeur == 0)
                    Console.ForegroundColor = ConsoleColor.Blue;

                // Afficher la température et la barre correspondante.
                Console.Write($"{valeur,6}°C | ");
                if(valeur == 0)
                    Console.WriteLine("-");
                else
                    Console.WriteLine(new string('█', Math.Max(nbSymboles, 0)));

                Console.ResetColor();
            }
        }


        /// <summary>
        /// Demande une saisie utilisateur et vérifie si elle peut être convertie en float.
        /// </summary>
        /// <param name="message">Message à afficher à l'utilisateur</param>
        /// <returns>La valeur float saisie</returns>
        private static float Typage(string message)
        {
            float valeur;
            bool saisie_valide = false;

            do
            {
                Console.Write(message);
                string? saisie = Console.ReadLine();

                if (float.TryParse(saisie, out valeur))
                    saisie_valide = true;
                else
                    Console.WriteLine("Veuillez saisir une valeur numérique valide.");

            } while (!saisie_valide);
            return valeur;
        }


        static public void Main(string[] args)
        {
            List<float> temperatures = new List<float>();
            int x = 1;
            float temp;
            string reponse = "o";

            // Saisie des températures par l'utilisateur.
            while (reponse.ToLower() != "n")
            {
                temp = 70;
                while (temp > 60 || temp < -60)
                {
                    temp = Typage($"Température n°{x} (entre -60 et 60) = ");
                    
                    if (temp > 60 || temp < -60)
                        Console.WriteLine("La température doit être comprise entre -60 et 60.");
                }
                temperatures.Add(temp);

                if(temperatures.Count() > 1)
                {
                    do
                    {
                        Console.Write("Autre température à saisir ? (o/n) ");
                        reponse = Console.ReadLine()!;
                    }while(reponse.ToLower() != "o" && reponse.ToLower() != "n");
                    
                }

                x++;
            }

            string choix = "z";
            string mot = "t° précise";
            var expressions = new List<string> {"", $" >= à une {mot}", $" <= à une {mot}", $" comprises entre 2 {mot}s"};
            int longueurMaximale = expressions.Max(expression => expression.Length) + 10;

            // Afficher le graphique après la saisie précédente.
            AfficherGraphique(temperatures);

            // Menu de sélection : lire les commentaires associés.
            while (choix != "0")
            {
                int k = 1;
                foreach (var expression in expressions)
                {
                    Afficher(expression, longueurMaximale);
                    Console.WriteLine($" {k}");
                    k++;
                }

                Afficher("Quitter", longueurMaximale, true);
                Console.WriteLine(" 0");

                choix = Console.ReadLine()!;
                switch (choix)
                {
                    default:
                        Console.WriteLine("\nSaisir un choix parmis ceux proposés (0,1,2,3,4).");
                        break;

                    case "1":   // Calculer la moyenne de toutes les températures réunies.
                        Console.WriteLine("Moyenne de toutes les températures = " + moyenne(temperatures));
                        break;

                    case "2":   // Calculer la moyenne de toutes les températures supérieures ou égales à un entier saisi.
                        float tmin = Typage("T° min = ");

                        Console.WriteLine("Moyenne des t° >= à " + tmin + " = " + moyenne(temperatures, tmin));
                        break;

                    case "3":   // Calculer la moyenne de toutes les températures inférieures ou égales à un entier saisi.
                        float tmax = Typage("T° max = ");

                        Console.WriteLine("Moyenne des t° <= à " + tmax + " = " + moyenne(temperatures, null, tmax));
                        break;

                    case "4":   // Calculer la moyenne de toutes les températures se trouvant dans une plage de deux entiers saisis.
                        float t_min = Typage("T° min = ");
                        float t_max = Typage("T° max = ");

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