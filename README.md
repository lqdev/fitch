# Fitch

Command line system information display utility for Linux systems built with .NET (F#).

![Fitch CLI Tool](./images/fitch-display.png)

**NOTE: This application should work on most Linux systems. However, it's only been tested on Arch-based distributions like Manjaro.**

## Dependencies

- [Spectre.Console](https://spectreconsole.net/)

## Build from source

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) 

### Instructions

1. Clone [fitch repo](http://www.luisquintanilla.me/github/fitch)
1. Nagivate to the project directory.

    ```bash
    cd fitch
    ```

1. Run the build command using dotnet CLI

    ```dotnetcli
    dotnet build
    ```

1. Run the publish command using the dotnet CLI

    ```dotnetcli
    dotnet publish -c Release
    ```

    Running this command will generate an executable called `fitch` in the *bin/Release/net7.0/linux-x64/publish* directory.


## Run application

1. Copy the executable from the publish directory (*bin/Release/net7.0/linux-x64/publish*) to the */usr/bin/* directory.

    ```bash
    cp bin/Release/net7.0/linux-x64/publish/fitch /usr/bin/
    ```

1. Run the following command in your terminal

    ```bash
    fitch
    ```

1. (Optional) Add the `fitch` command to your shell config file to start when your shell starts. 

## To-Dos

- [ ] Enable customization through config file
- [ ] Publish to NuGet as dotnet global tool

## Acknowledgements

This project was inspired by [Nitch](https://github.com/unxsh/nitch) and [Neofetch](https://github.com/dylanaraps/neofetch)