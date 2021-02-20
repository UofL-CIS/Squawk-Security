using System;
using System.Collections.Generic;
using System.Text;
using PacketDotNet;
using Squawk_SecurityML.Model;

namespace Squawk_Security.ClassLibrary.Models
{
    public interface IComplianceChecker
    {
        bool Check(Packet getPacket);
        bool Check(Packet getPacket, out ModelInput packetFeatures);
    }
}
