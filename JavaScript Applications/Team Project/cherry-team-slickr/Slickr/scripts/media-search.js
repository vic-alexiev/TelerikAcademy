var mediaSearch = (function () {

    var mediaData;
    var dataManager;
    var defaultImageUrl;

    var MediaSearcher = Class.create({

        initialize: function (successCallback) {
            mediaData = [];
            dataManager = successCallback;
        },

        getMediaData: function () {
            return mediaData;
        },

        getDataManager: function () {
            return dataManager;
        }
    });

    var YouTubeVideoSearcher = Class.create(MediaSearcher, {

        initialize: function ($super, successCallback, missingImageUrl) {
            $super(successCallback);
            defaultImageUrl = missingImageUrl;
        },

        getDefaultImageUrl: function () {
            return defaultImageUrl;
        },

        loadData: function (queryUrl) {

            jQuery.getJSON(queryUrl, function (data) {

                mediaData = [];

                if (data.feed.entry) {

                    mediaData = new Array(data.feed.entry.length);

                    jQuery.each(data.feed.entry, function (i, item) {
                        mediaData[i] = new Array(6);
                        if (item["app$control"] && item["app$control"]["yt$state"]) {

                            mediaData[i]["videoUrl"] = "#";
                            mediaData[i]["imageUrl"] = defaultImageUrl;
                            mediaData[i]["id"] = item["app$control"]["yt$state"]["$t"];

                        } else {
                            mediaData[i]["title"] = item["media$group"]["media$title"]["$t"];
                            mediaData[i]["imageUrl"] = item["media$group"]["media$thumbnail"][0]["url"];
                            mediaData[i]["width"] = item["media$group"]["media$thumbnail"][0]["width"];
                            mediaData[i]["height"] = item["media$group"]["media$thumbnail"][0]["height"];
                            mediaData[i]["description"] = item["media$group"]["media$description"]["$t"];
                            mediaData[i]["id"] = item["media$group"]["yt$videoid"]["$t"];
                            mediaData[i]["mediaPlayerUrl"] = "http://www.youtube.com/v/" + mediaData[i]["id"] + "?hl=en_US&amp;version=3";

                            var mediaPlayerUrl = item["media$group"]["media$player"]["url"];
                            var featureIndex = mediaPlayerUrl.search("&feature");

                            mediaData[i]["videoUrl"] = mediaPlayerUrl.substr(0, featureIndex);
                        }
                    });
                }

                dataManager(mediaData);
            });
        },

        getUploadedVideos: function (userName, maxCount, format) {

            if (jQuery.trim(userName).length == 0) {
                username = "InvalidUserName";
            }

            var queryUrl =
                "http://gdata.youtube.com/feeds/api/users/" +
                userName +
                "/uploads?&start-index=1&max-results=" +
                maxCount +
                "&v=2&alt=json-in-script&callback=?";

            if (format === "5") {
                queryUrl += "&format=5";
            }

            this.loadData(queryUrl);
        },

        getMatchingVideos: function (tags, boolOperator, maxCount, format) {

            var tagsArray = tags.split(",");
            var queryUrl =
                "https://gdata.youtube.com/feeds/api/videos?orderby=relevance&start-index=1&max-results=" +
                maxCount +
                "&v=2&alt=json-in-script&callback=?&q=";

            var query = "";
            if (boolOperator === "and") {

                query = "%22" + tagsArray[0];

                for (var i = 1; i < tagsArray.length; i++) {
                    query += "+" + tagsArray[i];
                }

                query += "%22";

            } else if (boolOperator === "or") {

                query = tagsArray[0];

                for (i = 1; i < tagsArray.length; i++) {

                    query += "%7c" + tagsArray[i];
                }
            }

            queryUrl += query;

            if (format === "5") {
                queryUrl += "&format=5";
            }

            this.loadData(queryUrl);
        },
    });

    var FlickrImageSearcher = Class.create(MediaSearcher, {

        initialize: function ($super, successCallback) {
            $super(successCallback);
        },

        getImages: function (words, maxCount) {

            var queryUrl = "http://api.flickr.com/services/feeds/photos_public.gne?jsoncallback=?";
            jQuery.getJSON(queryUrl, {
                tags: words,
                tagmode: "any",
                format: "json"
            })
            .done(function (data) {

                mediaData = new Array(maxCount);

                jQuery.each(data.items, function (i, item) {

                    if (i === maxCount) {
                        return false;
                    }

                    mediaData[i] = new Array(3);

                    mediaData[i]["imageUrl"] = item["media"]["m"];
                    mediaData[i]["title"] = item["title"];
                    mediaData[i]["id"] = item["link"];
                });

                dataManager(mediaData);
            });
        }
    });

    return {
        YouTubeVideoSearcher: YouTubeVideoSearcher,
        FlickrImageSearcher: FlickrImageSearcher
    };

})();