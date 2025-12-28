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
            if( command == CommandLines.ProcessTypes.New ) return new CloneProcessor();
            if( command == CommandLines.ProcessTypes.DefinitionFileGeneration ) return new DefinitionFileGenerationProcessor( definitionPath );
            throw new Exception( "NOT FOUND COMMAND TYPE." );
        }
    }
}
