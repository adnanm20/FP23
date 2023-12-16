//1
//BinaryTree
type BinaryTree<'a> =
 | Empty
 | Node of value:'a*left:BinaryTree<'a>*right:BinaryTree<'a>
let rec push<'a when 'a: comparison> (el:'a) (bTree:BinaryTree<'a>) =
  match bTree with
  | Empty -> Node (el, Empty, Empty)
  | Node (v, l, r) -> if el > v then
                          Node (v, push el l, r) else 
                          Node (v, l, push el r)
let rec foldr<'a> (func: 'a -> 'a -> 'a) (acc:'a) (bTree:BinaryTree<'a>) =
  match bTree with
  | Empty -> acc
  | Node (v, l, r) ->
    let res1 = foldr func acc r
    let res2 = func res1 v
    foldr func res2 l 
let t = Empty
let t1 = t |> push 5 |> push 4 |> push 6 |> push 2
let f = fun x y -> x+y
foldr f 0 t1

//2
[<AbstractClass>]
type Animal(n:string, a:int) =
  let mutable name = n
  let mutable age = a
  member this.Name 
    with get() = name
    and set (x:string) = name <- x
  member this.Age
    with get() = age
    and set(x:int) = age <- x
  abstract member makeSound: unit->unit
  abstract member move: unit->unit
  abstract member eat: string -> unit
  default this.eat (str:string) =
    printfn "%A eats %A" name str
  abstract member describe: unit->string
  default this.describe() =
    sprintf "I am %A and I am %A years old." name age

type Dog(n:string, a:int) =
  inherit Animal(n, a)

  override this.makeSound() =
    printfn "Dog %A barks" base.Name
  override this.move() =
    printfn "Dog runs"
  override this.describe () =
    base.describe() + "I am a dog."
type Elephant(n:string, a:int) =
  inherit Animal(n, a)

  override this.makeSound() =
    printfn "Elephant %A trumpets" this.Name
  override this.move() =
    printfn "Elephant walks"
  override this.describe () =
    base.describe() + "I am an elephant."

let animals = [Dog("D1", 7) :> Animal;
                            Elephant("E1", 25) :> Animal;
                            Dog("D2", 5) :> Animal;
                            Elephant("E2", 15) :> Animal;]
let rec foo<'a when 'a :> Animal> (anims:list<'a>) =
  match anims with
  | [] -> ()
  | x::xs ->
    x.makeSound()
    x.move()
    x.eat "something"
    printfn "%A" (x.describe ())
    foo anims[1..]
foo animals
