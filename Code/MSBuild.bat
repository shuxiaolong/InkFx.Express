%windir%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe "InkFx.Express.sln" /t:Rebuild /p:Configuration=Debug /p:Platform="Any CPU"


E:\ShuXiaolong\InkFx\Tools\InkFx.Confuse\Bin\InkFx.Confuse.exe -d "Bin\InkFx.Express.dll"
E:\ShuXiaolong\InkFx\Tools\InkFx.Confuse\Bin\InkFx.Confuse.exe -d "Bin\InkFx.Express.Test.exe"

pause