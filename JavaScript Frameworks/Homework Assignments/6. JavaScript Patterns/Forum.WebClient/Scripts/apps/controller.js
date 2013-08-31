/// <reference path="class.js" />
/// <reference path="persister.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="ui.js" />
define(["jquery", "class", "apps/persister", "apps/ui", "underscore", "jqueryUI"], function ($, Class, persisters, ui) {
    var controllers = controllers || {};

    var Controller = Class.create({
        init: function (selector) {

            this.persister = persisters.get();
            this.attachUIEventHandlers(selector);
        },

        isUserLoggedIn: function () {
            return this.persister.isUserLoggedIn();
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

        loadForumUI: function (selector) {
            this.persister.post.get().then(function (data) {
                var postsSorted = _.sortBy(data.result, function (p) {
                    return p["CreatedAt"];
                }).reverse();
                var forumHtml = ui.forumUI(postsSorted);
                $(selector).html(forumHtml);
            }, function (error) {
                console.log(JSON.stringify(error));
            });
        },

        loadSinglePost: function (postId) {
            var self = this;
            var postData = {};
            var post = {};

            var promise = new RSVP.Promise(function (resolve, reject) {
                return self.persister.post.getById(postId).then(function (data) {

                    post = data.result;
                    postData.title = post["Title"];
                    postData.content = post["Content"];
                    postData.tags = [];
                    postData.comments = [];
                    postData.author = "anonymous";

                    var tagIds = post["Tags"];
                    var commentIds = post["Comments"];
                    var authorId = post["CreatedBy"];

                    if (tagIds && tagIds.length > 0) {
                        return self.persister.tag.get(tagIds).then(function (tags) {
                            if (tags && tags.result && tags.result.length > 0) {
                                postData.tags = tags.result;
                            }

                            if (commentIds && commentIds.length > 0) {
                                return self.persister.comment.get(commentIds).then(function (comments) {
                                    if (comments && comments.result && comments.result.length > 0) {
                                        postData.comments = comments.result;
                                    }

                                    self.getAuthorById(authorId, self.persister, postData, resolve, reject);

                                }, function (error) {
                                    reject(error);
                                });
                            }

                            self.getAuthorById(authorId, self.persister, postData, resolve, reject);

                        }, function (error) {
                            reject(error);
                        });
                    }
                    if (commentIds && commentIds.length > 0) {
                        return self.persister.comment.get(commentIds).then(function (comments) {
                            if (comments && comments.result && comments.result.length > 0) {
                                postData.comments = comments.result;
                            }

                            self.getAuthorById(authorId, self.persister, postData, resolve, reject);

                        }, function (error) {
                            reject(error);
                        });
                    }

                    self.getAuthorById(authorId, self.persister, postData, resolve, reject);

                }, function (error) {
                    reject(error);
                });
            });

            return promise;
        },

        getAuthorById: function (authorId, persister, postData, resolve, reject) {
            if (authorId != "00000000-0000-0000-0000-000000000000") {
                return persister.user.getById(authorId).then(function (user) {
                    postData.author = user.result["DisplayName"];
                    resolve(postData);
                }, function (error) {
                    reject(error);
                });
            }
            resolve(postData);
        },

        loadSinglePostEventually: function (selector, postId) {
            var self = this;
            this.loadSinglePost(postId).then(function (postData) {
                var singlePostHtml = ui.singlePost(postData);
                $(selector).html(singlePostHtml);

            }, function (error) {
                console.log(JSON.stringify(error));
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

                self.persister.user.login(user).then(function () {
                    window.location = "#/posts";
                }, function () {
                    console.log(JSON.stringify(error));
                });

                return false;
            });

            wrapper.on("click", "#btn-register", function () {
                var user = {
                    username: $(selector + " #tb-register-username").val(),
                    displayName: $(selector + " #tb-register-display-name").val(),
                    email: $(selector + " #tb-register-email").val(),
                    password: $(selector + " #tb-register-password").val()
                };

                self.persister.user.register(user).then(function (data) {
                    window.location = "#/login";
                }, function (error) {
                    console.log(JSON.stringify(error));
                });

                return false;
            });

            wrapper.on("click", "#btn-logout", function () {
                self.persister.user.logout().then(function () {
                    window.location = "#/login";
                    console.log("Redirected to login");
                }, function (error) {
                    console.log(JSON.stringify(error));
                });
            });
        }
    });

    controllers.get = function (selector) {
        return new Controller(selector);
    }

    return controllers;
});