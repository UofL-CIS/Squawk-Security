using System;
using System.Collections.Generic;
using System.Text;
using Squawk_Security.ClassLibrary.Models;

namespace Squawk_Security.ClassLibrary
{
    public interface IReportingService
    {
        void SendAlert(string content);
        void SendAlert(string content, EvaluatedNetworkMessage evaluatedNetworkMessage);
        void SendEvaluatedNetworkMessage(EvaluatedNetworkMessage evaluatedNetworkMessage);
    }
}
