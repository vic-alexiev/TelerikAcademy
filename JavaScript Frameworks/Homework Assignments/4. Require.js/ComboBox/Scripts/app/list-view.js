define(["../libs/class"], function (Class) {

    var controls = controls || {};

    var ListView = Class.create({
        init: function (itemsSource) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of a ListView must be an array!";
            }
            this.itemsSource = itemsSource;
        },

        render: function (template) {
            var dropDownList = document.createElement("ul");

            dropDownList.id = "drop-down";

            for (var i = 0; i < this.itemsSource.length; i++) {
                var item = this.itemsSource[i];
                var listItem = document.createElement("li");
                listItem.setAttribute("data-id", item.id);
                listItem.innerHTML = template(item);

                dropDownList.appendChild(listItem);
            }

            return dropDownList.outerHTML;
        }
    });

    controls.getListView = function (itemsSource) {
        return new ListView(itemsSource);
    };

    return controls;
});