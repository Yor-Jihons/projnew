using Xunit;
using ProjNew.Processors;
using System.Diagnostics.Contracts;
using System;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using ProjNew.Defintions;
using System.Linq.Expressions;


namespace main.xTests;

public class CloneProcessorTest
{
    [Fact]
    public void Test1()
    {
        var template1 = new TemplateDefinition()
        {
            Id = "csharp",
            PostCloneActions =
            [
                "dotnet restore",
                "echo SUCCEEDED!"
            ]
        };
        var actual1 = CloneProcessor.CreateWarningMessage( template1 );
        string expected1 = "--------------------------------------------------------------------------------------------------\r\n";
        expected1 += "[ SECURITY WARNING: EXTERNAL COMMAND EXECUTION ]\r\n\r\n";
        expected1 += $"The template '{template1.Id}' you selected contains one or more setup commands in 'postCloneActions'.\r\n";
        expected1 += "These commands will be executed automatically on your system using the operating system shell (cmd/bash).\r\n\r\n";
        expected1 += "Commands to be executed:\r\n";
        expected1 += "1: dotnet restore\r\n2: echo SUCCEEDED!\r\n\r\n";
        expected1 += "!!! PROJNEW DOES NOT VALIDATE THE CONTENT OF THESE COMMANDS. EXECUTION IS AT YOUR OWN RISK. !!!\r\n\r\n";
        expected1 += "By proceeding, you agree that projnew is not responsible for any malicious or unintended behavior\r\ncaused by these external actions.\r\n\r\n";
        expected1 += "Do you want to proceed with executing these post-clone actions? (Y/n)\r\n";
        expected1 += "--------------------------------------------------------------------------------------------------\r\n";
        Assert.Equal( expected1, actual1 );
    }

    [Fact]
    public void Test2()
    {
        var template1 = new TemplateDefinition()
        {
            Id = "electron",
            PostCloneActions =
            [
                "npm install",
                "del *.jpg",
                "echo SUCCEEDED!"
            ]
        };
        var actual1 = CloneProcessor.CreateWarningMessage( template1 );
        string expected1 = "--------------------------------------------------------------------------------------------------\r\n";
        expected1 += "[ SECURITY WARNING: EXTERNAL COMMAND EXECUTION ]\r\n\r\n";
        expected1 += $"The template '{template1.Id}' you selected contains one or more setup commands in 'postCloneActions'.\r\n";
        expected1 += "These commands will be executed automatically on your system using the operating system shell (cmd/bash).\r\n\r\n";
        expected1 += "Commands to be executed:\r\n";
        expected1 += "1: npm install\r\n2: del *.jpg\r\n3: echo SUCCEEDED!\r\n\r\n";
        expected1 += "!!! PROJNEW DOES NOT VALIDATE THE CONTENT OF THESE COMMANDS. EXECUTION IS AT YOUR OWN RISK. !!!\r\n\r\n";
        expected1 += "By proceeding, you agree that projnew is not responsible for any malicious or unintended behavior\r\ncaused by these external actions.\r\n\r\n";
        expected1 += "Do you want to proceed with executing these post-clone actions? (Y/n)\r\n";
        expected1 += "--------------------------------------------------------------------------------------------------\r\n";
        Assert.Equal( expected1, actual1 );
    }
}