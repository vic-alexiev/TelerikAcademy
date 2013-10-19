function fillDigits() {
    var digits = {};
    var capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    var smallLetters = "abcdefghijklmnopqrstuvwxyz";
    var counter = 0;

    for (var upperIndex = 0; upperIndex <= 25; upperIndex++) {
        digits[capitalLetters[upperIndex]] = counter++;
    }

    for (var lowerIndex = 0; lowerIndex < 6; lowerIndex++) {
        for (upperIndex = 0; upperIndex <= 25; upperIndex++) {
            if (counter < 168) {
                digits[smallLetters[lowerIndex] + capitalLetters[upperIndex]] = counter++;
            }
            else {
                return digits;
            }
        }
    }
}

function durankulakToDecimal(value, digits) {
    var len = value.length;
    var index = 0;
    var decimalNumber = 0;
    while (index < len) {
        if (value[index] === value[index].toUpperCase()) {
            var key = value[index++];
            decimalNumber = decimalNumber * 168 + digits[key];
        }
        else {
            var key = value[index++] + value[index++];
            decimalNumber = decimalNumber * 168 + digits[key];
        }
    }

    return decimalNumber;
}

function Solve(args) {
    var digits = fillDigits();
    return durankulakToDecimal(args, digits);
}