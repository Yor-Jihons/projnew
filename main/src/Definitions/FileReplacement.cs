using Spectre.Console;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProjNew.Defintions
{
    public class FileReplacement
    {
        [System.Text.Json.Serialization.JsonPropertyName("fileName")]
        public string FileName{ get; set; } = "";

        [System.Text.Json.Serialization.JsonPropertyName("placeholder")]
        public string Placeholder{ get; set; } = "";

        [System.Text.Json.Serialization.JsonPropertyName("replacementValue")]
        public string ReplacementValue{ get; set; } = "";
    }
}
