// Napisati funkciju koja racuna cijenu potrosene elektricne energije.
// Cijena po kWh se racuna na osnovu kolicine potrosene energije
// Postoje 4 opsega potrosnje:
// Opseg A: 0 - 100 kWh - 0.1 KM po kWh
// Opseg B: 101 - 200 kWh - 0.15 po KWh
// Opseg C: 201 - 500 kWh - 0.2 po KWh
// Opseg D: preko 500 kWh - 0.25 po KWh
// Dodatno za preko 300 kWh potrosnje dodati 5 KM na ukupnu cijenu

let racun (kolicina:int) = 
  match kolicina with
  | kolicina when kolicina < 101 -> double kolicina * 0.1
  | kolicina when kolicina > 100 && kolicina < 201 -> double kolicina * 0.15
  | kolicina when kolicina > 200 && kolicina < 501 -> double kolicina * 0.2 + if kolicina > 300 then 5.0 else 0.0
  | kolicina when kolicina > 500 -> double kolicina * 0.25 + if kolicina > 300 then 5.0 else 0.0
  | _ -> 0.0
racun 525