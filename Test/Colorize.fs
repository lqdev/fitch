module Colorize

open System
open Xunit
open Lib

[<Fact>]
let ``Colorize fedora`` () =
  NeofetchLogos.logoDictionary |> Map.iter (fun _ v -> printfn "%s" (Colorize.colorize v); Console.ResetColor())

