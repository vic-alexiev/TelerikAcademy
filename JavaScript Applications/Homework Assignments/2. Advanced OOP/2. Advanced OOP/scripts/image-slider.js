var Image = Object.subClass({
    init: function (title, pictureUrl, thumbnailUrl, width, height, thumbnailWidth, thumbnailHeight) {
        this.title = title;
        this.pictureUrl = pictureUrl;
        this.thumbnailUrl = thumbnailUrl;
        this.width = width;
        this.height = height;
        this.thumbnailWidth = thumbnailWidth;
        this.thumbnailHeight = thumbnailHeight;
    }
});

var ArrowImage = Object.subClass({
    init: function (url, width, height) {
        this.url = url;
        this.width = width;
        this.height = height;
    }
});

var Font = Object.subClass({
    init: function (size, family, weight) {
        this.size = size;
        this.family = family;
        this.weight = weight;
    }
});

var ImageSlider = Object.subClass({

    init: function (containerId, images, leftArrow, rightArrow, font, backgroundColor) {
        this.containerId = containerId;
        this.images = images;
        this.leftArrow = leftArrow;
        this.rightArrow = rightArrow;
        this.font = font;
        this.backgroundColor = backgroundColor;
        this.previousIndex = 0;
        this.index = 0;

        this.previousImageSelected = this.bindAsEventListener(this, this.previousImageSelected);
        this.nextImageSelected = this.bindAsEventListener(this, this.nextImageSelected);
        this.imageSelected = this.bindAsEventListener(this, this.imageSelected);
    },

    load: function () {

        var buttonPrevious = document.createElement("a");
        buttonPrevious.setAttribute("href", "#");

        var arrowLeft = document.createElement("img");
        arrowLeft.setAttribute("src", this.leftArrow.url);
        arrowLeft.style.marginBottom = parseInt(this.images[0].height / 2) + "px";

        buttonPrevious.appendChild(arrowLeft);
        this.attachEvent(buttonPrevious, "click", this.previousImageSelected);

        var pictureHolder = document.createElement("div");
        pictureHolder.style.display = "inline-block";
        pictureHolder.style.width = (this.images[0].thumbnailWidth * this.images.length) + "px";
        pictureHolder.style.height = (this.images[0].height + 40) + "px";
        pictureHolder.style.backgroundColor = this.backgroundColor;

        this.picture = document.createElement("div");
        this.picture.style.width = this.images[0].width + "px";
        this.picture.style.height = this.images[0].height + "px";
        this.picture.style.backgroundRepeat = "no-repeat";
        this.picture.style.margin = "0 auto";

        pictureHolder.appendChild(this.picture);

        this.label = document.createElement("div");
        this.label.style.width = this.picture.style.width;
        this.label.style.margin = "0 auto";
        this.label.style.textAlign = "center";
        this.label.style.fontSize = this.font.size;
        this.label.style.fontFamily = this.font.family;
        this.label.style.fontWeight = this.font.weight;
        this.label.innerHTML = this.images[0].title;

        pictureHolder.appendChild(this.label);

        var buttonNext = document.createElement("a");
        buttonNext.setAttribute("href", "#");

        var arrowRight = document.createElement("img");
        arrowRight.setAttribute("src", this.rightArrow.url);
        arrowRight.style.marginBottom = parseInt(this.images[0].height / 2) + "px";

        buttonNext.appendChild(arrowRight);
        this.attachEvent(buttonNext, "click", this.nextImageSelected);

        var container = document.getElementById(this.containerId);
        container.appendChild(buttonPrevious);
        container.appendChild(pictureHolder);
        container.appendChild(buttonNext);

        var thumbnailHolder = document.createElement("div");
        thumbnailHolder.style.marginLeft = this.leftArrow.width + "px";

        this.thumbnails = [];

        for (var i = 0; i < this.images.length; i++) {
            this.thumbnails[i] = document.createElement("div");
            this.thumbnails[i].setAttribute("data-index", i);
            this.thumbnails[i].style.display = "inline-block";
            this.thumbnails[i].style.width = this.images[i].thumbnailWidth + "px";
            this.thumbnails[i].style.height = this.images[i].thumbnailHeight + "px";
            this.thumbnails[i].style.backgroundRepeat = "no-repeat";
            this.thumbnails[i].style.backgroundImage = "url(" + this.images[i].thumbnailUrl + ")";
            this.attachEvent(this.thumbnails[i], "click", this.imageSelected);

            thumbnailHolder.appendChild(this.thumbnails[i]);
        }

        container.appendChild(thumbnailHolder);

        this.displaySelectedImage();
    },

    previousImageSelected: function () {
        this.previousIndex = this.index;
        this.index--;

        this.displaySelectedImage();
    },

    nextImageSelected: function () {
        this.previousIndex = this.index;
        this.index++;

        this.displaySelectedImage();
    },

    imageSelected: function (event) {
        var eventSource = (event.target ? event.target : event.srcElement);
        this.previousIndex = this.index;
        this.index = parseInt(eventSource.getAttribute("data-index"));

        this.displaySelectedImage();
    },

    displaySelectedImage: function () {

        if (this.index <= -1) {
            this.index = this.images.length - 1;
        }

        if (this.index >= this.images.length) {
            this.index = 0;
        }

        this.picture.style.backgroundImage = "url(" + this.images[this.index].pictureUrl + ")";
        this.label.innerHTML = this.images[this.index].title;
        if (this.previousIndex >= 0 && this.previousIndex < this.thumbnails.length) {
            this.thumbnails[this.previousIndex].style.opacity = "1";
        }

        this.thumbnails[this.index].style.opacity = "0.5";
    },

    attachEvent: function (element, eventType, eventHandler) {
        if (document.attachEvent) {
            element.attachEvent("on" + eventType, eventHandler);
        } else if (document.addEventListener) {
            element.addEventListener(eventType, eventHandler, false);
        } else {
            element["on" + eventType] = eventHandler;
        }
    },

    bindAsEventListener: function (context, fn) {
        return function (event) {
            return fn.call(context, (event || window.event));
        }
    }
});