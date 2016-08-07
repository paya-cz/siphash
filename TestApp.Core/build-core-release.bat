REM https://docs.microsoft.com/en-us/dotnet/articles/core/app-types
REM https://docs.microsoft.com/en-us/dotnet/articles/core/tools/dotnet-publish

dotnet publish -c Release -r win7-x64
dotnet publish -c Release -r win7-x86
dotnet build -c Release -r win7-x64
dotnet build -c Release -r win7-x86