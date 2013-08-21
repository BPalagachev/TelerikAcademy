/// <reference path="OOPPlugin.js" />
(function ($) {
    SliderItemGenerator = $().classCreate({
        initialize: function () {
        },
        getHTML: function (options) {
            var sliderHTML = "";
            sliderHTML += 
                "<div>" +
                    "<h1>" + options.header + "</h1>" +
                    "<img src='" + options.img + "'/>" +
                    "<p>" + options.paragraphs + "</p>"
            "</div>";

            return sliderHTML;
        }
    });
}(jQuery))