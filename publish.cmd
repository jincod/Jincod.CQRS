nuget.exe pack src\Jincod.CQRS\Jincod.CQRS.csproj -Prop Configuration=Release
nuget push Jincod.CQRS.1.0.0.0.nupkg %API_KEY%