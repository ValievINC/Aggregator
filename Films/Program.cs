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
            string filmname = null;
            int year = 2019;
            float rating = 7.4f;
            int ageRating = 18;
            long earned = 2_800_000_000L;
            string country = "USA";
            WatchStatus watchStatus = WatchStatus.NotWatched;
            int stars = (int)Math.Round(rating);

            string mark = "";
            if (rating >= 8)
                mark = "Хит";
            else
                mark = "Обычный фильм";

            mark = rating >= 8
                ? "Хит"
                : "Обычный фильм";

            string title = "";
            if (filmname != null)
                title = filmname;
            else
                title = $"Без названия";

            title = filmname ?? "Без названия";

            int? filmnameLenght = filmname?.Length;

            var result = 11 % 100;
        }

        static string GetWatchStatusName(WatchStatus watchStatus)
        {
            string result = "";

            switch (watchStatus)
            {
                case WatchStatus.Watched:
                    result = "Просмотрено";
                    break;
                case WatchStatus.NotWatched:
                    result = "Не смотрел";
                    break;
                case WatchStatus.Watching:
                    result = "Смотрю";
                    break;
            }

            return result;
        }
    }
}
