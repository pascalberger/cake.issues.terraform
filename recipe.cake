#load nuget:?package=Cake.Recipe&version=2.2.0

Environment.SetVariableNames();

BuildParameters.SetParameters(
    context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./src",
    title: "Cake.Issues.Terraform",
    repositoryOwner: "cake-contrib",
    repositoryName: "Cake.Issues.Terraform",
    appVeyorAccountName: "cakecontrib",
    shouldGenerateDocumentation: false);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(
    context: Context,
    dupFinderExcludePattern: new string[]
        {
            BuildParameters.RootDirectoryPath + "/src/Cake.Issues.Terraform.Tests/*.cs",
            BuildParameters.RootDirectoryPath + "/src/Cake.Issues.Terraform*/**/*.AssemblyInfo.cs"
        },
    testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* -[Cake.Issues]* -[Cake.Issues.Testing]* -[Shouldly]* -[DiffEngine]* -[EmptyFiles]*",
    testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
    testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");

Build.RunDotNetCore();
