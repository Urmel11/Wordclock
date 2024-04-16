#addin "Cake.Putty&version=1.5.1"

var target = Argument("target", "Publish");
var configuration = Argument("configuration", "Release");

var deploymentTarget = Argument("deyploymentTarget", "raspberrypi");
var deploymentPath = Argument("deyploymentPath", "/home/raspberry/clock");
var deyplomentUser = Argument("user", "raspberry");
var deyplomentPassword = Argument("password", "pi");

var projectFile = "./src/Wordclock.Ui.Web/Wordclock.Ui.Web.csproj";
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
    DotNetPublish(projectFile, new DotNetPublishSettings
    {
        Configuration = configuration,
		Runtime = "linux-arm64",
		SelfContained = true,
		PublishSingleFile = true,
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