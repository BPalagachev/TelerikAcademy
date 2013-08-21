/// <reference path="../bower_components/jquery/jquery.js" />
/// <reference path="../bower_components/jquery/OOPPlugin.js" />

(function ($) {
    BasicTodo = $().classCreate({
        initialize: function (id, title, completed ) {
            this.id = id,
            this.title = title,
            this.completed = completed;
        },
        test: function () {
            console.log("works");
        }
    });
}(jQuery))