using System;
using System.Text;
using System.Threading;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using ProjNew.Defintions;

namespace ProjNew.Processors
{
    public class CloneProcessor : IProcessor
    {
        public void Run( CommandLines.CmdLine cmdLine, TemplateConfig templateConfig )
        {
            // 1. cmdline.Template が templateConfig.Templates 内にあるかどうか検索する
            // 2. 無ければ例外を投げる
            // 3. (1)のTemplateDefinitionを取り出す
            // 4. gitを外部プロセス起動で呼び出す
            // 5. 初回起動時はPostCloneActionsの直前に「自己責任で使いましょう」とメッセージを出す
            // 6. Yesを選択したらPostCloneActionsの処理を外部プロセス起動で呼び出す

            var templates = templateConfig.Templates.Where( obj => string.Equals( obj.Id, cmdLine.Template ) ).ToList();
            if (templates.Count == 0)
            {
                throw new Exception( "Not found the template." ); // TODO: Implement the exception.
            }

            Console.WriteLine( templates[0] );
        }
    }
}
