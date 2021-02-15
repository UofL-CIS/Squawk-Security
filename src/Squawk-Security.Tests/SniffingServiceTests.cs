using System;
using Moq;
using NUnit.Framework;
using PacketDotNet;
using SharpPcap;
using Squawk_Security.ClassLibrary;
using Squawk_Security.ClassLibrary.Models;
using Squawk_Security.ClassLibrary.Services;

namespace Squawk_Security.Tests
{
    public class SniffingServiceTests
    {
        private ISniffingService _sniffingService;

        [SetUp]
        public void Setup()
        {
            _sniffingService = new Mock<SharpPcapSniffingService>().Object;
        }

        [Test]
        public void Test1()
        {
            // Arrange
            

            // Act


            // Assert
            Assert.Pass();
        }
    }
}