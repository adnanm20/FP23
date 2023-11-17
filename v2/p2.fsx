// Napisati izraz koji treba kvadrira broj 5, a nakon
// toga da ga uveca za 1. Rezultat generisati prvo koristeci
// operator aplikacija funkcije, nakon toga forward pipe
// i konacno backward pipe.

let num = 5
let kvadr x = (double x)**2
let incr y = y + 1.0
let prvi = incr (kvadr num)
let drugi = num |> kvadr |> incr
let treci = incr <| (kvadr <| num)
string prvi + " " + string drugi + " " + string treci

