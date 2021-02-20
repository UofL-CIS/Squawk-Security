using System.Threading.Tasks;
using SharpPcap;
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

        public EvaluatedNetworkMessage AnalyzePacket(RawCapture capture) =>
            _complianceChecker.Check(capture.GetPacket(), out var packetFeatures)
                ? new EvaluatedNetworkMessage(capture.Timeval.Date, ComplianceLevel.Compliant, packetFeatures, capture)
                : new EvaluatedNetworkMessage(capture.Timeval.Date, ComplianceLevel.Noncompliant, packetFeatures, capture);

        public Task<EvaluatedNetworkMessage> AnalyzePacketAsync(RawCapture capture) =>
            Task.Run(() => AnalyzePacket(capture));
    }
}
