using System;

namespace Squawk_Security.ClassLibrary.Models.Exceptions
{
    public class NoCaptureDevicesAvailableException : Exception
    {
        public NoCaptureDevicesAvailableException(string message = "No capture devices were available") : base(message) { }
        public NoCaptureDevicesAvailableException(string message, Exception innerException) : base(message, innerException) { }
    }
}
