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
        public static IProcessor Create( CommandLines.ProcessTypes command )
        {
            if( command.Equals( "list" ) ) return new ListProcessor();
            if( command.Equals( "new" ) ) return new CloneProcessor();
            if( command.Equals( "-g" ) ) return new DefinitionFileGenerationProcessor();
        return null;
        }
    }
}
