using System;
using ProjNew.CommandLines;
using System.Linq;
using Spectre.Console;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ProjNew.Consoles;
using System.CommandLine;
using ProjNew.Defintions;
using System.IO;
using System.Reflection;
using System.Globalization;
using ProjNew.Processors;

namespace ProjNew
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var name = ConsoleUtil.AskText("Name? :");
            Console.WriteLine("NAME = " + name);

            var langList = new List<string>() { "C++", "C#", "TypeScript", "PHP" };
            var lang = ConsoleUtil.AskWithChoices("The language you like :", langList);
            Console.WriteLine(lang);

            var ret = ConsoleUtil.AskWithChoices("Your name is {name}, your favorite language is {lang}, right?", ["Yes", "No"] );
            Console.WriteLine($"You chooce {ret}.");
            */

            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            try
            {
                // 1. コマンドライン引数の解析
                var cmdline = CmdLine.Create( args );
                if( cmdline == null ) return;

                // 2. 定義ファイルの場所を取得する
                var defFile = new DefinitionPath();
                bool isFirstStart = !defFile.Exists();
                if(isFirstStart)
                {
                    // 2.1. 無ければHOMEディレクトリ直下に`.projnew`ディレクトリを作成し、リソースを読み込んで定義ファイルを生成する
                    defFile.CreateParentDirOnHome();
                    TemplateConfig.CreateDefaultDefinitionFile(defFile.FilePath);
                }

                // 3. 定義ファイルのデータを読み込む
                TemplateConfig templateConfig = null;
                if(cmdline.Command != ProcessTypes.DefinitionFileGeneration)
                {
                    templateConfig = TemplateConfig.Load(defFile.FilePath);
                }

                // 4. コマンドライン引数の第一引数で指定されたコマンドによってオブジェクトを生成する
                var processor = ProcessorFactory.Create( cmdline.Command, defFile );

                // 5. `(4)`のオブジェクトが各処理をする
                processor.Run( cmdline, templateConfig, isFirstStart );
            }
            catch( Exception e )
            {
                Console.WriteLine( e.Message );
            }
        }
    }
}
