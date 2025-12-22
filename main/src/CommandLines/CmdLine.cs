using System;
using System.Text;
using System.Threading;
using System.CommandLine;

namespace ProjNew.CommandLines
{
    public class CmdLine
    {
        public static CmdLine Create( string[] args )
        {
            return null;
        }

        public CommandLines.ProcessTypes ProcessTypes{ get; private set; }

        /// <summary>
        /// Creates the help text.
        /// </summary>
        /// <returns>The help text.</returns>
        private static string CreateHelpString()
        {
            string url = @"https://yorroom2.cloudfree.jp/help/en/dotnetversioner.html";
            var builder = new StringBuilder();
            builder.AppendLine( "[CMD]" );
            builder.AppendLine( "$ DotnetVersioner --info" );
            builder.AppendLine( "$ DotnetVersioner --list-sdks" );
            builder.AppendLine( "$ DotnetVersioner -g [--definition=<FILEPATH>] [--TargetFramework=<VERSION>]" );
            builder.AppendLine( "$ DotnetVersioner [--definition=<FILEPATH>] [--TargetFramework=<VERSION>]" );
            builder.AppendLine( "$ DotnetVersioner --help" );
            builder.AppendLine();
            builder.AppendLine( "[ARGUMENTS]" );
            builder.AppendLine( "  --info:" );
            builder.AppendLine( "    Show the info as \"dotnet --info\"." );
            builder.AppendLine( "    (shortened: -i)" );
            builder.AppendLine( "  --list-sdks:" );
            builder.AppendLine( "    Show the info as \"dotnet --list-sdks\"." );
            builder.AppendLine( "    (shortened: -l)" );
            builder.AppendLine( "  -g:" );
            builder.AppendLine( "    Create the xml file as definition file." );
            builder.AppendLine( "  --definition=<FILEPATH>:" );
            builder.AppendLine( "    Pass the xml file as the definition file." );
            builder.AppendLine( "    (shortened: -d=<FILEPATH>)" );
            builder.AppendLine( "  --TargetFramework=<VERSION>:" );
            builder.AppendLine( "    Pass the target framewrok." );
            builder.AppendLine( "    (shortened: -t=<VERSION>)" );
            builder.AppendLine( "  --help:" );
            builder.AppendLine( "    Show this help." );
            builder.AppendLine( "    (shortened: -h)" );
            builder.AppendLine();
            builder.AppendLine( $"See also {url}." );
        return builder.ToString();
        }

        /// <summary>
        /// Create a string which deleted "...=" from "...=<***>".
        /// </summary>
        /// <param name="str">A string</param>
        /// <returns>A string which deleted "...=" from "...=<***>".</returns>
        private static string SubStringEx( string str )
        {
            int beginPos = str.IndexOf( "=" );
            beginPos++;
            string res = str[beginPos..];
        return res;
        }
    }
}
