var consoleEx = (function () {
    // for private use
    function formatString(value, optionalParams) {
        var result = "";

        if (value) {
            result = value.toString();

            if (optionalParams) {
                for (var i = 0, len = arguments.length; i < len - 1; i++) {
                    var pattern = "\\{" + i + "\\}";
                    var regex = new RegExp(pattern, "g");

                    result = result.replace(regex, arguments[i + 1].toString());
                }
            }
        }

        return result;
    }

    function writeLine(value, optionalParams) {
        var result = formatString(value, optionalParams);
        console.log(result);
    }

    function writeError(value, optionalParams) {
        var result = formatString(value, optionalParams);
        console.error(result);
    }

    function writeWarning(value, optionalParams) {
        var result = formatString(value, optionalParams);
        console.warn(result);
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    }
})();