using System;
using System.Text;
using System.Threading;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;

namespace ProjNew.CommandLines
{
    public interface ICmdLine 
    {
        // 解析結果を保持するプロパティ
        ProcessTypes Command { get; }
        string Template { get; }
        string ProjectName { get; }
    }
}
