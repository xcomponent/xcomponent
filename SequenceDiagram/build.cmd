@echo off

set /p xcversion=<../Examples/xcversion.txt

pushd %~dp0

..\Examples\Tools\NuGet.exe update -self

..\Examples\Tools\NuGet.exe install FAKE -ConfigFile ..\Examples\Tools\Nuget.Config -ExcludeVersion -OutputDirectory ..\\Examples\packages -Version 4.10.3
..\Examples\Tools\NuGet.exe install XComponent.Community -ConfigFile ..\Examples\Tools\Nuget.Config -ExcludeVersion -OutputDirectory ..\Examples\packages -Version %xcversion%

set encoding=utf-8
..\Examples\packages\FAKE\tools\FAKE.exe build.fsx All

popd