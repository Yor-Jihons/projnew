using System;
using System.Text;
using System.Threading;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using ProjNew.Defintions;

namespace ProjNew.Processors
{
    public static class ProcessorFactory
    {
        public static IProcessor Create( CommandLines.ProcessTypes command, IDefinitionPath definitionPath )
        {
            if( command == CommandLines.ProcessTypes.List ) return new ListProcessor();
            if( command == CommandLines.ProcessTypes.New ) return new CloneProcessor( new GitProcess() );
            if( command == CommandLines.ProcessTypes.Init ) return new InitProcessor( definitionPath, new GitProcess() );
            throw new Exception( "NOT FOUND COMMAND TYPE." );
        }
    }
}
