module Utils

open System
open System.IO
open System.Net
open System.Net.Http

let getDistroId (fileName: string) = 
    match File.Exists(fileName) with
    | true ->
        let lines = File.ReadLines(fileName)
        let configProperties = 
            lines
            |> Seq.map(fun x -> 
                let values = x.Split('=')
                (values[0],values[1]))
            |> Seq.filter(fun (k,v) -> k = "ID")
            |> List.ofSeq
            

        let distroName = 
            match configProperties.IsEmpty with
            | true ->   
                ""
            | false -> 
                snd configProperties.Head
        distroName.Trim('"') 
    | false ->  ""

let getDistroName (fileName: string) = 
    match File.Exists(fileName) with
    | true ->
        let lines = File.ReadLines(fileName)
        let configProperties = 
            lines
            |> Seq.map(fun x -> 
                let values = x.Split('=')
                (values[0],values[1]))
            |> Seq.filter(fun (k,v) -> k = "PRETTY_NAME")
            |> List.ofSeq
            

        let distroName = 
            match configProperties.IsEmpty with
            | true ->   
                ""
            | false -> 
                snd configProperties.Head
        distroName.Trim('"') 
    | false ->  ""

let getHostName (fileName: string) = 
    match File.Exists(fileName) with 
    | true ->
        let lines = File.ReadLines(fileName) |> List.ofSeq
        match lines.IsEmpty with
        | true -> ""
        | false -> lines.Head
    | false -> 
        ""

let getKernel (fileName:string) = 
    match File.Exists(fileName) with
    | true -> 
        let lines = File.ReadLines(fileName) |> List.ofSeq
        match lines.IsEmpty with 
        | true -> ""
        | false -> lines.Head.Split(' ')[2]
    | false -> "" 

let getMemoryInfo (fileName:string) = 
    match File.Exists(fileName) with
    | true -> 
        let lines = File.ReadLines(fileName) |> List.ofSeq
        match lines.IsEmpty with
        | true -> ""
        | false -> 
            let totalMem = 
                lines[0].Split(' ')[^1] |> Int32.Parse
            let availMem = 
                lines[2].Split(' ')[^1] |> Int32.Parse 
        
            let totalMemMB = totalMem / 1024
            let availMemMB = availMem / 1024
            $"{availMemMB}MB / {totalMemMB}MB"
    | false -> 
        ""

let getShell (envVar:string) = 
    Environment.GetEnvironmentVariable(envVar).Split('/')[^0]

let getLocalIpAddress () = 
    let hostName = Dns.GetHostName()
    let addressList = 
        Dns.GetHostEntry(hostName).AddressList
        |> List.ofArray
    match addressList.IsEmpty with
    | true -> ""
    | false -> addressList[^2].ToString()

let getPublicIpAddressAsync (ipProvider:string) = 
    async {
        use client = new  HttpClient()
        return! client.GetStringAsync(ipProvider) |> Async.AwaitTask
    }

let getUptime (fileName:string) = 
    match File.Exists(fileName) with
    | true ->
        let lines = File.ReadLines(fileName) |> List.ofSeq
        match lines.IsEmpty with 
        | true -> ""
        | false -> 
            let uptime = lines[0].Split('.')[0] |> Int32.Parse
            let hours = uptime / 3600
            let minutes = (uptime % 3600) / 60
            $"{hours}h{minutes}m"
    | false -> 
        ""

let getUser (envVar:string) = 
    Environment.GetEnvironmentVariable(envVar)

let getCPUModelName (fileName:string) = 
    match File.Exists(fileName) with
    | true -> 
        let lines = 
            File.ReadLines(fileName)
            |> List.ofSeq

        match lines.IsEmpty with
        | true -> ""
        | false -> 
            let configProperties = 
                lines
                |> List.filter(fun line-> line.Contains(':'))
                |> List.map(fun line -> 
                    let kvPairs = line.Split(':')
                    let k,v = kvPairs[0].Trim(),kvPairs[1].Trim()
                    k,v)
                |> List.filter(fun (k,_) -> k = "model name")

            match configProperties.IsEmpty with
            | true -> ""
            | false -> 
                configProperties |> List.head |> snd

    | false -> ""    