using System;
using Moq;
using NUnit.Framework;
using PacketDotNet;
using SharpPcap;
using Squawk_Security.ClassLibrary;
using Version = SharpPcap.Version;

namespace Squawk_Security.Tests
{
    public class SniffingServiceTests
    {
        private Mock<ISniffingService> _mockSniffingService;

        [SetUp]
        public void Setup()
        {
            _mockSniffingService = new Mock<ISniffingService>();
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
        public void PacketsAreSniffableFromMockTest()
        {
            //Arrange
            var packetSniffed = false;
            var capture = new RawCapture(LinkLayers.Ethernet, new PosixTimeval(DateTime.Now), null);
            var device = new Mock<ICaptureDevice>().Object;

            _mockSniffingService
                .Setup(x => x.StartListening())
                .Raises(x => x.OnPcapArrival += null, new CaptureEventArgs(capture, device));

            //Act
            _mockSniffingService.Object.OnPcapArrival += (sender, args) =>
                packetSniffed = true;

            _mockSniffingService.Object.StartListening();

            //Assert
            Assert.IsTrue(packetSniffed);
        }
    }
}