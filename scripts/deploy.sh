#!/usr/bin/env bash

set -e

project_file=src/Jincod.CQRS/Jincod.CQRS.csproj
project_name=$(basename $project_file .csproj)

package_version=$(cat $project_file | grep -oP '<PackageVersion>(.*)<\/PackageVersion>' | sed "s/<PackageVersion>\|<\/PackageVersion>//g")
status_code=$(curl -s -o /dev/null -I -w "%{http_code}" https://api.nuget.org/v3/registration3/${project_name,,}/$package_version.json)

if [ $status_code = 200 ]; then
    echo "skip..."
else
    echo "publish..."
    dotnet pack $project_file --configuration Release --output "${PWD}"
    dotnet nuget push *.nupkg -k $NUGET_API_KEY -s https://www.nuget.org/api/v2/package
fi
