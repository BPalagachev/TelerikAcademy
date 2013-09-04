// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

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
                var calculator = new PrimeNumbersCalculator();

                var display = document.getElementById("display");
                var errorDisplay = document.getElementById("errors-display");

                var buttonToNumber = document.getElementById("btn-to-number");
                buttonToNumber.addEventListener("click", function () {
                    var number = document.getElementById("input-to-number").value;
                    var info = document.getElementById("info-to-number");
                    info.innerText = "Calculating";
                    calculator.calculatePrimesUpToNumberAsync(number).then(function (primes) {
                        display.innerText += '\nPrime numbers up to: ' + number + ' are: ';
                        display.innerHTML += primes.join(", ");
                        info.innerText = "Done";

                    }, function (errorMsg) {
                        errorDisplay.innerText += '\n' + errorMsg;
                    });
                });

                var buttonFirstPrimes = document.getElementById("btn-first-primes");
                buttonFirstPrimes.addEventListener("click", function () {
                    var number = document.getElementById("input-first-primes").value;
                    var info = document.getElementById("info-first-primes");
                    info.innerText = "Calculating";
                    calculator.calculateFirstPrimeNumbersAsync(number).then(function (primes) {
                        display.innerText += '\nFirst ' + number + 'prime numbers are: ';
                        display.innerHTML += primes.join(", ");
                        info.innerText = "Done";

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
