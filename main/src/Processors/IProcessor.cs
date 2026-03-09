using System;
using System.Text;
using System.Threading;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using ProjNew.Defintions;

namespace ProjNew.Processors
{
    public interface IProcessor
    {
        void Run( CommandLines.ICmdLine cmdLine, TemplateConfig templateConfig );
    }
}
