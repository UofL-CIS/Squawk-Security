using System;
using PacketDotNet;
using Squawk_SecurityML.Model;

namespace Squawk_Security.ClassLibrary.Models
{
    public class MLComplianceChecker : IComplianceChecker
    {


        public bool Check(Packet getPacket)
        {
            throw new NotImplementedException();
        }

        public bool Check(Packet getPacket, out ModelInput packetFeatures)
        {
            throw new NotImplementedException();
        }
    }
}
