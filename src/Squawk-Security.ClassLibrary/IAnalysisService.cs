using System;
using System.Collections.Generic;
using System.Text;
using SharpPcap;
using Squawk_Security.ClassLibrary.Models;

namespace Squawk_Security.ClassLibrary
{
    public interface IAnalysisService
    {
        EvaluatedNetworkMessage AnalyzePacket(RawCapture ePacket);
    }
}
