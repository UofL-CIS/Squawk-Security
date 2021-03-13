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
        public readonly string Details;
        public readonly string Reason;

        public EvaluatedNetworkMessage(DateTime timestamp, string details, (ComplianceLevel, string) compliance)
        {
            Timestamp = timestamp;
            Details = details;

            var (complianceLevel, reason) = compliance;
            ComplianceLevel = complianceLevel;
            Reason = reason;
        }

        public EvaluatedNetworkMessage(DateTime timestamp, string details, ComplianceLevel complianceLevel)
        {
            Timestamp = timestamp;
            Details = details;
            ComplianceLevel = complianceLevel;
        }

        public override string ToString() => this.PrintPropertiesAsString();
    }
}
