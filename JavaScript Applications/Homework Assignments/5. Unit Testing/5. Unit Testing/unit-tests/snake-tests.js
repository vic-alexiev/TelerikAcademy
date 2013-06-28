module("Snake.init");

test("When snake is initialized, should set the correct values", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 15;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    deepEqual(snake.position, position, "Position is set");
    equal(snake.speed, speed, "Speed is set");
    equal(snake.direction, direction, "Direction is set");
});

test("When snake is initialized, should contain 5 SnakePieces", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 15;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    ok(snake.pieces, "SnakePieces are created");
    equal(snake.pieces.length, 5, "Five SnakePieces are created");
    ok(snake.head, "HeadSnakePiece is created");
});


module("Snake.consume");
test("When object is Food, should grow", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);
    var size = snake.size;
    snake.consume(new snakeGame.Food());
    var actual = snake.size;
    var expected = size + 1;
    equal(actual, expected);
});

test("When object is SnakePiece, should die", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.consume(new snakeGame.SnakePiece());
    ok(isDead, "The snake is dead");
});

test("When object is Obstacle, should die", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.consume(new snakeGame.Obstacle());
    ok(isDead, "The snake is dead");
});

module("Snake.grow");
test("When grow() is invoked the snake should become longer", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var oldsize = snake.size;
    snake.grow();
    var newsize = snake.size;
    equal(newsize, oldsize + 1);
});

module("Snake.checkSelfBite");
test("The snake dies when it bites itself", function () {
    var headPosition = { x: 0, y: 0 };

    var snake = new snakeGame.Snake(headPosition, 5, 0);
    snake.pieces[1].position.x = headPosition.x;
    snake.pieces[1].position.y = headPosition.y;

    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.checkSelfBite();
    ok(isDead, "The snake has bitten itself");
});