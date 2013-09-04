/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
WinJS.Namespace.defineWithParent(Plants.Vegetables, "GMO", {
    CucumberGMO :  WinJS.Class.mix(Plants.Vegetables.Cucumber, MushroomMixin)
});