/// <reference path="jquery-2.0.2.js" />
/// <reference path="GridViewItem.js" />

(function ($) {
    GridViewControl = $().classCreate({
        initialize: function (containerSelector) {
            this.container = $(containerSelector);
            this.topGridViewItem = new GridViewItem();
            this.outerTable;
        },
        addHeader: function (arrayOfHeaders) {
            this.topGridViewItem.addHeader(arrayOfHeaders);
        },
        addRow: function (arrayOfCellData) {
            this.topGridViewItem.addRow(arrayOfCellData);
        },
        addGridSubGridView: function () {
            return this.topGridViewItem.addGridSubGridView();
        },
        setEventHandler: function (event, handler) {
            $(this.container).on(event, handler);
        },
        render: function () {
            this.outerTable = this.topGridViewItem.render();
            this.container.append(this.outerTable);
        }
    });
}(jQuery))