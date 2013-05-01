var bouncingBalls = (function () {

    var START_X = 50;
    var START_Y = 50;
    var SPEED_X = 10;
    var SPEED_Y = 10;

    var canvas;
    var context;

    // This is an array that will hold all the balls on the canvas.
    var balls = [];

    // These are the details that represent an individual ball.
    function Ball(x, y, dx, dy, radius, color) {
        this.x = x;
        this.y = y;
        this.dx = dx;
        this.dy = dy;
        this.radius = radius;
        this.color = color;
    }

    function addBall(radius, color) {
        // Create the new ball.
        var ball = new Ball(START_X, START_Y, SPEED_X, SPEED_Y, radius, color);

        // Store it in the balls array.
        balls.push(ball);
    }

    function clearBalls() {
        // Remove all the balls.
        balls = [];
    }

    function load() {
        canvas = document.getElementById("canvas");
        context = canvasPlus("canvas");

        // Redraw every 20 milliseconds.
        setTimeout(drawFrame, 20);
    }

    function drawFrame() {
        // Clear the canvas.
        context.clearRect(0, 0, canvas.width, canvas.height);
        context.beginPath();

        // Go through all the balls.
        for (var i = 0; i < balls.length; i++) {
            // Move each ball to its new position.
            var ball = balls[i];
            ball.x += ball.dx;
            ball.y += ball.dy;

            // If the ball has hit the side, bounce it.
            if ((ball.x + ball.radius > canvas.width) || (ball.x - ball.radius < 0)) {
                ball.dx = -ball.dx;
            }

            // If the ball has hit the bottom, bounce it.
            if ((ball.y + ball.radius > canvas.height) || (ball.y - ball.radius < 0)) {
                ball.dy = -ball.dy;
            }

            // Draw the ball.
            context.fillStyle = ball.color;
            context.drawCircle("fill", ball.x, ball.y, ball.radius);
        }

        // Draw the next frame in 20 milliseconds.
        setTimeout(drawFrame, 20);
    }

    return {
        load: load,
        addBall: addBall,
        clearBalls: clearBalls
    };
})();