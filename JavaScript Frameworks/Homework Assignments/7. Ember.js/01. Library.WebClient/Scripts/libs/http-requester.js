/// <reference path="ember-1.0.0.debug.js" />

window.httpRequester = (function () {

    function getJSON(requestUrl, headers) {
        var promise = new Ember.RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "GET",
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });

        return promise;
    }

    function postJSON(requestUrl, data, headers) {
        var promise = new Ember.RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });

        return promise;
    }

    function putJSON(requestUrl, data, headers) {
        var promise = new Ember.RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "PUT",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                headers: headers,
                success: function (result) {
                    resolve(result);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });

        return promise;
    }

    function deleteJSON(requestUrl, headers) {
        var promise = new Ember.RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "DELETE",
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });

        return promise;
    }

    return {
        getJSON: getJSON,
        postJSON: postJSON,
        putJSON: putJSON,
        deleteJSON: deleteJSON
    };
}());