module("MovingGameObject.init");
test("should set correct values",   
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.MovingGameObject(position, size, "#dedede", "#fefefe", speed, dir);
    equal(piece.position, position)
    equal(piece.size, 15);
    equal(piece.speed, speed);
    equal(piece.direction, dir);
  });

module("MovingGameObject.move");
test("Move with direction 0, x coord should decrease",
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.MovingGameObject(position, size, "#dedede", "#fefefe", speed, dir);
    piece.move();
    position.x - speed;
    deepEqual(piece.position, position);
  });
test("Move with direction 1, y coor should decrease",
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.MovingGameObject(position, size, "#dedede", "#fefefe", speed, dir);
    piece.move();
    position.y - speed;
    deepEqual(piece.position, position);
  });
test("Move with direction 2, x coords should increase",
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.MovingGameObject(position, size, "#dedede", "#fefefe", speed, dir);
    piece.move();
    position.x + speed;
    deepEqual(piece.position, position);
  });
test("Move with direction 3, y coord should increase",
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.MovingGameObject(position, size, "#dedede", "#fefefe", speed, dir);
    piece.move();
    position.y + speed;
    deepEqual(piece.position, position);
  });

module("MovingGameObject.changeDirection");
test("Direction is 0, change direction to 3(valid direction)",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.MovingGameObject(position, size, "#dedede", "#fefefe", speed, dir);
      var nextDirection = 3;
      piece.changeDirection(nextDirection);
      equal(nextDirection, piece.direction, "Snake cannot move directly in the opposite direction");
  });
module("MovingGameObject.changeDirection");
test("Direction is 3, change direction to 0(valid direction)",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 3;
      var piece = new snakeGame.MovingGameObject(position, size, "#dedede", "#fefefe", speed, dir);
      var nextDirection = 0;
      piece.changeDirection(nextDirection);
      equal(nextDirection, piece.direction, "Snake cannot move directly in the opposite direction");
  });
module("MovingGameObject.changeDirection");
test("Direction is 2, change direction to 0(invalid direction)",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 2;
      var piece = new snakeGame.MovingGameObject(position, size, "#dedede", "#fefefe", speed, dir);
      var nextDirection = 0;
      var expectedDirection = 2;
      piece.changeDirection(nextDirection);
      equal(expectedDirection, piece.direction, "Direction should not change from 2, because change from 2 - 0 is invalid");
  });