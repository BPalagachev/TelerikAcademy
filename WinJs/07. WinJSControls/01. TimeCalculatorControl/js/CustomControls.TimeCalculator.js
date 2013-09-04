/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.define("CustomControls", {
    TimeCalculator: WinJS.Class.define(function (element) {
        this.element = element;
        this.element.winControl = this;

        this.buildControl();
    },
	{
	    buildControl: function () {
	        // prepend show/hide switch
	        var showHideSwitchContainer = document.createElement("div");
	        var showHdeSwitch = new WinJS.UI.ToggleSwitch(showHideSwitchContainer,
				{ title: 'Show/Hide Time', labelOff: 'show', labelOn: 'hide' });
	        this.element.appendChild(showHideSwitchContainer);

	        // append start date
	        var dateFromContainer = document.createElement("span");
	        var dateFromLabel = document.createElement("label");
	        dateFromLabel.innerText = "Start Date: ";
	        var datePickerFrom = new WinJS.UI.DatePicker(dateFromContainer);
	        this.element.appendChild(dateFromLabel);
	        this.element.appendChild(dateFromContainer);

	        // append start time 
	        var startTimeContainer = document.createElement("span");
	        var startTimeLabel = document.createElement("label");
	        startTimeLabel.innerText = "Start Time: ";
	        var startTimePicker = new WinJS.UI.TimePicker(startTimeContainer);
	        this.element.appendChild(startTimeLabel);
	        this.element.appendChild(startTimeContainer);
	        this.element.appendChild(document.createElement("br"));

	        // append  end date
	        var dateToContainer = document.createElement("span");
	        var dateToLabel = document.createElement("label");
	        dateToLabel.innerText = "End  Date: ";
	        var datePickerTo = new WinJS.UI.DatePicker(dateToContainer);
	        this.element.appendChild(dateToLabel);
	        this.element.appendChild(dateToContainer);

	        // append  end time 
	        var endTimeContainer = document.createElement("span");
	        var endTimeLabel = document.createElement("label");
	        endTimeLabel.innerText = "End  Time: ";
	        var endTimePicker = new WinJS.UI.TimePicker(endTimeContainer);
	        this.element.appendChild(endTimeLabel);
	        this.element.appendChild(endTimeContainer);
	        this.element.appendChild(document.createElement("br"));

	        // Calculation Menu
	        var calculateMenuContainer = document.createElement("div");
	        var calculateMenu = new WinJS.UI.Menu(calculateMenuContainer);

	        // anchor button - calculate
	        var calculateMenuButton = document.createElement("button");
	        calculateMenuButton.textContent = "Calculate";
	        calculateMenu.anchor = calculateMenuButton;
	        this.element.appendChild(calculateMenuButton);

	        // calulate days button
	        var calculateDaysButton = document.createElement("button");
	        calculateDaysButton.textContent = "Calculate Days";
	        calculateMenuContainer.appendChild(calculateDaysButton);

	        // calculate hours button
	        var calculateHoursButton = document.createElement("button");
	        calculateHoursButton.textContent = "Calculate Hours";
	        calculateMenuContainer.appendChild(calculateHoursButton);

	        // calculate days and hours button
	        var calculateDaysAndHoursButton = document.createElement("button");
	        calculateDaysAndHoursButton.textContent = "Calculate Days and Hours";
	        calculateMenuContainer.appendChild(calculateDaysAndHoursButton);

	        this.element.appendChild(calculateMenuContainer);

	        // result containers
	        var daysContainer = document.createElement("div");
	        daysContainer.className += "result";
	        daysContainer.innerText = "Days: ";
	        var hoursContainer = document.createElement("div");
	        hoursContainer.className += "result";
	        hoursContainer.innerText = "Hours: "
	        this.element.appendChild(daysContainer);
	        this.element.appendChild(hoursContainer);

	        // flyout results
	        var flyoutContainer = document.createElement("div");
	        var resultFlyout = new WinJS.UI.Flyout(flyoutContainer);
	        var flyoutResult = document.createElement("div");
	        flyoutResult.className += "result";
	        flyoutContainer.appendChild(flyoutResult);

	        this.element.appendChild(flyoutContainer);


	        // attach events
	        showHdeSwitch.addEventListener("change", function (ev) {
	            if (startTimeContainer.style.display == "none"
					|| endTimeContainer.style.display == "none") {
	                startTimeContainer.style.display = "";
	                endTimeContainer.style.display = "";
	            }
	            else {
	                startTimeContainer.style.display = "none";
	                endTimeContainer.style.display = "none";
	            }
	        });

	        calculateMenuButton.addEventListener("click", function (ev) {
	            calculateMenu.show(calculateMenuButton, "bottom");
	        });

	        calculateDaysButton.addEventListener("click", function (ev) {
	            var milisecondsInOneDay = 1000 * 60 * 60 * 24;
	            var from = datePickerFrom.current;
	            var to = datePickerTo.current;
	            var difference = (to - from) / milisecondsInOneDay | 0;
	            daysContainer.innerText = "Days: " + difference;
	            calculateMenu.hide();

	            flyoutResult.innerText = "Days: " + difference;
	            resultFlyout.show(flyoutContainer);
	        });


	        calculateHoursButton.addEventListener("click", function (ev) {
	            var milisecondsInOnHour = 1000 * 60 * 60;
	            var start = startTimePicker.current;
	            var end = endTimePicker.current;
	            var difference = (end - start) / milisecondsInOnHour | 0;
	            hoursContainer.innerText = "Hours: " + difference;
	            calculateMenu.hide();

	            flyoutResult.innerText = "Hours: " + difference;
	            resultFlyout.show(flyoutContainer);
	        });

	        calculateDaysAndHoursButton.addEventListener("click", function (ev) {
	            var milisecondsInOneDay = 1000 * 60 * 60 * 24;
	            var from = datePickerFrom.current;
	            var to = datePickerTo.current;
	            var daysDifference = (to - from) / milisecondsInOneDay | 0;
	            daysContainer.innerText = "Days: " + daysDifference;

	            var milisecondsInOnHour = 1000 * 60 * 60;
	            var start = startTimePicker.current;
	            var end = endTimePicker.current;
	            var hoursDifference = (end - start) / milisecondsInOnHour | 0;
	            hoursContainer.innerText = "Hours: " + hoursDifference;
	            calculateMenu.hide();

	            flyoutResult.innerText = "Days: " + daysDifference + " and " + "Hours: " + hoursDifference;
	            resultFlyout.show(flyoutContainer);
	        });
	    }
	},
	{
	}),
});