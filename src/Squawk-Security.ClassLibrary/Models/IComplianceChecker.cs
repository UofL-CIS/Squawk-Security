using System;
using System.Collections.Generic;
using System.Text;
using PacketDotNet;

namespace Squawk_Security.ClassLibrary.Models
{
    public interface IComplianceChecker
    {
        bool Check(Packet getPacket);
    }
}
