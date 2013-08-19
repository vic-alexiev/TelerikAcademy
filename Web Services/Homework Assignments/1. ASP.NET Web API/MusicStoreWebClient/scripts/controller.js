/// <reference path="class.js" />
/// <reference path="data-persister.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="ui.js" />

var controllers = (function () {

    var rootUrl = "http://localhost:12392/api/";

    var Controller = Class.create({
        init: function () {
            this.dataPersister = data.getPersister(rootUrl);
        },
        loadSongsUI: function (selector) {
            var songsListHTML = ui.getSongsList()
            $(selector).html(songsListHTML);
        },
        
        attachUIEventHandlers: function (selector) {
            var wrapper = $(selector);
            var self = this;

            

            wrapper.on("click", "#btn-load-songs", function () {

                self.dataPersister.user.getSongs(function () {
                    self.loadSongsUI(selector);
                }, function (error) {
                    wrapper.html("Loading songs failed. " + error.responseJSON.Message);
                });

                return false;
            });
        }
    });
    return {
        getController: function () {
            return new Controller();
        }
    }
}());

$(function () {
    var controller = controllers.getController();
    controller.loadUI("#content");
});