using Films.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Films.Tests
{
    [TestFixture]
    internal class GetAverageTests
    {
        [Test]
        public void GetAverage_ThreeRatings()
        {
            var ratings = new List<double> { 8.7, 5.1, 7.2 };
            var average = Utils.GetAverageRating(ratings);

            Assert.AreEqual(7.0, average, 1e-4);
        }

        [Test]
        public void GetAverage_EmptyList()
        {
            var ratings = new List<double>();
            var average = Utils.GetAverageRating(ratings);

            Assert.AreEqual(0, average, 1e-4);
        }
    }
}
