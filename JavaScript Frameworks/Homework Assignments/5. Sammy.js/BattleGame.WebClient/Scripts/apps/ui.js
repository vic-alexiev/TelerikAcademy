define(["jquery", "mustache", "controls", "jqueryUI"], function ($, mustache, controls) {
    var ui = (function () {

        function buildLoginForm() {

            var loginFormTemplate = mustache.compile(document.getElementById("login-form-template").innerHTML);
            var html = loginFormTemplate();
            return html;
        }

        function buildRegisterForm() {
            var html =
                '<div id="register-form-holder">' +
                    '<form>' +
                        '<div id="register-form">' +
                            '<label for="tb-register-username">Username: </label>' +
                            '<input type="text" id="tb-register-username"><br />' +
                            '<label for="tb-register-nickname">Nickname: </label>' +
                            '<input type="text" id="tb-register-nickname"><br />' +
                            '<label for="tb-register-password">Password: </label>' +
                            '<input type="text" id="tb-register-password"><br />' +
                            '<button id="btn-register" class="button">Register</button>' +
                        '</div>' +
                    '</form>' +
                '</div>';
            return html;
        }

        function buildGameUI(nickname) {

            var html = '<div id="nickName">' +
                    '<h1>Hello, ' +
                        nickname +
                     '</h1>' +
                    '</div>' +
                    '<ul id="navigation" class="clearfix">' +
                        '<li>' +
                            '<a onclick="return false;" href="#" id="create-game">Create</a>' +
                        '</li>' +
                        '<li>' +
                            '<a href="#/join" id="open-game">Join game</a>' +
                        '</li>' +
                        '<li>' +
                            '<a href="#/active" id="my-active-games">Active</a>' +
                        '</li>' +
                        '<li>' +
                            '<a onclick="return false;" id="best-score">Score</a>' +
                        '</li>' +
                        '<li>' +
                            '<a href="#" id="btn-logout">Logout</a>' +
                        '</li>' +
                    '</ul>' +
                    '<div id="game-scores" title="Best Scores"></div>' +
                    '<div id="game-creator" title="Create new game">' +
                        '<p class="validateTips">Create game by title and/or password.</p>' +
                        '<form>' +
                            '<fieldset>' +
                                '<label for="name">Game Name</label>' +
                                '<input type="text" name="name" id="name" class="text ui-widget-content ui-corner-all" />' +
                                '<label for="password">Password</label>' +
                                '<input type="password" name="password" id="password" value="" class="text ui-widget-content ui-corner-all" />' +
                            '</fieldset>' +
                        '</form>' +
                    '</div>';

            return html;
        }

        function buildJoinGameForm() {
            var joinGameForm =
                '<div id="game-join" title="Enter in game">' +
                        '<p class="validateTips"></p>' +
                        '<form>' +
                            '<fieldset>' +
                                '<label for="pass">Password</label>' +
                                '<input type="password" name="pass" id="join-password" value="" class="text ui-widget-content ui-corner-all" />' +
                            '</fieldset>' +
                        '</form>' +
                    '</div>';
            return joinGameForm;
        }

        function buildOpenGamesList(games) {

            var openGamesTemplate = mustache.compile(document.getElementById("open-games-template").innerHTML);
            var openGamesHtml = openGamesTemplate(games);
            return openGamesHtml;
        }

        function buildActiveGamesList(games) {
            var activeGamesTemplate = mustache.compile(document.getElementById("active-games-template").innerHTML);
            var activeGamesHtml = activeGamesTemplate(games);
            return activeGamesHtml;
        }

        function buildGameField(data) {
            var htmlPlayers =
                '<a href="#/active" id="back">Back</a>' +
                '<div id="players">' +
                    '<div id="turn">turn: ' + data.turn + '</br>inTurn: ' + data.inTurn + '</div>' +
                    '<span id="red-player">nickname: ' + data.red.nickname + '</span>' +
                    '<span id="blue-player">nickname: ' + data.blue.nickname + '</span>' +
                '</div>';
            var rows = 9;
            var cols = 9;

            var units = new Array(rows * cols);

            var redUnits = data["red"]["units"];
            var position;
            var index;

            for (var i = 0; i < redUnits.length; i++) {
                position = redUnits[i]["position"];
                index = cols * position.x + position.y;
                units[index] = redUnits[i];
            }

            var blueUnits = data["blue"]["units"];

            for (var j = 0; j < blueUnits.length; j++) {
                position = blueUnits[j]["position"];
                index = cols * position.x + position.y;
                units[index] = blueUnits[j];
            }

            var tableView = controls.getTableView(units);
            var gameFieldCellTemplate = mustache.compile(document.getElementById("game-field-cell-template").innerHTML);
            var gameFieldHtml = tableView.render(gameFieldCellTemplate, rows, cols);

            return htmlPlayers + gameFieldHtml;
        }

        function buildGameState(gameField) {
            var html =
                '<div id="game-state" data-game-id="' + gameField.id + '">' +
                    '<h2>' + gameField.title + '</h2>' +
                    '<span> turn: ' + gameField.turn + '</span>' +
                    '<span> in turn: ' + gameField.inTurn + '</span>' +
                    '<div id="blue-guesses" class="guess-holder">' +
                        '<h3>' +
                            gameField.blue.nickname +
                        '</h3>' +
                    '</div>' +
                    '<div id="red-guesses" class="guess-holder">' +
                        '<h3>' +
                            gameField.red.nickname +
                        '</h3>' +
                    '</div>' +
            '</div>';
            return html;
        }

        function buildMessagesList(messages) {
            var list = '<ul class="messages-list">';
            var msg;
            for (var i = 0; i < messages.length; i += 1) {
                msg = messages[i];
                var item =
                    '<li>' +
                        '<a href="#" class="message-state-' + msg.state + '">' +
                            msg.text +
                        '</a>' +
                    '</li>';
                list += item;
            }
            list += '</ul>';
            return list;
        }

        function buildUserScoresList(users) {
            var userScoresTemplate = mustache.compile(document.getElementById("user-scores-template").innerHTML);
            var userScoresHtml = userScoresTemplate(users);
            return userScoresHtml;
        }

        return {
            gameUI: buildGameUI,
            openGamesList: buildOpenGamesList,
            loginForm: buildLoginForm,
            registerForm: buildRegisterForm,
            activeGamesList: buildActiveGamesList,
            gameState: buildGameState,
            messagesList: buildMessagesList,
            userScoresList: buildUserScoresList,
            gameField: buildGameField,
            joinGameForm: buildJoinGameForm
        };

    }());

    return ui;
});