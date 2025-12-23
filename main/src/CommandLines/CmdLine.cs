using System;
using System.Text;
using System.Threading;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;

namespace ProjNew.CommandLines
{
    public class CmdLine
    {
        // 解析結果を保持するプロパティ
        public string Command { get; private set; }
        public string Template { get; private set; }
        public string ProjectName { get; private set; }

        public static CmdLine Create( string[] args )
        {
            var instance = new CmdLine();

            // 1. オプションと引数の定義
            var nameOption = new Option<string>("--name", "Project-name.");
            nameOption.Aliases.Add( "-n" );

            var templateArgument = new Argument<string>("template")
            {
                Description = "Template-Name（例: electron）"
            };

            // 2. コマンド（サブコマンド）の定義
            var newCommand = new Command("new", "Creates a new project.")
            {
                templateArgument,
                nameOption
            };

            var listCommand = new Command("list", "Lists available templates.");

            // 3. ルートコマンドの構築
            var rootCommand = new RootCommand("projnew - The tool which creates the new-project from GitHub.")
            {
                newCommand,
                listCommand
            };

            // 4. 解析
            var parseResult = rootCommand.Parse(args);

            // 5. 値の抽出（GetValueForOption / GetValueForArgument を型指定で呼ぶ）
            // ※ 拡張メソッドではなく、ParseResultのメンバメソッドとして呼び出します
            var commandResult = parseResult.CommandResult;

            // 実行されたコマンド名を判定
            if (commandResult.Command.Name == "new")
            {
                instance.Command = "new";
                // 型を明示的に指定して値を取得します
                instance.Template = parseResult.GetValue<string>( templateArgument );
                instance.ProjectName = parseResult.GetValue<string>(nameOption);
            }
            else if (commandResult.Command.Name == "list")
            {
                instance.Command = "list";
            }

            // 4. ヘルプなどの自動表示
            if (args.Contains("--help") || args.Contains("-h") || args.Contains("--version"))
            {
                parseResult.Invoke();
                return null;
            }

            return instance;
        }
    }
}
