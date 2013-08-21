/// <reference path="../bower_components/jquery/jquery.js" />
/// <reference path="TodoManager.js" />

ToDoControl = (function () {
    return {
        startBasicToDoList: function (containerSelector, templateID, localStorageID) {
            var basicTodo = new TodoManager(containerSelector, templateID, localStorageID);
        },
        startExpirableEventTodo: function (selectorContainer, templateID, localStorageID) {
            var expirable = new ExpirableTodoManager(selectorContainer, templateID, localStorageID);
        }
    }
}())