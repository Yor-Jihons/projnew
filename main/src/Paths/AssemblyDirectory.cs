namespace ProjNew.Paths
{
    /// <summary>
    /// The class which manages the assembly-dir.
    /// </summary>
    public class AssemblyDirectory
    {
        /// <summary>
        /// The class which manages the assembly-dir.
        /// </summary>
        public AssemblyDirectory()
        {
            this.ThisDirPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location );
        }

        /// <summary>
        /// Enumerates the md-files which this assembly manages.
        /// </summary>
        /// <returns>The file paths which this assembly manages.</returns>
        public System.Collections.Generic.IEnumerable<string> EnumMarkdownFiles()
        {
            return System.IO.Directory.EnumerateFiles( this.ThisDirPath, "*.md", System.IO.SearchOption.AllDirectories );
        }

        /// <value>The path of the directory which include this assembly.</value>
        private string ThisDirPath{ get; set; }
    }
}
