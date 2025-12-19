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

        public string SourceUrl{ get; set; } = "https://example.com/projnew-sample-template.git";

        public string DefaultBranch{ get; set; } = "main";

        public List<FileReplacement> FileReplacements{ get; set; } =
        [
            new FileReplacement()
            {
                FileName = "README.md",
                Placeholder = "{PROJECT_NAME}",
                ReplacementValue = "{PROJECT_NAME}"
            },
            new FileReplacement()
            {
                FileName = "LICENSE",
                Placeholder = "{CURRENT_YEAR}",
                ReplacementValue = "{CURRENT_YEAR}"
            },
        ];

        public List<string> PostCloneActions{ get; set; } = [
            "npm install",
            "echo 'Setup complete. Start coding!'"
        ];
    }
}
