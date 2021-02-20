using System.Threading.Tasks;
using SharpPcap;
using Squawk_Security.ClassLibrary.Models;
using Squawk_Security.ClassLibrary.Models.Static;

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
            var modelInput = RawCaptureToModelInputConverter.Convert(capture);
            
            var compliance = _complianceChecker.Check(modelInput);

            return new EvaluatedNetworkMessage(capture.Timeval.Date, compliance, modelInput, capture);
        }

        public Task<EvaluatedNetworkMessage> AnalyzePacketAsync(RawCapture capture) =>
            Task.Run(() => AnalyzePacket(capture));
    }
}
