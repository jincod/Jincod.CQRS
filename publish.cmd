dotnet pack src\Jincod.CQRS\Jincod.CQRS.csproj --configuration Release --output %CD%
dotnet nuget push Jincod.CQRS.2.0.0.nupkg -k %API_KEY% -s https://www.nuget.org/api/v2/package