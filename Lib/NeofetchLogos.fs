module Lib.NeofetchLogos

open Types

let readLogo (file: string) =
  let asm = System.Reflection.Assembly.GetExecutingAssembly()
  let stream = asm.GetManifestResourceStream $"Lib.Logos.{file}.txt"
  let reader = new System.IO.StreamReader(stream)
  reader.ReadToEnd()

let arch =
  { distro = "Arch"
    colors = [ "6"; "6"; "7"; "1" ]
    logo = readLogo "arch" }

let debian =
  { distro = "Debian"
    colors = [ "7"; "1" ]
    logo = readLogo "debian" }

let fedora =
  { distro = "Fedora"
    colors = [ "12"; "7" ]
    logo = readLogo "fedora" }

let mac =
  { distro = "macOS"
    colors = [ "2"; "3"; "1" ;"1"; "5"; "4" ]
    logo = readLogo "mac" }

let mint =
  { distro = "Linux Mint"
    colors = [ "2"; "7"; "3" ]
    logo = readLogo "mint" }

let nixos =
  { distro = "NixOS"
    colors = [ "6"; "7"; "1" ]
    logo = readLogo "nixos" }

let ubuntu =
  { distro = "Ubuntu"
    colors = [ "1"; "7"; "3" ]
    logo = readLogo "ubuntu" }

let unknown =
  { distro = "Unknown"
    colors = [ "fg"; "8"; "3" ]
    logo = readLogo "unknown" }

let windows =
  { distro = "windows"; colors = ["6"; "7"]; logo = readLogo "windows" }

let logoDictionary =
  [ ("arch", arch)
    ("debian", debian)
    ("fedora", fedora)
    ("mac", mac)
    ("mint", mint)
    ("nixos", nixos)
    ("ubuntu", ubuntu)
    ("unknown", unknown)
    ("windows", windows) ]
  |> Map.ofList
