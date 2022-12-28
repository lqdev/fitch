open System
open System.IO

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
                |> List.filter(fun x->x.Contains(':'))
                |> List.map(fun x -> 
                    let kvPairs = x.Split(':')
                    let k,v = kvPairs[0].Trim(),kvPairs[1].Trim()
                    k,v)
                |> List.filter(fun (a,b) -> a = "model name")

            match configProperties.IsEmpty with
            | true -> ""
            | false -> 
                configProperties |> List.head |> snd

    | false -> ""

getCPUModelName("/proc/cpuinfo")