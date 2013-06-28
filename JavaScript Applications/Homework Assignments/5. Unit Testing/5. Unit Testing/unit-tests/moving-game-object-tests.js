(function () {

    module("MovingGameObject.init");

    test("should set correct values", function () {
        var position = { x: 0, y: 0 };
        var size = 10;
        var fillColor = "#abcdef";
        var strokeColor = "#abcdef";
        var speed = 11;
        var direction = 0;

        var movingObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, direction);

        deepEqual(movingObject.position, position, "We expect position to be set correctly.");
        equal(movingObject.size, size, "We expect size to be set correctly.");
        equal(movingObject.fillColor, fillColor, "We expect fill color to be set correctly.");
        equal(movingObject.strokeColor, strokeColor, "We expect stroke color to be set correctly.");
        equal(movingObject.speed, speed, "We expect speed to be set correctly.");
        equal(movingObject.direction, direction, "We expect direction to be set correctly.");
    });

    test("should set correct values", function () {
        var position = { x: 15, y: 25 };
        var size = 10;
        var fillColor = "#abcdef";
        var strokeColor = "#abcdef";
        var speed = 11;
        var direction = 0;

        var movingObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, direction);
        var otherMovingObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, direction);

        deepEqual(movingObject, otherMovingObject);
    });

    var movingGameObject;

    module("MovingGameObject.move", {
        setup: function () {
            var position = { x: 100, y: 100 };
            var size = 1;
            var fillColor = "#abcdef";
            var strokeColor = "#abcdef";
            var speed = 3;
            var direction = 0;

            movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, direction);
        }
    });

    test("move to the left", function () {
        movingGameObject.direction = 0;

        var oldX = movingGameObject.position.x;
        var oldY = movingGameObject.position.y;

        movingGameObject.move();

        var expectedPosition = { x: oldX - movingGameObject.speed, y: oldY };

        deepEqual(movingGameObject.position, expectedPosition);
    });

    test("move to the left, start from negative x and negative y", function () {
        movingGameObject.direction = { x: -10, y: -10 };
        movingGameObject.direction = 0;

        var oldX = movingGameObject.position.x;
        var oldY = movingGameObject.position.y;

        movingGameObject.move();

        var expectedPosition = { x: oldX - movingGameObject.speed, y: oldY };

        deepEqual(movingGameObject.position, expectedPosition);
    });

    test("move to the left, start from negative x and positive y", function () {
        movingGameObject.direction = { x: -10, y: 10 };
        movingGameObject.direction = 0;

        var oldX = movingGameObject.position.x;
        var oldY = movingGameObject.position.y;

        movingGameObject.move();

        var expectedPosition = { x: oldX - movingGameObject.speed, y: oldY };

        deepEqual(movingGameObject.position, expectedPosition);
    });

    test("move upward", function () {
        movingGameObject.direction = 1;

        var oldX = movingGameObject.position.x;
        var oldY = movingGameObject.position.y;

        movingGameObject.move();

        var expectedPosition = { x: oldX, y: oldY - movingGameObject.speed };

        deepEqual(movingGameObject.position, expectedPosition);
    });

    test("move right", function () {
        movingGameObject.direction = 2;

        var oldX = movingGameObject.position.x;
        var oldY = movingGameObject.position.y;

        movingGameObject.move();

        var expectedPosition = { x: oldX + movingGameObject.speed, y: oldY };

        deepEqual(movingGameObject.position, expectedPosition);
    });

    test("move down", function () {
        movingGameObject.direction = 3;

        var oldX = movingGameObject.position.x;
        var oldY = movingGameObject.position.y;

        movingGameObject.move();

        var expectedPosition = { x: oldX, y: oldY + movingGameObject.speed };

        deepEqual(movingGameObject.position, expectedPosition);
    });

    module("MovingGameObject.changeDirection", {
        setup: function () {
            var position = { x: 100, y: 100 };
            var size = 1;
            var fillColor = "#abcdef";
            var strokeColor = "#abcdef";
            var speed = 3;
            var direction = 0;

            movingGameObject = new snakeGame.MovingGameObject(position, size, fillColor, strokeColor, speed, direction);
        }
    });

    test("change direction from 0 to 0 (no change)", function () {
        movingGameObject.direction = 0;
        var newDirection = 0;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, newDirection);
    });

    test("change direction from 0 to 1", function () {
        movingGameObject.direction = 0;
        var newDirection = 1;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, newDirection);
    });

    test("change direction from 0 to 2 (no change)", function () {
        movingGameObject.direction = 0;
        var newDirection = 2;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, 0);
    });

    test("change direction from 0 to 3", function () {
        movingGameObject.direction = 0;
        var newDirection = 3;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, newDirection);
    });

    test("change direction from 1 to 0", function () {
        movingGameObject.direction = 1;
        var newDirection = 0;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, newDirection);
    });

    test("change direction from 1 to 1 (no change)", function () {
        movingGameObject.direction = 1;
        var newDirection = 1;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, newDirection);
    });

    test("change direction from 1 to 2", function () {
        movingGameObject.direction = 1;
        var newDirection = 2;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, newDirection);
    });

    test("change direction from 1 to 3 (no change)", function () {
        movingGameObject.direction = 1;
        var newDirection = 3;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, 1);
    });

    test("change direction from 2 to 0 (no change)", function () {
        movingGameObject.direction = 2;
        var newDirection = 0;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, 2);
    });

    test("change direction from 2 to 1", function () {
        movingGameObject.direction = 2;
        var newDirection = 1;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, newDirection);
    });

    test("change direction from 2 to 2 (no change)", function () {
        movingGameObject.direction = 2;
        var newDirection = 2;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, newDirection);
    });

    test("change direction from 2 to 3", function () {
        movingGameObject.direction = 2;
        var newDirection = 3;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, newDirection);
    });

    test("change direction from 3 to 0", function () {
        movingGameObject.direction = 3;
        var newDirection = 0;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, newDirection);
    });

    test("change direction from 3 to 1 (no change)", function () {
        movingGameObject.direction = 3;
        var newDirection = 1;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, 3);
    });

    test("change direction from 3 to 2", function () {
        movingGameObject.direction = 3;
        var newDirection = 2;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, newDirection);
    });

    test("change direction from 3 to 3 (no change)", function () {
        movingGameObject.direction = 3;
        var newDirection = 3;

        movingGameObject.changeDirection(newDirection);

        equal(movingGameObject.direction, newDirection);
    });

})();