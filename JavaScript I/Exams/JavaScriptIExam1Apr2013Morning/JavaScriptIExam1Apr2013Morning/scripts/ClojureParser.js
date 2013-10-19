// global variables
var stack;
var functions = {
    "+": function (a, b) {
        return a + b;
    },

    "-": function (a, b) {
        return a - b;
    },

    "*": function (a, b) {
        return a * b;
    },

    "/": function (a, b) {
        return parseInt(a / b);
    }
};

function evalList(tokens) {
    var op = tokens[0];
    if (op === "def") {
        stack[tokens[1]] = defined(stack[tokens[2]]) ? stack[tokens[2]] : parseInt(tokens[2]);

        // in this case the function returns "undefined"
    }
    else {
        var result = defined(stack[tokens[1]]) ? stack[tokens[1]] : parseInt(tokens[1]);

        var len = tokens.length;
        for (var i = 2; i < len; i++) {
            result = functions[op](result, defined(stack[tokens[i]]) ? stack[tokens[i]] : parseInt(tokens[i]));
        }

        return result;
    }
}

function defined(value) {
    return value != null && typeof value != "undefined";
};

function isInfinity(value) {
    return value === Infinity || value === -Infinity;
}

function parseClojure(command) {
    debugger;
    // add spaces so that the command can be split correctly into its parts
    command = command.replace(/\(/g, " ( ").replace(/\)/g, " ) ");
    var expression = command.split(" ");

    var len = expression.length;

    var index = 0;
    var tokenLists = [];
    var currentListIndex = -1;

    while (index < len) {
        // work only with the non-empty tokens
        if (expression[index].length > 0) {
            if (expression[index] === "(") {
                currentListIndex++;
                tokenLists[currentListIndex] = [];
            }
            else if (expression[index] === ")") {
                // evaluate the list at the top of the stack
                var listValue = evalList(tokenLists[currentListIndex]);

                // This is the bottom-level list or a division by zero has occurred.
                // In both cases return the value.
                if (currentListIndex === 0 ||
                    defined(listValue) &&
                    (isInfinity(listValue) || isNaN(listValue))) {
                    return listValue;
                }

                // push the value of the nested list at the end of the parent list
                tokenLists[--currentListIndex].push(listValue);
            }
            else {
                tokenLists[currentListIndex].push(expression[index]);
            }
        }

        index++;
    }
}

function Solve(params) {
    // initialize the global variables
    stack = {};

    var commandsCount = params.length;
    var commandResult;

    for (var i = 0; i < commandsCount; i++) {
        commandResult = parseClojure(params[i]);

        // a division by zero has occurred, return the value (Infinity)
        // and terminate the program
        if (defined(commandResult) &&
            (isInfinity(commandResult) || isNaN(commandResult))) {
            return "Division by zero! At Line:" + (i + 1);
        }

        if (i === commandsCount - 1) {
            return commandResult;
        }
    }
}