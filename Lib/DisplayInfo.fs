module DisplayInfo

open Lib
open Spectre.Console
open Spectre.Console.Rendering
open Lib.SystemInfo

let loadLogo (logo: string) =
  NeofetchLogos.logoDictionary.TryGetValue logo
  |> function
    | true, l -> l
    | false, _ -> NeofetchLogos.logoDictionary["unknown"]
  |> Colorize.colorize
  |> Text
  :> IRenderable

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
  let logoPanel = loadLogo info.distroId
  let textPanel = Rows rows :> IRenderable
  let columns = Columns [textPanel; logoPanel]
  AnsiConsole.Write columns
