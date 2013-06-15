var controls = (function () {

    var GridView = function (containerElement) {

        this.container = containerElement;
        this.header = null;
        this.rows = [];
        this.columnNames = [];

        this.container.on("click", "tr", function () {
            if ($(this).next().hasClass("subordinate-row")) {
                $(this).next().toggle();
            }
        });
    };

    GridView.prototype = {

        addHeader: function (/*columnNames*/) {

            this.columnNames = arguments;
            this.header = new GridViewHeader(arguments);
            return this.header;
        },

        addRow: function (/*cellValues*/) {
            var row = new GridViewRow(arguments);
            this.rows.push(row);

            return row;
        },

        render: function () {

            this.container.empty();
            var table = $("<table></table>");

            if (this.header) {
                var headerElement = this.header.render();
                table.append(headerElement);
            }

            for (var i = 0; i < this.rows.length; i++) {
                var row = this.rows[i].render();
                table.append(row);

                var subordinateRow = this.rows[i].renderNestedGridView();
                if (subordinateRow) {
                    table.append(subordinateRow);
                    subordinateRow.hide();
                }
            }

            this.container.append(table);
        }
    };

    var GridViewHeader = function (columnNames) {
        this.columnNames = columnNames;
    };

    GridViewHeader.prototype = {
        render: function () {
            var header = $("<thead></thead>");
            var headerRow = $("<tr></tr>");

            for (var i = 0; i < this.columnNames.length; i++) {
                headerRow.append("<th>" + escape(this.columnNames[i]).replace(/\%20/g, " ") + "</th>");
            }

            header.append(headerRow);
            return header;
        }
    };

    var GridViewRow = function (cellValues) {

        this.cellValues = cellValues;
        this.nestedGridView = null;
        this.nestedGridViewContainerCell = null;
    };

    GridViewRow.prototype = {

        createNestedGridView: function () {
            this.nestedGridViewContainerCell = $("<td></td>").attr("colspan", 999);
            this.nestedGridView = new GridView(this.nestedGridViewContainerCell);
            return this.nestedGridView;
        },

        render: function () {
            var row = $("<tr></tr>");

            for (var i = 0; i < this.cellValues.length; i++) {
                row.append("<td>" + this.cellValues[i] + "</td>");
            }

            if (this.nestedGridView) {
                row.addClass("primary-row");
            }

            return row;
        },

        renderNestedGridView: function () {
            if (this.nestedGridView) {

                this.nestedGridView.render();

                var subordinateRow = $("<tr></tr>");
                subordinateRow.addClass("subordinate-row");

                subordinateRow.append(this.nestedGridViewContainerCell);
                return subordinateRow;
            }

            return null;
        }
    };

    return {
        GridView: GridView
    };

})();