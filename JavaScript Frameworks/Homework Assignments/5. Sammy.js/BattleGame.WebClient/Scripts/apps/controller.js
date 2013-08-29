/// <reference path="class.js" />
/// <reference path="persister.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="ui.js" />

define(["jquery", "class", "apps/persister", "apps/ui", "underscore", "jqueryUI"], function ($, Class, persisters, ui) {
    var controllers = controllers || {};
    var rootUrl = "http://localhost:22954/api/";
    var Controller = Class.create({
        init: function (selector) {
            this.persister = persisters.get(rootUrl);
            this.attachUIEventHandlers(selector);
        },

        isUserLoggedIn: function () {
            return this.persister.isUserLoggedIn();
        },

        loadUI: function (selector) {
            this.loadLoginFormUI(selector);
        },

        loadLoginFormUI: function (selector) {
            var loginFormHtml = ui.loginForm()
            $(selector).html(loginFormHtml);
            $("#btn-login").button();
        },

        loadRegisterFormUI: function (selector) {
            var registerFormHtml = ui.registerForm()
            $(selector).html(registerFormHtml);
            $("#btn-register").button();
        },

        loadGameUI: function (selector) {
            var list = ui.gameUI(this.persister.nickname());
            $("#first-page").addClass("hidden");
            $(selector).html(list);
            this.createNavigation();
            this.createDialogs();
        },

        loadGameField: function (selector, gameId) {
            this.persister.game.field(gameId).then(function (data) {
                var gameFieldHtml = ui.gameField(data);
                $(selector).html(gameFieldHtml);
            }, function (error) {
                $(selector).html("<div class='errors'>" + error.responseJSON.Message + "</div>");
            });
        },

        loadOpenGames: function (selector) {
            this.persister.game.open().then(function (data) {
                var openGamesList = ui.openGamesList(data);
                $(selector).html(openGamesList);
            }, function (error) {
                $(selector).html("<div class='errors'>" + error.responseJSON.Message + "</div>");;
            });
        },

        loadActiveGames: function (selector) {
            this.persister.game.myActive().then(function (data) {
                var activeGamesList = ui.activeGamesList(data);
                $(selector).html(activeGamesList);
            }, function (error) {
                $(selector).html("<div class='errors'>" + error.responseJSON.Message + "</div>");;
            });
        },

        createNavigation: function () {
            $("#create-game").button();
            $("#best-score").button();
            $("#open-game").button();
            $("#my-active-games").button();
            $("#btn-logout").button();
        },

        createDialogs: function () {
            var self = this;
            $("#game-scores").dialog({ autoOpen: false });
            var name = $("#name"),
            password = $("#password"),
            joinPassword = $("#join-password"),
            allFields = $([]).add(name).add(password),
            tips = $(".validateTips");
            function updateTips(t) {
                tips
                .text(t)
                .addClass("ui-state-highlight");
                setTimeout(function () {
                    tips.removeClass("ui-state-highlight", 1500);
                }, 500);
            }
            function checkLength(o, n, min, max) {
                if (o.val().length > max || o.val().length < min) {
                    o.addClass("ui-state-error");
                    updateTips("Length of " + n + " must be between " +
                    min + " and " + max + ".");
                    return false;
                } else {
                    return true;
                }
            }
            function checkRegexp(o, regexp, n) {
                if (!(regexp.test(o.val()))) {
                    o.addClass("ui-state-error");
                    updateTips(n);
                    return false;
                } else {
                    return true;
                }
            }

            $("#game-creator").dialog({
                autoOpen: false,
                height: 300,
                width: 350,
                modal: true,
                buttons: {
                    "Create a game": function () {
                        var bValid = true;
                        allFields.removeClass("ui-state-error");
                        bValid = bValid && checkLength(name, "username", 3, 16);
                        bValid = bValid && checkRegexp(name, /^[a-z]([0-9a-z_])+$/i, "Username may consist of a-z, 0-9, underscores, begin with a letter.");
                        if (bValid) {
                            var game = {
                                title: name.val(),
                            }

                            if (password) {
                                game.password = password.val();
                            }

                            var text = "Successful created";
                            self.persister.game.create(game).then(function (data) {
                            }, function (data) {
                                text = data.responseJSON.Message;
                                return false;
                            });

                            updateTips(text);

                            var that = this;
                            setTimeout(function () {
                                $(that).dialog("close");
                            }, 3000);

                        }
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    allFields.val("").removeClass("ui-state-error");
                    updateTips("Create game by title and/or password.");
                }
            });

            $("#game-join").dialog({

                autoOpen: false,
                height: 300,
                width: 350,
                modal: true,
                buttons: {
                    "Join game": function () {

                        var gameId = $(this).data("game-id");

                        var gameData = {};
                        gameData.gameId = gameId;

                        allFields.removeClass("ui-state-error");
                        if (joinPassword) {
                            gameData.password = joinPassword.val();
                        }

                        var text = "Successful joined";
                        self.persister.game.join(gameData).then(function (data) {
                            console.log(data);
                        }, function (data) {
                            text = data.responseJSON.Message;
                        });

                        updateTips(text);

                        var that = this;
                        setTimeout(function () {
                            $(that).dialog("close");
                        }, 3000);
                        window.location = "#/join";
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    allFields.val("").removeClass("ui-state-error");
                    updateTips("Create game by title and/or password.");
                }
            });
        },

        attachUIEventHandlers: function (selector) {
            var wrapper = $(selector);
            var self = this;

            wrapper.on("click", "#btn-login", function () {
                var user = {
                    username: $(selector + " #tb-login-username").val(),
                    password: $(selector + " #tb-login-password").val()
                }

                self.persister.user.login(user, function () {
                    self.loadGameUI(selector);
                }, function (data) {
                    wrapper.html(JSON.parse(data.responseText).Message);
                });
                return false;
            });

            wrapper.on("click", "#btn-register", function () {
                var user = {
                    username: $(selector + " #tb-register-username").val(),
                    nickname: $(selector + " #tb-register-nickname").val(),
                    password: $(selector + " #tb-register-password").val()
                };

                self.persister.user.register(user, function () {
                    self.loadGameUI(selector);
                }, function (data) {
                    wrapper.html(JSON.parse(data.responseText).Message);
                });
                return false;
            });

            wrapper.on("click", "#btn-logout", function () {
                self.persister.user.logout().then(function () {
                    $("#first-page").removeClass("hidden");
                    self.loadLoginFormUI(selector);
                    clearInterval(updateTimer);
                }, function (err) {
                    console.log(err);
                });
            });

            wrapper.on("click", "#create-game", function () {
                $("#game-creator").dialog("open");
            });

            wrapper.on("click", "#best-score", function () {

                self.persister.user.scores().then(function (data) {
                    var usersSorted = _.sortBy(data, "score").reverse();

                    var list = ui.userScoresList(usersSorted);
                    $("#game-scores").html(list);
                    $("#game-scores").dialog("open");

                }, function (error) {
                    console.log(error);
                });
            });

            wrapper.on("click", "#open-games li", function () {
                if (!($("#game-join").length)) {
                    var dialogHTML = ui.joinGameForm();
                    $("body").append(dialogHTML);
                    self.createDialogs();
                }
                var pText = 'Enter in ' + $(this).children(".game-title").first().text() + ' with or withouth password.'
                $("#game-join p").html(pText);

                var gameId = $(this).data("game-id");
                $("#game-join").data("game-id", gameId).dialog("open");
            });

            wrapper.on("click", "#active-games li a .full", function () {
                var gameId = $(this).parents("li:first").data("game-id")
                self.persister.game.start(gameId).then(function (data) {
                    window.location = "#/active";
                }, function (error) {
                    console.log(error);
                });
            });
        }
    });

    controllers.get = function (selector) {
        return new Controller(selector);
    }

    return controllers;
});