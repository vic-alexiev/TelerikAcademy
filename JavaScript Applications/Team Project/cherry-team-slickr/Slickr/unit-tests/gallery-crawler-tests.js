/// <reference path="qunit-1.11.0.js" /> 
/// <reference path="../scripts/jquery-1.10.0.js" />
/// <reference path="../scripts/prototype.js" /> 
/// <reference path="../scripts/gallery-crawler.js" /> 

module("GalleryCrawler");

test("Test constructor when element is undefined (no gallery data source)", function () {
    var galleryCrawler = new dataRetrieval.GalleryCrawler();

    strictEqual(typeof galleryCrawler.element, "undefined", "We expect the jQuery element to be undefined.");
});

test("Test getData", function () {

    var imagesContainer = jQuery("#images");
    var imagesCount = imagesContainer.children().length;

    var galleryCrawler = new dataRetrieval.GalleryCrawler(imagesContainer);

    var mediaData = galleryCrawler.getData();

    strictEqual(mediaData.length, imagesCount, "We expect mediaData to contain all the images.");

    for (var i = 0; i < mediaData.length; i++) {

        strictEqual(mediaData[i].imageUrl, "../images/" + (i + 1) + ".jpg", "We expect the same URL's.");
        strictEqual(mediaData[i].title, "Description of the image " + (i + 1), "We expect the same titles.");
    }
});