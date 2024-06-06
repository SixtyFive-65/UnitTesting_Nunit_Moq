using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> fileReader = new Mock<IFileReader>();
        private Mock<IVideoRepository> videoRepo = new Mock<IVideoRepository>();
        private VideoService service = new VideoService();

        [SetUp]
        public void Setup()  // Setup helps us re-use Arranging without duplicating code
        {
            this.fileReader = new Mock<IFileReader>(); // Create mock object for IFileReader interface
            service = new VideoService(fileReader.Object, videoRepo.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = service.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnporcessed_UprocessedVideos_ReturnUnprocessedVideosEmptyList()
        {
            videoRepo.Setup(f => f.GetUnporocessedVideos()).Returns(new List<Video>());

            var result = service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnporcessed_UprocessedVideos_ReturnUnprocessedVideosList()
        {
            videoRepo.Setup(f => f.GetUnporocessedVideos()).Returns(new List<Video>()
                  { new Video { Id = 1},
                  { new Video { Id = 2 } },
                  { new Video { Id = 3 } }}
            );

            var result = service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
