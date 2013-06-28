module("SnakePiece.init");
test("should set correct values",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, direction = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, direction);
      equal(piece.position, position)
      equal(piece.size, 15);
      equal(piece.speed, speed);
      equal(piece.direction, direction);
  });

module("SnakePiece.move");
test("When direction is 0, decrease x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, direction = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, direction);
      piece.move();
      position.x - speed;
      deepEqual(piece.position, position);
  });

test("When  direction is 1, decrease y",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, direction = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, direction);
      piece.move();
      position.y - speed;
      deepEqual(piece.position, position);
  });

test("When  direction is 2, increase x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.move();
      position.x + speed;
      deepEqual(piece.position, position);
  });

test("When  direction is 3, increase x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.move();
      position.y + speed;
      deepEqual(piece.position, position);
  });