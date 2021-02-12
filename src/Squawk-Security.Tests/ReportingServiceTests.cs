using Moq;
using NUnit.Framework;
using Squawk_Security.ClassLibrary;

namespace Squawk_Security.Tests
{
    public class ReportingServiceTests
    {
        private Mock<IReportingService> _reportingService;

        [SetUp]
        public void Setup()
        {
            _reportingService = new Mock<IReportingService>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}