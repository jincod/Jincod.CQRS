var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var outputDir = "./artifacts/";
var solutionPath = System.IO.Directory.GetFiles(".", "*.sln", SearchOption.AllDirectories).First();

Task("Clean")
    .Does(() => {
        if (DirectoryExists(outputDir))
        {
            DeleteDirectory(outputDir, recursive:true);
        }
        CreateDirectory(outputDir);
    });

Task("Restore")
    .Does(() => {
        DotNetCoreRestore(solutionPath);
    });

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .Does(() => {
        var settings =  new DotNetCoreBuildSettings
        {
            Configuration = configuration
        };
        DotNetCoreBuild(solutionPath, settings);
    });

Task("Pack")
    .IsDependentOn("Clean")
    .Does(() => {
        var settings = new DotNetCorePackSettings
        {
            Configuration = configuration,
            OutputDirectory = outputDir
        };

        DotNetCorePack("./src/Jincod.CQRS/Jincod.CQRS.csproj", settings);
    });

Task("Publish")
    .IsDependentOn("Pack")
    .Does(() => {
        var package = System.IO.Directory.GetFiles(outputDir, "*.nupkg", SearchOption.AllDirectories).First();

        var settings = new NuGetPushSettings
        {
            Source = "https://www.nuget.org/api/v2/package",
            ApiKey = EnvironmentVariable("API_KEY")
        };
        NuGetPush(package, settings);
    });

Task("Default")
    .IsDependentOn("Build");

RunTarget(target);