using System;
using System.Text;
using System.Threading;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using ProjNew.Defintions;
using System.Diagnostics;

namespace ProjNew.Processors
{
    public class InitProcessor(IDefinitionPath definitionPath, IGitProcess gitProcess) : IProcessor
    {
        public void Run( CommandLines.CmdLine cmdLine, TemplateConfig templateConfig )
        {
            // `git --version`を試して、gitがインストールされているか確認する
            if(!_gitProcess1.Start())
            {
                throw new Exception( "Quit the process because the git-clone is failed." );
            }

            DefinitionPath.Create();

            var si = new ProcessStartInfo()
            {
                FileName = DefinitionPath.FilePath,
                UseShellExecute = true,
                CreateNoWindow = true
            };
            Process.Start(si);
        }

        private IDefinitionPath DefinitionPath { get; set; } = definitionPath;

        private readonly IGitProcess _gitProcess1 = gitProcess;
    }
}
