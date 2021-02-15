using System;
using Moq;
using NUnit.Framework;
using PacketDotNet;
using SharpPcap;
using Squawk_Security.ClassLibrary;
using Squawk_Security.ClassLibrary.Models;
using Squawk_Security.ClassLibrary.Services;
using Version = SharpPcap.Version;

namespace Squawk_Security.Tests
{
    public class SniffingServiceTests
    {
        private ISniffingService _sniffingService;

        [SetUp]
        public void Setup()
        {
            _sniffingService = new Mock<SharpPcapSniffingService>()
                .Object;
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
            bool packetSniffed = false;

            //Act
            _sniffingService.OnPcapArrival += (sender, args) =>
            {
                packetSniffed = true;
                _sniffingService.StopListening();
            };

            _sniffingService.StartListening();

            //Assert
            Assert.IsTrue(packetSniffed);
        }
    }
}