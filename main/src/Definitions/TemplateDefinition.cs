using Spectre.Console;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProjNew.Defintions
{
    public class TemplateDefinition
    {
        public string Id{ get; set; } = "";

        public string Description{ get; set; } = "";

        public string SourceType{ get; set; } = "git";

        public string SourceUrl{ get; set; } = "";
    }
}
