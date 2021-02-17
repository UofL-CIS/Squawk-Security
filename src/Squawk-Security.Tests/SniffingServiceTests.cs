using Moq;
using NUnit.Framework;
using SharpPcap;
using Squawk_Security.ClassLibrary;

namespace Squawk_Security.Tests
{
    public class SniffingServiceTests
    {
        private Mock<ISniffingService> _mockSniffingService;

        [SetUp]
        public void Setup()
        {
            _mockSniffingService = new Mock<ISniffingService>()
                ;
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

        [Test]
        public void PacketsAreSniffableTest()
        {
            //Arrange
            var packetSniffed = false;

            //Act
            _mockSniffingService.Object.OnPcapArrival += (sender, args) =>
            {
                packetSniffed = true;
                _mockSniffingService.Object.StopListening();
            };

            _mockSniffingService.Object.StartListening();

            //Assert
            Assert.IsTrue(packetSniffed);
        }
    }
}