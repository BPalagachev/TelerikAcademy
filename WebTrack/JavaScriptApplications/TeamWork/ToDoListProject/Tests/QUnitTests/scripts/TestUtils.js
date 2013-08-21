test("Test lenght of generated random string", function () {
    var randomString = Utils.uuid();
    var lengthOfGeneratedString = randomString.length
    equal(lengthOfGeneratedString, 36);
});

test("Test if the generated strings are not the same", function () {
    var randomString1 = Utils.uuid();
    var randomString2 = Utils.uuid();
    var areSame = randomString1 == randomString2;
    equal(areSame, false);
});

test("Test pluralize work with count 1", function () {
    var testWord = "Single";
    var count = 1;
    var resultWord = Utils.pluralize(count, testWord);
    deepEqual(testWord, resultWord);
});

test("Test pluralize work with count 3", function () {
    var testWord = "Plural";
    var count = 3;
    var resultWord = Utils.pluralize(count, testWord);
    var expectedWord = "Plurals";
    deepEqual(expectedWord, resultWord);
});

test("Test pluralize work with very big count", function () {
    var testWord = "Plural";
    var count = 3333333333333;
    var resultWord = Utils.pluralize(count, testWord);
    var expectedWord = "Plurals";
    deepEqual(expectedWord, resultWord);
});

test("Test parsing data - parse date correctly", function () {
    var inputString = "06/17/2013";
    var outputData = Utils.parseDate(inputString);
    var expectedDay = "17";
    equal(expectedDay, outputData.getDate());
});

test("Test parsing data - parse month correctly", function () {
    var inputString = "06/17/2013";
    var outputData = Utils.parseDate(inputString);
    var expectedMonth = "5";
    equal(expectedMonth, outputData.getMonth());
});

test("Test parsing data - parse year correctly", function () {
    var inputString = "06/17/2013";
    var outputData = Utils.parseDate(inputString);
    var expectedYear = "2013";
    equal(expectedYear, outputData.getFullYear());
});