using System;
namespace tests
{
    class Module
    {
        private static float? moyenne(List<float> valeurs, float? min = null, float? max = null)
        {

            List<float> valeursFiltrees = new List<float>{};
            foreach(float temperature in valeurs)
            {
                // 'HasValue' est une méthode vérifiant si le paramètre du module contient bien une valeur. Selon les cas, nous définissons quel opérateur logique appliquer.
                // Si le paramètre du module contient une valeur minimale, alors les valeurs plus grandes ou égales à la limite sont ignorées. Sinon, elles sont ajoutées à la liste des valeurs filtrées.
                // En adaptant évidemment la comparaison, le même principe se répercute sur les deux autres cas.
                if((min.HasValue && temperature <= min.Value) || (max.HasValue && temperature >= max.Value))
                {
                    continue;
                }
                else
                {
                    valeursFiltrees.Add(temperature);
                }
            }


            /// Faire la moyenne de toutes les valeurs filtrées.
            float somme = 0;
            float moyenne;
            if(valeursFiltrees.Count() == 0)
            {
                moyenne = -1;
                Console.WriteLine("pas de valeur concernée");
                return null;
            }
            foreach(float valeur in valeursFiltrees)
            {
                somme += valeur;
            }
            moyenne = somme / valeursFiltrees.Count();
            return moyenne;
        }      
    }
}
