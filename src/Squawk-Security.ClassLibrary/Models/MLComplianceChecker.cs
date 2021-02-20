using System;
using PacketDotNet;
using Squawk_SecurityML.Model;

namespace Squawk_Security.ClassLibrary.Models
{
    public class MLComplianceChecker : IComplianceChecker
    {
        private const string COMPLIANT_STRING = "Benign";

        public ComplianceLevel Check(ModelInput packetFeatures)
        {
            var result = ConsumeModel.Predict(packetFeatures);

            return result.Prediction.Contains(COMPLIANT_STRING)
                ? ComplianceLevel.Compliant
                : ComplianceLevel.Noncompliant;
        }
    }
}
