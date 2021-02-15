using System;
using System.Text;
using Moq;
using NUnit.Framework;
using PacketDotNet;
using SharpPcap;
using Squawk_Security.ClassLibrary;
using Squawk_Security.ClassLibrary.Models;
using Squawk_Security.ClassLibrary.Services;

namespace Squawk_Security.Tests
{
    public class PreventionServiceTests
    {
        private IPreventionService _preventionService;

        [SetUp]
        public void Setup()
        {
            _preventionService = new Mock<DeAuthenticationPreventionService>()
                .Object;
        }

        [TestCase("", true)]
        [TestCase("", false)]
        public void InvokeCountermeasuresTest(string packetData, bool isCompliant)
        {
            // Arrange
            var compliancy = isCompliant ? Compliancy.Compliant : Compliancy.Noncompliant;
            var evaluatedNetworkMessage = new EvaluatedNetworkMessage(DateTime.Now, new RawCapture(LinkLayers.Ethernet, new PosixTimeval(DateTime.Now), Encoding.UTF8.GetBytes(packetData)), compliancy);

            // Act
            _preventionService.InvokeCountermeasures(evaluatedNetworkMessage);

            // Assert
            Assert.Pass();
        }
    }
}