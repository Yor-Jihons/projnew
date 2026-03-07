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
    public class InitProcessor(IDefinitionPath definitionPath) : IProcessor
    {
        public void Run( CommandLines.CmdLine cmdLine, TemplateConfig templateConfig )
        {
            // `git --version`を試して、gitがインストールされているか確認する
            var gitProcess = new GitProcess( "--version" );
            gitProcess.Start();

            if(!DefinitionPath.Exists())
            {
                // 無ければHOMEディレクトリ直下に`.projnew`ディレクトリを作成し、リソースを読み込んで定義ファイルを生成する
                DefinitionPath.CreateParentDirOnHome();
                TemplateConfig.CreateDefaultDefinitionFile(DefinitionPath.FilePath);
            }

            var si = new ProcessStartInfo()
            {
                FileName = DefinitionPath.FilePath,
                UseShellExecute = true,
                CreateNoWindow = true
            };
            Process.Start(si);
        }

        private IDefinitionPath DefinitionPath { get; set; } = definitionPath;
    }
}
