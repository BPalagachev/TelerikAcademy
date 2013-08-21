test("Initializing correctly expirable todo id", function () {
    var expirable2 = new ExpirableTodo("id-test", "title-test", "completed-test", "06/08/2013");
    var expectedId = "id-test";
    deepEqual(expirable2.id, expectedId);
});

test("Initializing correctly expirable todo title", function () {
    var expirable2 = new ExpirableTodo("id-test", "title-test", "completed-test", "06/08/2013");
    var expectedTitle = "title-test";
    deepEqual(expirable2.title, expectedTitle);
});

test("Initializing correctly expirable todo completed", function () {
    var expirable2 = new ExpirableTodo("id-test", "title-test", "completed-test", "06/08/2013");
    var expectedCompleted = "completed-test";
    deepEqual(expirable2.completed, expectedCompleted);
});

test("Initializing correctly expirable todo date", function () {
    var expirable2 = new ExpirableTodo("id-test", "title-test", "completed-test", "06/08/2013");
    var expectedDate = "06/08/2013";
    deepEqual(expirable2.expirationDate, expectedDate);
});

test("Initializing correctly expirable todo remaining", function () {
    var expirable2 = new ExpirableTodo("id-test", "title-test", "completed-test", "06/08/2013", "8");
    var expectedRemaining = "8";
    deepEqual(expirable2.remaining, expectedRemaining);
});

test("Test initializing correctly same expirable todos", function () {
    var expirable2 = new ExpirableTodo("id-test", "title", "completed", "06/08/2013");
    var expirable3 = new ExpirableTodo("id-test", "title", "completed", "06/08/2013");
    deepEqual(expirable2, expirable3, "The 2 test are equal");
});