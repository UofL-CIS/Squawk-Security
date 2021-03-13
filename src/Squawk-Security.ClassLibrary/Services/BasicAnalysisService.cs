using System.Collections.Generic;
using System.Threading.Tasks;
using PacketDotNet;
using SharpPcap;
using Squawk_Security.ClassLibrary.Extensions;
using Squawk_Security.ClassLibrary.Models;

namespace Squawk_Security.ClassLibrary.Services
{
    public class BasicAnalysisService : IAnalysisService
    {
        private readonly IComplianceChecker _complianceChecker;

        public BasicAnalysisService(IComplianceChecker complianceChecker)
        {
            _complianceChecker = complianceChecker;
        }

        public EvaluatedNetworkMessage AnalyzePacket(RawCapture capture)
        {
            var targetPacket = capture.GetPacket();
            var payloadPackets = new List<Packet> { targetPacket };
            while (targetPacket.HasPayloadPacket)
            {
                targetPacket = targetPacket.PayloadPacket;
                payloadPackets.Add(targetPacket);
            }

            foreach (var payloadPacket in payloadPackets)
            {
                if (payloadPacket is TcpPacket packet)
                {
                    string details = packet.PrintPropertiesAsString();
                    return new EvaluatedNetworkMessage(capture.Timeval.Date, details, _complianceChecker.Check(packet));
                }
            }

            return new EvaluatedNetworkMessage(capture.Timeval.Date, "Packet not checked", ComplianceLevel.Compliant);
        }
        public Task<EvaluatedNetworkMessage> AnalyzePacketAsync(RawCapture capture) =>
            Task.Run(() => AnalyzePacket(capture));
    }
}
