/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

(function () {
    var httpRequester = {
        postJson: function (url, data) {
            return WinJS.xhr({
                type: "POST",
                url: url,
                data: JSON.stringify(data),
                headers: { "Content-Type": "application/json" },
            })
        },
        getJson: function (url) {
            return WinJS.xhr({
                type: "GET",
                url: url,
                headers: { "Content-Type": "application/json" },
            })
        }
    }

    WinJS.Namespace.define("HttpRequests", {
        httpRequester: httpRequester
    });

}())