using System;
using SharpPcap;

namespace Squawk_Security.ClassLibrary.Models
{
    public class RuleBasedComplianceChecker : IComplianceChecker
    {
        public ComplianceLevel Check(RawCapture capture)
        {
#if DEBUG
            return ComplianceLevel.Compliant;
#endif
            throw new NotImplementedException();
        }

        public ComplianceLevel Check(ICaptureStatistics captureStatistics)
        {
#if DEBUG
            return ComplianceLevel.Noncompliant;
#endif
            throw new NotImplementedException();
        }
    }
}
