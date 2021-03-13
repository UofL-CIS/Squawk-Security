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

        public (ComplianceLevel, string) Check(RawCapture capture)
        {
            var packet = capture.GetPacket();

            if (packet is TcpPacket)
            {
                var tcpPacket = packet.Extract<TcpPacket>();
                
                // Check checksum integrity
                if (!tcpPacket.ValidTcpChecksum)
                {
                    return (ComplianceLevel.Noncompliant, "Invalid TCP Checksum");
                }

                // Blacklisted port
                var port = tcpPacket.DestinationPort.ToString();
                if (_ruleSet.DestinationPortBlacklist.ContainsKey(port)
                    && !_ruleSet.DestinationPortBlacklist[port])
                {
                    return (ComplianceLevel.Noncompliant, $"{tcpPacket.DestinationPort} is not allowed by rule set");
                }
            }

            //if (packet is InternetPacket)
            //{
            //    var internetPacket = packet.Extract<InternetPacket>();
            //}

            //if (packet is IPPacket)
            //{
            //    var ipPacket = packet.Extract<IPPacket>();
            //}

            return (ComplianceLevel.Compliant, string.Empty);
        }
    }
}
