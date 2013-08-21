/// <reference path="jquery-2.0.2.js" />
(function ($) {
    Row = $().classCreate({
        initialize: function (arrayOfCells) {
            this.cells = arrayOfCells;
        },
        render: function () {
            var row = $(document.createElement("tr"));
            
            for(var i in this.cells){
                var cellHTML = "<td>"+ this.cells[i]+"</td>";
                row.append(cellHTML);
            }

            return row;
        }
    });
}(jQuery))