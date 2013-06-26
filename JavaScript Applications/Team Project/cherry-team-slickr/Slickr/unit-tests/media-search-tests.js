/// <reference path="qunit-1.11.0.js" /> 
/// <reference path="../scripts/jquery-1.10.0.js" /> 
/// <reference path="../scripts/prototype.js" /> 
/// <reference path="../scripts/media-search.js" /> 

module("MediaSearch");

test("FlickrImageSearcher constructor test, empty media data", function () {
    var mediaSearcher = new mediaSearch.FlickrImageSearcher();
    var mediaData = mediaSearcher.getMediaData();

    strictEqual(mediaData.length, 0, "We expect media data to be an empty array.");
    deepEqual(mediaData, [], "We expect media data to be an empty array.");
});

test("FlickrImageSearcher constructor test, no callback passed", function () {
    var mediaSearcher = new mediaSearch.FlickrImageSearcher();
    var dataManager = mediaSearcher.getDataManager();

    strictEqual(typeof dataManager, "undefined", "We expect the callback to be undefined.");
});

test("FlickrImageSearcher constructor test, callback passed", function () {

    var dummyFunction = function () {
        // does nothing
    };

    var mediaSearcher = new mediaSearch.FlickrImageSearcher(dummyFunction);
    var dataManager = mediaSearcher.getDataManager();

    deepEqual(dataManager, dummyFunction, "We expect the data manager callback to be initialized.");
});

test("YouTubeVideoSearcher constructor test, empty media data", function () {
    var mediaSearcher = new mediaSearch.YouTubeVideoSearcher();
    var mediaData = mediaSearcher.getMediaData();

    strictEqual(mediaData.length, 0, "We expect media data to be an empty array.");
    deepEqual(mediaData, [], "We expect media data to be an empty array.");
});

test("YouTubeVideoSearcher constructor test, no callback passed", function () {
    var mediaSearcher = new mediaSearch.YouTubeVideoSearcher();
    var dataManager = mediaSearcher.getDataManager();

    strictEqual(typeof dataManager, "undefined", "We expect the callback to be undefined.");
});

test("YouTubeVideoSearcher constructor test, no default image URL passed", function () {
    var dummy;
    var mediaSearcher = new mediaSearch.YouTubeVideoSearcher(dummy);
    var defaultImageUrl = mediaSearcher.getDefaultImageUrl();

    strictEqual(typeof defaultImageUrl, "undefined", "We expect the default image URL to be undefined.");
});

test("YouTubeVideoSearcher constructor test, default image URL passed", function () {
    var mediaSearcher = new mediaSearch.YouTubeVideoSearcher(null, "../images/no-thumbnail.png");
    var dataManager = mediaSearcher.getDataManager();
    var defaultImageUrl = mediaSearcher.getDefaultImageUrl();

    strictEqual(dataManager, null, "We expect the callback to be null.");
    strictEqual(defaultImageUrl, "../images/no-thumbnail.png", "We expect the default image URL to be a non-empty string.");
});

asyncTest("YouTubeVideoSearcher.getUploadedVideos test 10 videos returned", function () {

    var maxCount = 10;

    var mediaSearcher = new mediaSearch.YouTubeVideoSearcher(function (mediaData) {
        strictEqual(mediaData.length, maxCount, "We expect the returned videos will be 10.");
        start();
    });

    var defaultImageUrl = mediaSearcher.getUploadedVideos("TelerikAcademy", maxCount, "5");
});

asyncTest("YouTubeVideoSearcher.getUploadedVideos test non-existent user", function () {

    var maxCount = 10;

    var mediaSearcher = new mediaSearch.YouTubeVideoSearcher(function (mediaData) {

        strictEqual(mediaData.length, 0, "We expect the returned videos will be 0.");
        deepEqual(mediaData, [], "We expect media data to be an empty array.");
        start();
    });

    var defaultImageUrl = mediaSearcher.getUploadedVideos("InvalidUserName", maxCount, "5");
});

asyncTest("YouTubeVideoSearcher.getMatchingVideos test 7 videos returned", function () {

    var maxCount = 7;

    var mediaSearcher = new mediaSearch.YouTubeVideoSearcher(function (mediaData) {

        strictEqual(mediaData.length, maxCount, "We expect the returned videos will be maxCount.");
        start();
    });

    var defaultImageUrl = mediaSearcher.getMatchingVideos("asp,mvc", "and", maxCount, "5");
});

asyncTest("FlickrImageSearcher.getImages test 6 videos returned", function () {

    var maxCount = 6;

    var mediaSearcher = new mediaSearch.FlickrImageSearcher(function (mediaData) {

        strictEqual(mediaData.length, maxCount, "We expect the returned videos will be maxCount.");
        start();
    });

    var defaultImageUrl = mediaSearcher.getImages("jQuery", maxCount);
});