using System;
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

        public EvaluatedNetworkMessage(DateTime timestamp, RawCapture capture, ComplianceLevel complianceLevel)
        {
            Timestamp = timestamp;
            Capture = capture;
            ComplianceLevel = complianceLevel;
        }

        public override string ToString() => this.PrintPropertiesAsString();
    }
}
