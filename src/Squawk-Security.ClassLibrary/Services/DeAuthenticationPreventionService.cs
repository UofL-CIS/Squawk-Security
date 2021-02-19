using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Squawk_Security.ClassLibrary.Models;

namespace Squawk_Security.ClassLibrary.Services
{
    public class DeAuthenticationPreventionService : IPreventionService
    {
        public DeAuthenticationPreventionService()
        {
            
        }

        public void InvokeCountermeasures(EvaluatedNetworkMessage evaluatedNetworkMessage)
        {
            #if DEBUG
            return;
            #endif
            
            throw new NotImplementedException();
        }

        public Task InvokeCountermeasuresAsync(EvaluatedNetworkMessage evaluatedNetworkMessage)
            => Task.Run(() => InvokeCountermeasures(evaluatedNetworkMessage));
    }
}
