Installation Guide

1) Required tools
First all required tools need to be installed.
To do this, execut the commands listed in the file "installTools"

2) Prerequirements for the Wordclock App
Execute the commands listed in the file "installWordclock".
A separate folder will be created which contains the assemblies.
Futhermore a cronjob is created which starts the Wordclock App after a reboot.

3) Copy Wordclock App
You need to build the complete solution first.
The file "copyWordclock.bat" copies the required assemblies to the new folder
which was created in step 2.

4) Make start.sh executable
The cronjob will execute the file "start.sh".
Therefore this file must be marked with the executable flag.
To achieve this, execute the command "sudo chmod +x start.sh"