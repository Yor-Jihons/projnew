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
    public class GitProcess : IGitProcess
    {
        public GitProcess()
        {
            process1 = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "git",
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

        public string Arguments{ get; set; } = "--version";

        public string DefaultBranch{ get; set; } = "main";

        public bool Start()
        {
            process1.StartInfo.Arguments = this.Arguments;

            process1.Start();
            process1.BeginErrorReadLine();
            process1.BeginOutputReadLine();
            process1.WaitForExit();

            bool isSuccess = process1.ExitCode == 0;
            process1.Dispose();
            return isSuccess;
        }

        protected readonly Process process1;
    }
}
