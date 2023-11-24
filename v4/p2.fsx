// Napisati polimorfnu funkciju uporediGodine koja treba da uzme genericki tip
// koji moze imati member-e "godine" i "ime". Funkcija treba da uzme dva objekta
// navedenog tipa, uporedi godine i na ekran ispise:
// | Godine identicne
// | A stariji od B
// | A mladji od B

type Student = {ime: string; brojIndeksa: int; godine: int}
type Radnik = {ime: string; staz: int; godine: int}
let inline uporediGodine<'a when 'a: (member godine: int)
                  and 'a: (member ime: string)> (prvi : 'a) (drugi : 'a) : unit =
  match prvi.godine with
  | _ when prvi.godine = drugi.godine -> printfn "| Godine identicne"
  | _ when prvi.godine < drugi.godine -> printfn "| %s mladji od %s" prvi.ime drugi.ime
  | _ -> printfn "| %s stariji od %s" prvi.ime drugi.ime
let d = uporediGodine {ime="A"; brojIndeksa=4; godine=22} {ime="B"; brojIndeksa=5; godine=22}
let e = uporediGodine {ime="A"; staz=4; godine=21} {ime="B"; staz=5; godine=22}

