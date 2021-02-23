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

        public ComplianceLevel Analyze(ICaptureStatistics captureStatistics) =>
            _complianceChecker.Check(captureStatistics);

        public EvaluatedNetworkMessage Analyze(RawCapture capture) =>
            new EvaluatedNetworkMessage(capture.Timeval.Date, capture, _complianceChecker.Check(capture));

        public async Task<ComplianceLevel> AnalyzeAsync(ICaptureStatistics captureStatistics) =>
            await Task.FromResult(Analyze(captureStatistics));

        public async Task<EvaluatedNetworkMessage> AnalyzeAsync(RawCapture capture) =>
            await Task.FromResult(Analyze(capture));
    }
}
