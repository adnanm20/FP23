// Napisati funkciju foo koja sabira sve elemente proslijedjene liste sa lijeve na desnu
// stranu. Funkcija treba da radi za listu bilo kojeg tipa koji podrzava operator +
// Nakon toga dodati tipove za funkciju eksplicitno.
let a = [1; 2; 3; 4]
let b = ["hi"; "world"; "2"]
let inline sumiraj<'a when 'a: (static member (+): 'a * 'a -> 'a)> (lista: list<'a>) =
  let rec sumiraj_ lst =
    match lst with
    | [] -> failwith "prazna lista"
    | last::[] -> last
    | x::xs -> x + sumiraj_ xs
  sumiraj_ lista
sumiraj a
sumiraj b

