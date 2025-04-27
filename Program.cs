using System;
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
            List<float> valeursFiltrees = new List<float>{};
            foreach(float temperature in valeurs)
            {
                // 'HasValue' est une méthode vérifiant si le paramètre du module contient bien une valeur. Selon les cas, nous définissons quel opérateur logique appliquer.
                // Si le paramètre du module contient une valeur minimale, alors les valeurs plus grandes ou égales à la limite sont ignorées. Sinon, elles sont ajoutées à la liste des valeurs filtrées.
                // En adaptant évidemment la comparaison, le même principe se répercute sur les deux autres cas.
                if((min.HasValue && temperature < min.Value) || (max.HasValue && temperature > max.Value))
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
            if(valeursFiltrees.Count() == 0)
            {
                Console.WriteLine("pas de valeur concernée");
                return null;
            }
            foreach(float valeur in valeursFiltrees)
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
    static public void Main(string[] args)
    {
        List<float> temperatures = new List<float>();
        int x = 1;
        float temp;
        String reponse = "o";
        while(reponse != "n")
        {
            temp = 70;
            while(temp > 60 || temp < -60)
            {
                Console.Write("temperature n°" + x + "(entre -60 et 60) =");
                temp = float.Parse((Console.ReadLine()!));
            }
            temperatures.Add(temp);
            Console.Write("autre température à saisir ? (o/n )");
            reponse = (Console.ReadLine()!);
            x++;
        }

        String choix = "z";
        String mot = "t° précise";
        var expressions = new List<string> {"", $">= à une {mot}", $"<= à une {mot}", $"comprises entre 2 {mot}s"};
        int longueurMaximale = expressions.Max(expression => expression.Length) + 10;

        while(choix != "0")
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
            switch(choix)
            {
                case "1" :
                    Console.WriteLine("moyenne de toutes les temperatures = " + moyenne(temperatures));
                    break;


                case "2":
                    Console.Write("t° min = ");
                    float tmin = float.Parse(Console.ReadLine()!);
                    
                    Console.WriteLine("moyenne des t° >= à " + tmin + " = " + moyenne(temperatures, tmin));
                    break;
                    
                case "3":
                    Console.Write("t° min = ");
                    float tmax = float.Parse(Console.ReadLine()!);
                    
                    Console.WriteLine("moyenne des t° >= à " + tmax + " = " + moyenne(temperatures, null, tmax));
                    break;

                case "4":
                    Console.Write("t° min = ");
                    float t_min = float.Parse(Console.ReadLine()!);
                    Console.Write("t° min = ");
                    float t_max = float.Parse(Console.ReadLine()!);
                    
                    Console.WriteLine("moyenne des t° >= à " + t_min + " et <= à " + t_max + " = " + moyenne(temperatures, t_min, t_max));
                    break;

                case "0":
                    Console.WriteLine("Fin du traitement");
                    break;
            }
        }
    }
    }
}