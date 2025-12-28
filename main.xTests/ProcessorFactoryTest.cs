using Xunit;
using ProjNew.Processors;
using System.Diagnostics.Contracts;
using System;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;


namespace main.xTests;

class DummyDefinitionPath : ProjNew.Defintions.IDefinitionPath
{
    public void CreateParentDirOnHome()
    {
        // DUMMY
    }

    public bool Exists()
    {
        return true;
    }

    public string FileName{ get; set; } = "";
    public string FilePath{ get; set; } = "";

    public string ParentDirPath{ get; set; } = "";
}

public class ProcessorFactoryTest
{
    [Fact]
    public void Test1()
    {
        var dummyData = new DummyDefinitionPath();

        var process1 = ProcessorFactory.Create( ProjNew.CommandLines.ProcessTypes.New, dummyData );
        Assert.IsType<CloneProcessor>( process1 );

        var process2 = ProcessorFactory.Create( ProjNew.CommandLines.ProcessTypes.List, dummyData );
        Assert.IsType<ListProcessor>( process2 );

        var process3 = ProcessorFactory.Create( ProjNew.CommandLines.ProcessTypes.DefinitionFileGeneration, dummyData );
        Assert.IsType<DefinitionFileGenerationProcessor>( process3 );

        var ex = Assert.Throws<Exception>( () => ProcessorFactory.Create( ProjNew.CommandLines.ProcessTypes.Unknown, dummyData ) );
        Assert.Equal( "NOT FOUND COMMAND TYPE.", ex.Message );
    }
}