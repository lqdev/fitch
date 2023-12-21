module DisplayInfo

open Lib
open Spectre.Console
open Spectre.Console.Rendering
open Lib.SystemInfo

let loadLogo (logo: string) =
  NeofetchLogos.logoDictionary["debian"] |> Colorize.colorize |> Text

let printLogoWithText (logo: string) (rows: IRenderable seq) =
  let logoPanel = loadLogo logo :> IRenderable
  let textPanel = Rows rows :> IRenderable
  let columns = Columns [ logoPanel; textPanel ]
  AnsiConsole.Write columns

let displayInfo () =
  let info = systemInfo ()

  let (rows: IRenderable seq) =
    seq {
      Text($"Distribution: {info.distroName}", Style(Color.HotPink))
      Text($"Kernel: {info.kernelName}", Style(Color.HotPink))
      Text($"Shell: {info.shell}", Style(Color.HotPink))
      Text($"User: {info.user}", Style(Color.Yellow))
      Text($"Hostname: {info.hostName}", Style(Color.Yellow))
      Text($"Uptime: {info.upTime}", Style(Color.Blue))
      Text($"Memory: {info.memInfo}", Style(Color.Blue))
      Text($"CPU: {info.cpuModel}", Style(Color.Blue))
      Text($"LocalIP: {info.localIp}", Style(Color.Green))
    }
    |> Seq.map (fun x -> x :> IRenderable)

  printLogoWithText info.distroId rows
