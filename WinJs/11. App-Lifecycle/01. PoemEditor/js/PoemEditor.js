/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.define("Editors", {
    PoemEditor: WinJS.Class.define(function (selector) {
        var self = this;
        this.container = WinJS.Utilities.query(selector)[0];
        this.editorTextArea;
        this.verseSwitch;
        this.verseLinesInput;

        this._appData = Windows.Storage.ApplicationData.current;
        this._sessionState = WinJS.Application.sessionState;

        this._buildHtml().then(function(){
            self._tempName = self._loadTempOpenFile() || "temp-file" + Date.now();
        });
        
    }, {
        _buildHtml: function () {
            var self = this;
            var promise = new WinJS.Promise(function (seccess, error) {
                // text area
                var textArea = document.createElement("textarea");
                self.editorTextArea = textArea;
                textArea.rows = 15;
                textArea.cols = 75;

                textArea.addEventListener("change", function (ev) {
                    self._appData.localFolder.createFileAsync(self._tempName,
                        Windows.Storage.CreationCollisionOption.replaceExisting).then(function (file) {
                            var text = textArea.value;
                            Windows.Storage.FileIO.writeTextAsync(file, text);
                            self._appData.localSettings.values["tempFile"] = self._tempName;
                        });
                });

                self.container.appendChild(textArea);
                // settings container
                var settingsContainer = document.createElement("div");

                // verse line setting
                var labelVerseLine = document.createElement("label");
                labelVerseLine.innerText = "Set number of verse lines: ";
                var inputVerseLines = document.createElement("input");
                inputVerseLines.id = "input-verse-lines";
                var btnVerseLines = document.createElement("button");
                btnVerseLines.innerText = "Apply";
                self.verseLinesInput = inputVerseLines;
                settingsContainer.appendChild(labelVerseLine);
                settingsContainer.appendChild(inputVerseLines);
                settingsContainer.appendChild(btnVerseLines);

                // setting pair verse rhymes settings
                var verseSwitchContainer = document.createElement("div");
                verseSwitchContainer.id = "verse-switch-container";
                var verseSwitchLabel = document.createElement("label");
                verseSwitchLabel.innerText = "Verse rhymes settings";
                verseSwitchContainer.appendChild(verseSwitchLabel);
                var verseSwitch = new WinJS.UI.ToggleSwitch(verseSwitchContainer);
                verseSwitch.labelOn = "sequential";
                verseSwitch.labelOff = "skipping";
                self.verseSwitch = verseSwitch;
                settingsContainer.appendChild(verseSwitchContainer);

                // apply settings in settings container
                self.container.appendChild(settingsContainer);

                // Message box
                var messageBox = document.createElement("div");
                var messageBoxTitle = document.createElement("h2");
                messageBoxTitle.innerText = "Messages";
                messageBox.appendChild(messageBoxTitle);
                var messageBoxMessages = document.createElement("div");
                messageBox.appendChild(messageBoxMessages);

                self.container.appendChild(messageBox);

                seccess();
            });
            return promise;
        },
        _loadTempOpenFile: function () {
            var tempFileName = this._appData.localSettings.values["tempFile"];
            var self = this;
            if (tempFileName) {
                var filename = tempFileName;
                this._appData.localFolder.getFileAsync(filename).then(function (file) {
                    Windows.Storage.FileIO.readTextAsync(file).then(function (text) {
                        self.editorTextArea.value = text;
                    });
                });
                return filename;
            }
        },
        loadOptions: function (options) {
            this.verseSwitch.checked = options.toggleSwitch.checked;
            this.verseLinesInput.value = options.verseInput.size;
        },
        saveCurrentFile: function () {
            var self = this;
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.defaultFileExtension = ".txt";
            savePicker.fileTypeChoices.insert("Poem", [".txt"]);
            savePicker.suggestedFileName ="New Poem";
            savePicker.pickSaveFileAsync().then(function (file) {
                var text = self.editorTextArea.value;
                Windows.Storage.FileIO.writeTextAsync(file, text);
            });
        },
        loadFile: function () {
            var self = this;
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
            openPicker.fileTypeFilter.append(".txt");

            openPicker.pickSingleFileAsync().then(function (file) {
                if (file) {
                    Windows.Storage.FileIO.readTextAsync(file).then(function (text) {
                        self.editorTextArea.value = text;
                    });
                }                
            });

        },
        close: function () {
            var self = this;
            self.container.innerHTML = "";
            this._appData.localFolder.getFileAsync(this._tempName).then(function (file) {
                file.deleteAsync().then(function () {
                    self._appData.localSettings.values["tempFile"] = undefined;
                });
            });
        }
    }, {
    })
});