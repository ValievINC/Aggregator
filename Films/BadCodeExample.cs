using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Films
{
    public static class BadCodeExample
    {
        enum WatchStatus
        {
            NotWatched = 0,
            Watching = 1,
            Watched = 2,
        }

        const int CardWidth = 20;

        static void PrintSeparator()
        {
            Console.WriteLine(new string('=', CardWidth));
         }

        static void PrintStatusText(WatchStatus status)
            {
            if (status == WatchStatus.NotWatched)
                Console.WriteLine("Статус: не смотрел");
            else if (status == WatchStatus.Watching)
                Console.WriteLine("Статус: смотрю");
            else if (status == WatchStatus.Watched)
                Console.WriteLine("Статус: посмотрел");
        }

        static void PrintStars(double rating)
        {
            Console.Write("Оценка: ");
            int stars1 = (int)Math.Round(rating);
            for (int i = 0; i < stars1; i++)
                Console.Write("*");
        }

        static void PrintMovie(string title, int year, double rating, WatchStatus status)
        {
            PrintSeparator();

                Console.WriteLine($"{title} ({year})");
                PrintStars(rating);

            Console.WriteLine();

                PrintStatusText(status);
                PrintSeparator();
        }

        public static void RefactorMe()
        {
            PrintMovie("The Matrix", 1999, 8.7, WatchStatus.Watched);
            PrintMovie("Dune", 2021, 8.0, WatchStatus.Watching);
            PrintMovie("Ералаш", 1970, 10.0, WatchStatus.NotWatched);
        }
    }
}
