#!/bin/bash

echo " "
echo "===================================================================== "
echo " "
echo "This script configures FITCH on your system ..."
echo " "
echo "===================================================================== "
echo " "

dotnet build

dotnet publish -c Release

sudo cp bin/Release/net7.0/linux-x64/publish/fitch /usr/bin/

fitch


