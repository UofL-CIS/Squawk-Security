using Moq;
using NUnit.Framework;
using SharpPcap;
using Squawk_Security.ClassLibrary;

namespace Squawk_Security.Tests
{
    public class AnalysisServiceTests
    {
        private IAnalysisService _analysisService;

        [SetUp]
        public void Setup()
        {
            _analysisService = new Mock<IAnalysisService>().Object;
        }

        [Test]
        public void SharpPcap_HasCapturableDevicesTest()
        {
            //Arrange
            CaptureDeviceList deviceList;

            //Act
            deviceList = CaptureDeviceList.Instance;

            //Assert
            Assert.IsTrue(deviceList.Count > 0);
        }

        [Test]
        public void SharpPcap_HasVersionNumberTest()
        {
            //Arrange
            string sharpPcapVersion;

            //Act
            sharpPcapVersion = Version.VersionString;

            //Assert
            Assert.IsFalse(string.IsNullOrEmpty(sharpPcapVersion));
        }
    }
}