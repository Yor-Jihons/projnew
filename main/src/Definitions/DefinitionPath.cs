using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Reflection;
using System.Globalization;
using System;
using System.Runtime.CompilerServices;


namespace ProjNew.Defintions
{
    public class DefinitionPath : IDefinitionPath
    {
        public DefinitionPath()
        {
            string fileName = "projnew.templates.json";
            ParentDirPath = Path.Join( Environment.GetFolderPath( Environment.SpecialFolder.UserProfile ), ".projnew" );
            FilePath = Path.Join( ParentDirPath, fileName );
        }

        public void Create()
        {
            if(!this.Exists())
            {
                // 無ければHOMEディレクトリ直下に`.projnew`ディレクトリを作成し、リソースを読み込んで定義ファイルを生成する
                this.CreateParentDirOnHome();
                TemplateConfig.CreateDefaultDefinitionFile(this.FilePath);
            }
        }

        private void CreateParentDirOnHome()
        {
            Directory.CreateDirectory( ParentDirPath );
        }

        public bool Exists()
        {
            return Path.Exists( FilePath );
        }

        public string FilePath{ get; set; }

        public string ParentDirPath{ get; set; }
    }
}
