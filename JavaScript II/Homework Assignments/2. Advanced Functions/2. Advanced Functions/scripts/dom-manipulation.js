var dom = (function () {

    // an associative array of document fragments
    var fragmentsBuffer = [];
    // maximum size of a document fragment
    var MAX_FRAGMENT_SIZE = 10;

    // for private use
    function createElement(tagName, attributes, innerHTML) {
        var child = document.createElement(tagName);

        for (var attrName in attributes) {
            child.setAttribute(attrName, attributes[attrName]);
        }

        child.innerHTML = innerHTML;
        return child;
    }

    // for private use
    function getElement(selector) {
        return document.querySelector(selector);
    }

    function addElement(parentSelector, tagName, attributes, innerHTML) {
        var parent = getElement(parentSelector);
        var newChild = createElement(tagName, attributes, innerHTML);

        parent.appendChild(newChild);
    }

    function removeElement(selector) {
        var elementToRemove = getElement(selector);
        elementToRemove.parentNode.removeChild(elementToRemove);
    }

    function attachEvent(selector, eventType, handler) {
        var element = getElement(selector);
        if (element.addEventListener) {
            element.addEventListener(eventType, handler, false);
        } else {
            element.attachEvent("on" + eventType, handler);
        }
    }

    function addElementViaBuffer(parentSelector, tagName, attributes, innerHTML) {

        if (!fragmentsBuffer[parentSelector]) {
            // there isn't a fragment for this selector - create one
            fragmentsBuffer[parentSelector] = document.createDocumentFragment();
        }

        var element = createElement(tagName, attributes, innerHTML);

        // append the element in the fragment
        fragmentsBuffer[parentSelector].appendChild(element);

        if (fragmentsBuffer[parentSelector].childNodes.length === MAX_FRAGMENT_SIZE) {
            // the fragment has reached its maximum size, append it 
            // to the DOM tree and empty it
            var parent = getElement(parentSelector);
            parent.appendChild(fragmentsBuffer[parentSelector]);
            // empty the document fragment
            fragmentsBuffer[parentSelector] = null;
        }
    }

    return {
        addElement: addElement,
        removeElement: removeElement,
        attachEvent: attachEvent,
        addElementViaBuffer: addElementViaBuffer
    };
})();