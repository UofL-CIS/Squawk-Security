using SharpPcap;

namespace Squawk_Security.ClassLibrary.Models
{
    public interface IComplianceChecker
    {
        ComplianceLevel Check(RawCapture capture);
    }
}
