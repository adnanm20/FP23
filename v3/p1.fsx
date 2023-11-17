// Napisati program koji definira tip Student koji sadrzi:
// ime, prezime, godine i najdrazi_predmet
// Program treba da instancira 3 studenta te ih ispise na ekran
// koristeci funkciju "ispisiStudenta". Funkcija treba da ispise
// studenta na sljedeci nacin:
//
// |Student|Godine|Najdrazi predmet|?|
// |Ime Prezime|22|Funkcionalno programiranje|:)|
// ili
// |Student|Godine|Najdrazi predmet|?|
// |Ime Prezime|20|Objektno orijentirano programiranje|:(|

type Student = {Ime : string; Prezime : string; Godine : int; najdrazi_predmet : string}
let s1: Student = {Ime = "Adnan"; Prezime = "Maleskic"; Godine = 21; najdrazi_predmet = "Arhitektura racunara"}
let s2: Student = {Ime = "Emin"; Prezime = "Alikadic"; Godine = 21; najdrazi_predmet = "Objektno Orijentisano Programiranje"}
let s3: Student = {Ime = "Haris"; Prezime = "Mujic"; Godine = 21; najdrazi_predmet = "Funkcionalno programiranje"}
let ispisiStudenta ({Ime = ime; Prezime = prezime; Godine = godine; najdrazi_predmet = predmet}) =
  printfn "%A" ("|Student|Godine|Najdrazi predmet|?|\n")
  let text: string =  "|" + ime + " " + prezime + "|" + (string godine) + "|" + predmet + "|"
  match predmet with
  | "Funkcionalno programiranje" -> printf "%A" (text + ":)|\n")
  | _ -> printf "%A" (text + ":(|\n")
ispisiStudenta s2
