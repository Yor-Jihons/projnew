using System;
using System.Text;
using System.Threading;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using ProjNew.Defintions;

namespace ProjNew.Processors
{
    public class ListProcessor : IProcessor
    {
        public void Run( TemplateConfig templateConfig )
        {
            Console.WriteLine( templateConfig == null ? "templateConfig is NULL" : "OK" );
            Console.WriteLine( templateConfig.Templates == null ? "templateConfig.Templates is null" : "OK" );
            Console.WriteLine( templateConfig.Templates.Count() );
            foreach(var template in templateConfig.Templates)
            {
                Console.WriteLine( $"{template.Id}: {template.Description}" ); // TODO: spectre.consoleの方を使う?
            }
        }
    }
}
