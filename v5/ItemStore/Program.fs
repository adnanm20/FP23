// For more information see https://aka.ms/fsharp-console-apps
open DBStore
[<EntryPoint>]
let main argv : int =
  let item:Types.Item = {Id = -100; Name = "Bilo sta"; Qty = 35; Px = 25.0}
  Queries.CreateSchema ()
  Queries.insertItem item
  let fetched = Queries.selectItem 1
  printfn "%A" fetched
  0