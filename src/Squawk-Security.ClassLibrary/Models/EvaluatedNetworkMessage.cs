using System;
using System.Linq;
using System.Net;
using PacketDotNet;
using SharpPcap;
using Squawk_Security.ClassLibrary.Extensions;

namespace Squawk_Security.ClassLibrary.Models
{
    public class EvaluatedNetworkMessage
    {
        public readonly DateTime Timestamp;
        public readonly ComplianceLevel ComplianceLevel;
        public readonly RawCapture Capture;
        public readonly string Reason;

        public EvaluatedNetworkMessage(DateTime timestamp, RawCapture capture, (ComplianceLevel, string) compliance)
        {
            Timestamp = timestamp;
            Capture = capture;

            var (complianceLevel, reason) = compliance;
            ComplianceLevel = complianceLevel;
            Reason = reason;
        }

        public EvaluatedNetworkMessage(DateTime timestamp, RawCapture capture, ComplianceLevel complianceLevel)
        {
            Timestamp = timestamp;
            Capture = capture;
            ComplianceLevel = complianceLevel;
        }

        public string GetCaptureChecksum() => Capture.Data.Sum(x => x).ToString();

        public override string ToString() => this.PrintPropertiesAsString();
    }
}
