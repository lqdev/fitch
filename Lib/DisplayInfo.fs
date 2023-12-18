module DisplayInfo

open System.Reflection
open Spectre.Console
open Spectre.Console.Rendering
open Lib.SystemInfo

let loadLogo (logo: string) =
  let assembly = Assembly.GetExecutingAssembly()
  use stream = assembly.GetManifestResourceStream $"Lib.distro_logos.{logo}.png"
  let image = CanvasImage stream
  image.MaxWidth <- 16
  image.PixelWidth <- 2
  image

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
