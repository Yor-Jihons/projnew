using System;
using System.Text;
using System.Threading;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using ProjNew.Defintions;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace ProjNew.Consoles
{
    public interface IConsole
    {
        void WriteLine( string text );
        string ReadLine();
    }
}
