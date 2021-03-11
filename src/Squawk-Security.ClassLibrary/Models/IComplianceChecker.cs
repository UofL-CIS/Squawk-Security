using SharpPcap;

namespace Squawk_Security.ClassLibrary.Models
{
    public interface IComplianceChecker
    {
        ComplianceLevel Check(RawCapture capture);
        ComplianceLevel Check(ICaptureStatistics captureStatistics);
    }
}
