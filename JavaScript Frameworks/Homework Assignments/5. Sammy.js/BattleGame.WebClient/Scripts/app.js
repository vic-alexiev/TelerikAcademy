/// <reference path="libs/require.js" />
/// <reference path="libs/mustache.js" />
/// <reference path="libs/sammy-0.7.4.js" />
/// <reference path="libs/http-requester.js" />
/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="lib/class.js" />
/// <reference path="lib/rsvp.min.js" />
/// <reference path="apps/controller.js" />
/// <reference path="libs/jquery-ui.js" />
/// <reference path="lib/sha1.js" />

(function () {
    require.config({
        paths: {
            jquery: "libs/jquery-2.0.3",
            underscore: "libs/underscore",
            mustache: "libs/mustache",
            sammy: "libs/sammy-0.7.4",
            rsvp: "libs/rsvp.min",
            "httpRequester": "libs/http-requester",
            "class": "libs/class",
            "controls": "apps/controls",
            sha1: "libs/sha1",
            jqueryUI: "libs/jquery-ui"
        }
    })

    require(["jquery", "sammy", "mustache", "rsvp", "apps/controller"],
        function ($, sammy, mustache, rsvp, controllers) {

            var controller = controllers.get("#content");

            var app = sammy("#content", function () {
                this.get("#/", function () {
                    $("#content").html("<img width=\"650\" src='Images/BattleField.jpg' />");
                });
                this.get("#/login", function () {
                    if (controller.isUserLoggedIn()) {
                        window.location = "#/main";
                    }
                    else {
                        controller.loadUI("#content");
                    }
                });

                this.get("#/register", function () {
                    if (controller.isUserLoggedIn()) {
                        window.location = "#/main";
                    }
                    else {
                        controller.loadRegisterFormUI("#content");
                    }
                });
                this.get("#/main", function () {
                    if (controller.isUserLoggedIn()) {
                        controller.loadGameUI("#content");
                        $("#first-page").addClass("hidden");
                    }
                    else {
                        window.location = "#/login";
                    }
                });
                this.get("#/join", function () {
                    if (controller.isUserLoggedIn()) {
                        controller.loadOpenGames("#content");
                        $("#first-page").addClass("hidden");
                    }
                    else {
                        window.location = "#/login";
                    }

                });
                this.get("#/active", function () {
                    if (controller.isUserLoggedIn()) {
                        controller.loadActiveGames("#content");
                        $("#first-page").addClass("hidden");
                    }
                    else {
                        window.location = "#/login";
                    }

                });
                this.get("#/field/:gameId", function () {
                    if (controller.isUserLoggedIn()) {
                        var gameId = this.params["gameId"];
                        $("#first-page").addClass("hidden");
                        controller.loadGameField("#content", gameId);
                    }
                    else {
                        window.location = "#/login";
                    }
                });
            });

            $(function () {
                app.run("#/");
            });
        });
}());