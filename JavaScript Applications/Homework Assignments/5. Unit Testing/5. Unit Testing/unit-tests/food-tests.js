module("Food.init");

test("When food is initialized, should set the correct values", function () {
    var position = {
        x: 150,
        y: 150
    };
    var size = 10;
    var food = new snakeGame.Food(position, size);

    deepEqual(food.position, position, "Position is set");
    equal(food.size, size, "Speed is set");
});

test("change food position from (150, 150) to (-100, -100)", function () {
    var position = {
        x: 150,
        y: 150
    };
    var size = 10;
    var food = new snakeGame.Food(position, size);

    var newPosition = {
        x: -100,
        y: -100
    };

    food.changePosition(newPosition);

    deepEqual(food.position, newPosition, "Position is set");
});