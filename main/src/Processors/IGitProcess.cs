using System;
using System.Text;
using System.Threading;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using ProjNew.Defintions;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace ProjNew.Processors
{
    public interface IGitProcess
    {
        bool Start();
    }
}
