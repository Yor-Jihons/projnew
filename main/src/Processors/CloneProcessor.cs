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
    public class CloneProcessor : IProcessor
    {
        public void Run( CommandLines.CmdLine cmdLine, TemplateConfig templateConfig, bool isFirstStart )
        {
            /// 1. cmdline.Template が templateConfig.Templates 内にあるかどうか検索する
            /// 2. 無ければ例外を投げる
            /// 3. (1)のTemplateDefinitionを取り出す
            /// 4. gitを外部プロセス起動で呼び出す
            // 5. 初回起動時はPostCloneActionsの直前に「自己責任で使いましょう」とメッセージを出す
            // 6. Yesを選択したらPostCloneActionsの処理を外部プロセス起動で呼び出す

            var templates = templateConfig.Templates.Where( obj => string.Equals( obj.Id, cmdLine.Template ) ).ToList();
            if (templates.Count == 0)
            {
                throw new Exception( "Not found the template." ); // TODO: Implement the exception.
            }

            var template = templates[0];
            Console.WriteLine( template );

            StringBuilder argument = new( "clone " );
            argument.Append( template.SourceUrl );

            var gitProcess = new GitProcess( argument.ToString(), template.DefaultBranch );
            gitProcess.Start();

            if(isFirstStart)
            {
                // TODO: ここで「自己責任で使いましょう」系メッセージの表示して、"Yes"を選択したら次へ進む
            }





            //var st = template.
        }
    }
}
