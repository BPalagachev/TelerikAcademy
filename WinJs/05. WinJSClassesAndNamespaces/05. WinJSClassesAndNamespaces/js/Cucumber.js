/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.defineWithParent(Plants, "Vegetables", {
    Cucumber: WinJS.Class.derive(Plants.Vegetable,
    function (color, length) {
        Plants.Vegetable.call(this, color, false, length);
    })
});