// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;
    var storadgePermissions = Windows.Storage.AccessCache.StorageApplicationPermissions;

    var permissionTokens = Windows.Storage.ApplicationData.current.localSettings.values["permissionTokens"];

    var addButton;
    var playList;
    var removeButton;
    var openPlaylistButton;
    var savePlayListButton;
    var videoPlayer;
    var currentSong = undefined;
    var actionIsDelete = false;

    app.onactivated = function (args) {
        args.setPromise(WinJS.UI.processAll().then(function () {
            addButton = document.getElementById("cmdAdd");
            removeButton = document.getElementById("cmdRemove");
            playList = document.getElementById("loaded-videos");
            openPlaylistButton = document.getElementById("cmdOpenPlayList");
            savePlayListButton = document.getElementById("cmdSavePlayList");
            videoPlayer = document.getElementById("player");

            videoPlayer.addEventListener("ended", function () {
                if (currentSong) {
                    var currentToken = permissionTokens[currentSong];
                    storadgePermissions.futureAccessList.getFileAsync(currentToken)
                        .then(function (currentFile) {
                            currentFile.properties.getVideoPropertiesAsync().then(function (proerties) {
                                var fileUrl = URL.createObjectURL(currentFile);
                                videoPlayer.src = fileUrl;
                                videoPlayer.play();
                            });
                        });                    
                }
            });
            
            addButton.addEventListener("click", addFileToPlayList);

            playList.addEventListener("click", function (event) {
                var videoEntry = event.target;

                if (videoEntry.tagName.toLowerCase() == "strong") {
                    videoEntry = videoEntry.parentElement;
                }

                var token = videoEntry.getAttribute("data-video-token");
                if (actionIsDelete) {
                    //storadgePermissions.futureAccessList.remove(token);
                    permissionTokens.splice(permissionTokens.indexOf(token), 1);
                    actionIsDelete = false;
                    Windows.Storage.ApplicationData.current.localSettings.values["permissionTokens"] =
                        JSON.stringify(permissionTokens);
                    printPlayList();
                }
                else {
                    currentSong = permissionTokens.indexOf(token);
                    player.src = videoEntry.getAttribute("data-video-url");
                    player.play();
                }

            });

            removeButton.addEventListener("click", function (event) {
                var appBarControl = removeButton.winControl;
                
                if (actionIsDelete) {
                    actionIsDelete = false;
                    appBarControl.label = "Remove";
                }
                else {
                    var flyout = document.getElementById("flyout").winControl;
                    flyout.show(removeButton);
                    actionIsDelete = true;
                    appBarControl.label = "Cancel";
                }
            });

            savePlayListButton.addEventListener("click", function (event) {
                var textToSave = JSON.stringify(permissionTokens);
                
                var savePicker = new Windows.Storage.Pickers.FileSavePicker();
                savePicker.defaultFileExtension = ".txt";
                savePicker.fileTypeChoices.insert("Playlist as plain text", [".txt"]);
                savePicker.suggestedFileName = "New Playlist";

                savePicker.pickSaveFileAsync().then(function (file) {
                    if (file) {
                        Windows.Storage.FileIO.writeTextAsync(file, textToSave, Windows.Storage.Streams.UnicodeEncoding.utf8);
                    }
                });
            });

            openPlaylistButton.addEventListener("click", function (event) {
                var openFile = Windows.Storage.Pickers.FileOpenPicker();
                openFile.fileTypeFilter.append(".txt");
                openFile.pickSingleFileAsync().then(function (file) {
                    if (file) {
                        Windows.Storage.FileIO.readTextAsync(file, Windows.Storage.Streams.UnicodeEncoding.utf8).then(function (text) {
                            currentSong = undefined;
                            permissionTokens = JSON.parse(text);
                            printPlayList();
                        })
                    }                    
                });

            });


        }));

        initializePermissionTokens();
        printPlayList();
    };

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
    };

    function initializePermissionTokens() {
        if (permissionTokens) {
            permissionTokens = JSON.parse(permissionTokens);
        }
        else {
            permissionTokens = [];
            Windows.Storage.ApplicationData.current.localSettings.values["permissionTokens"] =
                JSON.stringify(permissionTokens);
        }
    }

    function buildVideoListItem(name, duration, url, currentToken) {
        var listItem = document.createElement("li");
        listItem.innerHTML = "<strong>" + name + "</strong>, Duration: " + duration;
        listItem.setAttribute("data-video-url", url);
        listItem.setAttribute("data-video-token", currentToken);
        playList.appendChild(listItem);
    }

    function printPlayList() {
        playList.innerHTML = "";

        for (var i = 0; i < permissionTokens.length; i++) {
            var currentToken = permissionTokens[i];
            storadgePermissions.futureAccessList.getFileAsync(currentToken)
                .then(function (currentFile) {
                    currentFile.properties.getVideoPropertiesAsync().then(function (proerties) {
                        var fileUrl = URL.createObjectURL(currentFile);
                        buildVideoListItem(currentFile.name, proerties.duration, fileUrl, currentToken);
                    });
                });
        }
    }

    function addFileToPlayList() {
        var fileOpenPicker = new Windows.Storage.Pickers.FileOpenPicker();
        fileOpenPicker.fileTypeFilter.append("*");

        fileOpenPicker.pickMultipleFilesAsync().then(function (files) {
            if (files) {
                files.forEach(function (file) {
                    var token = permissionTokens.length + file.name;
                    storadgePermissions.futureAccessList.addOrReplace(token, file);

                    permissionTokens.push(token);
                    Windows.Storage.ApplicationData.current.localSettings.values["permissionTokens"] =
                        JSON.stringify(permissionTokens);
                });
                printPlayList();
            }
        });
    }

    app.start();
})();
