var recycleBinGame = (function () {

    var ITEMS_TOTAL = 10;
    var FIELD_ID = "field";
    var RECYCLE_BIN_TOP = 10;
    var RECYCLE_BIN_LEFT = 10;
    var MIN_TOP = 10;
    var MIN_LEFT = 280;
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

        if (event.clientX >= RECYCLE_BIN_LEFT + eventSource.clientWidth / 2 &&
            event.clientY <= RECYCLE_BIN_TOP + eventSource.clientHeight / 3) {

            var itemId = event.dataTransfer.getData("dragged-item-id");
            var item = document.getElementById(itemId);
            item.parentElement.removeChild(item);
            eventSource.src = "images/RecycleBinClosed.png";

            itemsCount--;

            if (itemsCount === 0) {
                finishGame();
            }
        } else {
            eventSource.src = "images/RecycleBinClosed.png";
        }
    }

    function allowDropItem(event) {
        // ensure the event object is defined
        if (!event) event = window.event;
        var eventSource = (event.target ? event.target : event.srcElement);

        if (event.clientX >= RECYCLE_BIN_LEFT + eventSource.clientWidth / 2 &&
            event.clientY <= RECYCLE_BIN_TOP + eventSource.clientHeight / 3) {

            eventSource.src = "images/RecycleBinOpened.png";
        }

        if (event.preventDefault) {
            event.preventDefault();
        }
    }

    function restoreState(event) {
        // ensure the event object is defined
        if (!event) event = window.event;
        var eventSource = (event.target ? event.target : event.srcElement);
        eventSource.src = "images/RecycleBinClosed.png";

        if (event.preventDefault) {
            event.preventDefault();
        }
    }

    function finishGame() {
        var endTime = new Date();
        // get the time spent gathering the items
        var milliseconds = endTime.getTime() - startTime.getTime();
        var score = milliseconds / 1000;

        alert("Your score (sec): " + score);

        var nickname;
        do {
            nickname = prompt("Please enter your nickname");
        } while (!nickname);

        localStorage.setItem(nickname, score);

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

    function addRecycleBin() {
        var recycleBin = document.createElement("img");
        recycleBin.src = "images/RecycleBinClosed.png";

        recycleBin.style.position = "absolute";
        recycleBin.style.top = RECYCLE_BIN_TOP + "px";
        recycleBin.style.left = RECYCLE_BIN_LEFT + "px";

        if (recycleBin.addEventListener) {
            recycleBin.addEventListener("drop", dropItem, false);
        } else {
            recycleBin.attachEvent("ondrop", dropItem);
        }

        if (recycleBin.addEventListener) {
            recycleBin.addEventListener("dragover", allowDropItem, false);
        } else {
            recycleBin.attachEvent("ondragover", allowDropItem);
        }

        if (recycleBin.addEventListener) {
            recycleBin.addEventListener("dragleave", restoreState, false);
        } else {
            recycleBin.attachEvent("ondragleave", restoreState);
        }

        var field = document.getElementById(FIELD_ID);
        field.appendChild(recycleBin);
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

        addRecycleBin();

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