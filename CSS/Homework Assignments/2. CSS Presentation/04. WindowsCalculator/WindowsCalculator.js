// JavaScript source code
function swapImage(mode) {
    var imgObject = document.getElementById("left-arrow");
    if (mode == "on") {
        imgObject.src = "images/LeftArrowHover.png";
    }
    else {
        imgObject.src = "images/LeftArrow.png";
    }
}
