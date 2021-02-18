using System;
using System.Text;
using Moq;
using NUnit.Framework;
using PacketDotNet;
using SharpPcap;
using Squawk_Security.ClassLibrary;
using Squawk_Security.ClassLibrary.Models;

namespace Squawk_Security.Tests
{
    public class PreventionServiceTests
    {
        private Mock<IPreventionService> _preventionService;

        [SetUp]
        public void Setup()
        {
            _preventionService = new Mock<IPreventionService>()
                ;
        }

        [TestCase("", true)]
        [TestCase("", false)]
        public void InvokeCountermeasuresTest(string packetData, bool isCompliant)
        {
            // Arrange
            var complianceLevel = isCompliant ? ComplianceLevel.Compliant : ComplianceLevel.Noncompliant;
            var evaluatedNetworkMessage = new EvaluatedNetworkMessage(DateTime.Now, new RawCapture(LinkLayers.Ethernet, new PosixTimeval(DateTime.Now), Encoding.UTF8.GetBytes(packetData)), complianceLevel);

            // Act
            _preventionService.Object.InvokeCountermeasures(evaluatedNetworkMessage);

            // Assert
            Assert.Fail();
        }
    }
}