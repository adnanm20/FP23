// Napraviti tip koji predstavlja rezultat neke operacije. Rezultat operacije moze biti ili
// double vrijednost ili Greska koja sa sobom nosi string koji je opisuje.
// Nakon toga napisati funkciju podijeli koja ce vratiti tip Rezultat koji ce nositi
// rezultat dijeljenja ukoliko je dijeljenje moguce ili ce nositi gresku ukoliko
// dijeljenje nije moguce.
// Nakon toga pozvati funkciju podijeli i testirati sa razlicitim inputima.

type Rezultat = Good of value : float | Greska of err : string
let podijeli  (a : float) (b : float) : Rezultat = 
  match b with
  | 0.0 -> Greska "Nemoguce dijeliti s 0"
  | _ -> Good (a/b)
let r1 = podijeli 4.0 2.0
match r1 with
  | Greska err -> printfn "%A" err
  | Good value -> printfn "%A" value
let r2 = podijeli 4.0 0.0
match r2 with
  | Greska err -> printfn "%A" err
  | Good value -> printfn "%A" value