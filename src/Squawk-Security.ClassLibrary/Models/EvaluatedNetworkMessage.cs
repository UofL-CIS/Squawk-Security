using System;
using System.Net;
using PacketDotNet;
using SharpPcap;

namespace Squawk_Security.ClassLibrary.Models
{
    public class EvaluatedNetworkMessage
    {
        public readonly DateTime Timestamp;
        public readonly RawCapture Capture;
        public readonly Compliancy Compliancy;

        public EvaluatedNetworkMessage(DateTime timestamp, RawCapture capture, Compliancy compliancy)
        {
            Timestamp = timestamp;
            Capture = capture;
            Compliancy = compliancy;
        }
    }
}
