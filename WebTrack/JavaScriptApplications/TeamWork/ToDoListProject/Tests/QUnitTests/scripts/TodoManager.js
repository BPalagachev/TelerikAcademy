/// <reference path="../bower_components/jquery/OOPPlugin.js" />
/// <reference path="../bower_components/jquery/jquery.js" />

(function ($) {
    TodoManager = $().classCreate({
        initialize: function (containerSelector, templateID, localStorageID) {
            this.templateID = templateID;
            this.containerSelector = $(containerSelector);
            this.localStorageID = localStorageID;
            this.ENTER_KEY = 13;
            this.todos = Utils.store(this.localStorageID);
            this.cacheElements();
            this.bindEvents();
            this.render();

        },
        cacheElements: function () {
            this.todoTemplate = Handlebars.compile($(this.templateID).html());
            this.footerTemplate = Handlebars.compile($('#footer-template').html());


            this.$todoApp = this.containerSelector;

            this.$newTodo = this.$todoApp.find('.new-todo');
            this.$toggleAll = this.$todoApp.find('.toggle-all');
            this.$main = this.$todoApp.find('.main');
            this.$todoList = this.$todoApp.find('.todo-list');
            this.$footer = this.$todoApp.find('.footer');
            this.$count = this.$todoApp.find('.todo-count');
            this.$clearBtn = this.$todoApp.find('.clear-completed');
        },
        bindEvents: function () {
            var list = this.$todoList;
            this.addCreateEventHandler();
            this.addToggleAllEventhandler();
            this.addDestroyCompletedEventHandler();
            this.addToggleEventHandler();
            list.on('dblclick', 'label', this.edit);
            this.addBlurOnEnter();
            this.addUpdateEventHandler();
            this.addDestroyEventHandler();
        },
        render: function () {
            this.$todoList.html(this.todoTemplate(this.todos));
            this.$main.toggle(!!this.todos.length);
            this.$toggleAll.prop('checked', !this.activeTodoCount());
            this.renderFooter();
            Utils.store(this.localStorageID, this.todos);
        },
        renderFooter: function () {
            var todoCount = this.todos.length;
            var activeTodoCount = this.activeTodoCount();
            var footer = {
                activeTodoCount: activeTodoCount,
                activeTodoWord: Utils.pluralize(activeTodoCount, 'item'),
                completedTodos: todoCount - activeTodoCount
            };

            this.$footer.toggle(!!todoCount);
            this.$footer.html(this.footerTemplate(footer));
        },
        addToggleAllEventhandler: function () {
            var self = this;
            this.$toggleAll.on('change', function () {
                var isChecked = $(this).prop('checked');

                $.each(self.todos, function (i, val) {
                    val.completed = isChecked;
                });

                self.render();
            });
        },
        activeTodoCount: function () {
            var count = 0;

            $.each(this.todos, function (i, val) {
                if (!val.completed) {
                    count++;
                }
            });

            return count;
        },
        addDestroyCompletedEventHandler: function () {
            var self = this;
            this.$footer.on('click', '#clear-completed', function () {
                var todos = self.todos;
                var l = todos.length;

                while (l--) {
                    if (todos[l].completed) {
                        todos.splice(l, 1);
                    }
                }

                self.render();
            });
        },
        getTodo: function (elem, callback) {
            var self = this;
            var id = $(elem).closest('li').data('id');

            $.each(this.todos, function (i, val) {
                if (val.id === id) {
                    callback.apply(self, arguments);
                    return false;
                }
            });
        },
        addCreateEventHandler: function () {
            var self = this;
            this.$newTodo.on('keyup', function (e) {
                var $input = $(this);
                var val = $.trim($input.val());

                if (e.which !== self.ENTER_KEY || !val) {
                    return;
                }

                var newTodo = new BasicTodo(Utils.uuid(), val, false);
                self.todos.push(newTodo);

                $input.val('');
                self.render();
            });            
        },
        addToggleEventHandler: function () {
            var self = this;
            var list = this.$todoList;

            list.on('change', '.toggle', function () {
                self.getTodo(this, function (i, val) {
                    val.completed = !val.completed;
                });
                self.render();
            });            
        },
        edit: function () {
            $(this).closest('li').addClass('editing').find('.edit').focus();
        },
        addBlurOnEnter: function () {
            var self = this;
            var list = this.$todoList;

            list.on('keypress', '.edit', function (e) {
                if (e.which === self.ENTER_KEY) {
                    e.target.blur();
                }
            });
        },
        addUpdateEventHandler: function () {
            var self = this;
            var list = this.$todoList;

            list.on('blur', '.edit', function () {
                var val = $.trim($(this).removeClass('editing').val());

                self.getTodo(this, function (i) {
                    if (val) {
                        this.todos[i].title = val;
                    } else {
                        this.todos.splice(i, 1);
                    }
                    this.render();
                });
            });            
        },
        addDestroyEventHandler: function () {
            var self = this;
            var list = this.$todoList;

            list.on('click', '.destroy', function () {
                self.getTodo(this, function (i) {
                    this.todos.splice(i, 1);
                    this.render();
                });
            });
        }
    });
}(jQuery))