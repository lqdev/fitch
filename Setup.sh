#!/bin/bash

echo " "
echo "===================================================================== "
echo " "
echo "This script configures FITCH on your system ..."
echo " "
echo "===================================================================== "
echo " "

cd src

dotnet build

dotnet publish -c Release

sudo cp bin/Release/net8.0/linux-x64/publish/fitch /usr/bin/

cd ..

fitch


