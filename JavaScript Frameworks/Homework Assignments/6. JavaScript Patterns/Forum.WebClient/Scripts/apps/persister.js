/// <reference path="http-requester.js" />
/// <reference path="class.js" />
/// <reference path="http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/sha1.js" />

define(["jquery", "class", "sha1", "httpRequester", "everlive", "rsvp"], function ($, Class, sha1, httpRequester) {
    var persisters = (function () {
        var displayName = localStorage.getItem("displayName");
        var accessToken = localStorage.getItem("accessToken");

        var everliveConfig = {
            appKey: "Vec1mVAtq3kEjNU6",
            url: "https://api.everlive.com/v1/Vec1mVAtq3kEjNU6/"
        };

        var everlive = new Everlive(everliveConfig.appKey);

        function saveUserData(userData) {
            localStorage.setItem("displayName", userData.displayName);
            localStorage.setItem("accessToken", userData.accessToken);
            displayName = userData.displayName;
            accessToken = userData.accessToken;
        }

        function clearUserData() {
            localStorage.removeItem("displayName");
            localStorage.removeItem("accessToken");
            displayName = null;
            accessToken = null;
        }

        function getAuthorizationHeader() {
            return {
                "Authorization": "Bearer " + accessToken
            };
        }

        var MainPersister = Class.create({
            init: function () {
                var currentAccessToken = localStorage.getItem("accessToken");
                if (currentAccessToken != null) {
                    everlive.setup.token = currentAccessToken
                }

                this.user = new UserPersister();
                this.post = new PostPersister();
                this.tag = new TagPersister();
                this.comment = new CommentPersister();
            },
            isUserLoggedIn: function () {
                var isLoggedIn = displayName != null && accessToken != null;
                return isLoggedIn;
            },
            getDisplayName: function () {
                return displayName;
            }
        });

        var UserPersister = Class.create({
            init: function () {
                this.users = everlive.Users;
            },
            login: function (user) {

                var userData = {
                    username: user.username,
                    password: CryptoJS.SHA1(user.username + user.password).toString()
                };
                var self = this;
                return this.users.login(userData.username, userData.password).then(function (data) {
                    var userData = {};
                    userData.accessToken = data.result["access_token"];
                    self.users.currentUser().then(function (data) {
                        userData.displayName = data.result["DisplayName"];
                        saveUserData(userData);
                    }, function (error) {
                        console.log(JSON.stringify(error));
                    });
                }, function (error) {
                    console.log(JSON.stringify(error));
                });
            },

            getById: function (id) {
                return this.users.getById(id);
            },

            register: function (user) {

                var userData = {
                    username: user.username,
                    displayName: user.displayName,
                    email: user.email,
                    password: CryptoJS.SHA1(user.username + user.password).toString()
                };

                return this.users.register(
                    userData.username,
                    userData.password,
                    {
                        Email: userData.email,
                        DisplayName: userData.displayName
                    });
            },

            logout: function () {
                return this.users.logout().then(function () {
                    clearUserData();
                }, function (error) {
                    console.log(JSON.stringify(error));
                });
            }
        });

        var PostPersister = Class.create({
            init: function () {
                this.posts = everlive.data("Posts");
            },

            get: function () {
                return this.posts.get();
            },

            getById: function (id) {
                return this.posts.getById(id);
            }
        });

        var TagPersister = Class.create({
            init: function () {
                this.tags = everlive.data("Tags");
            },

            get: function (tagIds) {
                var query = new Everlive.Query();
                query.where().isin("Id", tagIds);

                return this.tags.get(query);
            }
        });

        var CommentPersister = Class.create({
            init: function () {
                this.comments = everlive.data("Comments");
            },

            get: function (commentIds) {

                var query = new Everlive.Query();
                query.where().isin("Id", commentIds);

                return this.comments.get(query);
            }
        });

        return {
            get: function () {
                return new MainPersister();
            }
        };
    }());

    return persisters;
});