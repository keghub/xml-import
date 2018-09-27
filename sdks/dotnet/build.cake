#addin "Cake.ExtendedNuGet"
#addin "nuget:?package=NuGet.Core"
#tool "nuget:?package=JetBrains.dotCover.CommandLineTools"

var target = Argument("Target", "Test");

FilePath SolutionFile = MakeAbsolute(File("EMG.XML.sln"));

var testFolder = SolutionFile.GetDirectory().Combine("tests");
var outputFolder = SolutionFile.GetDirectory().Combine("outputs");
var testOutputFolder = outputFolder.Combine("tests");
var coverageOutputFile = testOutputFolder.CombineWithFilePath("coverage.dcvr");
var dotCoverFolder = MakeAbsolute(Context.Tools.Resolve("dotcover.exe").GetDirect‌​ory());

Setup(context => 
{
    CleanDirectory(outputFolder);
});

Task("Restore")
    .Does(() =>
{
    DotNetCoreRestore(SolutionFile.FullPath);
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = "Debug"
    };

    DotNetCoreBuild(SolutionFile.FullPath, settings);
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() => 
{
    Information("Skipped for lack of tests");
});

Task("Pack")
    .IsDependentOn("Test")
    .Does(() =>
{
    var packSettings = new DotNetCorePackSettings 
    {
        Configuration = "Release",
        OutputDirectory = outputFolder
    };

    DotNetCorePack(SolutionFile.FullPath, packSettings);
});

Task("Push")
    .IsDependentOn("Pack")
    .Does(() =>
{
    var apiKey = EnvironmentVariable("NuGetApiKey");

    var settings = new DotNetCoreNuGetPushSettings
    {
        Source = "https://api.nuget.org/v3/index.json",
        ApiKey = apiKey
    };

    var files = GetFiles($"{outputFolder}/*.nupkg");

    foreach (var file in files)
    {
        var fileName = file.GetFilename();

        try
        {
            Information($"Pushing {fileName}");

            DotNetCoreNuGetPush(file.FullPath, settings);
            Information($"{fileName} pushed!");
        }
        catch (CakeException)
        {
            Warning($"{fileName} already published, removing from artifacts");
            DeleteFile(file);
        }
    }
});

RunTarget(target);