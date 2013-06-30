/// <reference path="class.js" />
var onlineMapTourism = (function () {

    var Map = Class.create({
        init: function (mapContainerId, navigationId, locations) {
            var options = {
                zoom: 9,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };

            var mapContainer = document.getElementById(mapContainerId);

            this.map = new google.maps.Map(mapContainer, options);
            this.locations = locations;

            this.marker = new google.maps.Marker({
                map: this.map
            });

            this.infoWindow = new google.maps.InfoWindow({
                maxWidth: 300
            });

            var self = this;
            google.maps.event.addListener(this.marker, "click", function () {
                self.infoWindow.open(self.map, self.marker);
            });

            this.goToPreviousLocation = this.bindAsEventListener(this, this.goToPreviousLocation);
            this.goToNextLocation = this.bindAsEventListener(this, this.goToNextLocation);
            this.goToLocation = this.bindAsEventListener(this, this.goToLocation);

            var navigation = document.getElementById(navigationId);
            this.addNavigation(navigation);

            this.locationIndex = 0;
            this.goToIndex(this.locationIndex);
        },
        addNavigation: function (container) {
            container.style.textAlign = "center";

            var blank = document.createTextNode("\u00A0");

            var buttonPrevious = document.createElement("a");
            buttonPrevious.setAttribute("href", "#");
            buttonPrevious.innerHTML = "&lt; Previous";
            this.attachEvent(buttonPrevious, "click", this.goToPreviousLocation);

            var buttonNext = document.createElement("a");
            buttonNext.setAttribute("href", "#");
            buttonNext.innerHTML = "Next &gt;";
            this.attachEvent(buttonNext, "click", this.goToNextLocation);

            var locationsList = document.createElement("ul");
            locationsList.style.paddingLeft = "5px";
            locationsList.style.paddingRight = "5px";
            locationsList.style.display = "inline";
            locationsList.style.listStyleType = "none";

            for (var i = 0; i < this.locations.length; i++) {
                var listItem = document.createElement("li");
                var link = document.createElement("a");
                link.setAttribute("href", "#");
                link.innerHTML = this.locations[i].name + "&nbsp;";
                link.setAttribute("data-index", i);
                this.attachEvent(link, "click", this.goToLocation);
                listItem.appendChild(link);
                listItem.appendChild(blank);

                listItem.style.display = "inline";
                locationsList.appendChild(listItem);
            }

            container.appendChild(buttonPrevious);
            container.appendChild(locationsList);
            container.appendChild(buttonNext);
        },
        goToPreviousLocation: function () {
            if (this.locationIndex == 0) {
                this.locationIndex = this.locations.length - 1;
            } else {
                this.locationIndex--;
            }
            this.goToIndex(this.locationIndex);
        },
        goToNextLocation: function () {
            if (this.locationIndex == this.locations.length - 1) {
                this.locationIndex = 0;
            } else {
                this.locationIndex++;
            }
            this.goToIndex(this.locationIndex);
        },
        goToLocation: function (event) {
            var eventSource = (event.target ? event.target : event.srcElement);
            this.locationIndex = parseInt(eventSource.getAttribute("data-index"));
            this.goToIndex(this.locationIndex);
        },
        goToIndex: function (index) {
            this.infoWindow.close();

            var location = new google.maps.LatLng(
                this.locations[index].latitude, this.locations[index].longitude);

            this.marker.setPosition(location);
            this.marker.setTitle(this.locations[index].name);

            this.map.panTo(location);
            this.infoWindow.setContent(this.locations[index].info);
        },
        bindAsEventListener: function (context, fn) {
            return function (event) {
                return fn.call(context, (event || window.event));
            }
        },
        attachEvent: function (element, eventType, eventHandler) {
            if (document.attachEvent) {
                element.attachEvent("on" + eventType, eventHandler);
            } else if (document.addEventListener) {
                element.addEventListener(eventType, eventHandler, false);
            } else {
                element["on" + eventType] = eventHandler;
            }
        }
    });

    return {
        Map: Map
    };
})();