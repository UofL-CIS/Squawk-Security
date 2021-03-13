using System;
using System.Collections.Generic;
using System.Text;
using PacketDotNet;
using PacketDotNet.Ieee80211;
using SharpPcap;

namespace Squawk_Security.ClassLibrary.Models
{
    public class RuleBasedComplianceChecker : IComplianceChecker
    {
        private readonly IRuleSet _ruleSet;

        public RuleBasedComplianceChecker(IRuleSet ruleSet)
        {
            _ruleSet = ruleSet;
        }

        public (ComplianceLevel, string) Check(TcpPacket tcpPacket)
        {
            // Check for Blacklisted port
            if (CheckIfBlacklistedPortUsed(tcpPacket, out var compliance))
                return compliance;

            return (ComplianceLevel.Compliant, string.Empty);
        }

        private bool CheckIfBlacklistedPortUsed(TcpPacket tcpPacket, out (ComplianceLevel, string) compliance)
        {
            var destinationPort = tcpPacket.DestinationPort.ToString();
            if (_ruleSet.DestinationPortBlacklist.ContainsKey(destinationPort)
                && !_ruleSet.DestinationPortBlacklist[destinationPort])
            {
                {
                    compliance = (ComplianceLevel.Noncompliant,
                        $"Outbound port ({tcpPacket.DestinationPort}) is not allowed by rule set");
                    return true;
                }
            }

            var Inbound = tcpPacket.DestinationPort.ToString();
            if (_ruleSet.InboundPortBlacklist.ContainsKey(destinationPort)
                && !_ruleSet.DestinationPortBlacklist[destinationPort])
            {
                {
                    compliance = (ComplianceLevel.Noncompliant,
                        $"Outbound port ({tcpPacket.DestinationPort}) is not allowed by rule set");
                    return true;
                }
            }

            compliance = (ComplianceLevel.Compliant, string.Empty);
            return false;
        }
    }
}
