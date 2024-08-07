#!/bin/bash

echo " "
echo "===================================================================== "
echo " "
echo "This script configures FITCH on your system ..."
echo " "
echo "===================================================================== "
echo " "

dotnet tool restore
dotnet paket restore
cd Cli
dotnet publish -c Release
dotnet pack
dotnet tool uninstall -g fitch
dotnet tool install -g fitch --add-source nupkg
