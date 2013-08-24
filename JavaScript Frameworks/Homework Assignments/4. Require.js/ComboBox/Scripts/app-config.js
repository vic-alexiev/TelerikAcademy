/// <reference path="libs/require.js" />

var appConfig = (function () {

    require.config({
        paths:
            {
                jquery: "libs/jquery-2.0.3",
                httpRequester: "libs/http-requester",
                mustache: "libs/mustache",
                rsvp: "libs/rsvp.min"
            }
    });

    require(["jquery", "httpRequester", "mustache", "data/data-models", "app/list-view", "app/combo-box"], function ($, httpRequester, mustache, dataModels, controls, newControls) {

        $(function () {
            httpRequester.getJSON("http://localhost:20298/api/students/detailed")
            .then(function (data) {
                if (data.length == 0) {
                    throw "No data.";
                }

                var studentTemplate = mustache.compile(document.getElementById("student-template").innerHTML);

                var comboBox = newControls.getComboBox(data);
                var comboBoxHtml = comboBox.render(studentTemplate);
                document.getElementById("combo-box-wrapper").innerHTML = comboBoxHtml;

                var listView = controls.getListView(data);
                var listViewHtml = listView.render(studentTemplate);
                document.getElementById("content").innerHTML = listViewHtml;

                document.getElementById("selected-item").innerHTML = studentTemplate(data[0]);

            }, function (error) {
                console.log(error);
            })
        });

        $("#wrapper").on("click", "#selected-item", function () {
            $("#content").toggle();
        });

        $("#wrapper").on("click", "#drop-down > li", function () {
            $("#content").toggle();
            $("#selected-item").html($(this).html());
        });
    });

})();