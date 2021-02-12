using Moq;
using NUnit.Framework;
using Squawk_Security.ClassLibrary;

namespace Squawk_Security.Tests
{
    public class AnalysisServiceTests
    {
        private Mock<IAnalysisService> _analysisService;

        [SetUp]
        public void Setup()
        {
            _analysisService = new Mock<IAnalysisService>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}