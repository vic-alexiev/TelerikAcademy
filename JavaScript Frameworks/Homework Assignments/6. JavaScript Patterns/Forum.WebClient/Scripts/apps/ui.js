define(["jquery", "mustache", "controls", "jqueryUI"], function ($, mustache, controls) {
    var ui = (function () {

        function buildLoginForm() {

            var loginFormTemplate = mustache.compile(document.getElementById("login-form-template").innerHTML);
            var html = loginFormTemplate();
            return html;
        }

        function buildRegisterForm() {
            var registerFormTemplate = mustache.compile(document.getElementById("register-form-template").innerHTML);
            var html = registerFormTemplate();
            return html;
        }

        function buildForumUI(posts) {

            var postsTemplate = mustache.compile(document.getElementById("posts-template").innerHTML);
            var postsHtml = '<a href="#" id="btn-logout">Logout</a><br />';
            postsHtml += postsTemplate(posts);
            return postsHtml;
        }

        function buildSinglePost(postData) {

            var singlePostTemplate = mustache.compile(document.getElementById("single-post-template").innerHTML);
            var html = singlePostTemplate(postData);
            return html;
        }

        return {
            loginForm: buildLoginForm,
            registerForm: buildRegisterForm,
            forumUI: buildForumUI,
            singlePost: buildSinglePost
        };

    }());

    return ui;
});