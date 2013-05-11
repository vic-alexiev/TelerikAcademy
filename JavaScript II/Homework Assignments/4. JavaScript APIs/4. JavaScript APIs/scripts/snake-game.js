/*
 * The original source code can be found at
 * http://red-root.com/sandbox/snake/game.html
 */
var snakeGame = function (canvas) {

    // get canvas and context
    var canvas = $(canvas)[0];
    var context = canvas.getContext("2d");

    // enumerations
    var Direction = Object.freeze({
        "LEFT": 0,
        "UP": 1,
        "RIGHT": 2,
        "DOWN": 3
    });

    var CELL_SIZE = 20;

    // Actually, the snake moves in a matrix.
    // canvas.width / CELL_SIZE yields the number
    // of columns and canvas.height / CELL_SIZE -
    // the number of rows.
    var COLS = canvas.width / CELL_SIZE;
    var ROWS = canvas.height / CELL_SIZE;

    // the number of segments added to the snake's body
    // after eating an apple
    var GROWTH = 5;

    // the snake is an array of segments
    var snakeSegments;
    // the direction in which the snake is crawling
    var crawlingDirection;
    // how much the snake will grow after eating an apple
    var segmentsToGrow;
    // used in the game loop
    var timer;
    // the apple object (with its coordinates)
    var apple;
    // current score
    var score;

    // start method, inits the game
    function startGame() {
        setupGame();
        listenForKeyboardEvents();
        showScores();
        requestInterval(gameLoop, 100);
    };

    //reset game
    function resetGame() {
        addScore(score);
        setupGame();
    };

    function setupGame() {
        crawlingDirection = Direction.RIGHT;
        score = 0;

        snakeSegments = [];
        snakeSegments.unshift(new Segment(4, 4));

        segmentsToGrow = GROWTH;

        setScore();
        placeApple();
    };

    function listenForKeyboardEvents() {

        $(document).keydown(function (e) {
            switch (e.keyCode) {
                case 37:
                    // left arrow
                    crawlingDirection = (crawlingDirection === Direction.RIGHT) ? Direction.RIGHT : Direction.LEFT;
                    break;
                case 38:
                    // up arrow
                    crawlingDirection = (crawlingDirection === Direction.DOWN) ? Direction.DOWN : Direction.UP;
                    break;
                case 39:
                    // right arrow
                    crawlingDirection = (crawlingDirection === Direction.LEFT) ? Direction.LEFT : Direction.RIGHT;
                    break;
                case 40:
                    // down arrow
                    crawlingDirection = (crawlingDirection === Direction.UP) ? Direction.UP : Direction.DOWN;
                    break;
            }
        });
    };

    // game loop funtion, runs every 100 milliseconds
    function gameLoop() {
        advanceSnake();
        checkForCollisions();
        clearCanvas();
        drawSnake();
        drawApple();
    };

    // Adds a new segment in front of the current head segment
    // and chops the tail if the snake doesn't grow. If the snake
    // grows, just decrement the number of segments which remain
    // to be added.
    function advanceSnake() {
        var head = snakeSegments[0];

        switch (crawlingDirection) {
            case Direction.UP:
                snakeSegments.unshift(new Segment(head.row - 1, head.col));
                break;
            case Direction.RIGHT:
                snakeSegments.unshift(new Segment(head.row, head.col + 1));
                break;
            case Direction.DOWN:
                snakeSegments.unshift(new Segment(head.row + 1, head.col));
                break;
            case Direction.LEFT:
                snakeSegments.unshift(new Segment(head.row, head.col - 1));
                break;
        }

        if (segmentsToGrow === 0) {
            // no growth - chop the tail
            snakeSegments.pop();
        } else {
            // still needs to grow
            segmentsToGrow--;
        }
    };

    // Checks for collisions between the head and the apple or 
    // between the head and the sides.
    function checkForCollisions() {
        var head = snakeSegments[0];

        // check for collision with the apple
        if (head.row === apple.row && head.col === apple.col) {
            segmentsToGrow += GROWTH;
            score += 1;
            setScore();
            placeApple();
        }

        // check for collision with the sides
        if (head.row === -1 || head.col === -1 ||
            head.row >= ROWS || head.col >= COLS) {
            resetGame();
        }

        // check for collison with itself
        if (inSnakeBody(head.row, head.col, false)) {
            resetGame();
        }
    };

    // empty canvas to prepare for drawing
    function clearCanvas() {
        context.clearRect(0, 0, canvas.width, canvas.height);
    };

    // draws the snake based on array
    function drawSnake() {
        var length = snakeSegments.length;

        for (var i = 0; i < length; i++) {
            var color = "#d00";

            if (i != 0) {
                color = "hsl(" + (Math.round((i / length) * 360)) + ", 60%, 50%)";
            }

            drawSegment(snakeSegments[i], color);
        }
    };

    // place the apple
    function placeApple() {
        var row = Math.round(Math.random() * (ROWS - 1));
        var col = Math.round(Math.random() * (COLS - 1));

        if (inSnakeBody(row, col, true)) {
            // keep invoking the function (recursively)
            // until a suitable (i.e. outside the snake's body) 
            // position for the apple is found
            placeApple();
        } else {
            apple = { row: row, col: col };
        }
    };

    // draw the apple
    function drawApple() {
        drawInCell(apple.row, apple.col, function () {
            context.fillStyle = "red";
            context.beginPath();
            context.arc(CELL_SIZE / 2, CELL_SIZE / 2,
					CELL_SIZE / 2, 0, 2 * Math.PI, true);
            context.fill();
        });
    };

    // draw a single segment on the canvas
    function drawSegment(segment, color) {
        drawInCell(segment.row, segment.col, function () {
            context.fillStyle = color ? color : "black";
            context.beginPath();
            context.rect(0, 0, CELL_SIZE, CELL_SIZE);
            context.fill();
        });
    };

    // draw in cell, translates to a location
    // and runs the callback
    function drawInCell(row, col, callback) {
        var x = col * CELL_SIZE;
        var y = row * CELL_SIZE;

        // save the state of context onto a stack
        context.save();
        // move to correct location
        context.translate(x, y);
        callback();
        // reverts changes
        context.restore();
    };

    // Checks if the cell is part of the snake's body
    // (the head included / excluded).
    function inSnakeBody(row, col, includeHead) {
        var length = snakeSegments.length;
        var i = includeHead ? 0 : 1;

        for (i; i < length; i++) {
            if (row === snakeSegments[i].row && col === snakeSegments[i].col) {
                return true;
            }
        }

        return false;
    };

    // A constructor for segment objects
    function Segment(row, col) {
        this.row = row;
        this.col = col;
    }

    ///// score functions ////

    // Displays the score.
    function setScore() {
        $("h2 span").text(score);
    }

    // Displays the scoreboard.
    function showScores() {
        if (typeof (localStorage) == "undefined") {
            alert("You browser doesn\'t support HTML5 localStorage, so scoring the game is not possible.");
        } else {
            $("#scores").fadeIn("slow");

            if (localStorage.getItem("snakeScores") != null) {
                updateScores();
            } else {
                var newli = $("<li></li>").text("You have no scores yet.");
                $("#scores ol").append(newli);
            }
        }
    };

    // Updates the highest scores.
    function addScore(score) {

        var stored = localStorage.getItem("snakeScores");

        if (localStorage.getItem("snakeScores") != null) {

            var scores = stored.split("xxx").map(Number);

            // add new score 
            scores.push(parseInt(score));

            // sort as numbers in descending order
            scores.sort(function (a, b) { return a - b; }).reverse();

            // now pop off the bottom result
            while (scores.length > 5) {
                scores.pop();
            }

            localStorage.setItem("snakeScores", scores.join("xxx"));

        } else {
            localStorage.setItem("snakeScores", score);
        }

        updateScores();
    };

    // Puts the latest scores on the list
    function updateScores() {

        var scores = localStorage.getItem("snakeScores").split("xxx");
        var ol = $("#scores ol");

        // remove all current ones
        ol.find("li").fadeOut("slow").remove();

        for (var i = 0; i < 5; i++) {
            ol.append($('<li></li>').html(scores[i]));
        }
    };

    return {
        start: startGame
    };
};

