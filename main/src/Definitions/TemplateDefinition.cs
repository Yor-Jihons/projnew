using Spectre.Console;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProjNew.Defintions
{
    public class TemplateDefinition
    {
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string Id{ get; set; } = "";

        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public string Description{ get; set; } = "";

        [System.Text.Json.Serialization.JsonPropertyName("sourceType")]
        public string SourceType{ get; set; } = "git";

        [System.Text.Json.Serialization.JsonPropertyName("sourceUrl")]
        public string SourceUrl{ get; set; } = "https://example.com/projnew-sample-template.git";


        [System.Text.Json.Serialization.JsonPropertyName("defaultBranch")]
        public string DefaultBranch{ get; set; } = "main";

        [System.Text.Json.Serialization.JsonPropertyName("fileReplacements")]
        public List<FileReplacement> FileReplacements{ get; set; } = [];

        [System.Text.Json.Serialization.JsonPropertyName("postCloneActions")]
        public List<string> PostCloneActions{ get; set; } = [];
    }
}
