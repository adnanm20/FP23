// 1
let scale (a : float) (b : float) (x : float) : float =
  System.Math.Log(x, a) * b
let exponent (a : float) (b : float) (x : float) : float =
  (a ** x) * b
let mod_offset (a : float) (b : float) (x : float) : float =
  (x % a) + b
let processValue : float -> float = (scale 5.0 2.0) >> (exponent 3.4 2.5) >> (mod_offset 2.0 3.5)
processValue 3.5

// 2
type FileOp =
  | AddPrefix of prefix : string
  | RemoveExtension
  | ToLower
let rec remExt (file : string) : string =
  if file.Length > 4 then
    (string) file[0] + remExt file[1..]
  else
    ""
let performOpOnFile (op : FileOp) (file : string) : string =
  match op with
  | AddPrefix pref -> pref + file
  | RemoveExtension -> remExt file
  | ToLower -> file.ToLower()
let rec apOps (ops : list<FileOp>) (file : string) : string =
  match ops with
  | [] -> file
  | _ -> apOps ops[1..] (performOpOnFile ops[0] file)
let rec fs (files : list<string>) (ops : list<FileOp>) : list<string> =
  match files with
  | [] -> []
  | _ -> List.append [apOps ops files[0]] (fs files[1..] ops)
let applyOpsOnFiles (files : list<string>) (ops : list<FileOp>) : list<string> =
  fs files ops
let (texts : list<string>) = ["directory.txt"; "image.png"; "notes.pdf"]
let (ops : list<FileOp>) = [AddPrefix "Updated_"; RemoveExtension; ToLower]
applyOpsOnFiles texts ops

