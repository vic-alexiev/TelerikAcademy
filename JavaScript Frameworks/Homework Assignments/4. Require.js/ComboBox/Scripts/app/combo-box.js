define(["../libs/class"], function (Class) {

    var controls = controls || {};

    var ComboBox = Class.create({
        init: function (itemsSource) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of a ComboBox must be an array!";
            }
            this.itemsSource = itemsSource;
        },

        render: function (template) {
            var comboBox = document.createElement("select");

            comboBox.id = "combo-box";

            for (var i = 0; i < this.itemsSource.length; i++) {
                var item = this.itemsSource[i];
                var option = document.createElement("option");
                option.innerHTML = template(item);

                comboBox.appendChild(option);
            }

            return comboBox.outerHTML;
        }
    });

    controls.getComboBox = function (itemsSource) {
        return new ComboBox(itemsSource);
    };

    return controls;
});