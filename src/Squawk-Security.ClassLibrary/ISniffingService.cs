using System;
using SharpPcap;

namespace Squawk_Security.ClassLibrary
{
    public interface ISniffingService
    {
        ICaptureStatistics CaptureStatistics { get; }
        event EventHandler OnPcapArrival;
        void StartListening();
        void StopListening();
    }
}
