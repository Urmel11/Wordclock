#addin "Cake.Putty&version=1.5.1"

var target = Argument("target", "Publish");
var configuration = Argument("configuration", "Release");

var deploymentTarget = Argument("deyploymentTarget", "raspberrypi");
var deploymentPath = Argument("deyploymentPath", "/home/pi/clock");
var deyplomentUser = Argument("user", "pi");
var deyplomentPassword = Argument("password", "pi");

var projectFile = "./src/Wordclock.App/Wordclock.App.csproj";
var outputDirectory = "./artifacts";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(outputDirectory);
});

Task("Publish")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCorePublish(projectFile, new DotNetCorePublishSettings
    {
        Configuration = configuration,
		Runtime = "linux-arm64",
		PublishSingleFile=true,
		OutputDirectory=outputDirectory,
    });

});

Task("Deploy")
    .IsDependentOn("Publish")
    .Does(() =>
{
	var source = outputDirectory + "/*";
	var destination = $"{deploymentTarget}:{deploymentPath}";
	Pscp(source, destination, new PscpSettings
		{
			SshVersion = SshVersion.V2,
			User = deyplomentUser,
			Password=deyplomentPassword,
			CopyDirectoriesRecursively =true
		}
	);
});


//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);