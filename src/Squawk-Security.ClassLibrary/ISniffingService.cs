using System;

namespace Squawk_Security.ClassLibrary
{
    public interface ISniffingService
    {
        event EventHandler OnPcapArrival;
        void StartListening();
        void StopListening();
    }
}
