/*
 * Reporting Service:
 * Should add alerts for administrators via email
 * Should add alerts for metrics via Seq
 * Should add informational metrics via Seq
 */

using System;
using System.Linq;
using System.Net;
using System.Text;
using Moq;
using NUnit.Framework;
using PacketDotNet;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Sinks.TestCorrelator;
using SharpPcap;
using Squawk_Security.ClassLibrary;
using Squawk_Security.ClassLibrary.Models;
using Squawk_Security.ClassLibrary.Services;

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
                _reportingService = new Mock<IReportingService>(Log.Logger)
                    ;

                // Act
                _reportingService.Object.SendEmail(body);
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
                isCompliant ? Compliancy.Compliant : Compliancy.Noncompliant);

            using (TestCorrelator.CreateContext())
            {
                _reportingService = new Mock<IReportingService>(Log.Logger)
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