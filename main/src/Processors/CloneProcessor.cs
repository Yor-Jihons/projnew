using System;
using System.Text;
using System.Threading;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using ProjNew.Defintions;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace ProjNew.Processors
{
    public class CloneProcessor : IProcessor
    {
        public void Run( CommandLines.CmdLine cmdLine, TemplateConfig templateConfig )
        {
            // 1. cmdline.Template が templateConfig.Templates 内にあるかどうか検索する
            var templates = templateConfig.Templates.Where( obj => string.Equals( obj.Id, cmdLine.Template ) ).ToList();
            if (templates.Count == 0)
            {
                throw new Exception( "Not found the template." ); // TODO: Implement the exception.
            }

            // 2. (1)のTemplateDefinitionを取り出す
            var template = templates[0];

            StringBuilder argument = new( "clone " );
            argument.Append( template.SourceUrl );
            argument.Append( " " + cmdLine.ProjectName );

            // 3. gitを外部プロセス起動で呼び出す
            var gitProcess = new GitProcess( argument.ToString(), template.DefaultBranch );
            if(!gitProcess.Start())
            {
                Console.WriteLine( "Quit the process because the git-clone is failed." );
                Environment.Exit(-1);
                return;
            }

            if(template.PostCloneActions.Count == 0) return;

            // 4. PostCloneActionsの直前に「自己責任で使いましょう」とメッセージを出す
            Console.Write(CreateWarningMessage( template ) );
            var input = Console.ReadLine();
            if(!string.Equals(input,"Y", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            // TODO: Windows向けなのかMacOS/Linux向けなのかで分岐させる(v2.0.0以降)
            var fileNameBuilder = new StringBuilder();
            fileNameBuilder.Append( "cmd.exe" );
            var commandBuilder = new StringBuilder();
            commandBuilder.Append( "/c " );

            // 5. Yesを選択したらPostCloneActionsの処理を外部プロセス起動で呼び出す
            foreach(var command in template.PostCloneActions)
            {
                var argumentCommand = new StringBuilder( commandBuilder.ToString() );
                argumentCommand.Append( command );
                var process = new ExternalCommandProcess( fileNameBuilder.ToString(), argumentCommand.ToString() );
                if (!process.Start())
                {
                    Console.WriteLine( $"Quit the process because the {command} is failed." );
                    Environment.Exit(-1);
                    return;
                }
            }
        }

        public static string CreateWarningMessage( TemplateDefinition templateDefinition )
        {
            var messageBuilder = new StringBuilder();
            messageBuilder.AppendLine( "--------------------------------------------------------------------------------------------------" );
            messageBuilder.AppendLine( "[ SECURITY WARNING: EXTERNAL COMMAND EXECUTION ]" );
            messageBuilder.AppendLine( "" );
            messageBuilder.AppendLine( $"The template '{templateDefinition.Id}' you selected contains one or more setup commands in 'postCloneActions'." );
            messageBuilder.AppendLine( "These commands will be executed automatically on your system using the operating system shell (cmd/bash)." );
            messageBuilder.AppendLine( "" );
            messageBuilder.AppendLine( "Commands to be executed:" );
            int count = 0;
            foreach( var item in templateDefinition.PostCloneActions)
            {
                count++;
                messageBuilder.AppendLine( $"{count}: {item}" );
            }
            messageBuilder.AppendLine( "" );
            messageBuilder.AppendLine( "!!! PROJNEW DOES NOT VALIDATE THE CONTENT OF THESE COMMANDS. EXECUTION IS AT YOUR OWN RISK. !!!" );
            messageBuilder.AppendLine( "" );
            messageBuilder.AppendLine( "By proceeding, you agree that projnew is not responsible for any malicious or unintended behavior" );
            messageBuilder.AppendLine( "caused by these external actions." );
            messageBuilder.AppendLine( "" );
            messageBuilder.AppendLine( "Do you want to proceed with executing these post-clone actions? (Y/n)" );
            messageBuilder.AppendLine( "--------------------------------------------------------------------------------------------------" );
            return messageBuilder.ToString();
        }
    }
}
