(function () {
    "use strict";

    WinJS.UI.Pages.define("/pages/home/home.html", {
        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        ready: function (element, options) {
            // TODO: Initialize the page here.
        }
    });
})();

function gotoscope(e) {
    e.preventDefault();
    WinJS.Navigation.navigate('/pages/scope/scope.html', { someStateProp: "random" });
}

function gototwoTheoryView(e) {
    e.preventDefault();
    WinJS.Navigation.navigate('/pages/twoTheoryView/twoTheoryView.html', { someStateProp: "random" });
}

function gotoonTheTheoryOfRelativity(e) {
    e.preventDefault();
    WinJS.Navigation.navigate('/pages/onTheTheoryOfRelativity/onTheTheoryOfRelativity.html', { someStateProp: "random" });
}

function gotospecialRelativity(e) {
    e.preventDefault();
    WinJS.Navigation.navigate('/pages/specialRelativity/specialRelativity.html', { someStateProp: "random" });
}

function gotogeneralRelativity(e) {
    e.preventDefault();
    WinJS.Navigation.navigate('/pages/generalRelativity/generalRelativity.html', { someStateProp: "random" });
}

function gotoTestsOfSpecialRelativity(e) {
    e.preventDefault();
    WinJS.Navigation.navigate('/pages/TestsOfSpecialRelativity/TestsOfSpecialRelativity.html', { someStateProp: "random" });
}

function gotoTestsOfGeneralRelativity(e) {
    e.preventDefault();
    WinJS.Navigation.navigate('/pages/TestsOfGeneralRelativity/TestsOfGeneralRelativity.html', { someStateProp: "random" });
}

function gotoHistory(e) {
    e.preventDefault();
    WinJS.Navigation.navigate('/pages/History/history.html', { someStateProp: "random" });
}

function gotoHistory(e) {
    e.preventDefault();
    WinJS.Navigation.navigate('/pages/MinorityViews/minorityViews.html', { someStateProp: "random" });
}
