// JavaScript source code
var previouslyDisplayedElement;

function showElement(id) {

    var element = document.getElementById(id);

    if (element != null) {

        if (previouslyDisplayedElement != null) {
            previouslyDisplayedElement.style.display = 'none';
        }

        element.style.display = 'block';
        previouslyDisplayedElement = element;
    }
}