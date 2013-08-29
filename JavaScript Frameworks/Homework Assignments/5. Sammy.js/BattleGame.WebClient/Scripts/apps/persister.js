/// <reference path="http-requester.js" />
/// <reference path="class.js" />
/// <reference path="http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/sha1.js" />

define(["jquery", "class", "sha1", "httpRequester", "rsvp"], function ($, Class, sha1, httpRequester) {
    var persisters = (function () {
        var updateTimer = null;
        var nickname = localStorage.getItem("nickname");
        var sessionKey = localStorage.getItem("sessionKey");

        function saveUserData(userData) {
            localStorage.setItem("nickname", userData.nickname);
            localStorage.setItem("sessionKey", userData.sessionKey);
            nickname = userData.nickname;
            sessionKey = userData.sessionKey;
        }
        function clearUserData() {
            localStorage.removeItem("nickname");
            localStorage.removeItem("sessionKey");
            nickname = "";
            sessionKey = "";
        }

        var MainPersister = Class.create({
            init: function (rootUrl) {
                this.rootUrl = rootUrl;
                this.user = new UserPersister(this.rootUrl);
                this.game = new GamePersister(this.rootUrl);
                this.battle = new BattlePersister(this.rootUrl);
            },
            isUserLoggedIn: function () {
                var isLoggedIn = nickname != null && sessionKey != null;
                return isLoggedIn;
            },
            nickname: function () {
                return nickname;
            }
        });

        var UserPersister = Class.create({
            init: function (rootUrl) {
                //...api/user/
                this.rootUrl = rootUrl + "user/";
            },
            login: function (user, success, error) {
                var url = this.rootUrl + "login";
                var userData = {
                    username: user.username,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString()
                };

                httpRequester.postJSON(url, userData).then(function (data) {
                    saveUserData(data);
                    success(data);
                }, function (data) {
                    error(data);
                });
            },

            register: function (user, success, error) {
                var url = this.rootUrl + "register";
                var userData = {
                    username: user.username,
                    nickname: user.nickname,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString()
                };
                httpRequester.postJSON(url, userData).then(function (data) {
                    saveUserData(data);
                    success(data);
                }, function (data) {
                    error(data);
                });
            },

            logout: function () {
                var url = this.rootUrl + "logout/" + sessionKey;

                return httpRequester.putJSON(url).then(function (data) {
                    clearUserData();
                }, function (error) {
                    console.log(error)
                });
            },

            scores: function () {
                var url = this.rootUrl + "scores/" + sessionKey;
                return httpRequester.getJSON(url);
            }
        });

        var GamePersister = Class.create({
            init: function (url) {
                this.rootUrl = url + "game/";
            },

            create: function (game) {
                var gameData = {
                    title: game.title,
                };
                if (game.password) {
                    gameData.password = CryptoJS.SHA1(game.password).toString();
                }
                var url = this.rootUrl + "create/" + sessionKey;

                return httpRequester.postJSON(url, gameData);
            },

            join: function (game) {
                var gameData = {
                    id: game.gameId,
                };
                if (game.password) {
                    gameData.password = CryptoJS.SHA1(game.password).toString();
                }
                var url = this.rootUrl + "join/" + sessionKey;
                return httpRequester.postJSON(url, gameData);
            },

            start: function (gameId) {
                var url = this.rootUrl + gameId + "/start/" + sessionKey;
                return httpRequester.putJSON(url);
            },

            myActive: function () {
                var url = this.rootUrl + "my-active/" + sessionKey;
                return httpRequester.getJSON(url);
            },

            open: function () {
                var url = this.rootUrl + "open/" + sessionKey;
                return httpRequester.getJSON(url);
            },

            field: function (gameId) {
                var url = this.rootUrl + gameId + "/field/" + sessionKey;
                return httpRequester.getJSON(url);
            }
        });

        var BattlePersister = Class.create({
            init: function (url) {
                this.rootUrl = url + "battle/";
            },
            make: function () {

            }
        });
        return {
            get: function (url) {
                return new MainPersister(url);
            }
        };
    }());

    return persisters;
});