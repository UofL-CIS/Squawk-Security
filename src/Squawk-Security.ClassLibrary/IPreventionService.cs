using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;
using Squawk_Security.ClassLibrary.Models;

namespace Squawk_Security.ClassLibrary
{
    public interface IPreventionService
    {
        void InvokeCountermeasures(RawCapture capture);
        Task InvokeCountermeasuresAsync(RawCapture capture);
    }
}
