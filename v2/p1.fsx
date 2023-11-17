// Napraviti pipeline operacija koji uzima pocetnu vrijednost
// nakon toga aplicira serije aritmetickih operacija nad datom
// pocetnom vrijednoscu.

let (|>) v f = f v
let foo (x:int) = (double x) / 5.0
let bar (y) = (double y) * 3.0
6 |> foo |> bar
