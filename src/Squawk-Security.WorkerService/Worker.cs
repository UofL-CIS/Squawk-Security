using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Serilog;
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

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;

            var container = Dependencies.GetContainer();
            _sniffingService = container.Resolve<ISniffingService>();
            _analysisService = container.Resolve<IAnalysisService>();
            _preventionService = container.Resolve<IPreventionService>();
            _reportingService = container.Resolve<IReportingService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _sniffingService.OnPcapArrival += SniffingService_OnPcapArrival;
            _sniffingService.StartListening();

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }

            _sniffingService.OnPcapArrival -= SniffingService_OnPcapArrival;
            _sniffingService.StopListening();

            const string msg = "Worker was cancelled";
            _logger.LogCritical(msg);
        }

        private void SniffingService_OnPcapArrival(object sender, EventArgs e)
        {
            var capture = ((CaptureEventArgs)e).Packet;

            var evaluatedNetworkMessage = _analysisService.AnalyzePacket(capture);

            if (evaluatedNetworkMessage.Compliancy == Compliancy.Noncompliant)
            {
                _reportingService.SendEmail("Countermesaures were invoked");
                _preventionService.InvokeCountermeasures(evaluatedNetworkMessage);
            }

            _reportingService.SendEvaluatedNetworkMessage(evaluatedNetworkMessage);
        }
    }
}
