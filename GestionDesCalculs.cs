using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionDesCalculs
{
    public class Calcul
    {
        /// <summary>
        /// Récupérer une liste de valeurs en vérifiant si les limites (minimale ou maximale) sont respectées. 
        /// Calculer la moyenne des valeurs filtrées.
        /// </summary>
        public static float? Moyenne(List<float> valeurs, float? min = null, float? max = null)
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

            // Calculer la moyenne des valeurs filtrées.
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
            return somme / valeursFiltrees.Count();
        }

        /// <summary>
        /// Afficher un graphique en barres normalisées des températures.
        /// </summary>
        public static void AfficherGraphique(List<float> valeurs)
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
        /// Afficher un texte avec des points pour aligner les résultats.
        /// </summary>
        public static void Afficher(string text, int nb, bool afficher_prefixe = false)
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
    }
}
