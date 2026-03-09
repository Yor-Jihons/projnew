using Xunit;
using ProjNew.Processors;
using System.Diagnostics.Contracts;
using System;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using ProjNew.Defintions;
using System.Linq.Expressions;
using ProjNew.CommandLines;
using ProjNew.Consoles;


namespace main.xTests;


public class CmdLine4Test4List : ICmdLine 
{
    // 解析結果を保持するプロパティ
    public ProcessTypes Command { get; }
    public string Template { get; } = "electron";
    public string ProjectName { get; } = "new-proj";
}

public class TestConsole4List : IConsole
{
    public void WriteLine( string text)
    {
        
    }
    public string ReadLine()
    {
        return "Y";
    }
}


public class ListProcessorTest
{
    [Fact]
    public void Test1()
    {
        ListProcessor listProcessor1 = new()
        {
            Console = new TestConsole4List()
        };

        TemplateConfig templateConfig1 = new()
        {
            Templates = [
                new TemplateDefinition(){
                    Id = "electron",
                    Description = "",
                }
            ]
        };

        listProcessor1.Run( new CmdLine4Test(), templateConfig1 );

        TemplateConfig templateConfig2 = new()
        {
            Templates = []
        };

        var ex1 = Assert.Throws<System.Exception>( () => listProcessor1.Run( new CmdLine4Test(), templateConfig2 ) );
        Assert.Equal( "Not found the templates.", ex1.Message );
    }
}