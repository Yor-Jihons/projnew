using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Reflection;
using System.Globalization;
using System;
using System.Runtime.CompilerServices;


namespace ProjNew.Defintions
{
    public interface IDefinitionPath
    {
        void CreateParentDirOnHome();

        bool Exists();

        string FilePath{ get; set; }

        string ParentDirPath{ get; set; }
    }
}
