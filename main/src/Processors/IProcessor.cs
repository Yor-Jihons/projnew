using System;
using System.Text;
using System.Threading;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;

namespace ProjNew.Processors
{
    public interface IProcessor
    {
        void Run();
    }
}
