namespace Films.Core
{
    public static class Utils
    {
        public static double GetAverageRating(List<double> ratings)
        {
            if (ratings.Count == 0)
                return 0;

            double sum = 0;
            foreach (var rating in ratings)
                sum += rating;
            return sum / ratings.Count;
        }

        public static string Shorten(string text, int width)
        {
            if (text.Length <= width)
                return text;

            return text.Substring(0, width - 3) + "...";
        }
    }
}
