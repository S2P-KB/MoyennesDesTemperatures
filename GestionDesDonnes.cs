using System;
using System.Collections.Generic;

namespace GestionDesDonnees
{
    public class Saisie
    {
        /// <summary>
        /// Demande une saisie utilisateur et vérifie si elle peut être convertie en float.
        /// </summary>
        /// <param name="message">Message à afficher à l'utilisateur</param>
        /// <returns>La valeur float saisie</returns>
        public static float SaisirTemperature(string message)
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

        /// <summary>
        /// Demande la saisie de températures dans une plage spécifiée et les ajoute à la liste.
        /// </summary>
        /// <param name="temperatures">Liste des températures saisies</param>
        public static void SaisirTemperatures(List<float> temperatures)
        {
            int x = 1;
            string reponse = "o";
            float temp;

            while (reponse.ToLower() != "n")
            {
                temp = 70;
                while (temp > 60 || temp < -60)
                {
                    temp = SaisirTemperature($"Température n°{x} (entre -60 et 60) = ");
                    
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
                    } while(reponse.ToLower() != "o" && reponse.ToLower() != "n");
                }

                x++;
            }
        }
    }
}
