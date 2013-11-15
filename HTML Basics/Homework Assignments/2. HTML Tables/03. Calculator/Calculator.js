/* This Script is from www.htmlfreecodes.com, Coded by: Krishna Eydat */

var keypad = document.keypad;
var accumulate = 0;
var flagNewNum = false;
var pendingOp = "";

function numPressed(num) {
    if (flagNewNum) {
        keypad.result.value = num;
        flagNewNum = false;
    }
    else {
        if (keypad.result.value == "0")
            keypad.result.value = num;
        else
            keypad.result.value += num;
    }
}

function operation(op) {
    var result = keypad.result.value;
    if (flagNewNum && pendingOp != "=");
    else {
        flagNewNum = true;
        if (pendingOp == '+')
            accumulate += parseFloat(result);
        else if (pendingOp == '-')
            accumulate -= parseFloat(result);
        else if (pendingOp == '/')
            accumulate /= parseFloat(result);
        else if (pendingOp == '*')
            accumulate *= parseFloat(result);
        else
            accumulate = parseFloat(result);
        keypad.result.value = accumulate;
        pendingOp = op;
    }
}

function decimal() {
    var curResult = keypad.result.value;
    if (flagNewNum) {
        curResult = "0.";
        flagNewNum = false;
    }
    else {
        if (curResult.indexOf(".") == -1)
            curResult += ".";
    }
    keypad.result.value = curResult;
}

function clearEntry() {
    result = "0";
    keypad.result.value = "0";
    flagNewNum = true;
}

function clearAll() {
    accumulate = 0;
    pendingOp = "";
    clearEntry();
}