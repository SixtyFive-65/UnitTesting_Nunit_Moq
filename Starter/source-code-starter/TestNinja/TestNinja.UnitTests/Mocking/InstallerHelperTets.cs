using Moq;
using NUnit.Framework;
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTets
    {
        private Mock<IInstallerHerlperRepo> installerHelper = new Mock<IInstallerHerlperRepo>();

        private InstallerHelper service = new InstallerHelper();

        [SetUp]
        public void Setup()
        {
            installerHelper = new Mock<IInstallerHerlperRepo>();
            service = new InstallerHelper(installerHelper.Object);
        }

        [Test]
        [TestCase("customer","installer")]
        public void DownloadInstaller_DownloadFaied_ReturnFalse(string n, string m)
        {
            installerHelper.Setup(p => p.DownloadInstaller(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = service.DownloadInstaller(n,m);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        [TestCase("customer", "installer")]
        public void DownloadInstaller_DownloadSuccess_ReturnTrue(string n, string m)
        {
            installerHelper.Setup(p => p.DownloadInstaller(It.IsAny<string>(), It.IsAny<string>()));

            var result = service.DownloadInstaller(n, m);

            Assert.That(result, Is.EqualTo(true));
        }
    }
}
