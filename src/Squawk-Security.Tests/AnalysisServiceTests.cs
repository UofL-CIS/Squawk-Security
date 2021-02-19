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
    public class AnalysisServiceTests
    {
        private Mock<IComplianceChecker> _complianceChecker;
        private Mock<IAnalysisService> _analysisService;

        [SetUp]
        public void Setup()
        {
            _complianceChecker = new Mock<IComplianceChecker>();
            _analysisService = new Mock<IAnalysisService>();
        }

        [TestCase("", true)]
        [TestCase("", false)]
        public void AnalyzePacketTest(string packetData, bool isCompliant)
        {
            var capture = new RawCapture(LinkLayers.Ethernet, new PosixTimeval(DateTime.Now), Encoding.UTF8.GetBytes(packetData));

            var result = _analysisService.Object.AnalyzePacket(capture);

            if (isCompliant)
                Assert.IsTrue(result.ComplianceLevel == ComplianceLevel.Compliant);
            else
                Assert.IsFalse(result.ComplianceLevel == ComplianceLevel.Noncompliant);
        }
    }
}