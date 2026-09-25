using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filmname = "Avengers";
            int year = 2019;
            float rating = 8.4f;
            int ageRating = 18;
            long earned = 2_800_000_000L;
            string country = "USA";

            int stars = (int)Math.Round(rating);
            var title = $"{filmname} ({year})";

            Console.WriteLine(GetCategory(rating));
        }

        static string GetCategory(float rating)
        {
            if (rating > 8)
                return "high";

            if (rating > 5)
                return "mid";

            return "low";
        }
    }
}
