﻿using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using SharpPcap;
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

        public void SendAlert(string content) =>
            _logger.Warning("[Alert] - {Content}", content);

        public void SendAlert(string content, EvaluatedNetworkMessage evaluatedNetworkMessage) =>
            _logger.Warning(
                "[Alert] - {Content} | Evaluated Network Message: {Timestamp}; Compliance: {ComplianceLevel}; Link Layer: {LinkLayerType};",
                content, evaluatedNetworkMessage.Timestamp, evaluatedNetworkMessage.ComplianceLevel,
                evaluatedNetworkMessage.Capture.LinkLayerType, evaluatedNetworkMessage.GetCaptureChecksum());

        public void SendEvaluatedNetworkMessage(EvaluatedNetworkMessage evaluatedNetworkMessage) =>
            _logger.Information(
                "Evaluated Network Message: {Timestamp}; Compliance: {ComplianceLevel}; Link Layer: {LinkLayerType}; Capture Checksum: {CaptureChecksum}",
                evaluatedNetworkMessage.Timestamp, evaluatedNetworkMessage.ComplianceLevel,
                evaluatedNetworkMessage.Capture.LinkLayerType, evaluatedNetworkMessage.GetCaptureChecksum());
    }
}
