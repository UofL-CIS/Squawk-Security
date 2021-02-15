using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Squawk_Security.ClassLibrary.Models;

namespace Squawk_Security.ClassLibrary
{
    public interface IPreventionService
    {
        void InvokeCountermeasures(EvaluatedNetworkMessage evaluatedNetworkMessage);
        Task InvokeCountermeasuresAsync(EvaluatedNetworkMessage evaluatedNetworkMessage);
    }
}
