using System;
using System.Collections.Generic;
using System.Text;
using PacketDotNet;
using SharpPcap;

namespace Squawk_Security.ClassLibrary.Static
{
    public static class RawCaptureExtensions
    {
        public static List<Packet> ExtractPayloadsFromRawCapture(this RawCapture capture)
        {
            var targetPacket = capture.GetPacket();
            var payloadPackets = new List<Packet> { targetPacket };
            while (targetPacket.HasPayloadPacket)
            {
                targetPacket = targetPacket.PayloadPacket;
                payloadPackets.Add(targetPacket);
            }

            return payloadPackets;
        }
    }
}
