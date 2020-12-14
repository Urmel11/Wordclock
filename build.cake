#addin "Cake.Putty&version=1.5.1"

var target = Argument("target", "Publish");
var configuration = Argument("configuration", "Release");

var deploymentTarget = Argument("deyploymentTarget", "raspberrypi");
var deploymentPath = Argument("deyploymentPath", "/home/pi/test");
var deyplomentUser = Argument("user", "pi");
var deyplomentPassword = Argument("password", "raspberry");

var projectFile = "./src/Wordclock/Wordclock.csproj";
var outputDirectory = "./output";

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
		Runtime = "linux-arm",
		PublishSingleFile=true,
		OutputDirectory=outputDirectory,
    });
});

Task("Deploy")
    .IsDependentOn("Publish")
    .Does(() =>
{
	var files = GetFiles(outputDirectory + "/*").Select(m => m.ToString()).ToArray();
	
	var destination = $"{deploymentTarget}:{deploymentPath}";
	Pscp(files, destination, new PscpSettings
		{
			SshVersion = SshVersion.V2,
			User = deyplomentUser,
			Password=deyplomentPassword
		}
	);
});


//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);