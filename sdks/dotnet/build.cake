#addin "Cake.ExtendedNuGet"
#addin "nuget:?package=NuGet.Core"

var target = Argument("Target", "Test");

FilePath SolutionFile = MakeAbsolute(File("EMG.XML.sln"));

var testFolder = SolutionFile.GetDirectory().Combine("tests");
var outputFolder = SolutionFile.GetDirectory().Combine("outputs");
var testOutputFolder = outputFolder.Combine("tests");

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
    Information($"Looking for test projects in {testFolder.FullPath}");

    var testProjects = GetFiles($"{testFolder}/**/*.csproj").Where(p => !p.FullPath.Contains("Helper"));

    foreach (var project in testProjects)
    {
        Information($"Testing {project.FullPath}");

        var testResultFile = testOutputFolder.CombineWithFilePath(project.GetFilenameWithoutExtension() + ".trx");
        
        Verbose($"Saving test results on {testResultFile.FullPath}");

        var settings = new DotNetCoreTestSettings
        {
            NoBuild = true,
            NoRestore = true,
            Logger = $"trx;LogFileName={testResultFile.FullPath}"
        };

        DotNetCoreTest(project.FullPath, settings);

        if (BuildSystem.IsRunningOnTeamCity)
        {
            TeamCity.ImportData("mstest", testResultFile);
        }
    }
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
    .WithCriteria(!BuildSystem.IsLocalBuild, "This step can only be executed when on a build server")
    .WithCriteria(!IsBuildPersonal(), "This step cannot be executed on personal builds")
    .WithCriteria(IsMaster(), "This step can only be executed when on the master branch")
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

Task("CI")
    .IsDependentOn("Push");

bool IsBuildPersonal() => bool.TryParse(EnvironmentVariable("BUILD_IS_PERSONAL"), out bool res) && res;

bool IsMaster() => EnvironmentVariable("Git_Branch") == @"refs/heads/master";

RunTarget(target);
