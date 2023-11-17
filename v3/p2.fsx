// Napisati program koji 3 studenta iz prethodnog zadatka smjesti u listu
// te svakom studentu povecava godine za 1. Nakon toga ispisati sve
// studente sa uvecanim godinama na ekran.
// 


// Definicija tipa Student i instanciranje 3 studenta s1, s2 i s3:

type Student = {Ime : string; Prezime : string; Godine : int; najdrazi_predmet : string}
let s1: Student = {Ime = "Adnan"; Prezime = "Maleskic"; Godine = 21; najdrazi_predmet = "Arhitektura racunara"}
let s2: Student = {Ime = "Emin"; Prezime = "Alikadic"; Godine = 21; najdrazi_predmet = "Objektno Orijentisano Programiranje"}
let s3: Student = {Ime = "Haris"; Prezime = "Mujic"; Godine = 21; najdrazi_predmet = "Funkcionalno programiranje"}
let students = [s1; s2; s3]
let ispisiStudenta ({Ime = ime; Prezime = prezime; Godine = godine; najdrazi_predmet = predmet}) =
  let text: string =  "|" + ime + " " + prezime + "|" + (string godine) + "|" + predmet + "|"
  match predmet with
  | "Funkcionalno programiranje" -> printf "%A" (text + ":)|\n")
  | _ -> printf "%A" (text + ":(|\n")
let rec ispisiStudente (studenti : list<Student>) =
  match studenti with
  | [] -> ()
  | _ -> 
    ispisiStudenta studenti[0]
    ispisiStudente studenti[1..]
let rec incAge (students : list<Student>) : list<Student> =
  match students with
  | [] -> []
  | _ -> 
    let std = {students[0] with Godine = students[0].Godine + 1}
    let l1 = [std]
    List.append l1 (incAge students[1..])
incAge students
ispisiStudente students

