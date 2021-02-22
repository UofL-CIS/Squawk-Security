using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using SharpPcap;
using Squawk_Security.ClassLibrary;
using Squawk_Security.ClassLibrary.Models;

namespace Squawk_Security.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISniffingService _sniffingService;
        private readonly IAnalysisService _analysisService;
        private readonly IPreventionService _preventionService;
        private readonly IReportingService _reportingService;

        public Worker(
            ILogger<Worker> logger,
            ISniffingService sniffingService,
            IAnalysisService analysisService,
            IPreventionService preventionService,
            IReportingService reportingService)
        {
            _logger = logger;
            _sniffingService = sniffingService;
            _analysisService = analysisService;
            _preventionService = preventionService;
            _reportingService = reportingService;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Start sniffing
            _sniffingService.OnPcapArrival += SniffingService_OnPcapArrival;
            _sniffingService.StartListening();

            // Continue service until requested to stop
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }

            // Stop sniffing
            _sniffingService.OnPcapArrival -= SniffingService_OnPcapArrival;
            _sniffingService.StopListening();

            _logger.LogCritical("Worker was cancelled");
        }

        private void SniffingService_OnPcapArrival(object sender, EventArgs e)
        {
            // This is a hardcoded dependency on SharpPcap.CaptureEventArgs
            var capture = ((CaptureEventArgs)e).Packet;

            // Check packet for complianceLevel
            var evaluatedNetworkMessage = _analysisService.AnalyzePacket(capture);

            if (evaluatedNetworkMessage.ComplianceLevel == ComplianceLevel.Noncompliant)
            {
                // Notify administrator via email
                _reportingService.SendEmail("Countermeasures were invoked");

                // Counter non-compliant packet source
                _preventionService.InvokeCountermeasures(evaluatedNetworkMessage);
            }

            // Log Network Message
            _reportingService.SendEvaluatedNetworkMessage(evaluatedNetworkMessage);
        }
    }
}
