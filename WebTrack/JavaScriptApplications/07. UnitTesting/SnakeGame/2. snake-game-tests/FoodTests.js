module("Food.init");
test("should set correct values",
  function () {
      var position = { x: 150, y: 150 }, size = 15;
      var piece = new snakeGame.Food(position, size);
      ok(piece);
      equal(piece.position, position)
      equal(piece.size, 15);
  });