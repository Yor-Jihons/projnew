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
                var cmdline = CmdLine.Create( args );
                if( cmdline == null ) return;

                // TODO: Extract this.
                var assm = Assembly.GetExecutingAssembly();
                using (var stream = assm.GetManifestResourceStream("projnew.templates.json")) {
                    var reader = new StreamReader(stream);
                    Console.WriteLine(reader.ReadToEnd());
                }

                //var obj = Defintions.TemplateConfig.Load( "file1.json" );

                var obj = new TemplateConfig()
                {
                    Templates =
                    [
                        new()
                        {
                            Id = "electron",
                            Description = "Electron + Reactのプロジェクト",
                            SourceUrl = "http://example.com/sample.git",
                            FileReplacements = [
                                new(){
                                    FileName = "README.md",
                                    Placeholder = "{PROJECT_NAME}",
                                    ReplacementValue = "{PROJECT_NAME}"
                                },
                                new(){
                                    FileName = "LICENSE",
                                    Placeholder = "{CURRENT_YEAR}",
                                    ReplacementValue = "{CURRENT_YEAR}"
                                }
                            ],
                            PostCloneActions = [
                                "npm install",
                                "echo 'Setup complete. Start coding!'"
                            ]
                        },
                        new()
                        {
                            Id = "csharp",
                            Description = "C#のプロジェクト",
                            SourceUrl = "http://example.com/sample1.git",
                            PostCloneActions = [
                                "echo 'Setup complete. Start coding!'"
                            ]
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
