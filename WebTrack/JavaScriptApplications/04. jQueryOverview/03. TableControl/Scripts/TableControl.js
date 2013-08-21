/// <reference path="jquery-2.0.2.js" />
(function ($) {
    // headers are mandatory!
    TableControl = $().classCreate({
        initialize: function (tableContainerSelector) {
            this.masterTableContainer = $(tableContainerSelector);
            this.header = [];
            this.data = [];

            this._init();
        },
        _init: function(){
            this.tableContainer = $(document.createElement("div"));
            this.tableContainer.addClass("TableControl");
        },
        addHeaders: function (headers) {
            this.headers = headers;
        },
        addData: function (data) {
            this.data.push(data);
        },
        render: function () {
            this.tableContainer.remove();

            // create table head row
            var headerRow = $(document.createElement("tr"));
            for (var i in this.headers) {
                var thCell = "<th>" + this.headers[i] + "</th>";
                headerRow.append(thCell);
            }
            var thead = $(document.createElement("thead")).append(headerRow);

            // create table body
            var tbody = $(document.createElement("tbody"));
            var numberOfCellsPerRow = this.headers.length;
            var cellCount = 0;
            for (var i in this.data) {
                var newRow = $(document.createElement("tr"));

                for (var field in this.data[i]) {
                    if (typeof (this.data[i][field]) === 'string'
                        || typeof (this.data[i][field]) === 'number') {
                        var newCell = "<td>" + this.data[i][field] + "</td>";
                        newRow.append(newCell);

                        if (cellCount >= numberOfCellsPerRow) {
                            // if more cells than header elements are inserted, the extra cells are ignored
                            break;
                        }
                        cellCount++;
                    }
                }
                
                tbody.append(newRow);
                cellCount = 0;               
            }

            // create table
            var newTable = $(document.createElement("table"));
            newTable.append(thead);
            newTable.append(tbody);
            this.tableContainer.append(newTable);

            $(this.masterTableContainer).append(this.tableContainer);
        }
    });

}(jQuery))