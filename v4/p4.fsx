// Napisati Trie rekurzivnu strukturu podataka objasnjenu na sljedecem linku:
// https://www.geeksforgeeks.org/introduction-to-trie-data-structure-and-algorithm-tutorials/
//
// Napisati funkciju insertWord koja dodaje rijec u Trie data strukturu (svako
// slovo treba da bude jedan cvor).
// Napisati funkciju koja uzima string i nazad vraca listu stringova
// koje se nalaze u Trie strukturi podataka.

type Trie =
  | Empty
  | Node of letter:char * connections:list<Trie> * wordsEnding:int
  | Root of connections:list<Trie>
let rec insertWord (word:string) (tr:Trie) : Trie =
  match word with
  | "" -> Empty
  | _ -> 
    match tr with
    | Empty -> 
      Node (word[0], List.init 26 
        (fun num -> if (word.Length=1 || num=(int word[1] - 97)) then
                           (insertWord word[1..] tr) else Empty), if word.Length=1 then 1 else 0)
    | Node (l, conns, wE) -> 
      Node (l, List.init 26 
              (fun num -> if (word.Length=1 || num=(int word[1] - 97)) then
                                insertWord word[1..] conns[int word[0] - 97] 
                                else conns[num]), if word.Length = 1 then wE+1 else wE)
    | Root conns -> 
      Root (List.init 26 
              (fun num -> if num=(int word[0] - 97) then
                                (insertWord word conns[int word[0] - 97]) else conns[num]))
let rec findStrings (w:string) (tr:Trie) : List<string> =
  let rec search (word:string) (t:Trie) : List<string> =
    match word with
    | "" ->
      match tr with
      | Empty -> []
      | Node (l, conns) ->
        let acc = [];
        List.iter (fun c -> List.append acc (search "" c)) conns
        let rec iter (c:List<Trie>) (acc:list<string>) : List<string> =
          match c with
          | [] -> acc
          | _ ->
            let newAcc = List.append acc (search "" c[0])
            iter c[1..] newAcc 
        let x = iter conns []
        List.init x.Length (fun num -> (string l) + x[num])
      | Root (conns) ->
        let rec iter (c:List<Trie>) (acc:list<string>) : List<string> =
          match c with
          | [] -> acc
          | _ ->
            let newAcc = List.append acc (search "" c[0])
            iter c[1..] newAcc
        iter conns []
    | _ ->
      match t with
      | Empty -> []
      | Node (l, conns) -> 
        (if word.Length > 1 then 
          let x = (search word[1..] conns[int word[1] - 97])
          List.init x.Length (fun num -> (string l) + string x[num])
        else search "" t)
      | Root (conns) -> 
        let x = search word conns[int word[0] - 97]
        List.init x.Length (fun num -> x[num])
  search w tr
let x = insertWord "hello" (Root (List.init 26 (fun _ -> Empty)))
