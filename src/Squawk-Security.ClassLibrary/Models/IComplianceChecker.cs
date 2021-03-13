using PacketDotNet;
using SharpPcap;

namespace Squawk_Security.ClassLibrary.Models
{
    public interface IComplianceChecker
    {
        (ComplianceLevel, string) Check(TcpPacket tcpPacket);
    }
}
