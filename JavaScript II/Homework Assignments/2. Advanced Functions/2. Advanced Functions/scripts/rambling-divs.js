var ramblingDivs = (function () {

    var DIV_WIDTH = 50;
    var DIV_HEIGHT = 50;
    var MIN_TOP = 200;
    var MIN_LEFT = 200;
    var MAX_TOP = screen.height - 300;
    var MAX_LEFT = screen.width - 100;
    var BORDER_RADIUS = 30;
    var BORDER_WIDTH = 1;
    var MAJOR_SEMIAXIS = 230;
    var MINOR_SEMIAXIS = 130;
    var ELLIPSE_DEGREES_INCREMENT = 6;
    var RECTANGLE_DEGREES_INCREMENT = 3;

    var ellipseDegreePositions = [];
    var rectangleDegreePositions = [];

    var ellipseCenters = [];
    var rectangleCenters = [];

    var divsMovingInEllipse = document.getElementsByClassName("div-in-ellipse");
    var divsMovingInRectangle = document.getElementsByClassName("div-in-rectangle");

    // shim layer with setTimeout fallback 
    window.requestAnimFrame = (function () {
        return window.requestAnimationFrame ||
            window.webkitRequestAnimationFrame ||
            window.mozRequestAnimationFrame ||
            window.oRequestAnimationFrame ||
            window.msRequestAnimationFrame ||
            function (callback) {
                window.setTimeout(callback, 1000 / 60);
            };
    })();

    window.requestAnimFrame(setDivsInMotion);

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

    function setElementStyle(
            element,
            width,
            height,
            minTop,
            minLeft,
            maxTop,
            maxLeft,
            borderRadius,
            borderWidth) {

        // set the width
        element.style.width = width + "px";

        // set the height
        var heightInPixels = height + "px";
        element.style.height = heightInPixels;
        element.style.lineHeight = heightInPixels;

        // set the background color
        element.style.backgroundColor = generateRandomColor();

        // set the font color
        element.style.color = generateRandomColor();

        // set the screen position
        element.style.position = "absolute";

        var top = getRandomInt(minTop, maxTop - height);
        element.style.top = top + "px";

        var left = getRandomInt(minLeft, maxLeft - width);
        element.style.left = left + "px";

        // set the text
        element.innerHTML = element.tagName;
        element.style.textAlign = "center";

        // set the border radius
        var radiusInPixels = borderRadius + "px";

        element.style.borderRadius = radiusInPixels; // standard
        element.style.MozBorderRadius = radiusInPixels; // Mozilla
        element.style.WebkitBorderRadius = radiusInPixels; // WebKit

        // set the border
        var borderWidthInPixels = borderWidth + "px";

        element.style.border = borderWidthInPixels + " solid " + generateRandomColor();
    }

    function moveInEllipse(element, centerTop, centerLeft, majorSemiaxis, minorSemiaxis, angleInDegrees) {
        var theta = angleInDegrees * Math.PI / 180;
        var left = parseInt(centerLeft + majorSemiaxis * Math.sin(theta));
        element.style.left = left + "px";

        var top = parseInt(centerTop - minorSemiaxis * Math.cos(theta));
        element.style.top = top + "px";
    }

    /**
     * @see The forum discussion in <a href="http://math.stackexchange.com/questions/69099/equation-of-a-rectangle">Stack Exchange</a>. 
     */
    function moveInRectangle(element, centerTop, centerLeft, halfWidth, halfHeight, angleInDegrees) {
        var theta = angleInDegrees * Math.PI / 180;
        var cosTheta = Math.cos(theta);
        var sinTheta = Math.sin(theta);

        var left = parseInt(centerLeft + halfWidth * (Math.abs(cosTheta) * cosTheta + Math.abs(sinTheta) * sinTheta));
        element.style.left = left + "px";

        var top = parseInt(centerTop + halfHeight * (Math.abs(cosTheta) * cosTheta - Math.abs(sinTheta) * sinTheta));
        element.style.top = top + "px";
    }

    function setDivsInMotion() {
        window.requestAnimFrame(setDivsInMotion);

        for (var i = 0; i < ellipseDegreePositions.length; i++) {
            ellipseDegreePositions[i] += ELLIPSE_DEGREES_INCREMENT;
            if (ellipseDegreePositions[i] >= 360) {
                ellipseDegreePositions[i] = ellipseDegreePositions[i] % 360;
            }

            moveInEllipse(divsMovingInEllipse[i], ellipseCenters[i].top, ellipseCenters[i].left, MAJOR_SEMIAXIS, MINOR_SEMIAXIS, ellipseDegreePositions[i]);
        }

        for (var i = 0; i < rectangleDegreePositions.length; i++) {
            rectangleDegreePositions[i] += RECTANGLE_DEGREES_INCREMENT;
            if (rectangleDegreePositions[i] >= 360) {
                rectangleDegreePositions[i] = rectangleDegreePositions[i] % 360;
            }

            moveInRectangle(divsMovingInRectangle[i], rectangleCenters[i].top, rectangleCenters[i].left, MAJOR_SEMIAXIS, MINOR_SEMIAXIS, rectangleDegreePositions[i]);
        }
    }

    function add(orbitType) {

        var ramblingDiv = document.createElement("div");

        setElementStyle(ramblingDiv, DIV_WIDTH, DIV_HEIGHT, MIN_TOP, MIN_LEFT, MAX_TOP, MAX_LEFT, BORDER_RADIUS, BORDER_WIDTH);

        if (orbitType === "ellipse") {
            ramblingDiv.classList.add("div-in-ellipse");
            ellipseDegreePositions.push(0);
            ellipseCenters.push({
                top: parseInt(ramblingDiv.style.top),
                left: parseInt(ramblingDiv.style.left) - MAJOR_SEMIAXIS
            });
        } else {
            ramblingDiv.classList.add("div-in-rectangle");
            rectangleDegreePositions.push(0);
            rectangleCenters.push({
                top: parseInt(ramblingDiv.style.top),
                left: parseInt(ramblingDiv.style.left) - MAJOR_SEMIAXIS
            });
        }

        var field = document.getElementById("field");
        field.appendChild(ramblingDiv);
    }

    return {
        add: add
    };
})();