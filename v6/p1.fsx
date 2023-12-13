// Napisati interface Shape koji sadrzi funkcije:
// Area, Perimeter i Scale u modulu Shapes

// Vas kod ovdje
type Shape =
  abstract member Area: unit -> double
  abstract member Perimeter: unit -> double
  abstract member Scale: double -> Shape

// Prosiriti modul Shapes sa implementacijom tri
// izvedene klase Shape-a: Circle, Square i Rect

// Vas kod ovdje
module Shapes =
  type Circle(radius: double) =
    let mutable r = radius
    interface Shape with
      member this.Area () = r*r*3.14159
      member this.Perimeter () = 2.*r*3.14159
      member this.Scale (s:double) = Circle(r*s)
    override this.ToString() =
      $"Circle with radius: {r}"
    member this.Radius
      with get() = r
      and set x = r <- x
    static member (+) (first: Circle, second: Circle) = 
      Circle(first.Radius + second.Radius)
  type Rect(a: double, b: double) =
    let mutable sideA = a
    let mutable sideB = b
    interface Shape with
      member this.Area () = sideA*sideB
      member this.Perimeter () = 2.*sideA + 2.*sideB
      member this.Scale (s:double) = Rect(sideB*s, sideB*s)
    override this.ToString() =
      $"Rectangle(axb): {sideA}x{sideB}"
    member this.A
      with get() = sideA
      and set x = sideA <- x
    member this.B
      with get() = sideB
      and set x = sideB <- x
    static member (+) (first: Rect, second: Rect) = 
      Rect(first.A + second.A, first.B + second.B)
  type Square(side: double) =
    let mutable a = side
    interface Shape with
      member this.Area () = a*a
      member this.Perimeter () = 4.*a
      member this.Scale (s:double) = Square(a*s)
    override this.ToString() =
      $"Square with side: {a}"
    member this.Side 
      with get() = a
      and set x = a <- x
    static member (+) (first: Square, second: Square) =
      Square(first.Side + second.Side)

open Shapes

// Pozvati metode area, perimeter i scale nad instancama ispod
let cir = Circle(5.)
let squ = Square(5.)
let (rect : Rect) = Rect(4, 2)

// Vas kod ovdje
(cir :> Shape).Area () |> printfn "Circle area: %A"
(cir :> Shape).Perimeter () |> printfn "Circle perim: %A"
(cir :> Shape).Scale(0.5).Area () |> printfn "Circle area after scale: %A"
(squ:> Shape).Area () |> printfn "Square area: %A"
(squ:> Shape).Perimeter () |> printfn "Square perim: %A"
(squ:> Shape).Scale(0.5).Area () |> printfn "Square area after scale: %A"
(rect:> Shape).Area () |> printfn "Rect area: %A"
(rect:> Shape).Perimeter () |> printfn "Rect perim: %A"
(rect:> Shape).Scale(0.5).Area () |> printfn "Rect area after scale: %A"


// Napisati funkciju sumShapesArea koja ce sabrati vrijednosti povrsine za sve tipove iz liste
let shape_list:list<Shape> = [Circle(radius = 3.); 
                              Rect(2.1, 3.3); 
                              Square(side = 4.002); 
                              Circle(radius = 2.0705); 
                              Square(side = 2.5001); 
                              Rect(2.1, 3.2)]

// Vas kod ovdje
let rec sumShapes<'a when 'a :> Shape> (lst: list<'a>) =
  match lst with
  | [] -> 0.0
  | x::xs -> x.Area() + sumShapes xs
sumShapes shape_list

// Napisati operatore + i metode ToString za sva tri oblika
// Odraditi operacije: 
//  cir + cir2
//  squ + squ2
//  rect + rect2
// Napraviti listu Shapes tipova od dobivenih rezultata, te for 
// petljom proci kroz sve oblike i pozvati ToString nad rezultatom.
let cir2 = Circle(3.)
let squ2 = Square(9.)
let rect2 = Rect(4., 8.) 

let cirSum = cir + cir2
let squSum = squ + squ2
let rectSum = rect + rect2

// Napraviti get i set metode za sve membere pojedinih oblika.
// Izmjeniti cir2, squ2 i rect2, te ponovno odraditi operacije
// sabiranja i ispisivanja na ekran

cir2.Radius <- 4
let sum = cir + cir2

// Za svaki oblik napraviti staticki clan koji ce brojati
// broj instanci pojedinog oblika

