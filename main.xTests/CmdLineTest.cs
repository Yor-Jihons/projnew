using Xunit;
using ProjNew.CommandLines;
using System.Diagnostics.Contracts;
using System;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;


namespace main.xTests;

public class CmdLineTest
{
    [Fact]
    public void Test1()
    {
        string[] arg1 = [ "new" ];
        var ex = Assert.Throws<InvalidOperationException>( () => CmdLine.Create( arg1 ) );
    }
}