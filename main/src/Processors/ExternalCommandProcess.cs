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
    public class ExternalCommandProcess : IExternalCommandProcess
    {
        public void Build()
        {
            process1 = new Process
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = this.FileName,
                    Arguments = this.Argument,
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

        public bool Start()
        {
            process1.Start();
            process1.BeginErrorReadLine();
            process1.BeginOutputReadLine();
            process1.WaitForExit();

            bool isSuccess = process1.ExitCode == 0;
            process1.Dispose();
            return isSuccess;
        }

        private Process process1;

        public string FileName{ get; set; }
        public string Argument{ get; set; }
    }
}
