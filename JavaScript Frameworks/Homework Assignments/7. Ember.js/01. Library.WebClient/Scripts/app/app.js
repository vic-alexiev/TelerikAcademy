/// <reference path="../libs/http-requester.js" />

(function () {
    App = Ember.Application.create({});

    App.Router.map(function () {
        this.resource('about');
        this.resource('books', function () {
            this.resource('book', { path: ':book_id' });
        });
    });

    App.BooksRoute = Ember.Route.extend({
        model: function () {
            return httpRequester.getJSON('http://localhost:12576/api/books').then(function (books) {
                return books;
            });
        }

        //setupController: function (controller) {

        //    httpRequester.getJSON('http://localhost:12576/api/books').then(function (books) {
        //        controller.set('model', books);
        //    });
        //}
    });

    App.BookRoute = Ember.Route.extend({
        model: function (params) {
            return httpRequester.getJSON('http://localhost:12576/api/books/' + params.book_id).then(function (book) {
                return book;
            }, function (error) {
                console.log(JSON.stringify(error));
            });
        }
    });

    App.BookController = Ember.ObjectController.extend({
        isEditing: false,

        edit: function () {
            this.set('isEditing', true);
        },

        doneEditing: function () {
            this.set('isEditing', false);

            var book = this.get('model');

            httpRequester.putJSON('http://localhost:12576/api/books/' + book.id, book).then(function (result) {
                console.log(JSON.stringify(result));
            });
        },

        remove: function () {

            var book = this.get('model');

            var self = this;
            httpRequester.deleteJSON('http://localhost:12576/api/books/' + book.id).then(function (result) {
                self.transitionToRoute('/');
                console.log(JSON.stringify(result));
            });
        }
    });

    var showdown = new Showdown.converter();

    Ember.Handlebars.helper('format-markdown', function (input) {
        return new Handlebars.SafeString(showdown.makeHtml(input));
    });

    Ember.Handlebars.helper('format-date', function (date) {
        return moment(date).fromNow();
    });
})();