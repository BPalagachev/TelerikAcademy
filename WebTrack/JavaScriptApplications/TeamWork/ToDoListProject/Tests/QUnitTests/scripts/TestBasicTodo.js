test("Initializing correctly basic todo id", function () {
    var expirable2 = new BasicTodo("id-test", "title-test", "completed-test");
    var expectedId = "id-test";
    deepEqual(expirable2.id, expectedId);
});

test("Initializing correctly basic todo title", function () {
    var expirable2 = new BasicTodo("id-test", "title-test", "completed-test");
    var expectedTitle = "title-test";
    deepEqual(expirable2.title, expectedTitle);
});

test("Initializing correctly basic todo completed", function () {
    var expirable2 = new BasicTodo("id-test", "title-test", "completed-test");
    var expectedCompleted = "completed-test";
    deepEqual(expirable2.completed, expectedCompleted);
});

test("Test initializing correctly same basic todos", function () {
    var expirable2 = new BasicTodo("id-test", "title", "completed");
    var expirable3 = new BasicTodo("id-test", "title", "completed");
    deepEqual(expirable2, expirable3, "The 2 test are equal");
});