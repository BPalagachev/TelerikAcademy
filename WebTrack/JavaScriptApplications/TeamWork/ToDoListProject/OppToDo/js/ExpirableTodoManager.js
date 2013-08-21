(function ($) {
    ExpirableTodoManager = $().classCreate(TodoManager, {
        initialize: function ($super, selectorContainer, templateID, localStorageID) {
            $super(selectorContainer, templateID, localStorageID);
            this.updateDaysAndRemove();
        },
        addCreateEventHandler: function () {
            var self = this;
            this.$newTodo.on('keyup', function (e) {
                var $input = $(this);
                var val = $.trim($input.val());
                var date = $.trim($input.prevAll("input").val());

                var today = new Date();
                var expire = Utils.parseDate(date);

                var difference = expire.getTime() - today.getTime() ;
                var remainingDays = Math.floor(difference / (1000 * 60 * 60 * 24)) + 1;
                                
                if (e.which !== self.ENTER_KEY || !val || remainingDays < 0) {
                    return;
                }

                var remainingDays = Math.floor(difference / (1000 * 60 * 60 * 24));
                console.log("remainingDays " + remainingDays);
                var newTodo = new ExpirableTodo(Utils.uuid(), val, false, date, remainingDays);
                self.todos.push(newTodo);

                $input.val('');
                $input.prevAll("input").val('')
                self.render();
            });
        },
        updateDaysAndRemove: function () {
            var self = this;
            for (var i = 0; i < self.todos.length; i++) {
                var today = new Date();
                var expire = Utils.parseDate(self.todos[i].expirationDate);
                var difference = expire.getTime() - today.getTime();
                var remainingDays = Math.floor(difference / (1000 * 60 * 60 * 24));
                self.todos[i].remaining = remainingDays + 1;
            }
            self.render();

            var timer = setInterval(
                function () {
                    for (var i = 0; i < self.todos.length; i++) {
                        var today = new Date();
                        var expire = Utils.parseDate(self.todos[i].expirationDate);
                        var difference = expire.getTime() - today.getTime();
                        var remainingDays = Math.floor(difference / (1000 * 60 * 60 * 24));
                        self.todos[i].remaining = remainingDays + 1;
                    }
                    self.render();
                },
                1000*60*60);
        },
        edit: function () {
            $(this).closest('li').addClass('editing').find('.edit-title').focus();
        },
        addUpdateEventHandler: function () {
            var self = this;
            var list = this.$todoList;

            list.on('blur', '.edit', function () {
                var isTitle = $(this).attr('class').indexOf("title") != -1;
                var val = $.trim($(this).removeClass('editing').val());

                self.getTodo(this, function (i) {
                    if (val) {
                        if (isTitle) {
                            this.todos[i].title = val;
                        }
                        else {
                            this.todos[i].expirationDate = val;
                        }
                    } else {
                        this.todos.splice(i, 1);
                    }

                    for (var i = 0; i < self.todos.length; i++) {
                        var today = new Date();
                        var expire = Utils.parseDate(self.todos[i].expirationDate);
                        var difference = expire.getTime() - today.getTime();
                        var remainingDays = Math.floor(difference / (1000 * 60 * 60 * 24));
                        self.todos[i].remaining = remainingDays + 1;
                    }
                    self.render();

                    this.render();
                });
            });
        },
    });
}(jQuery))