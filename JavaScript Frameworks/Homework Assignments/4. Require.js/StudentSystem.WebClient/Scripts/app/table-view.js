define(["../libs/class"], function (Class) {

    var controls = controls || {};

    var TableView = Class.create({
        init: function (itemsSource, rows, cols) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of a TableView must be an array!";
            }
            this.itemsSource = itemsSource;
            this.rows = rows;
            this.cols = cols;
        },

        render: function (template) {
            var table = document.createElement("table");
            var index = 0;
            for (var i = 0; i < this.rows; i++) {
                var rowItem = document.createElement("tr");
                for (var j = 0; j < this.cols; j++) {
                    var cellItem = document.createElement("td");
                    var item = this.itemsSource[index];
                    if (item) {
                        cellItem.setAttribute("data-id", item.id);
                        cellItem.innerHTML = template(item);
                    }
                    rowItem.appendChild(cellItem);
                    index++;
                }

                table.appendChild(rowItem);
            }

            return table.outerHTML;
        }

    });

    controls.getTableView = function (itemsSource, rows, cols) {
        return new TableView(itemsSource, rows, cols);
    };

    return controls;
});