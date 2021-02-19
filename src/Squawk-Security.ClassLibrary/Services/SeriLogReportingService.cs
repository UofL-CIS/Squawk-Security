using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Squawk_Security.ClassLibrary.Models;

namespace Squawk_Security.ClassLibrary.Services
{
    public class SerilogReportingService : IReportingService
    {
        private readonly ILogger _logger;

        public SerilogReportingService(ILogger logger)
        {
            _logger = logger;
        }

        public void SendEmail(string content) =>
            _logger.Warning("{emailContent}", content);

        public void SendEvaluatedNetworkMessage(EvaluatedNetworkMessage evaluatedNetworkMessage) =>
            _logger.Information("{evaluatedNetworkMessage}", evaluatedNetworkMessage);
    }
}
