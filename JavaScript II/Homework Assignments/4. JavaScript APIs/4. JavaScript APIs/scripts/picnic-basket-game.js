var picnicBasketGame = (function () {

    var ITEMS_TOTAL = 10;
    var FIELD_ID = "field";

    var BASKET_TOP = screen.availHeight - 400;
    var BASKET_LEFT = 30;
    var BASKET_CLOSED_IMAGE = "images/PicnicBasketClosed.png";
    var BASKET_OPENED_IMAGE = "images/PicnicBasketOpened.png";

    var MIN_TOP = 10;
    var MIN_LEFT = 300;
    var MAX_TOP = screen.height - 300;
    var MAX_LEFT = screen.width - 400;

    var TOP_SCORES_TO_KEEP = 5;

    var startTime = new Date();
    var itemsCount = 0;

    var images = [
        "images/Apple.png",
        "images/Banana.png",
        "images/Cherries.png",
        "images/Grapes.png",
        "images/Lemon.png",
        "images/Pineapple.png",
        "images/Raspberry.png",
        "images/Strawberry.png"
    ];

    // Returns a random integer between min and max
    // Using Math.round() will give you a non-uniform distribution!
    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function createItem(minTop, minLeft, maxTop, maxLeft) {

        var item = document.createElement("img");
        item.id = "item" + (itemsCount - 1);

        // set the screen position
        item.style.position = "absolute";

        var top = getRandomInt(minTop, maxTop);
        item.style.top = top + "px";

        var left = getRandomInt(minLeft, maxLeft);
        item.style.left = left + "px";

        item.setAttribute("draggable", "true");

        var imageIndex = getRandomInt(0, images.length - 1);
        item.src = images[imageIndex];

        if (item.addEventListener) {
            item.addEventListener("dragstart", dragItem, false);
        } else {
            item.attachEvent("ondragstart", dragItem);
        }

        return item;
    }

    function dragItem(event) {
        // ensure the event object is defined
        if (!event) event = window.event;
        var eventSource = (event.target ? event.target : event.srcElement);

        event.dataTransfer.setData("dragged-item-id", eventSource.id);
    }

    function dropItem(event) {
        // ensure the event object is defined
        if (!event) event = window.event;
        if (event.preventDefault) {
            event.preventDefault();
        }

        var eventSource = (event.target ? event.target : event.srcElement);

        if (event.clientX >= BASKET_LEFT + eventSource.clientWidth / 2 &&
            event.clientY <= BASKET_TOP + eventSource.clientHeight / 3) {

            var itemId = event.dataTransfer.getData("dragged-item-id");
            var item = document.getElementById(itemId);
            item.parentElement.removeChild(item);
            eventSource.src = BASKET_CLOSED_IMAGE;

            itemsCount--;

            if (itemsCount === 0) {
                finishGame();
            }
        } else {
            eventSource.src = BASKET_CLOSED_IMAGE;
        }
    }

    function allowDropItem(event) {
        // ensure the event object is defined
        if (!event) event = window.event;
        var eventSource = (event.target ? event.target : event.srcElement);

        if (event.clientX >= BASKET_LEFT + eventSource.clientWidth / 2 &&
            event.clientY <= BASKET_TOP + eventSource.clientHeight / 3) {

            eventSource.src = BASKET_OPENED_IMAGE;
        }

        if (event.preventDefault) {
            event.preventDefault();
        }
    }

    function restoreState(event) {
        // ensure the event object is defined
        if (!event) event = window.event;
        var eventSource = (event.target ? event.target : event.srcElement);
        eventSource.src = BASKET_CLOSED_IMAGE;

        if (event.preventDefault) {
            event.preventDefault();
        }
    }

    function finishGame() {
        var endTime = new Date();
        // get the time spent gathering the items
        var milliseconds = endTime.getTime() - startTime.getTime();
        var score = milliseconds / 1000;

        var nickname = prompt("Your score (sec): " + score + "\r\nPlease enter your nickname");

        localStorage.setItem(nickname ? nickname : "[anonymous]", score);

        if (localStorage.length > TOP_SCORES_TO_KEEP) {

            var worstScore = 0;
            var worstNickname;
            for (var i = 0; i < localStorage.length; i++) {

                var key = localStorage.key(i);
                var value = Number(localStorage.getItem(key));

                if (value > worstScore) {
                    worstScore = value;
                    worstNickname = key;
                }
            }

            localStorage.removeItem(worstNickname);
        }

        loadGame();
    }

    function addBasket() {
        var basket = document.createElement("img");
        basket.src = BASKET_CLOSED_IMAGE;

        basket.style.position = "absolute";
        basket.style.top = BASKET_TOP + "px";
        basket.style.left = BASKET_LEFT + "px";

        if (basket.addEventListener) {
            basket.addEventListener("drop", dropItem, false);
        } else {
            basket.attachEvent("ondrop", dropItem);
        }

        if (basket.addEventListener) {
            basket.addEventListener("dragover", allowDropItem, false);
        } else {
            basket.attachEvent("ondragover", allowDropItem);
        }

        if (basket.addEventListener) {
            basket.addEventListener("dragleave", restoreState, false);
        } else {
            basket.attachEvent("ondragleave", restoreState);
        }

        var field = document.getElementById(FIELD_ID);
        field.appendChild(basket);
    }

    function addItem() {
        itemsCount++;

        var field = document.getElementById(FIELD_ID);
        var item = createItem(MIN_TOP, MIN_LEFT, MAX_TOP, MAX_LEFT);
        field.appendChild(item);
    }

    // creates a table which contains the top scoring players
    // this data is kept in the local storage
    function displayTopScores() {

        var localStorageArray = [];

        if (localStorage.length && localStorage.length > 0) {

            for (var i = 0; i < localStorage.length; i++) {

                var key = localStorage.key(i);
                var value = Number(localStorage.getItem(key));

                localStorageArray.push({ key: key, value: value });
            }

            localStorageArray.sort(function (kvp1, kvp2) {
                return kvp1.value - kvp2.value;
            });
        }

        var table = document.createElement("table");
        table.style.margin = "auto";

        if (localStorageArray.length > 0) {

            var tableHeader = document.createElement("thead");
            tableHeader.innerHTML =
                "<thead>" +
                "<tr><th colspan='2'>TOP PLAYERS</th></tr>" +
                "<tr><th>NICKNAME</th><th>SCORE (SEC)</th></tr>" +
                "</thead>";
            table.appendChild(tableHeader);
        }

        for (var j = 0; j < localStorageArray.length; j++) {

            var row = document.createElement("tr");
            row.innerHTML =
                "<td><strong>" + localStorageArray[j].key + "</strong></td>" +
                "<td>" + localStorageArray[j].value + "</td>";
            table.appendChild(row);
        }

        var tableFooter = document.createElement("tfoot");
        var footerRow = document.createElement("tr");
        var footerCell = document.createElement("td");
        footerCell.setAttribute("colspan", "2");
        var startButton = document.createElement("button");
        startButton.innerHTML = "Start Game";
        startButton.style.width = "100%";

        // attach click event handler
        if (startButton.addEventListener) {
            startButton.addEventListener("click", startGame, false);
        } else {
            startButton.attachEvent("onclick", startGame);
        }

        footerCell.appendChild(startButton);
        footerRow.appendChild(footerCell);
        tableFooter.appendChild(footerRow);
        table.appendChild(tableFooter);

        var field = document.getElementById(FIELD_ID);
        field.appendChild(table);
    }

    function loadGame() {
        var field = document.getElementById(FIELD_ID);
        // clear field
        while (field.firstChild) {
            field.removeChild(field.firstChild);
        }

        displayTopScores();
    }

    function startGame() {
        var field = document.getElementById(FIELD_ID);
        // clear field
        field.removeChild(document.querySelector("table"));

        addBasket();

        for (var i = 0; i < ITEMS_TOTAL; i++) {
            addItem();
        }

        // start the timer
        startTime = new Date();
    }

    return {
        loadGame: loadGame
    };
})();