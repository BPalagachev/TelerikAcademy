/// <reference path="../bower_components/jquery/jquery.js" />
/// <reference path="../bower_components/jquery/jquery.ui.core.js" />
/// <reference path="../bower_components/jquery/jquery.ui.datepicker.js" />
/// <reference path="../bower_components/jquery/jquery.ui.mouse.js" />
/// <reference path="../bower_components/jquery/jquery.ui.sortable.js" />
/// <reference path="../bower_components/jquery/jquery.ui.tabs.js" />
/// <reference path="../bower_components/jquery/jquery.ui.widget.js" />

Init = (function ($) {
    return {
        initializeDatePickers: function () {
            $("#datepicker").datepicker();
        },
        initializeSortable: function () {
            $(".todo-list").sortable();
            $(".todo-list").disableSelection();
        },
        initializeTabs: function () {
            $("#tabs").tabs();
        }
    }
}(jQuery))