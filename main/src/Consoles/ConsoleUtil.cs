using Spectre.Console;
using System.Collections.Generic;

namespace ProjNew.Consoles
{
    public static class ConsoleUtil
    {
        public static string AskWithChoices(string question, List<string> choices)
        {
            var prompt = new SelectionPrompt<string>()
                .Title($"[green]{question}[/]")
                .PageSize(10)
                .MoreChoicesText("[grey](Use arrow keys to navigate, Enter to select)[/]");
            prompt.AddChoices(choices);
            return AnsiConsole.Prompt(prompt);
        }

        public static string AskText(string question)
        {
            return AnsiConsole.Ask<string>(question);
        }
    }
}
