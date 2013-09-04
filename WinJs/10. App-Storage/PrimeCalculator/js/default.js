// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;
    var appData = Windows.Storage.ApplicationData.current;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize
                // your application here.
            } else {
                // TODO: This application has been reactivated from suspension.
                // Restore application state here.
            }
            args.setPromise(WinJS.UI.processAll().then(function () {
                var workersCount = appData.localSettings["numberOfWorkers"] || 3;
                var calculator = new PrimeNumbersCalculator(workersCount);

                var display = document.getElementById("display");
                var errorDisplay = document.getElementById("errors-display");

                var buttonToNumber = document.getElementById("btn-to-number");
                buttonToNumber.addEventListener("click", function () {
                    var number = document.getElementById("input-to-number").value;
                    var info = document.getElementById("info-to-number");
                    info.innerText = "Calculating";
                    appData.temporaryFolder.getFileAsync("calculatePrimesUpToNumber" + number).then(function (file) {
                        Windows.Storage.FileIO.readTextAsync(file, Windows.Storage.Streams.UnicodeEncoding.utf8).then(function (text) {
                            display.innerText += '\nPrime numbers up to: ' + number + ' are: ';
                            display.innerHTML += text;
                            info.innerText = "Done";
                        })
                    },
                    function() {
                        calculator.calculatePrimesUpToNumberAsync(number).then(function (primes) {
                        display.innerText += '\nPrime numbers up to: ' + number + ' are: ';
                        display.innerHTML += primes.join(", ");
                        info.innerText = "Done";
                            appData.temporaryFolder.createFileAsync("calculatePrimesUpToNumber" + number,
                            Windows.Storage.CreationCollisionOption.replaceExisting).
                        done(function (file) {
                            Windows.Storage.FileIO.writeTextAsync(file, primes.join(", "));
                        });
                    });
                    

                    }, function (errorMsg) {
                        errorDisplay.innerText += '\n' + errorMsg;
                    });

                });

                var buttonFirstPrimes = document.getElementById("btn-first-primes");
                buttonFirstPrimes.addEventListener("click", function () {
                    var number = document.getElementById("input-first-primes").value;
                    var info = document.getElementById("info-first-primes");
                    info.innerText = "Calculating";
                    appData.temporaryFolder.getFileAsync("buttonFirstPrimes" + number).then(function (file) {
                        Windows.Storage.FileIO.readTextAsync(file, Windows.Storage.Streams.UnicodeEncoding.utf8)
                            .then(function (text) {
                                display.innerText += '\nFirst ' + number + 'prime numbers are: ';
                                display.innerHTML += text;
                                info.innerText = "Done";
                        })
                    },
                    function () {
                        calculator.calculateFirstPrimeNumbersAsync(number).then(function (primes) {
                        display.innerText += '\nFirst ' + number + 'prime numbers are: ';
                        display.innerHTML += primes.join(", ");
                        info.innerText = "Done";
                        appData.temporaryFolder.createFileAsync("buttonFirstPrimes" + number,
                            Windows.Storage.CreationCollisionOption.replaceExisting)
                        .then(function (file) {
                            Windows.Storage.FileIO.writeTextAsync(file, primes.join(", "));
                        })
                    });

                    }, function (errorMsg) {
                        errorDisplay.innerText += '\n' + errorMsg;
                    });
                });

                var buttonInterval = document.getElementById("btn-interval");
                buttonInterval.addEventListener("click", function () {
                    var start = document.getElementById("input-interval-start").value;
                    var end = document.getElementById("input-interval-end").value;
                    var info = document.getElementById("info-interval");
                    info.innerText = "Calculating";
                    calculator.calculatePrimersInIntervalAsync(start, end).then(function (primes) {
                        display.innerText += '\nPrime numbers between ' + start + ' and '+ end +' are: ';
                        display.innerHTML += primes.join(", ");
                        info.innerText = "Done";

                    }, function (errorMsg) {
                        errorDisplay.innerText += '\n' + errorMsg;
                    });
                });

                var buttonWokersCountChange = document.getElementById("btn-settings-workers");
                buttonWokersCountChange.addEventListener("click", function () {
                    var numberOfWorkers = document.getElementById("input-settings-workers").value;
                    appData.localSettings["numberOfWorkers"] = numberOfWorkers;
                    calculator.setNumberOfWorkers(numberOfWorkers);
                });

            }));
        }
    };

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
    };

    app.start();
})();
