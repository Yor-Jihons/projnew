using System;
using System.Text;
using System.Threading;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using ProjNew.Defintions;

namespace ProjNew.Processors
{
    public class DefinitionFileGenerationProcessor(DefinitionPath definitionPath) : IProcessor
    {
        public void Run( CommandLines.CmdLine cmdLine, TemplateConfig templateConfig, bool isFirstStart )
        {
            if(!DefinitionPath.Exists())
            {
                // 無ければHOMEディレクトリ直下に`.projnew`ディレクトリを作成し、リソースを読み込んで定義ファイルを生成する
                DefinitionPath.CreateParentDirOnHome();
                TemplateConfig.CreateDefaultDefinitionFile(DefinitionPath.FilePath);
            }
        }

        private DefinitionPath DefinitionPath { get; set; } = definitionPath;
    }
}
