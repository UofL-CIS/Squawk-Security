using System.Threading.Tasks;
using SharpPcap;
using Squawk_Security.ClassLibrary.Models;

namespace Squawk_Security.ClassLibrary
{
    public interface IAnalysisService
    {
        ComplianceLevel Analyze(ICaptureStatistics captureStatistics);
        EvaluatedNetworkMessage Analyze(RawCapture capture);
        Task<ComplianceLevel> AnalyzeAsync(ICaptureStatistics captureStatistics);
        Task<EvaluatedNetworkMessage> AnalyzeAsync(RawCapture capture);
    }
}
