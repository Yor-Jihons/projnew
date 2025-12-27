using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Reflection;
using System.Globalization;

namespace ProjNew.Defintions
{
    public class TemplateConfig
    {
        public static TemplateConfig Load( string filePath )
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<TemplateConfig>(jsonString);
        }

        public static void CreateDefaultDefinitionFile( string filePath )
        {
            var assm = Assembly.GetExecutingAssembly();
            using var stream = assm.GetManifestResourceStream("projnew.templates.json");
            var reader = new StreamReader(stream);
            File.WriteAllText(filePath, reader.ReadToEnd());
        }

        public static void Save( TemplateConfig template, string filePath )
        {
            string newJsonString = JsonSerializer.Serialize(template, new JsonSerializerOptions
            {
                WriteIndented = true, // 読みやすくするためのオプション
            });
            File.WriteAllText( filePath, newJsonString );
        }

        [System.Text.Json.Serialization.JsonPropertyName("templates")]
        public List<TemplateDefinition> Templates{ get; set; }
    }
}
