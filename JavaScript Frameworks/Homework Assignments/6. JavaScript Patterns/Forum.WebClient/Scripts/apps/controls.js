/// <reference path="class.js" />

define(["class"], function (Class) {

    var TableView = Class.create({
        init: function (itemsSource) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of a TableView must be an array!";
            }
            this.itemsSource = itemsSource;
        },
        render: function (template, rows, cols) {
            var table = document.createElement("table");
            table.id = "battle-field";
            for (var row = 0; row < rows; row++) {
                var tableRow = document.createElement("tr");

                for (var col = 0; col < cols; col++) {

                    var cell = document.createElement("td");

                    var index = cols * row + col;
                    if (this.itemsSource[index]) {
                        var cellContent = template(this.itemsSource[index]);
                        $(cell).html(cellContent);
                        $(cell).addClass(this.itemsSource[index].owner);
                        $(cell).addClass(this.itemsSource[index].type);
                        $(cell).attr('id', this.itemsSource[index].id);
                    }

                    cell.setAttribute("data-row", row);
                    cell.setAttribute("data-col", col);

                    tableRow.appendChild(cell);
                }

                table.appendChild(tableRow);
            }

            return table.outerHTML;
        }
    });

    return {
        getTableView: function (itemsSource) {
            return new TableView(itemsSource);
        }
    };
});