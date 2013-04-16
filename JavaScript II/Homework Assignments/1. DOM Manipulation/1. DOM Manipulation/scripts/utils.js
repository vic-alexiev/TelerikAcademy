// Returns a random integer between min and max
// Using Math.round() will give you a non-uniform distribution!
function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function generateRandomColor() {
    var red = getRandomInt(0, 255);
    var green = getRandomInt(0, 255);
    var blue = getRandomInt(0, 255);

    return "rgb(" + red + ", " + green + ", " + blue + ")";
}