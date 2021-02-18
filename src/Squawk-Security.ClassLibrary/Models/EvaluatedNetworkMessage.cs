using System;
using System.Net;
using PacketDotNet;
using SharpPcap;

namespace Squawk_Security.ClassLibrary.Models
{
    public class EvaluatedNetworkMessage
    {
        public readonly DateTime Timestamp;
        public readonly RawCapture Capture;
        public readonly ComplianceLevel ComplianceLevel;

        public EvaluatedNetworkMessage(DateTime timestamp, RawCapture capture, ComplianceLevel complianceLevel)
        {
            Timestamp = timestamp;
            Capture = capture;
            ComplianceLevel = complianceLevel;
        }
    }
}
