open Elmish
open Elmish.React
open Feliz

type State = First | Second | Third

type Operation = Nil | Add | Sub | Div | Mul

type Msg = 
  | Number of value:int64
  | Clear
  | Operator of op:Operation
  | End

type Data = { DisplayNumber : int64; ResultInf : bool; ResultNaN : bool; Operator : Operation; Operand : int64 }

type CalcState = {State: State; Data: Data}

let init () = {State = First; Data = {DisplayNumber = 0L; ResultInf = false; ResultNaN = false; Operator = Nil; Operand = 0L}}

let calc data =
  match data.Operator with
  | Nil -> data
  | Add -> 
    if abs(data.Operand + data.DisplayNumber) < 10000000000L then
      {data with DisplayNumber = data.Operand + data.DisplayNumber; Operator = Nil; Operand = 0L}
    else 
      {data with DisplayNumber = data.Operand + data.DisplayNumber; Operator = Nil; Operand = 0L; ResultInf = true;}
  | Sub ->
    if abs(data.Operand - data.DisplayNumber) < 10000000000L then
      {data with DisplayNumber = data.Operand - data.DisplayNumber; Operator = Nil; Operand = 0L}
    else 
      {data with DisplayNumber = data.Operand - data.DisplayNumber; ResultInf = true; Operator = Nil; Operand = 0L;}
  | Div ->
    if data.DisplayNumber <> 0L then
      {data with DisplayNumber = data.Operand / data.DisplayNumber; Operand = 0L}
    else {DisplayNumber = 0L; ResultInf = false; ResultNaN = true; Operator = Nil; Operand = 0L}
  | Mul -> 
    if abs(data.Operand * data.DisplayNumber) < 10000000000L then
      {data with DisplayNumber = data.Operand * data.DisplayNumber; Operator = Nil; Operand = 0L}
    else 
      {data with DisplayNumber = data.Operand * data.DisplayNumber; ResultInf = true; Operator = Nil; Operand = 0L;}

let insertNumber (value:int64) (number: int64) =
  let sgn = sign(number)
  if sgn = 0 then
    value
  else
    if abs(number * 10L + value) < 10000000000L then
      (int64 sgn) * (abs(number * 10L) + value)
    else
      number

let update msg (calcState:CalcState) = 
  match calcState.State with
  | First ->
    match msg with
    | Number value ->
      {calcState with Data = {calcState.Data with DisplayNumber = (insertNumber value calcState.Data.DisplayNumber)}}
    | Clear ->
      init () 
    | Operator op ->
      if calcState.Data.DisplayNumber <> 0L then
        {calcState with State = Second; Data = {calcState.Data with Operand = calcState.Data.DisplayNumber; Operator = op}}
      else calcState
    | End ->
      calcState
  | Second ->
    match msg with
    | Number value ->
      {calcState with State = Third; Data = {calcState.Data with DisplayNumber = value}}
    | Clear ->
      init () 
    | Operator op ->
      {calcState with Data = {calcState.Data with Operator = op}}
    | End ->
      calcState
  | Third ->
    match msg with
    | Number value ->
      {calcState with Data = {calcState.Data with DisplayNumber = (insertNumber value calcState.Data.DisplayNumber)}}
    | Clear ->
      init () 
    | Operator op ->
      {calcState with State = First; Data = calc calcState.Data} //should be staying in state 3 but "ja i?" ¯\_(-_-)_/¯
    | End ->
      {calcState with State = First; Data = calc calcState.Data}


let view (calcState:CalcState) dispatch =
  let createBtn (cl:string) (cmd:Msg) (txt:string) =
      Html.button [
        prop.className cl 
        prop.onClick (fun _ -> dispatch (cmd))
        prop.text txt
      ]
  Html.div [
    Html.h1 [
      if calcState.Data.ResultNaN then
        prop.text ("NaN")
      else if calcState.Data.ResultInf then
        prop.text ((if calcState.Data.DisplayNumber < 0L then "-" else "") + "Inf")
      else
        prop.text (string calcState.Data.DisplayNumber)
    ]
    Html.div [
      createBtn "number" (Number 1) "1"
      createBtn "number" (Number 2) "2"
      createBtn "number" (Number 3) "3"
      createBtn "operator" (Operator Add) "+"
      createBtn "number" (Number 4) "4"
      createBtn "number" (Number 5) "5"
      createBtn "number" (Number 6) "6"
      createBtn "operator" (Operator Sub) "-"
      createBtn "number" (Number 7) "7"
      createBtn "number" (Number 8) "8"
      createBtn "number" (Number 9) "9"
      createBtn "operator" (Operator Mul) "*"
      createBtn "clear" (Clear) "CE"
      createBtn "number" (Number 0) "0"
      createBtn "equals" (End) "="
      createBtn "operator" (Operator Div) "/"
   ]
  ]


Program.mkSimple init update view 
|> Program.withReactSynchronous "app"
|> Program.run





