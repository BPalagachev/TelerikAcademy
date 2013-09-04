/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.defineWithParent(Plants, "Vegetables", {
    Tomato : WinJS.Class.derive(Plants.Vegetable,
    function (color, radius) {
        Plants.Vegetable.call(this, color, true, radius);
    })
});