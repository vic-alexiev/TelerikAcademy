/// <reference path="../libs/_references.js" />

window.views = (function () {
    var Views = Class.create({
        init: function (rootPath) {
            this.root = rootPath;
            this.templates = {};
        },

        loadPartialHtml: function (name) {
            var self = this;
            var promise = new RSVP.Promise(function (resolve, reject) {
                if (self.templates[name]) {
                    resolve(self.templates[name]);
                }
                else {
                    $.ajax({
                        url: self.root + name + ".html",
                        type: "GET",
                        success: function (templateHtml) {
                            self.templates[name] = templateHtml;
                            resolve(self.templates[name]);
                        },
                        error: function (err) {
                            reject(err);
                        }
                    });
                }
            });

            return promise;
        },

        booksView: function () {
            return this.loadPartialHtml("books");
        }
    });

    return {
        get: function (rootPath) {
            return new Views(rootPath);
        }
    };

}());