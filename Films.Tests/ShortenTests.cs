using Films.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Films.Tests
{
    [TestFixture]
    internal class ShortenTests
    {
        [TestCase("Dune", 10, "Dune")]
        [TestCase("1234567890", 10, "1234567890")]
        [TestCase("The Lord Of The Rings", 10, "The Lor...")]
        public void Shorten_ReturnExpected(string text, int width, string expected)
        {
            Assert.AreEqual(expected, Utils.Shorten(text, width));
        }
    }
}
