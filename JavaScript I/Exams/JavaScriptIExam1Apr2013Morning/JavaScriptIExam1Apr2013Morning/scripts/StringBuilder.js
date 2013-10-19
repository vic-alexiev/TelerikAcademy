// Initializes a new instance of the StringBuilder class.
function StringBuilder() {

    var chunkChars = [];
    var length = 0;

    // Appends the given value to the end of this instance.
    this.append = function (value) {
        value = verify(value);

        var len = value.length;

        if (len > 0) {
            for (var i = 0; i < len; i++) {
                chunkChars[length++] = value[i];
            }
        }

        return this;
    };

    // Appends a formatted string to the stringbuilder's internal array.  
    this.appendFormat = function (value, arg0, arg1, arg2) {
        for (var i = 0, len = arguments.length; i < len - 1; i++) {
            var pattern = "\\{" + i + "\\}";
            var regex = new RegExp(pattern, "g");

            value = value.replace(regex, arguments[i + 1]);
        }

        return this.append(value);
    };

    this.appendLine = function (value) {
        this.append(value);
        return this.append("\r\n");
    };

    // Inserts a String in the array buffer
    this.insert = function (index, value) {
        value = verify(value);

        var len = value.length;

        if (len > 0) {
            for (var i = 0; i < len; i++) {
                chunkChars.splice(index + i, 0, value[i]);
            }

            length = chunkChars.length;
        }

        return this;
    }

    // Removes a String from the array buffer
    this.remove = function (index, count) {

        if (count > 0) {
            chunkChars.splice(index, count);
            length = chunkChars.length;
        }

        return this;
    }

    // Clears the array buffer.
    this.clear = function () {
        chunkChars = [];
        length = 0;
        return this;
    };

    this.isEmpty = function () {
        return length === 0;
    };

    this.getLength = function () {
        return length;
    }

    this.setLength = function (value) {
        chunkChars.length = value;
        length = value;
    }

    // Converts this instance to a String.
    this.toString = function () {
        return chunkChars.join("");
    }

    var verify = function (value) {
        if (!defined(value)) return "";
        if (getType(value) != getType(new String())) return String(value);
        return value;
    };

    var defined = function (value) {
        return value != null && typeof (value) != "undefined";
    };

    var getType = function (instance) {
        if (!defined(instance.constructor)) throw Error("Unexpected object type");
        var type = String(instance.constructor).match(/function\s+(\w+)/);

        return defined(type) ? type[1] : "undefined";
    };
}