var controls = controls || {};
(function (c) {
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
        },

        renderMarks: function (template, studentId) {
            var student;
            for (var i = 0; i < this.itemsSource.length; i++) {
                if (this.itemsSource[i].id == studentId) {
                    student = this.itemsSource[i];
                    break;
                }
            }

            return template(student);
        }
    });

    c.getTableView = function (itemsSource, rows, cols) {
        return new TableView(itemsSource, rows, cols);
    }
}(controls || {}));