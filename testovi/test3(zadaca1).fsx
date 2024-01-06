//1
//given
type CalcVal =
  | None
  | Value of v:int64
  | InfinityPlus
  | InfinityMinus
  | NaN
let allDigits (str:string) =
  Seq.forall System.Char.IsDigit str
//our code after
//basic solution, should be fixed with helper functions
let strToCalcVal (str:string) =
  match str with
  | "" -> None
  | _ ->
    match str[0] with
    | '-' ->
      if allDigits str[1..] then
        if str.Length > 11 then
          InfinityMinus
        else
          Value (int64 str)
      else
        NaN
    | _ ->
      if allDigits str then
        if str.Length > 11 then
          InfinityPlus
        else
          Value (int64 str)
      else
        NaN


//2 (needs these installed with femto)
open Elmish
open Elmish.React
open Feliz
//our code here
type CalcOp = Add | Sub | Mul | Div
type Message =
  | Number of val1:string
  | Operator of o:CalcOp
  | Equals
  | Clear
type State =
  | FirstNumInput of val1:string
  | OperatorClicked of val1:string*op:CalcOp
  | SecondNumInput of val1:string*op:CalcOp*val2:string
let digitF (str:string) (dis:Message->unit) : ReactElement =
  Html.button [
    prop.text str
    prop.onClick (fun _ -> dis (Number str))
  ]
let opF (o:CalcOp) (dis:Message->unit) : ReactElement =
  Html.button [
    match o with
    | Add -> "+"
    | Sub -> "-"
    | Mul -> "*"
    | Div -> "/"
    |> prop.text
    prop.onClick (fun _ -> dis (Operator o))
  ]
let clrF (dis:Message->unit) : (MouseEvent->unit) =
  (fun _ -> dis Clear)
let eqF (dis:Message->unit) : (MouseEvent->unit) =
  (fun _ -> dis Equals)
//given (need to add necessary to make this compile)
let view (state:State) (dispatch: Message -> unit) : ReactElement =
  let digit (v:int64) =
    digitF (string v) dispatch
  let op (o:CalcOp) =
    opF o dispatch
  let clr =
    Html.button [prop.text "CE"; clrF dispatch |> prop.onClick]
  let eq =
    Html.button [prop.text "="; eqF dispatch |> prop.onClick]
  let br = Html.br []
  Html.div [
    Html.div [
      match state with
      | FirstNumInput val1 ->
        val1
      | OperatorClicked (val1, o) ->
        val1
      | SecondNumInput (val1, o, val2) ->
        val2
      |> prop.text
    ]
    Html.div [
      digit 1; digit 2; digit 3; op Add; br
      digit 4; digit 5; digit 6; op Sub; br
      digit 7; digit 8; digit 9; op Mul; br
      clr; digit 2; eq; op Div; br
    ]
  ]