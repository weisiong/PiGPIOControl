
1. Download sshdeploy https://unosquare.github.io/sshdeploy/

2. Edit the project .csproj 
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.2</TargetFramework>
    <SshDeployHost>192.168.2.10</SshDeployHost>
    <SshDeployClean />
    <SshDeployTargetPath>/software/PiGpioControl</SshDeployTargetPath>
    <SshDeployUsername>pi</SshDeployUsername>
    <SshDeployPassword>pi2</SshDeployPassword>
    <RunPostBuildEvent>OnBuildSuccess</RunPostBuildEvent>
    <Platforms>AnyCPU</Platforms>
  </PropertyGroup>

3. Post-Build Event Add This Line
echo %DATE% %TIME% >> "$(TargetDir)sshdeploy.ready"

4. Run Command Prompt
dotnet-sshdeploy monitor -s "C:\Users\Ric-HomePC\source\repos\PiGpioControl\bin\Debug\netcoreapp2.2\linux-arm" -t "/software/PiGpioControl" -h 192.168.2.10 -u pi -w pi2 --pre "pgrep -f 'dotnet' | xargs -r kill" --post "dotnet /software/PiGpioControl/PiGpioControl.dll" --clean False


Not In use
===========
dotnet-sshdeploy run -h 192.168.2.10 -u pi -w pi2 -c "ls -ali"

dotnet publish -f netcoreapp2.2 -o C:\Users\Ric-HomePC\source\repos\PiGpioControl\bin\Debug\netcoreapp2.2\linux-arm\ -r linux-arm 

