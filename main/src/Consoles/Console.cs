namespace ProjNew.Consoles
{
    public class Console : IConsole
    {
        public void WriteLine( string text)
        {
            System.Console.WriteLine( text );
        }

        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}
