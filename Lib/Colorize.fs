module Lib.Colorize

open Lib.Types

let color (colorCode: string) =
  let reset = "\x1b[0m"

  match colorCode with
  | "0"
  | "1"
  | "2"
  | "3"
  | "4"
  | "5"
  | "6" -> sprintf "%s\x1b[3%sm" reset colorCode
  | "7"
  | "fg" -> sprintf "\x1b[37m%s" reset
  | _ -> sprintf "\x1b[38;5;%sm" colorCode

let replaceColors (logo: string) (colors: string list) =
  let xs = colors |> List.mapi (fun i c -> sprintf "${c%d}" (i + 1), color $"{c}")
  xs |> List.fold (fun (acc: string) -> acc.Replace) logo

let colorize (l: DistroLogo) = replaceColors l.logo l.colors
