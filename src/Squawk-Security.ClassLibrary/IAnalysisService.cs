using System.Threading.Tasks;
using SharpPcap;
using Squawk_Security.ClassLibrary.Models;

namespace Squawk_Security.ClassLibrary
{
    public interface IAnalysisService
    {
        EvaluatedNetworkMessage AnalyzePacket(RawCapture capture);
        Task<EvaluatedNetworkMessage> AnalyzePacketAsync(RawCapture capture);
    }
}
