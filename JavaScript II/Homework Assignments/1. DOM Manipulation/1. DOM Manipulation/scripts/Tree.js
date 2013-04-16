function Tree() {
    this.root = document.createElement("ul");
    this.root.style.listStyleType = "none";

    this.icons = ["images/blank.png", "images/collapsed.png", "images/expanded.png"];

    /*
     * Gets called during initialization or any time an image is clicked.
     * @param {Node} node The parent 'li' of the image which has been clicked.
     */
    this.getIcon = function (node) {
        // see if there are any subtrees
        var subtrees = node.getElementsByTagName("ul");

        if (subtrees.length === 0) {
            // no icon for the nested 'ul'
            return this.icons[0];
        }

        if (subtrees[0].style.display === "none") {
            return this.icons[1];
        }
        else {
            return this.icons[2];
        }
    };

    /*
     * Adds a simple 'li' to the tree or another tree with its label specified.
     * @param {string|Tree} item The item to add in the tree. If it is another tree, 
     * it has a label specified.
     * @param {string} label The label of the subtree passed as first parameter.
     * This label will be set as the text of the parent 'li' element.
     */
    this.addTreeItem = function (item, label) {
        var listItem = document.createElement("li");
        // save reference to the parent
        listItem.parent = this;
        // create an image element
        var image = document.createElement("img");
        // create a 'span' element and push the 'li' content in it (except for the nested 'ul' element).
        var spanWrapper = document.createElement("span");

        if (arguments.length === 1) {
            spanWrapper.innerHTML = item;
        }
        else {
            item.root.style.display = "none";
            listItem.appendChild(item.root);
            spanWrapper.innerHTML = label;

            image.onclick = function (event) {
                // ensure the event object is defined
                if (!event) event = window.event;

                // find the HTML element the event took place on
                // (an image, its parent should be a 'li' element)
                var eventSource = (event.target ? event.target : event.srcElement);
                // call handler to process event
                eventSource.parentNode.parent.onClickImage(eventSource.parentNode);
            };
        }

        // assign image URL
        image.src = this.getIcon(listItem);
        // insert the 'span' in the 'li' element
        listItem.insertBefore(spanWrapper, listItem.firstChild);
        // insert the image in the 'li' element before any other child
        listItem.insertBefore(image, listItem.firstChild);
        // add the 'li' in the tree
        this.root.appendChild(listItem);
    };

    /*
     * Used to visualize the tree in the HTML document.
     * @param {string} parentId The Id of the parent
     * which this tree will be appended to.
     */
    this.setParent = function (parentId) {
        var parent = document.getElementById(parentId);
        parent.appendChild(this.root);
    };

    /*
     * Gets called when an image is clicked to expand / collapse the node.
     * @param {Node} node The parent 'li' of the image which has been clicked.
     */
    this.onClickImage = function (node) {
        // check if there are subtrees
        var subtrees = node.getElementsByTagName("ul");
        if (subtrees.length === 0) {
            return;
        }

        // toggle visibility of the subtree (the nested 'ul')
        if (subtrees[0].style.display !== "none") {
            subtrees[0].style.display = "none";
        }
        else {
            subtrees[0].style.display = "block";
        }

        var nodeImages = node.getElementsByTagName("img");
        // change the node image.
        nodeImages[0].src = this.getIcon(node);
    };
}