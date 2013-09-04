/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

(function () {
    WinJS.Namespace.define("CustomControls", {
        Repeater: WinJS.Class.define(function(templateUrl){
            this.templateUrl = templateUrl;
            this.template = new WinJS.Binding.Template(null, {href: this.templateUrl});
        }, {
            render: function (observableCollection, element) {
                if (!element) {
                    element = document.createElement("div");
                    document.body.appendChild(element);
                }
                if (observableCollection.length == 1) {
                    this.template.render(observableCollection[0], element)
                }
                else {
                    var self = this;
                    observableCollection.reduce(function (prev, item, i) {

                        if (i == 1) {
                            return self.template.render(prev, element).then(function () {
                                self.template.render(item, element);
                            });
                        } else {
                            return prev.then(function () {
                                self.template.render(item, element);
                            });
                        }
                    });
                }
            }
        },{
        })
    });
}())