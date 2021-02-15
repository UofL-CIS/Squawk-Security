﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;
using Squawk_Security.ClassLibrary.Models;

namespace Squawk_Security.ClassLibrary.Services
{
    public class RoleBasedAnalysisService : IAnalysisService
    {
        private IRuleSet _ruleSet;

        public RoleBasedAnalysisService(IRuleSet ruleSet)
        {
            _ruleSet = ruleSet;
        }

        public EvaluatedNetworkMessage AnalyzePacket(RawCapture capture)
        {
            EvaluatedNetworkMessage evaluatedNetworkMessage;

            if (_ruleSet.CheckCompliancy(capture.GetPacket()))
            {
                evaluatedNetworkMessage = new EvaluatedNetworkMessage(capture.Timeval.Date, capture, Compliancy.Compliant);
            }
            else
            {
                evaluatedNetworkMessage = new EvaluatedNetworkMessage(capture.Timeval.Date, capture, Compliancy.Noncompliant);
            }

            return evaluatedNetworkMessage;
        }

        public Task<EvaluatedNetworkMessage> AnalyzePacketAsync(RawCapture capture) =>
            Task.Run(() => AnalyzePacket(capture));
    }
}
