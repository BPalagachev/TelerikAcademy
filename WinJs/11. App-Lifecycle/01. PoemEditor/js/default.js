// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        var poemEditor;

        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                poemEditor = new Editors.PoemEditor("#poem-container");
            } else {
                // TODO: This application has been reactivated from suspension.
                // Restore application state here.
                var options =
                    {
                        toggleSwitch: {},
                        verseInput: {}
                    };

                options.toggleSwitch.checked = app.sessionState["checked"];
                options.verseInput.size = app.sessionState["inputVerseSettings"];
                poemEditor = new Editors.PoemEditor("#poem-container");
                poemEditor.loadOptions(options);
            }
        }

        args.setPromise(WinJS.UI.processAll().then(function(){
            var btnSave = document.getElementById("cmdSave");
            btnSave.addEventListener("click", function () {
                poemEditor.saveCurrentFile();
            });

            var btnLoad = document.getElementById("cmdRemove");
            btnLoad.addEventListener("click", function () {
                var msg = new Windows.UI.Popups.MessageDialog("Are you sure? All unsaved data will be lost!", "Load file");
                msg.commands.append(new Windows.UI.Popups.UICommand("Yes", function () { }, 0));
                msg.commands.append(new Windows.UI.Popups.UICommand("No", function () { }, 1));

                msg.defaultCommandIndex = 1;
                msg.cancelCommandIndex = 1;
                msg.showAsync().done(function(command){
                    if (command.id === 0) {
                        poemEditor.close();
                        poemEditor = new Editors.PoemEditor("#poem-container");
                        poemEditor.loadFile();
                    }
                });
            });

            var btnNew = document.getElementById("cmdNew");
            btnNew.addEventListener("click", function () {
                var msg = new Windows.UI.Popups.MessageDialog("Are you sure? All unsaved data will be lost!", "Create new file");
                msg.commands.append(new Windows.UI.Popups.UICommand("Yes", function () { }, 0));
                msg.commands.append(new Windows.UI.Popups.UICommand("No", function () { }, 1));

                msg.defaultCommandIndex = 1;
                msg.cancelCommandIndex = 1;
                msg.showAsync().done(function (command) {
                    if (command.id === 0) {
                        poemEditor.close();
                        poemEditor = new Editors.PoemEditor("#poem-container");
                    }
                });                
            });
        }));

    };


    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
        var inputVerseLines = document.getElementById("input-verse-lines");
        app.sessionState["inputVerseSettings"] = inputVerseLines.value;
        var verseSwitchContainer = document.getElementById("verse-switch-container");
        var verseSwitch = verseSwitchContainer.winControl;
        app.sessionState["checked"] = verseSwitch.checked;
    };

    app.start();
})();
