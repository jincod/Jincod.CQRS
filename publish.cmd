dotnet pack src\Jincod.CQRS\Jincod.CQRS.csproj --configuration Release --output %CD%
dotnet nuget push Jincod.CQRS.2.0.0.0.nupkg %API_KEY%