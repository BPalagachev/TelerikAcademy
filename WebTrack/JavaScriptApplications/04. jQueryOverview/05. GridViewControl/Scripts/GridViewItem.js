/// <reference path="jquery-2.0.2.js" />
/// <reference path="Row.js" />

(function ($) {
    GridViewItem = $().classCreate({
        initialize: function () {
            this.header;
            this.rows = [];
            this.subGridView;
        },
        addHeader: function (arrayOfTitles) {
            this.header = [];
            for (var header in arrayOfTitles) {
                this.header.push(arrayOfTitles[header]);
            }
        },
        addRow: function (arrayOfCells) {
            var row = new Row(arrayOfCells);
            this.rows.push(row);
        },
        addGridSubGridView: function () {
            var subGrid = new GridViewItem();
            this.subGridView = subGrid;
            return subGrid;
        },
        addRowDynamicly: function () {
            this.addRow();
        },
        render: function () {
            // create header
            var thead = $(document.createElement("thead"));
            var headerRow = $(document.createElement("tr")).addClass("GridViewTableHeader");
            for (var title in this.header) {
                var headerCellHTML = "<th>" + this.header[title] + "</th>";
                headerRow.append(headerCellHTML);
            }
            thead.append(headerRow);

            // create table body
            var tbody = $(document.createElement("tbody"));

            for (var i = 0; i < this.rows.length; i++) {
                var newRow = this.rows[i].render();
                tbody.append(newRow);
            }

            var table = $(document.createElement("table"));
            table.append(thead);
            table.append(tbody);

            if (this.subGridView) {
                var tableCell = $(document.createElement("td"))
                    .attr("colspan", this.header.length.toString());
                var subGrid = this.subGridView.render();
                tableCell.append(subGrid);
                table.append(tableCell);
            }

            return table;
        }
    });
}(jQuery))