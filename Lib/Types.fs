module Lib.Types

type Info =
  { distroId: string
    distroName: string
    kernelName: string
    shell: string
    user: string
    hostName: string
    memInfo: string
    cpuModel: string
    localIp: string
    upTime: string }

type DistroLogo =
  { distro: string
    logo: string
    colors: string list }
