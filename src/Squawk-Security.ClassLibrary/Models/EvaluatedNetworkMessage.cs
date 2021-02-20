using System;
using SharpPcap;
using Squawk_SecurityML.Model;

namespace Squawk_Security.ClassLibrary.Models
{
    public class EvaluatedNetworkMessage
    {
        public readonly DateTime Timestamp;
        public readonly ComplianceLevel ComplianceLevel;
        public readonly ModelInput PacketFeatures;
        public readonly RawCapture PacketCapture;

        public EvaluatedNetworkMessage(DateTime timestamp, ComplianceLevel complianceLevel, ModelInput packetFeatures,
            RawCapture packetCapture)
        {
            Timestamp = timestamp;
            ComplianceLevel = complianceLevel;
            PacketFeatures = packetFeatures;
            PacketCapture = packetCapture;
        }
    }
}
