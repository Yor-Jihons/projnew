using System;
using System.Text;
using System.Threading;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using ProjNew.Defintions;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace ProjNew.Processors
{
    public class GitProcess
    {
        public GitProcess( string arguments, string defualtBranch )
        {
            process1 = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "git",
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                }
            };
            process1.OutputDataReceived += (sender, ev) => {
                Console.WriteLine( ev.Data );
            };
            process1.ErrorDataReceived += (sender, ev) =>
            {
                Console.WriteLine( ev.Data );
            };
        }

        public void Start()
        {
            process1.Start();
            process1.BeginErrorReadLine();
            process1.BeginOutputReadLine();
            process1.WaitForExit();
        }

        private readonly Process process1;
    }
}
