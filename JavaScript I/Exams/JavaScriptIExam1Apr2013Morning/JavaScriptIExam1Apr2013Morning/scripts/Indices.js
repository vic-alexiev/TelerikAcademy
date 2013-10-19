/*function updateStringPrototype() {
    if (!String.prototype.insert) {
        String.prototype.insert = function (startIndex, value) {
            if (index > 0) {
                return [this.slice(0, startIndex), value, this.slice(startIndex)].join("");
            }
            else {
                return value + this;
            }
        };
    }
}

function updateArrayPrototype() {
    if (!Array.prototype.insert) {
        Array.prototype.insert = function (startIndex, value) {
            return this.splice(startIndex, 0, value);
        }
    }
}*/

function defined(value) {
    return value != null && typeof (value) != "undefined";
};

function Solve1(args) {
    var array = args[1].split(" ");

    var size = array.length;

    var indices = [];

    for (var i = 0; i < size; i++) {
        indices[i] = +array[i];
    }

    var resultBuilder = [];
    var visited = [];
    var step = 0;
    var index = 0;
    var loopStart = -1;

    while (index >= 0 && index < size) {
        if (defined(visited[index])) {
            var loopStart = visited[index];
            if (loopStart > 0) {
                resultBuilder[loopStart - 1] = resultBuilder[loopStart - 1].trim();
            }
            resultBuilder.splice(loopStart, 0, "(");
            break;
        }

        visited[index] = step;
        resultBuilder.push(index + " ");

        step++;
        index = indices[index];
    }

    var len = resultBuilder.length;
    resultBuilder[len - 1] = resultBuilder[len - 1].trim();

    if (index >= 0 && index < size) {
        resultBuilder.push(")");
    }

    return resultBuilder.join("");
}

function Solve(args) {
    var array = args[1].split(" ");

    var size = array.length;

    var indices = [];

    for (var i = 0; i < size; i++) {
        indices[i] = +array[i];
    }

    var used = [];
    var loopStart = 0;
    var loopEnd = 0;
    var loopFound = false;

    while (loopStart >= 0 && loopStart < size) {
        if (used[loopStart]) {
            loopFound = true;
            break;
        }

        used[loopStart] = true;
        loopEnd = loopStart;
        loopStart = indices[loopStart];
    }

    var index = 0;
    var resultBuilder = [];

    while (index >= 0 && index < size) {
        var len = resultBuilder.length;

        if (index === loopStart && index === loopEnd && loopFound) {
            if (len > 0) {
                resultBuilder[len - 1] = resultBuilder[len - 1].trim();
            }

            resultBuilder.push("(" + index + ") ");
            break;
        }
        else if (index === loopEnd && loopFound) {
            resultBuilder.push(index + ")");
            break;
        }
        else if (index === loopStart && loopFound) {
            if (len > 0) {
                resultBuilder[len - 1] = resultBuilder[len - 1].trim();
            }
            resultBuilder.push("(" + index + " ");
        }
        else {
            resultBuilder.push(index + " ");
        }

        index = indices[index];
    }

    return resultBuilder.join("").trim();
}