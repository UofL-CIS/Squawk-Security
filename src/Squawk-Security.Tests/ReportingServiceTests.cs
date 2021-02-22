/*
 * Reporting Service:
 * Should add alerts for administrators via email
 * Should add alerts for metrics via Seq
 * Should add informational metrics via Seq
 */

using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.TestCorrelator;
using Squawk_Security.ClassLibrary;
using Squawk_Security.ClassLibrary.Models;

namespace Squawk_Security.Tests
{
    public class ReportingServiceTests
    {
        private Mock<IReportingService> _reportingService;

        [SetUp]
        public void Setup()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.TestCorrelator()
                .CreateLogger();
        }

        [TestCase("emailContent", "This is a test email!")]
        public void SendEmailTest(string template, string body)
        {
            // Arrange
            using (TestCorrelator.CreateContext())
            {
                _reportingService = new Mock<IReportingService>()
                    ;

                // Act
                _reportingService.Object.SendAlert(body);
            }

            var events = TestCorrelator.GetLogEventsFromCurrentContext().ToList();

            // Assert
            Assert.IsTrue(events.Count > 0);
            Assert.IsTrue(events.Any(x => x.Level == LogEventLevel.Warning), "Log level was not Warning!");
            Assert.IsTrue(events[0].Properties.TryGetValue(template, out var msgPropertyValue));
            Assert.IsTrue(msgPropertyValue.ToString().Contains(body));
        }

        [TestCase("networkMessage",true)]
        [TestCase("networkMessage", false)]
        public void SendNetworkMessageTest(string template, bool isCompliant)
        {
            // Arrange
            var networkMessage = new EvaluatedNetworkMessage(DateTime.Now,
                null,
                isCompliant ? ComplianceLevel.Compliant : ComplianceLevel.Noncompliant);

            using (TestCorrelator.CreateContext())
            {
                _reportingService = new Mock<IReportingService>()
                    ;

                // Act
                _reportingService.Object.SendEvaluatedNetworkMessage(networkMessage);
            }

            var events = TestCorrelator.GetLogEventsFromCurrentContext().ToList();

            // Assert
            Assert.IsTrue(events.Count > 0);
            Assert.IsTrue(events.Any(x => x.Level == (isCompliant ? LogEventLevel.Information : LogEventLevel.Warning)), "Log level was not correct!");
            Assert.IsTrue(events[0].Properties.TryGetValue(template, out var msgPropertyValue));
            Assert.IsNotNull(msgPropertyValue);
        }
    }
}