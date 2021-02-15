using Moq;
using NUnit.Framework;
using Squawk_Security.ClassLibrary;

namespace Squawk_Security.Tests
{
    public class PreventionServiceTests
    {
        private IPreventionService _preventionService;

        [SetUp]
        public void Setup()
        {
            _preventionService = new Mock<IPreventionService>().Object;
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}