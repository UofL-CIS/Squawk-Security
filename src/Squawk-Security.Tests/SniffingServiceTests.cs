using Moq;
using NUnit.Framework;
using Squawk_Security.ClassLibrary;

namespace Squawk_Security.Tests
{
    public class SniffingServiceTests
    {
        private Mock<ISniffingService> _sniffingService;

        [SetUp]
        public void Setup()
        {
            _sniffingService = new Mock<ISniffingService>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}