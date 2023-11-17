// Definirati discriminated union pod nazivom MathOps sa varijantama konstruktora:
// Add, Sub, Mul  Div gdje svaka varijanta cuva jedan float.
// Napisati rekurzivnu funkciju performOps koja uzima pocetnu vrijednost i listu
// matematickih operacija. Funkcija vraca nazad float nakon apliciranja operacija
// sa lijeve na desnu stranu. Nakon toga napraviti implementaciju iste funkcije
// koja aplicira operacije sa desne na lijevu stranu.

type MathOps = 
  | Add of value : float
  | Sub of value : float
  | Mul of value : float
  | Div of value : float
let rec performOps (startValue : float) (ops : list<MathOps>) : float = 
  match ops with
  | [] -> startValue
  | _ ->
    match ops[0] with
    | Add (num: float) -> performOps (startValue + num) ops[1..]
    | Sub (num: float) -> performOps (startValue - num) ops[1..]
    | Mul (num: float) -> performOps (startValue * num) ops[1..]
    | Div (num: float) -> performOps (startValue / num) ops[1..]
let rec performOpsRev (startValue : float) (ops : list<MathOps>) : float = 
  match ops with
  | [] -> startValue
  | _ ->
    match ops[0] with
    | Add (num: float) -> performOpsRev startValue ops[1..] + num
    | Sub (num: float) -> performOpsRev startValue ops[1..] - num
    | Mul (num: float) -> performOpsRev startValue ops[1..] * num
    | Div (num: float) -> performOpsRev startValue ops[1..] / num
let r1 = performOps 3.0 [Add 5.0; Sub 2.5; Mul 4.0; Div 6.0]
let r2 = performOpsRev 3.0 [Div 6.0; Mul 4.0; Sub 2.5; Add 5.0]
r1 = r2

