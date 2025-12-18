using Spectre.Console;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProjNew.Defintions
{
    public class TemplateConfig
    {
        public static TemplateConfig Load( string filePath )
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<TemplateConfig>(jsonString);
        }

        public static void Save( TemplateConfig template, string filePath )
        {
            string newJsonString = JsonSerializer.Serialize(template, new JsonSerializerOptions
            {
                WriteIndented = true, // 読みやすくするためのオプション
            });
            File.WriteAllText( filePath, newJsonString );
        }

        public List<TemplateDefinition> Templates{ get; set; }
    }
}
