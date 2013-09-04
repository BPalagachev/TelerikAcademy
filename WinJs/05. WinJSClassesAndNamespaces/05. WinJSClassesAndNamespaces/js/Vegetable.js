/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.define("Plants", {
    Vegetable: WinJS.Class.define(function (color, couldBeEaten, size) {
        this.color = color;
        this.couldBeEaten = couldBeEaten;
        this.size = size;
    })
});