// clear scores list
function clearScores() {
    try {
        localStorage.removeItem("snakeScores");
        $("#scores ol li").fadeOut("slow").remove();
    } catch (e) {
        console.log(e);
    }
};

// launch
$(function () {
    window.game = snakeGame("#game");
    game.start();
});

// utility functions thanks to Joe Lambert @joelambert and Paul Irish
window.requestAnimFrame = (function () {
    return window.requestAnimationFrame ||
        window.webkitRequestAnimationFrame ||
        window.mozRequestAnimationFrame ||
        window.oRequestAnimationFrame ||
        window.msRequestAnimationFrame ||
        function (/* function */ callback, /* DOMElement */ element) {
            return window.setTimeout(callback, 1000 / 60);
        };
})();

window.requestInterval = function (callback, delay) {
    if (!window.requestAnimationFrame &&
        !window.webkitRequestAnimationFrame &&
        !window.mozRequestAnimationFrame &&
        !window.oRequestAnimationFrame &&
        !window.msRequestAnimationFrame) {

        return window.setInterval(callback, delay);
    }

    var start = new Date().getTime();
    var handle = new Object();

    function loop() {
        var current = new Date().getTime(),
        delta = current - start;

        if (delta >= delay) {
            callback.call();
            start = new Date().getTime();
        }

        handle.value = requestAnimFrame(loop);
    };

    handle.value = requestAnimFrame(loop);
    return handle;
};

window.clearRequestInterval = function (handle) {
    window.cancelAnimationFrame ? window.cancelAnimationFrame(handle.value) :
    window.webkitCancelRequestAnimationFrame ? window.webkitCancelRequestAnimationFrame(handle.value) :
    window.mozCancelRequestAnimationFrame ? window.mozCancelRequestAnimationFrame(handle.value) :
    window.oCancelRequestAnimationFrame ? window.oCancelRequestAnimationFrame(handle.value) :
    window.msCancelRequestAnimationFrame ? msCancelRequestAnimationFrame(handle.value) :
    clearInterval(handle);
};

window.cancelRequestAnimFrame = (function () {
    return window.cancelAnimationFrame ||
        window.webkitCancelRequestAnimationFrame ||
        window.mozCancelRequestAnimationFrame ||
        window.oCancelRequestAnimationFrame ||
        window.msCancelRequestAnimationFrame ||
        clearTimeout;
})();