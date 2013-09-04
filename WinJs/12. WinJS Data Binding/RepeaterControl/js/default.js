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
                var collection = [];
                populateTestData();


                var computerAddBtn = document.getElementById("btn-add-computer");
                computerAddBtn.addEventListener("click", function () {
                    var computerName = document.getElementById("input-name").value;
                    var computerImage = document.getElementById("input-image-url").value;
                    var computerPrice = document.getElementById("input-price").value;
                    var computerRatingInput = document.getElementById("input-rating");
                    var rating = computerRatingInput.winControl.userRating;
                    var processorName = document.getElementById("input-processor-name").value;
                    var processorFrequency = document.getElementById("input-processor-frequency").value;

                    var computer = Data.getComputer(computerName, computerImage, computerPrice, rating, processorName, processorFrequency);
                    collection.push(computer);
                });

                var renderBtn = document.getElementById("btn-render-computers");
                renderBtn.addEventListener("click", function () {
                    var repeater = new CustomControls.Repeater("/templates/computer-template.html");
                    var element = document.getElementById("repeater-container");
                    repeater.render(collection, element);
                });

            }));
        }

        function populateTestData() {
            document.getElementById("input-name").value = "Dell Studio 1535";
            document.getElementById("input-image-url").value = "/images/studio-1535.png";
            document.getElementById("input-price").value = 2000;
            document.getElementById("input-processor-name").value = "Core i5";
            document.getElementById("input-processor-frequency").value = "2.0";
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
