var social = (function () {

    window.fbAsyncInit = function () {
        // init the FB JS SDK
        FB.init({
            appId: "347176632052577", // App ID from the app dashboard
            status: true, // Check Facebook Login status
            xfbml: true // Look for social plugins on the page
        });
    };

    // Load the SDK asynchronously
    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/all.js";
        fjs.parentNode.insertBefore(js, fjs);
    }(document, "script", "facebook-jssdk"));

    var FacebookSharer = Class.create({

        post: function (mediaItem) {

            FB.ui({
                method: "feed",
                name: mediaItem.title,
                caption: mediaItem.title,
                description: mediaItem.description,
                link: mediaItem.videoUrl,
                picture: mediaItem.imageUrl

            }, function (response) {
                if (response && response.post_id) {
                    alert("Post was published.");
                } else {
                    alert("Post was not published.");
                }
            });
        }
    });

    return {
        FacebookSharer: FacebookSharer
    };
})();