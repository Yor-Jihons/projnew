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
                //     2.1. 無ければHOMEディレクトリ直下に`.projnew`ディレクトリを作成し、リソースを読み込んで定義ファイルを生成する
                TemplateConfig.CreateDefaultDefinitionFile( "projnew.templates.json" );

                // 3. 定義ファイルのデータを読み込む

                // 4. コマンドライン引数の第一引数で指定されたコマンドによってオブジェクトを生成する

                // 5. `(4)`のオブジェクトが各処理をする
            }
            catch( Exception e )
            {
                Console.WriteLine( e );
            }

            try
            {
                string dirpath = Path.Join( Environment.GetFolderPath( Environment.SpecialFolder.UserProfile ), ".projnew" );
                string templateFilePath = Path.Join( dirpath, "projnew.tempaltes.json" );
                Console.WriteLine( templateFilePath );

                //var obj = Defintions.TemplateConfig.Load( "file1.json" );
            }
            catch( Exception e )
            {
                Console.WriteLine( e );
            }

        }
    }
}
