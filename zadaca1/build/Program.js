import { Record, Union } from "./fable_modules/fable-library.4.9.0/Types.js";
import { record_type, bool_type, int64_type, union_type } from "./fable_modules/fable-library.4.9.0/Reflection.js";
import { fromInt32, toFloat64, op_Multiply, op_Division, equals, op_Subtraction, op_Addition, toInt64, abs, compare } from "./fable_modules/fable-library.4.9.0/BigInt.js";
import { int64ToString, createObj, sign } from "./fable_modules/fable-library.4.9.0/Util.js";
import { createElement } from "react";
import { singleton, delay, toList } from "./fable_modules/fable-library.4.9.0/Seq.js";
import { ofArray } from "./fable_modules/fable-library.4.9.0/List.js";
import { Interop_reactApi } from "./fable_modules/Feliz.2.7.0/Interop.fs.js";
import { ProgramModule_mkSimple, ProgramModule_run } from "./fable_modules/Fable.Elmish.4.0.0/program.fs.js";
import { Program_withReactSynchronous } from "./fable_modules/Fable.Elmish.React.4.0.0/react.fs.js";

export class State extends Union {
    constructor(tag, fields) {
        super();
        this.tag = tag;
        this.fields = fields;
    }
    cases() {
        return ["First", "Second", "Third"];
    }
}

export function State_$reflection() {
    return union_type("Program.State", [], State, () => [[], [], []]);
}

export class Operation extends Union {
    constructor(tag, fields) {
        super();
        this.tag = tag;
        this.fields = fields;
    }
    cases() {
        return ["Nil", "Add", "Sub", "Div", "Mul"];
    }
}

export function Operation_$reflection() {
    return union_type("Program.Operation", [], Operation, () => [[], [], [], [], []]);
}

export class Msg extends Union {
    constructor(tag, fields) {
        super();
        this.tag = tag;
        this.fields = fields;
    }
    cases() {
        return ["Number", "Clear", "Operator", "End"];
    }
}

export function Msg_$reflection() {
    return union_type("Program.Msg", [], Msg, () => [[["value", int64_type]], [], [["op", Operation_$reflection()]], []]);
}

export class Data extends Record {
    constructor(DisplayNumber, ResultInf, ResultNaN, Operator, Operand) {
        super();
        this.DisplayNumber = DisplayNumber;
        this.ResultInf = ResultInf;
        this.ResultNaN = ResultNaN;
        this.Operator = Operator;
        this.Operand = Operand;
    }
}

export function Data_$reflection() {
    return record_type("Program.Data", [], Data, () => [["DisplayNumber", int64_type], ["ResultInf", bool_type], ["ResultNaN", bool_type], ["Operator", Operation_$reflection()], ["Operand", int64_type]]);
}

export class CalcState extends Record {
    constructor(State, Data) {
        super();
        this.State = State;
        this.Data = Data;
    }
}

export function CalcState_$reflection() {
    return record_type("Program.CalcState", [], CalcState, () => [["State", State_$reflection()], ["Data", Data_$reflection()]]);
}

export function init() {
    return new CalcState(new State(0, []), new Data(0n, false, false, new Operation(0, []), 0n));
}

export function calc(data) {
    const matchValue = data.Operator;
    switch (matchValue.tag) {
        case 1:
            if (compare(abs(toInt64(op_Addition(data.Operand, data.DisplayNumber))), 10000000000n) < 0) {
                return new Data(toInt64(op_Addition(data.Operand, data.DisplayNumber)), data.ResultInf, data.ResultNaN, new Operation(0, []), 0n);
            }
            else {
                return new Data(toInt64(op_Addition(data.Operand, data.DisplayNumber)), true, data.ResultNaN, new Operation(0, []), 0n);
            }
        case 2:
            if (compare(abs(toInt64(op_Subtraction(data.Operand, data.DisplayNumber))), 10000000000n) < 0) {
                return new Data(toInt64(op_Subtraction(data.Operand, data.DisplayNumber)), data.ResultInf, data.ResultNaN, new Operation(0, []), 0n);
            }
            else {
                return new Data(toInt64(op_Subtraction(data.Operand, data.DisplayNumber)), true, data.ResultNaN, new Operation(0, []), 0n);
            }
        case 3:
            if (!equals(data.DisplayNumber, 0n)) {
                return new Data(toInt64(op_Division(data.Operand, data.DisplayNumber)), data.ResultInf, data.ResultNaN, data.Operator, 0n);
            }
            else {
                return new Data(0n, false, true, new Operation(0, []), 0n);
            }
        case 4:
            if (compare(abs(toInt64(op_Multiply(data.Operand, data.DisplayNumber))), 10000000000n) < 0) {
                return new Data(toInt64(op_Multiply(data.Operand, data.DisplayNumber)), data.ResultInf, data.ResultNaN, new Operation(0, []), 0n);
            }
            else {
                return new Data(toInt64(op_Multiply(data.Operand, data.DisplayNumber)), true, data.ResultNaN, new Operation(0, []), 0n);
            }
        default:
            return data;
    }
}

