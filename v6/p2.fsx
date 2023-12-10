// Zasto se kod ispod ne kompajlira?

let mutable s = "Hello"

let foo (str : byref<string>) =
    str <- "World"
    ()

foo &s

printfn "S: %s" s 