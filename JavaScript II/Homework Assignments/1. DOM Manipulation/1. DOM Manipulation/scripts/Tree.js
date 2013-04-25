function Tree() {
    var root = document.createElement("ul");
    root.style.listStyleType = "none";

    /*
     * Adds a simple 'li' to the tree or another tree with its label specified.
     * @param {string|Tree} item The item to add in the tree. If it is another tree, 
     * it has a label specified.
     * @param {string} label The label of the subtree passed as first parameter.
     * This label will be set as the text of the parent 'li' element.
     */
    function addTreeItem(item, label) {
        var listItem = document.createElement("li");
        // create an image element
        var image = document.createElement("img");
        // create a 'span' element and push the 'li' content in it (except for the nested 'ul' element).
        var spanWrapper = document.createElement("span");

        if (arguments.length === 1) {
            spanWrapper.innerHTML = item;
        } else {
            item.root.style.display = "none";
            listItem.appendChild(item.root);
            spanWrapper.innerHTML = label;

            if (image.addEventListener) {
                image.addEventListener("click", onClickImage, false);
            } else {
                image.attachEvent("onclick", onClickImage);
            }
        }

        // assign image URL
        image.src = getIcon(listItem);
        // insert the 'span' in the 'li' element
        listItem.insertBefore(spanWrapper, listItem.firstChild);
        // insert the image in the 'li' element before any other child
        listItem.insertBefore(image, listItem.firstChild);
        // add the 'li' in the tree
        root.appendChild(listItem);
    }

    /*
     * Used to visualize the tree in the HTML document.
     * @param {string} parentId The Id of the parent
     * which this tree will be appended to.
     */
    function setParent(parentId) {
        var parent = document.getElementById(parentId);
        parent.appendChild(root);
    }

    /*
     * Gets called during initialization or any time an image is clicked.
     * @param {Node} node The parent 'li' of the image which has been clicked.
     */
    function getIcon(node) {
        // see if there are any subtrees
        var subtrees = node.getElementsByTagName("ul");

        if (subtrees.length === 0) {
            // no icon for the nested 'ul'
            return "images/blank.png";
        }

        if (subtrees[0].style.display === "none") {
            return "images/collapsed.png";
        } else {
            return "images/expanded.png";
        }
    }

    /*
     * Gets called when an image is clicked to expand / collapse the node.
     * @param {Node} node The parent 'li' of the image which has been clicked.
     */
    function onClickImage(event) {
        // ensure the event object is defined
        if (!event) event = window.event;

        // find the HTML element the event took place on
        // (an image, its parent should be a 'li' element)
        var eventSource = (event.target ? event.target : event.srcElement);

        // check if there are subtrees
        var subtrees = eventSource.parentNode.getElementsByTagName("ul");
        if (subtrees.length > 0) {
            // toggle visibility of the subtree (the nested 'ul')
            if (subtrees[0].style.display !== "none") {
                subtrees[0].style.display = "none";
            } else {
                subtrees[0].style.display = "block";
            }

            var nodeImages = eventSource.parentNode.getElementsByTagName("img");
            // change the node image.
            nodeImages[0].src = getIcon(eventSource.parentNode);
        }

        if (event.preventDefault) {
            event.preventDefault();
        }

        return false;
    }

    return {
        addTreeItem: addTreeItem,
        setParent: setParent,
        root: root
    };
}