// Napisati rekurzivnu strukturu podataka "BinaryTree". Struktura
// treba da bude polimorfna i da sadrzi comparison constraint nad
// tipom. 
// Napisati funkcije push, traverse, foldl i foldr. Elementi treba
// da se dodaju u binarno stablo koristeci operator "<".
// Traverse treba da prolazi kroz binarno stablo i ispisuje elemente
// in-order koristeci prnt funkciju koja treba da bude parametar
// travers-a.
// foldl treba uzme 3 parametra: funkciju koja uzima dva parametra
// pocetnu vrijednost i BinaryTree strukturu.
// Potrebno je pocetnu vrijednost apply-ati funkcijom sa elementom na 
// kranjoj lijevoj strani i rezultat date operacije apply-ati kao
// pocetnu vrijednost stabla sa desne strane   
// foldr treba da radi istu stvar u suprotnom smijeru.

type BinaryTree<'a when 'a: comparison> =
  | Empty
  | Node of left:BinaryTree<'a>*value:'a*right:BinaryTree<'a>
let inline push (xval: 'a) (tree: BinaryTree<'a>) : BinaryTree<'a> =
  let rec push_ (t: BinaryTree<'b>) (x: 'b) : BinaryTree<'b> =
    match t with
    | Empty -> Node (Empty, x, Empty)
    | Node (l, v, r) -> 
      if x < v then Node (push_ l x, v, r)
      else Node (l, v, push_ r x)
  push_ tree xval
let inline traverse prnt (tree: BinaryTree<'a>) : unit =
  let rec traverse_ t =
    match t with
    | Empty -> ()
    | Node (l, v, r) ->
      traverse_ l
      prnt v
      traverse_ r
  traverse_ tree
let inline foldl start funk tree =
  let rec foldl_ st f t =
    match t with
    | Empty -> st
    | Node (l, v, r) ->
      f (f (foldl_ st f l) v) (foldl_ st f r)
  foldl_ start funk tree
let inline foldr start funk tree =
  let rec foldr_ st f t =
    match t with
    | Empty -> st
    | Node (l, v, r) ->
      f (f (foldr_ st f r) v) (foldr_ st f l)
  foldr_ start funk tree
let x1 = push 4 Empty |> push 5 |> push 7 |> traverse (printfn "%A")
let x2 = push 4 Empty |> push 5 |> push 7 |> foldl 0 (+)
let x3 = push 4 Empty |> push 5 |> push 7 |> foldr 0 (+)
