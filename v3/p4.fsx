// Napisati discriminated union Oblik koji ima 3 varijante konstruktora:
// Krug, Kvadrat i Pravougaonik
// Svaki od konstruktora treba da uzme odgovarajuci broj parametara potrebnih
// za izracunavanje obima i povrsine oblika.
// Napisati funkcije obim i povrsina koje izracunavaju obim i povrsinu oblika.

type Oblik =
  | Krug of radius : float
  | Kvadrat of stranica : float
  | Pravougaonik of height : float * width : float
let obim (o : Oblik) : float = 
  match o with
  | Krug (r: float) -> 2.0*r*3.14
  | Kvadrat (str: float) -> 4.0*str
  | Pravougaonik (h: float,w: float) -> 2.0*h+2.0*w
let povrsina (o : Oblik) : float = 
  match o with
  | Krug (r: float) -> r*r*3.141592535
  | Kvadrat (str: float) -> str*str
  | Pravougaonik (h: float,w: float) -> w*h
let kr = Krug 5.0
let kv = Kvadrat 3.0
let pr = Pravougaonik (2.0, 3.0)
printfn "obim kr %A" <| obim kr
printfn "obim kv %A" <| obim kv
printfn "obim pr %A" <| obim pr
printfn "povr kr %A" <| povrsina kr
printfn "povr kv %A" <| povrsina kv
printfn "povr pr %A" <| povrsina pr
