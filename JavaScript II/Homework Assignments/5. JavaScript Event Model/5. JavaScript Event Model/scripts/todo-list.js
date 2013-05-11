var todoList = (function () {

    var itemsList;
    var inputBox;

    function load(containerId, title) {
        var container = document.getElementById(containerId);

        var listTitle = document.createElement("div");
        listTitle.style.padding = "5px";
        listTitle.innerHTML = title;
        container.appendChild(listTitle);

        itemsList = document.createElement("ul");
        itemsList.id = "todo-list";
        itemsList.style.listStyleType = "none";

        container.appendChild(itemsList);

        var addItemForm = document.createElement("form");
        addItemForm.style.padding = "5px";
        container.appendChild(addItemForm);

        inputBox = document.createElement("input");
        inputBox.setAttribute("type", "text");
        inputBox.setAttribute("placeholder", "New item here...");

        addItemForm.appendChild(inputBox);

        appendButton(addItemForm, "Add", addItem);
        appendButton(addItemForm, "Remove selected", removeSelectedItems);
        appendButton(addItemForm, "Hide selected", hideSelectedItems);
        appendButton(addItemForm, "Show hidden", showSelectedItems);
    };

    function appendButton(parent, value, listener) {
        var button = document.createElement("input");
        button.setAttribute("type", "button");
        button.setAttribute("value", value);

        if (document.addEventListener) {
            button.addEventListener("click", listener, false);
        } else if (document.attachEvent) {
            button.attachEvent("onclick", listener);
        }

        parent.appendChild(button);
    };

    function addItem() {
        var item = document.createElement("li");
        var label = document.createElement("label");

        var checkBox = document.createElement("input");
        checkBox.setAttribute("type", "checkbox");
        label.appendChild(checkBox);

        var name = document.createTextNode(inputBox.value);
        label.appendChild(name);

        item.appendChild(label);
        itemsList.appendChild(item);
    };

    function hideSelectedItems() {
        toggleSelectedItems("none");
    };

    function showSelectedItems() {
        toggleSelectedItems("block");
    };

    function getCheckedCheckBoxes() {
        return document.querySelectorAll("#todo-list li > label > input[type=checkbox]:checked");
    };

    function toggleSelectedItems(display) {
        var checkedCheckBoxes = getCheckedCheckBoxes();

        for (var i = 0; i < checkedCheckBoxes.length; i++) {
            checkedCheckBoxes[i].parentElement.parentElement.style.display = display;
        }
    };

    function removeSelectedItems() {
        var checkedCheckBoxes = getCheckedCheckBoxes();

        for (var i = 0; i < checkedCheckBoxes.length; i++) {
            itemsList.removeChild(checkedCheckBoxes[i].parentElement.parentElement);
        }
    };

    return {
        load: load
    };
})();