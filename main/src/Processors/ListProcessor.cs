using System;
using System.Text;
using System.Threading;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using ProjNew.Defintions;
using System.Data.Common;

namespace ProjNew.Processors
{
    public class ListProcessor : IProcessor
    {
        public void Run( CommandLines.CmdLine cmdLine, TemplateConfig templateConfig )
        {
            if(templateConfig.Templates.Count == 0)
            {
                throw new Exception( "Not found the templates." );
            }

            Console.WriteLine( "" );
            Console.WriteLine( "[Available Templates]" );
            foreach(var template in templateConfig.Templates)
            {
                Console.WriteLine( $"{template.Id}: {template.Description}" );
            }
            Console.WriteLine( "" );
        }
    }
}
