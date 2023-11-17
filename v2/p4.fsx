// Napisati funkciju calcNums koja uzima dva broja (double tipa) i
// string koji predstavlja operaciju koju treba izvesti.
// Funkcija nazad vraca string koji predstavlja izvedenu operaciju
// ili error poruku ukoliko operacija nije uspjela (dijeljenje sa 0
// ili nevalidna operacija).
// Funkcija treba da podrzava operacije "add", "sub", "mul" i "div"
// Primjer: calcNums 10.0 5.0 mul -> "10.0 * 5.0 = 50.0"


let calcNums x y (op:string) = 
  match op with 
  | "add" -> let res = x+y in
              string x + " + " + string y + " = " + string res
  | "sub" -> let res = x-y in
              string x + " - " + string y + " = " + string res
  | "mul" -> let res = x*y in
              string x + " * " + string y + " = " + string res
  | "div" when (y <> 0.0) -> let res = x/y in
                               string x + " / " + string y + " = " + string res
  | _ -> "asd"
let r1 = calcNums 10.0 5.0 "add"
let r2 = calcNums 10.0 5.0 "sub"
let r3 = calcNums 10.0 5.0 "mul"
let r4 = calcNums 10.0 5.0 "div"
let r5 = calcNums 10.0 10.0 "mod"
r1 + r2 + r3 + r4 + r5

let calcNums2 (x:float32) (y:float32) (op:string) : string = 
  if op = "add" then
    let res = x + y
    string x + " + " + string y + " = " + string res
  elif op = "sub" then 
    let res = x - y
    string x + " - " + string y + " = " + string res
  elif op = "div" then
    if y <> 0.0f then 
      let res = x / y
      string x + " / " + string y + " = " + string res
    else 
      "No div with 0"
  elif op = "mul" then
    let res = x * y
    string x + " * " + string y + " = " + string res
  else 
    "abc"
let r1 = calcNums2 10.0f 5.0f "add"
let r2 = calcNums2 10.0f 5.0f "sub"
let r3 = calcNums2 10.0f 5.0f "mul"
let r4 = calcNums2 10.0f 5.0f "div"
let r5 = calcNums2 10.0f 10.0f "mod"
r1 + r2 + r3 + r4 + r5
