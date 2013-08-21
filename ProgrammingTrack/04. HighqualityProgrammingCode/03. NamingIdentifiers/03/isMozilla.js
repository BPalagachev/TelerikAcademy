function buttonOnClick(eventHander, args) {
    var currentWindow = window;
    var currentBrowser = currentWindow.navigator.appCodeName;

    var isMozilla = (currentBrowser == "Mozilla");

    if (isMozilla) {
        alert("isMozilla: True");
    }
    else {
        alert("isMozilla: False");
    }
}
