/// <reference path="jquery-2.0.2.js" />

(function ($) {
    Slider = $().classCreate({
        initialize: function (containerSelector) {
            this.container = $(document.querySelector(containerSelector));
            this.currentItem = 0;
            this.slides = [];
            this.timer
        },
        addNewItem: function (itemHTML) {
            var newItem = $(document.createElement("div"));
            newItem.append(itemHTML);
            newItem.addClass("SliderItem");
            this.slides.push(newItem);
           },
        render: function () {
            var self = this;

            var btnNext = $(document.createElement("button"));
            var btnPrevious = $(document.createElement("button"));

            btnNext.text("Next");
            btnPrevious.text("Previous");

            btnNext.on("click", function () {
                self.nextitem();
                self.displayItem();
                // when slide is changed manualy, the timer is restarted so the intervals remain consistent
                self.restartTimer();
            });
            btnPrevious.on("click", function () {
                self.previousItem();
                self.displayItem();
                self.restartTimer();
            });

            this.container.append(btnPrevious);
            this.container.append(btnNext);

            var currentItem = this.slides[this.currentItem];
            this.container.append(currentItem).hide().fadeIn(800);
        },
        displayItem: function () {
            var self = this;
            var currentItem = this.slides[this.currentItem];
            this.container.children(".SliderItem").fadeOut(800, function () {
                self.container.children(".SliderItem").remove();
                self.container.append(currentItem);
                self.container.children(".SliderItem").hide().fadeIn(800);
            });
        },
        nextitem: function () {
            this.currentItem += 1;
            if (this.currentItem >= this.slides.length) {
                this.currentItem = 0;
            }
        },
        previousItem: function () {
            this.currentItem -= 1;
            if (this.currentItem < 0) {
                this.currentItem = this.slides.length - 1;
            }
        },
        autoRotate: function () {
            var self = this;
            this.timer = setInterval(
                function () {
                    self.nextitem();
                    self.displayItem();
                },
                5000);
        },
        restartTimer: function () {
            if (this.timer)
            {
                clearInterval(this.timer)
                this.autoRotate();
            };
        }
    });
}(jQuery));

