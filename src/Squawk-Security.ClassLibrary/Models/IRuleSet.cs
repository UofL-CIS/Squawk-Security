using System;
using System.Collections.Generic;
using System.Text;
using PacketDotNet;

namespace Squawk_Security.ClassLibrary.Models
{
    public interface IRuleSet
    {
        bool CheckCompliancy(Packet getPacket);
    }
}
