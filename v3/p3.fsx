// Napisati funkciju "analizirajPodatke" koja treba da uzme tuple kao argument
// koji se sastoji od stringa, integera i float-a. String predstavlja kategoriju
// mjerenja integer predstavlja unikatni identifikator mjerenja, dok float 
// predstavlja rezultat mjerenja. Program treba da ispise na ekran:

// Kategorija: Temperatura, ID: 2, Mjerenje: 90.25
// Mjerenje je unutar granica norme

// za tuple: ("Temperatura", 1, 9.5)
// Mjerenje je unutar norme ukoliko je rezultat mjerenja ispod vrijednosti 10.0
// Funkcija treba nazad da vrati tuple sa istom kategorijom, identifikatorom
// uvecanim za 1 i kvadriranom vrijednoscu mjerenja

let analizirajPodatke (kategorija : string, id : int, mjerenje : float) : string*int*float = 
  let ((a, b, c) : string*int*float) = (kategorija, id+1, mjerenje*mjerenje)
  let text: string = "Kategorija: " + a + ", ID: " + (string b) + ", Mjerenje: " + (string c)
  printfn "%A" text
  match mjerenje with
  | _ when mjerenje < 10.0 -> printfn "%A" "Mjerenje je unutar granica norme"
  | _ -> printfn "%A" "Mjerenje nije unutar granica norme"
  (a, b, c)
analizirajPodatke ("Temperatura", 1, 10.5)
