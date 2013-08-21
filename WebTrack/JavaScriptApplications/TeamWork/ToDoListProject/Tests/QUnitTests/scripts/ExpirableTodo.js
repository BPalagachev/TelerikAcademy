(function ($) {
    ExpirableTodo = $().classCreate(BasicTodo, {
        initialize: function ($super, id, title, completed, date, remaining) {
            $super(id, title, completed);
            this.expirationDate = date;
            this.remaining = remaining;
        },
        test: function () {

            
            console.log("works");
        }
    });
}(jQuery))