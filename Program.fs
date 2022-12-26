open Spectre.Console
open Spectre.Console.Rendering
open Utils

let DisplayInfo () =
    let distroId = 
        getDistroId("/etc/os-release")

    let distroName = 
        getDistroName("/etc/os-release")

    let kernelName = 
        getKernel("/proc/version")

    let (shell:string) = 
        getShell("SHELL")

    let user = 
        getUser("USER")

    let hostName = 
        getHostName("/etc/hostname")

    let memInfo = 
        getMemoryInfo("/proc/meminfo")
        
    let localIp = 
        getLocalIpAddress() 

    // Uncomment to get public IP
    // let publicIp = 
    //     getPublicIpAddressAsync("http://ident.me") |> Async.RunSynchronously
    
    let uptime = 
        getUptime("/proc/uptime")

    let (rows:IRenderable seq) = 
        seq {
            new Text($"Distribution: {distroName}", new Style(Color.DarkRed)) :> IRenderable
            new Text($"Kernel: {kernelName}", new Style(Color.DarkRed)) :> IRenderable
            new Text($"Shell: {shell}", new Style(Color.DarkRed)) :> IRenderable
            new Text($"User: {user}", new Style(Color.Yellow)) :> IRenderable
            new Text($"Hostname: {hostName}", new Style(Color.Yellow)) :> IRenderable
            new Text($"Uptime: {uptime}", new Style(Color.Blue)) :> IRenderable
            new Text($"Memory: {memInfo}", new Style(Color.Blue)) :> IRenderable
            new Text($"LocalIP: {localIp}", new Style(Color.Green)) :> IRenderable
            
            //Uncomment to display public IP
            // new Text($"PublicIP: {publicIp}", new Style(Color.Green)) :> IRenderable
        }

 
    let distroIdFig = new FigletText(distroId)
    distroIdFig.Color <- Color.Green

    AnsiConsole.Write(distroIdFig)
    AnsiConsole.Write(new Rows(rows))

DisplayInfo()