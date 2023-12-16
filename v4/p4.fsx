// Napisati Trie rekurzivnu strukturu podataka objasnjenu na sljedecem linku:
// https://www.geeksforgeeks.org/introduction-to-trie-data-structure-and-algorithm-tutorials/
//
// Napisati funkciju insertWord koja dodaje rijec u Trie data strukturu (svako
// slovo treba da bude jedan cvor).
// Napisati funkciju koja uzima string i nazad vraca listu stringova
// koje se nalaze u Trie strukturi podataka.

type Trie =
  | Empty
  | Node of letter:char * connections:list<Trie> * wordEnding:bool
  | Root of connections:list<Trie>
let rec insertWord (word:string) (tr:Trie) : Trie =
  match word with
  | "" -> Empty
  | _ -> 
    match tr with
    | Empty -> 
      Node (word[0], List.init 26 
        (fun num -> if (word.Length>1 && num=(int word[1] - 97)) then
                           (insertWord word[1..] tr) else Empty), word.Length=1)
    | Node (l, conns, _) -> 
      Node (l, List.mapi 
              (fun num t  -> if (word.Length>1 && num=(int word[1] - 97)) then
                                insertWord word[1..] t else t) conns,
                                word.Length = 1)
    | Root conns -> 
      Root (List.init 26 
              (fun num -> if num=(int word[0] - 97) then
                                (insertWord word conns[int word[0] - 97]) else conns[num]))
let rec findStrings (w:string) (tr:Trie) : List<string> =
  match w with
  | "" -> 
    match tr with
    | Empty -> []
    | Node (ch, conn, wE) ->
      List.map (fun s -> if wE then s else string ch + s)
        (List.append (if wE then [string ch] else [])
        (List.collect (fun c -> (findStrings "" c)) conn))
    | Root conn -> List.collect (fun c -> (findStrings "" c)) conn
  | _ ->
    match tr with
    | Empty -> []
    | Node (ch, conn, _) -> 
      findStrings w[1..] conn[int w[0] - 97]
    | Root (conn) -> List.map (fun (s:string) -> w + s[1..]) (findStrings w[1..] conn[int w[0] - 97])
    

let cppkeyword = (Root (List.replicate 26  Empty)) |> 
                  insertWord "alignas" |>
                  insertWord "alignof" |>
                  insertWord "an" |>
                  insertWord "ande" |>
                  insertWord "as" |>
                  insertWord "atomiccancel" |>
                  insertWord "atomiccommit" |>
                  insertWord "atomicnoexcept" |>
                  insertWord "auto" |>
                  insertWord "bitan" |>
                  insertWord "bito" |>
                  insertWord "bool" |>
                  insertWord "break" |>
                  insertWord "cast" |>
                  insertWord "catch" |>
                  insertWord "char" |>
                  insertWord "char8t" |>
                  insertWord "char16t" |>
                  insertWord "char32t" |>
                  insertWord "class" |>
                  insertWord "comp" |>
                  insertWord "concept" |>
                  insertWord "const" |>
                  insertWord "consteval" |>
                  insertWord "constexpr" |>
                  insertWord "constinit" |>
                  insertWord "constcast" |>
                  insertWord "continue" |>
                  insertWord "coawait" |>
                  insertWord "coreturn" |>
                  insertWord "coyield" |>
                  insertWord "decltype" |>
                  insertWord "default" |>
                  insertWord "delete" |>
                  insertWord "do" |>
                  insertWord "double" |>
                  insertWord "dynamiccast" |>
                  insertWord "else" |>
                  insertWord "enum" |>
                  insertWord "explicit" |>
                  insertWord "export" |>
                  insertWord "extern" |>
                  insertWord "false" |>
                  insertWord "float" |>
                  insertWord "for" |>
                  insertWord "friend" |>
                  insertWord "goto" |>
                  insertWord "if" |>
                  insertWord "inline" |>
                  insertWord "int" |>
                  insertWord "long" |>
                  insertWord "mutable" |>
                  insertWord "namespace" |>
                  insertWord "new" |>
                  insertWord "noexcept" |>
                  insertWord "not" |>
                  insertWord "noteq" |>
                  insertWord "nullptr" |>
                  insertWord "operator" |>
                  insertWord "or" |>
                  insertWord "oreq" |>
                  insertWord "private" |>
                  insertWord "protected" |>
                  insertWord "public" |>
                  insertWord "reflexpr" |>
                  insertWord "register" |>
                  insertWord "reinterpretcast" |>
                  insertWord "requires" |>
                  insertWord "return" |>
                  insertWord "short" |>
                  insertWord "signed" |>
                  insertWord "sizeof" |>
                  insertWord "static" |>
                  insertWord "staticassert" |>
                  insertWord "staticcast" |>
                  insertWord "struct" |>
                  insertWord "switch" |>
                  insertWord "synchronized" |>
                  insertWord "template" |>
                  insertWord "this" |>
                  insertWord "threadlocal" |>
                  insertWord "throw" |>
                  insertWord "true" |>
                  insertWord "try" |>
                  insertWord "typedef" |>
                  insertWord "typeid" |>
                  insertWord "typename" |>
                  insertWord "union" |>
                  insertWord "unsigned" |>
                  insertWord "using" |>
                  insertWord "virtual" |>
                  insertWord "void" |>
                  insertWord "volatile" |>
                  insertWord "wchart" |>
                  insertWord "while" |>
                  insertWord "xor" |>
                  insertWord "xoreq"
let res = findStrings "a" cppkeyword
