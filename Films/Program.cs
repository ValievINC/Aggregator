using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Films
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "9000plus.csv");
            var fileExists = File.Exists(path);

            string[] lines = File.ReadAllLines("9000plus.csv", Encoding.UTF8);
            Console.WriteLine(lines.Length);

            var titles = new List<string>();
            var genresLists = new List<string>();
            var ratings = new List<double>();
            var years = new List<int>();
            var releases = new List<DateTime>();

            for (int i = 1; i < lines.Length; i++)
            {
                var fields = Parser.ParseCsvLine(lines[i]);
                if (fields.Count != 9)
                    continue;

                years.Add(int.Parse(fields[0].Split('-')[0]));
                releases.Add(DateTime.Parse(fields[0]));
                titles.Add(fields[1]);
                genresLists.Add(fields[7]);
                ratings.Add(double.Parse(fields[5], CultureInfo.InvariantCulture));
            }

            var genreCount = new Dictionary<string, int>();

            foreach (var genreList in genresLists)
            {
                var genres = genreList.Split(new[] { ", " }, StringSplitOptions.None);

                foreach (var genre in genres)
                {
                    if (!genreCount.ContainsKey(genre))
                        genreCount[genre] = 0;

                    genreCount[genre]++;
                }
            }

            var ratingsByTitle = new Dictionary<string, double>();
            List<string> missedFilms = new List<string>();
            for (int i = 0; i < titles.Count; i++)
            {
                string key = $"{titles[i]} ({years[i]})";
                if (!ratingsByTitle.Keys.Contains(key))
                    ratingsByTitle.Add(key, ratings[i]);
                else
                    missedFilms.Add(key);
            }

            var report = "";
            foreach (var title in titles)
                report += title + ", ";

            var builder = new StringBuilder();
            foreach (var title in titles)
            {
                builder.Append(title);
                builder.Append(", ");
            }
            var report2 = builder.ToString();

            var averageRating = GetAverageRating(ratings);

            Console.WriteLine("{0} ({1}) - {2}", titles[0], years[0], ratings[0]);
            var output = String.Format(CultureInfo.InvariantCulture, "Средний рейтинг фильмов: {0:0.00}", averageRating);
            Console.WriteLine(output);

            var release = releases[0];
            Console.WriteLine("Премьера фильма: {0:dd.MM.yyyy}", release);

            Console.WriteLine($"Новый \t \n фильм: \"{titles[0]}\"");
            //var path = "C:\\Users\\genna\\OneDrive\\Рабочий стол\\Пекусы\\Aggregator\\Films";
        }

        static double GetAverageRating(List<double> ratios)
        {
            double sum = 0;
            foreach (var ratio in ratios)
                sum += ratio;

            return sum / ratios.Count;
        }
    }
}
