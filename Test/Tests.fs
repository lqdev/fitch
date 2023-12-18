module Tests

open Lib
open Xunit

[<Fact>]
let ``Get info`` () =
  let info = SystemInfo.systemInfo()
  printfn $"%A{info}"