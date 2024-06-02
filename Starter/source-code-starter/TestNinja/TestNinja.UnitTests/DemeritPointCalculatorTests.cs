using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointCalculatorTests
    {
        [Test]

        public void CalculateDemeritPoints_CalculatePointsBySpeed_ReturnArgumentNulls()
        {
            var demit = new DemeritPointsCalculator();

            Assert.That(() => demit.CalculateDemeritPoints(-1), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void CalculateDemeritPoints_CalculatePointsBySpeed_Return0()
        {
            var demit = new DemeritPointsCalculator();

            var result = demit.CalculateDemeritPoints(65);

            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void CalculateDemeritPoints_CalculatePointsBySpeed_ReturnDemiritPoints()
        {
            var demit = new DemeritPointsCalculator();

            var result = demit.CalculateDemeritPoints(130);

            Assert.That(result, Is.EqualTo(13));
        }
    }
}
