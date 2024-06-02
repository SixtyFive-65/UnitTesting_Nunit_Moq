using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    //[TestFixture]
    public class ReservationTests
    {
        //[Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()  //CanBeCancelledBy_Scenario_ExpectedBehavior() : MethodName_Scebario_ExpectedBehavior
        {
            //Arrange  (Initialize the test object - prepare object we want to test) 

            var reservation = new Reservation();

            //Act  (Call a method we are going to test)

            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true});

            //Assert (Verify that result is true)

            Assert.That(result, Is.True);
        }

       // [Test]
        public void CanBeCancelledBy_MadeByUser_ReturnsTrue()  //CanBeCancelledBy_Scenario_ExpectedBehavior() : MethodName_Scebario_ExpectedBehavior
        {
            //Arrange  (Initialize the test object - prepare object we want to test) 

            var user = new User();

            var reservation = new Reservation() { MadeBy = user};

            //Act  (Call a method we are going to test)

            var result = reservation.CanBeCancelledBy(reservation.MadeBy);

            //Assert (Verify that result is true)

            Assert.IsTrue(result);
        }

       // [Test]
        public void CanBeCancelledBy_NotAdminOrUser_ReturnsFalse()  //CanBeCancelledBy_Scenario_ExpectedBehavior() : MethodName_Scebario_ExpectedBehavior
        {
            //Arrange  (Initialize the test object - prepare object we want to test) 

            var reservation = new Reservation();

            //Act  (Call a method we are going to test)

            var result = reservation.CanBeCancelledBy(new User { IsAdmin = false});

            //Assert (Verify that result is true)

            Assert.IsFalse(result);
        }
    }
}
