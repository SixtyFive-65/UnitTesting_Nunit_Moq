using NUnit.Framework;
using System.Linq;
using Math = TestNinja.Fundamentals.Math;
namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();  //Arrrange
        }

        [Test]
        [Ignore("Cause I can")]
        public void Add_Add2Numbers_NumbersAdded()
        {
            var sum = _math.Add(1, 2) ; //Act

            Assert.That(sum , Is.EqualTo(3)); //Assert
        }

        [Test]
        [TestCase(2,1,2)]
        [TestCase(1,2,2)]
        [TestCase(1,1,1)]
        public void Max_ReturnGreatorArgument_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            expectedResult = _math.Max(a, b);

            Assert.That(expectedResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNUmbers_LimitGreaterThan0_ReturnOrdNUmbers()
        {
            var result = _math.GetOddNumbers(5);

            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count(), Is.EqualTo(3));

            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));

            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5}));  //equivalent to above 3 lines
          //  Assert.That(result, Is.Ordered);
          //  Assert.That(result, Is.Unique);
        }
    }
}
