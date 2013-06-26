/// <reference path="qunit-1.11.0.js" /> 
/// <reference path="../scripts/jquery-1.10.0.js" /> 
/// <reference path="../scripts/prototype.js" /> 
/// <reference path="../scripts/gallery-crawler.js" /> 
/// <reference path="../scripts/slickr.js" /> 

(function () {

    var slickr;
    var imagesCount;
    var galleryData;
    var options;

    module("Slickr", {
        setup: function () {

            var imagesContainer = jQuery("#images");
            imagesCount = imagesContainer.children().length;

            var galleryCrawler = new dataRetrieval.GalleryCrawler(imagesContainer);

            galleryData = galleryCrawler.getData();

            options = {
                galleryRenderer: function (self) {
                    var html =
                      '<div class="' + self.options.slidePanelClassName + '" style="display:none"></div>' +
                      '<a href="javascript:void(0)" class="' + self.options.navLeftClassName + '" style="display:none"><img src="images/arrow-left.gif" alt="Backward"/></a>' +
                      '<a href="javascript:void(0)" class="' + self.options.navRightClassName + '" style="display:none"><img src="images/arrow-right.gif" alt="Forward"/></a>' +
                      '<div class="title-desc">' +
                      '<h1></h1>' +
                      '<div class="indicator">SLIDE <span class="currentNumber"></span> OF <span class="totalNumber"></span></div>' +
                      '</div>' +
                      '<p class="desc"></p>';

                    return jQuery(html);
                },
                playerId: "video-player",
                autoScrollDelay: 3000
            };

            slickr = new controls.Slickr(options);

            slickr.setData(galleryData);
        }
    });

    test("Check data items count", function () {

        var data = slickr.getData();

        strictEqual(data.length, galleryData.length, "We expect the media data to contain items.");
        strictEqual(data.length, imagesCount, "We expect the media data to contain items.");
    });

    test("Check all data in the gallery", function () {

        var data = slickr.getData();

        deepEqual(data, galleryData, "We expect Slickr data to be equal to its data source (galleryData).");
    });

    test("Check slides count", function () {

        var slidesCount = slickr.getSlidesCount();

        strictEqual(slidesCount, galleryData.length, "We expect slides count to be equal to images count.");
        strictEqual(slidesCount, imagesCount, "We expect slides count to be equal to images count.");
    });

    test("Check current slide index initial value", function () {

        var currentSlide = slickr.getCurrentSlide();

        strictEqual(currentSlide, -1, "We expect current slide index to be -1.");
    });

    test("Check auto-scroll delay value", function () {

        var autoScrollDelay = slickr.options.autoScrollDelay;

        strictEqual(autoScrollDelay, 3000, "We expect autoScrollDelay to be 3000.");
    });

})();