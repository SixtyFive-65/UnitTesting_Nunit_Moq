using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PlaceOder_WhenCalled_StoreTheOder()
        {
            var storage = new Mock<IStorage>();
            
            var service = new OrderService(storage.Object);

            var oder = new Order();

            service.PlaceOrder(oder);

            storage.Verify( s => s.Store(oder));

        }
    }
}
