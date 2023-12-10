// Zasto se kod ispod ne kompajlira?
// inref znaci da necemo mijenjati var, u funkciji pokusavamo

let mutable s = "Hello"

let foo (str : inref<string>) =
    str <- "World"
    ()

foo &s

printfn "S: %s" s 