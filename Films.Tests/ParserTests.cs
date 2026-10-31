using Films.Core;
using NUnit.Framework;
using System.Text;

namespace Films.Tests
{
    [TestFixture]
    public class ParserTests
    {
        static void AssertFields(string line, params string[] expected)
        {
            var fields = Parser.ParseCsvLine(line);
            Assert.AreEqual(expected.Length, fields.Count);

            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], fields[i]);
        }

        [Test]
        public void ParseCsvLine_SimpleLine()
        {
            AssertFields(
                "2021-12-15,Spider-Man: No Way Home,7.8",
                "2021-12-15", "Spider-Man: No Way Home", "7.8");
        }

        [Test]
        public void ParseCsvLine_CommaInsideQuotes()
        {
            AssertFields(
                "2021-12-15,\"Spider-Man, No Way Home\",7.8",
                "2021-12-15", "Spider-Man, No Way Home", "7.8");
        }

        [Test]
        public void ParseCsvLine_DoubleQuotes()
        {
            AssertFields(
                "2021-12-15,\"Spider-Man \"\"No Way Home\"\"\",7.8",
                "2021-12-15", "Spider-Man \"No Way Home\"", "7.8");
        }

        [Test]
        public void ParseCsvLine_RandomField()
        {
            var random = new Random(42);
            const string Alphabet = "abcXYZ ,\"-";
            for (int test = 0; test < 1000; test++)
            {
                var originalFields = new List<string>();
                int fieldCount = random.Next(1, 6);
                for (int i = 0; i < fieldCount; i++)
                {
                    var text = new StringBuilder();
                    int textLength = random.Next(0, 10);
                    for (int k = 0; k < textLength; k++)
                    {
                        text.Append(Alphabet[random.Next(Alphabet.Length)]);
                    }
                    originalFields.Add(text.ToString());
                }

                var escaped = new List<string>();
                foreach (var field in originalFields)
                {
                    escaped.Add(Parser.EscapeCsvField(field));
                }
                var line = string.Join(',', escaped);


                var parsed = Parser.ParseCsvLine(line);
                Assert.AreEqual(originalFields.Count, parsed.Count, line);
                for (int k = 0; k < originalFields.Count; k++)
                    Assert.AreEqual(originalFields[k], parsed[k], line);
            }
        }
    }
}
