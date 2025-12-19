using Spectre.Console;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProjNew.Defintions
{
    public class FileReplacement
    {
        public string FileName{ get; set; } = "";

        public string Placeholder{ get; set; } = "";

        public string ReplacementValue{ get; set; } = "";
    }
}
