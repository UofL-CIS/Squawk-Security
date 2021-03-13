using System;
using System.Linq;
using System.Threading.Tasks;
using PacketDotNet;
using SharpPcap;
using Squawk_Security.ClassLibrary.Static;

namespace Squawk_Security.ClassLibrary.Services
{
    public class DeAuthenticationPreventionService : IPreventionService
    {
        public DeAuthenticationPreventionService()
        {
            
        }

        public void InvokeCountermeasures(RawCapture capture)
        {
#if DEBUG
            return;
#endif
            throw new NotImplementedException();

            var payloads = capture.ExtractPayloadsFromRawCapture();

            var tcpPacket = payloads.FirstOrDefault(p => p is TcpPacket) as TcpPacket;
            tcpPacket.Finished = true;
        }

        public Task InvokeCountermeasuresAsync(RawCapture capture)
            => Task.Run(() => InvokeCountermeasures(capture));
    }
}
