var facebookHelper = (function () {

    var profileContainerId = "profileInfo";

    window.fbAsyncInit = function () {
        // init the FB JS SDK
        FB.init({
            appId: "515008555221806", // App ID from the app dashboard
            status: true, // Check Facebook Login status
            xfbml: true // Look for social plugins on the page
        });

        FB.login(function (response) {
            if (response.authResponse) {
                getProfileInfo();
            } else {
                console.log('User cancelled login or did not fully authorize.');
            }
        }, { scope: 'read_friendlists, user_photos, user_birthday' });
    };

    function getProfileInfo() {
        FB.api('/me', function (response) {
            var profileContainer = $("#" + profileContainerId);
            var url = "https://graph.facebook.com/" + response.id + "/picture";
            profileContainer.append('<img src="' + url + '" />' +
                '<div>Name: ' + response.name + '</div>' +
                '<div>Birthday: ' + response.birthday + '</div>' +
                '<div>Location: ' + response.location.name + '</div>');
        });
        $("fb:login-button").css("display", "none");
    }

    // Load the SDK asynchronously
    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/all.js";
        fjs.parentNode.insertBefore(js, fjs);
    }(document, "script", "facebook-jssdk"));

    return {
        showFriends: function (containerSelector) {
            FB.api("/me/friends", function (response) {
                var friendsContainer = $(containerSelector);
                for (i = 0; i < response.data.length; i++) {
                    var friendPictureUrl = "https://graph.facebook.com/" + response.data[i].id + "/picture";
                    var friendName = response.data[i].name;
                    friendsContainer.append('<img src ="' + friendPictureUrl + '" title="' + friendName + '" />');
                }
            });
        },

        sendMessage: function (title, url) {
            FB.ui({
                method: "send",
                name: title,
                link: url,
            });
        },

        logout: function () {
            FB.logout(function (response) {
                // user is now logged out
            });
        }
    };

})();