export function insertNumber(value, number) {
    const sgn = sign(toFloat64(number)) | 0;
    if (sgn === 0) {
        return value;
    }
    else if (compare(abs(toInt64(op_Addition(toInt64(op_Multiply(number, 10n)), value))), 10000000000n) < 0) {
        return toInt64(op_Multiply(toInt64(fromInt32(sgn)), toInt64(op_Addition(abs(toInt64(op_Multiply(number, 10n))), value))));
    }
    else {
        return number;
    }
}

export function update(msg, calcState) {
    let bind$0040_3, bind$0040_2, bind$0040_4, bind$0040_1, bind$0040;
    const matchValue = calcState.State;
    switch (matchValue.tag) {
        case 1:
            switch (msg.tag) {
                case 1:
                    return init();
                case 2: {
                    const op_1 = msg.fields[0];
                    return new CalcState(calcState.State, (bind$0040_3 = calcState.Data, new Data(bind$0040_3.DisplayNumber, bind$0040_3.ResultInf, bind$0040_3.ResultNaN, op_1, bind$0040_3.Operand)));
                }
                case 3:
                    return calcState;
                default: {
                    const value_1 = msg.fields[0];
                    return new CalcState(new State(2, []), (bind$0040_2 = calcState.Data, new Data(value_1, bind$0040_2.ResultInf, bind$0040_2.ResultNaN, bind$0040_2.Operator, bind$0040_2.Operand)));
                }
            }
        case 2:
            switch (msg.tag) {
                case 1:
                    return init();
                case 2: {
                    const op_2 = msg.fields[0];
                    return new CalcState(new State(0, []), calc(calcState.Data));
                }
                case 3:
                    return new CalcState(new State(0, []), calc(calcState.Data));
                default: {
                    const value_2 = msg.fields[0];
                    return new CalcState(calcState.State, (bind$0040_4 = calcState.Data, new Data(insertNumber(value_2, calcState.Data.DisplayNumber), bind$0040_4.ResultInf, bind$0040_4.ResultNaN, bind$0040_4.Operator, bind$0040_4.Operand)));
                }
            }
        default:
            switch (msg.tag) {
                case 1:
                    return init();
                case 2: {
                    const op = msg.fields[0];
                    if (!equals(calcState.Data.DisplayNumber, 0n)) {
                        return new CalcState(new State(1, []), (bind$0040_1 = calcState.Data, new Data(bind$0040_1.DisplayNumber, bind$0040_1.ResultInf, bind$0040_1.ResultNaN, op, calcState.Data.DisplayNumber)));
                    }
                    else {
                        return calcState;
                    }
                }
                case 3:
                    return calcState;
                default: {
                    const value = msg.fields[0];
                    return new CalcState(calcState.State, (bind$0040 = calcState.Data, new Data(insertNumber(value, calcState.Data.DisplayNumber), bind$0040.ResultInf, bind$0040.ResultNaN, bind$0040.Operator, bind$0040.Operand)));
                }
            }
    }
}

export function view(calcState, dispatch) {
    let children;
    const createBtn = (cl, cmd, txt) => createElement("button", {
        className: cl,
        onClick: (_arg) => {
            dispatch(cmd);
        },
        children: txt,
    });
    const children_2 = ofArray([createElement("h1", createObj(toList(delay(() => (calcState.Data.ResultNaN ? singleton(["children", "NaN"]) : (calcState.Data.ResultInf ? singleton(["children", ((compare(calcState.Data.DisplayNumber, 0n) < 0) ? "-" : "") + "Inf"]) : singleton(["children", int64ToString(calcState.Data.DisplayNumber)]))))))), (children = ofArray([createBtn("number", new Msg(0, [toInt64(fromInt32(1))]), "1"), createBtn("number", new Msg(0, [toInt64(fromInt32(2))]), "2"), createBtn("number", new Msg(0, [toInt64(fromInt32(3))]), "3"), createBtn("operator", new Msg(2, [new Operation(1, [])]), "+"), createBtn("number", new Msg(0, [toInt64(fromInt32(4))]), "4"), createBtn("number", new Msg(0, [toInt64(fromInt32(5))]), "5"), createBtn("number", new Msg(0, [toInt64(fromInt32(6))]), "6"), createBtn("operator", new Msg(2, [new Operation(2, [])]), "-"), createBtn("number", new Msg(0, [toInt64(fromInt32(7))]), "7"), createBtn("number", new Msg(0, [toInt64(fromInt32(8))]), "8"), createBtn("number", new Msg(0, [toInt64(fromInt32(9))]), "9"), createBtn("operator", new Msg(2, [new Operation(4, [])]), "*"), createBtn("clear", new Msg(1, []), "CE"), createBtn("number", new Msg(0, [toInt64(fromInt32(0))]), "0"), createBtn("equals", new Msg(3, []), "="), createBtn("operator", new Msg(2, [new Operation(3, [])]), "/")]), createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children)),
    }))]);
    return createElement("div", {
        children: Interop_reactApi.Children.toArray(Array.from(children_2)),
    });
}

ProgramModule_run(Program_withReactSynchronous("app", ProgramModule_mkSimple(init, update, view)));

