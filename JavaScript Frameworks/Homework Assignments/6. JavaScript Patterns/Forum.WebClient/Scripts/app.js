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
            rsvp: "libs/rsvp",
            "httpRequester": "libs/http-requester",
            "class": "libs/class",
            "controls": "apps/controls",
            sha1: "libs/sha1",
            everlive: "libs/everlive.all",
            jqueryUI: "libs/jquery-ui"
        }
    })

    require(["jquery", "sammy", "mustache", "rsvp", "apps/controller"],
        function ($, sammy, mustache, rsvp, controllers) {

            var controller = controllers.get("#content");

            var app = sammy("#content", function () {
                this.get("#/", function () {
                    $("#content").html("Telerik Academy Forum");
                });

                this.get("#/login", function () {
                    if (controller.isUserLoggedIn()) {
                        window.location = "#/posts";
                    }
                    else {
                        controller.loadLoginFormUI("#content");
                    }
                });

                this.get("#/register", function () {
                    if (controller.isUserLoggedIn()) {
                        window.location = "#/posts";
                    }
                    else {
                        controller.loadRegisterFormUI("#content");
                    }
                });

                this.get("#/posts", function () {
                    if (controller.isUserLoggedIn()) {
                        controller.loadForumUI("#content");
                    }
                    else {
                        window.location = "#/login";
                    }
                });

                this.get("#/posts/:postId", function () {
                    var postId = this.params["postId"];
                    if (controller.isUserLoggedIn()) {

                        controller.loadSinglePostEventually("#content", postId);
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