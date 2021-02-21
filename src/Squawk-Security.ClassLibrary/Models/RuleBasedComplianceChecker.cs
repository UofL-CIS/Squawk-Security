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
        public ComplianceLevel Check(RawCapture capture)
        {
            throw new NotImplementedException();
        }
    }
}
