/// <reference path="jquery-2.0.2.js" />
(function ($) {
    $.fn.TreeViewControl = function (selector, onOpen, onClose) {
        $(selector).find("ul").find("ul").css("display", "none");

        $(selector).on("click", "li", function (ev) {
            ev.preventDefault();
            ev.stopPropagation();
            var el = $(ev.target);
            var aaa = $("> ul", el);
            if ($("> ul", el).css("display") == "none") {
                $("> ul", el).show();
                if (onOpen) {
                    onOpen(ev);
                }
            }
            else {
                $("> ul", el).hide();
                if (onClose) {
                    onClose(ev);
                }
            }
        });
    }
}(jQuery))