using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Films
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title1 = "The Matrix";
            string title2 = "Dune";
            string title3 = "Tenet";
            double rating1 = 8.7;
            double rating2 = 8.0;
            double rating3 = 7.3;

            string[] titles = new string[3];
            titles[0] = "The Matrix";
            titles[1] = "Dune";
            titles[2] = "Tenet";
            // Console.WriteLine(titles[2].Length);

            //double[] ratings = new double[3];
            //ratings[0] = 8.7;
            //ratings[1] = 8.0;
            //ratings[2] = 7.3;

            //var ratings = new double[] { 8.7, 8.0, 7.3 };
            //var ratings = new[] { 8.7, 8.0, 7.3 };
            double[] ratings = { 8.7, 8.0, 7.3 };

            ratings[0] = 10.0;
            ratings[1] = 2.0;

            //Console.WriteLine(string.Join(", ", ratings));

            double averageRating = GetAverageRating(ratings);
            TurnToFive(ratings);

            var years = new int[3];
            var movieNames = new string[3];

            //Console.WriteLine(years[0]);
            //Console.WriteLine(movieNames[0].Length);

            int year = 2000;
            int otherYear = year;

            year = 2005;

            int[,] scores =
            {
                { 9, 10, 5, 3 }, // Зритель 1
                { 9, 10, 2, 3 }, // Зритель 2
                { 9, 10, 5, 8 }, // Зритель 3
            };

            for (int viewer = 0; viewer < scores.GetLength(0); viewer++)
            {
                for (int movie = 0; movie < scores.GetLength(1); movie++)
                {
                    //Console.WriteLine(scores[viewer, movie]);
                }
            }

            var result = scores.Rank;

            string[][] casts = new string[3][];
            casts[0] = new[] { "Катя", "Миша", "Маша" }; 
            casts[1] = new[] { "Катя", "Миша" }; 
            casts[2] = new[] { "Катя" }; 

            Console.WriteLine(casts.Length);
            Console.WriteLine(casts[0].Length);
            Console.WriteLine(casts[1].Length);

            Console.WriteLine(casts[1][0]);

            for (int movie = 0; movie < casts.Length; movie++)
            {
                foreach (var actor in casts[movie])
                {
                    Console.WriteLine(actor);
                }
                Console.WriteLine("");
            }

            int[][][] a;
            int[][,] b;
            int[,][] c;
        }

        private static double GetAverageRating(double rating1, double rating2, double rating3)
        {
            return (rating1 + rating2 + rating3) / 3.0;
        }

        private static double GetAverageRating(double[] ratings)
        {
            double sum = 0;

            foreach (double rating in ratings)
            {
                sum += rating;
            }

            //for (int i = 0; i < ratings.Length; i++)
            //{
            //    sum += ratings[i];
            //}

            return (sum / ratings.Length);
        }

        private static void TurnToFive(double[] ratings)
        {
            for (int i = 0; i < ratings.Length; i++)
            {
                ratings[i] = ratings[i] / 2;
            }
        }
    }
}
