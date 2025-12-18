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

            try
            {
                //var obj = Defintions.TemplateConfig.Load( "file1.json" );

                var obj = new TemplateConfig()
                {
                    Templates =
                    [
                        new()
                        {
                            Id = "electron",
                            Description = "Electron + Reactのプロジェクト",
                            SourceUrl = "http://example.com/sample.git"
                        },
                        new()
                        {
                            Id = "csharp",
                            Description = "C#のプロジェクト",
                            SourceUrl = "http://example.com/sample1.git"
                        }
                    ]
                };

                TemplateConfig.Save( obj, "file1.json" );
            }
            catch( Exception e )
            {
                Console.WriteLine( e );
            }

        }
    }
}
