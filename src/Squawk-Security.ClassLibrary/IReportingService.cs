using System;
using System.Collections.Generic;
using System.Text;
using Squawk_Security.ClassLibrary.Models;

namespace Squawk_Security.ClassLibrary
{
    public interface IReportingService
    {
        void SendEmail(string content);
        void SendEvaluatedNetworkMessage(EvaluatedNetworkMessage evaluatedNetworkMessage);
    }
}
