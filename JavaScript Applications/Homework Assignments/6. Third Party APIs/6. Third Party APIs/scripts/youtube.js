var youTube = (function () {

    var Player = Class.create({
        init: function (playerContainerId, controlsContainerId, shareButtonId) {
            this.controlsContainer = document.getElementById(controlsContainerId);
            this.shareButton = document.getElementById(shareButtonId);

            // Lets Flash from another domain call JavaScript
            var params = { allowScriptAccess: "always" };
            // The element id of the Flash embed
            var attributes = { id: "ytPlayer" };

            swfobject.embedSWF("http://www.youtube.com/apiplayer?" +
                "version=3&enablejsapi=1&playerapiid=player1",
                playerContainerId, "640", "360", "8", null, null, params, attributes);

            this.ytPlayState = true;
            this.ytMuteState = false;

            this.loadVideo = this.bindAsEventListener(this, this.loadVideo);
            this.toggleVolume = this.bindAsEventListener(this, this.toggleVolume);
            this.adjustVolume = this.bindAsEventListener(this, this.adjustVolume);
            this.togglePlayback = this.bindAsEventListener(this, this.togglePlayback);
            this.loadVideoIds = this.bindAsEventListener(this, this.loadVideoIds);
            this.playPreviousVideo = this.bindAsEventListener(this, this.playPreviousVideo);
            this.playNextVideo = this.bindAsEventListener(this, this.playNextVideo);

            this.addControls();
        },
        initPlayer: function (defaultVideoId, defaultPlaylist) {
            this.player = document.getElementById("ytPlayer");
            this.player.cueVideoById(defaultVideoId);
            this.textBoxVideoId.value = defaultVideoId;
            this.textBoxVideoIds.value = defaultPlaylist;
        },
        togglePlayback: function () {
            this.ytPlayState = !this.ytPlayState;

            if (this.player) {
                if (this.ytPlayState) {
                    this.player.pauseVideo();
                    this.buttonPlay.innerHTML = "Play";
                } else {
                    this.player.playVideo();
                    this.buttonPlay.innerHTML = "Pause";
                }
            }
        },
        toggleVolume: function () {
            this.ytMuteState = !this.ytMuteState;

            if (this.player) {
                if (this.ytMuteState) {
                    this.player.mute();
                    this.buttonMute.innerHTML = "Unmute";
                } else {
                    this.player.unMute();
                    this.buttonMute.innerHTML = "Mute";
                }
            }
        },
        adjustVolume: function () {
            var volume = parseInt(this.slider.value);
            if (isNaN(volume) || volume < 0 || volume > 100) {
                alert("Please enter a valid volume between 0 and 100.");
            } else if (this.player) {
                this.player.setVolume(volume);
            }
        },
        addControls: function () {
            var labelVideoId = document.createElement("label");
            labelVideoId.innerHTML = "Video ID: ";
            this.controlsContainer.appendChild(labelVideoId);

            this.textBoxVideoId = document.createElement("input");
            this.textBoxVideoId.setAttribute("type", "text");
            this.controlsContainer.appendChild(this.textBoxVideoId);

            var buttonLoadVideo = document.createElement("button");
            buttonLoadVideo.innerHTML = "Load video";
            this.controlsContainer.appendChild(buttonLoadVideo);
            this.attachEvent(buttonLoadVideo, "click", this.loadVideo);

            this.buttonPlay = document.createElement("button");
            this.buttonPlay.innerHTML = "Play";
            this.controlsContainer.appendChild(this.buttonPlay);
            this.attachEvent(this.buttonPlay, "click", this.togglePlayback);

            this.buttonMute = document.createElement("button");
            this.buttonMute.innerHTML = "Mute";
            this.controlsContainer.appendChild(this.buttonMute);
            this.attachEvent(this.buttonMute, "click", this.toggleVolume);

            var labelVolume = document.createElement("label");
            labelVolume.innerHTML = "Volume: ";
            this.controlsContainer.appendChild(labelVolume);

            this.slider = document.createElement("input");
            this.slider.setAttribute("type", "range");
            this.slider.setAttribute("min", "1");
            this.slider.setAttribute("max", "100");
            this.slider.setAttribute("step", "1");
            this.slider.setAttribute("value", "100");
            this.controlsContainer.appendChild(this.slider);
            this.attachEvent(this.slider, "change", this.adjustVolume);

            var newLine = document.createElement("br");
            this.controlsContainer.appendChild(newLine);

            var labelPlaylist = document.createElement("label");
            labelPlaylist.innerHTML = "Playlist: ";
            this.controlsContainer.appendChild(labelPlaylist);

            this.textBoxVideoIds = document.createElement("input");
            this.textBoxVideoIds.setAttribute("type", "text");
            this.controlsContainer.appendChild(this.textBoxVideoIds);

            var buttonLoadPlaylist = document.createElement("button");
            buttonLoadPlaylist.innerHTML = "Load playlist";
            this.controlsContainer.appendChild(buttonLoadPlaylist);
            this.attachEvent(buttonLoadPlaylist, "click", this.loadVideoIds);

            var buttonPreviousVideo = document.createElement("button");
            buttonPreviousVideo.innerHTML = "Previous video";
            this.controlsContainer.appendChild(buttonPreviousVideo);
            this.attachEvent(buttonPreviousVideo, "click", this.playPreviousVideo);

            var buttonNextVideo = document.createElement("button");
            buttonNextVideo.innerHTML = "Next video";
            this.controlsContainer.appendChild(buttonNextVideo);
            this.attachEvent(buttonNextVideo, "click", this.playNextVideo);
        },
        playPreviousVideo: function () {
            this.player.previousVideo();
        },
        playNextVideo: function () {
            this.player.nextVideo();
        },
        loadVideoIds: function () {
            var videoIds = this.textBoxVideoIds.value.split(",");
            this.player.loadPlaylist(videoIds, 0, 0, "default");
            this.togglePlayback();
        },
        loadVideo: function () {
            var videoId = this.textBoxVideoId.value;
            this.player.cueVideoById(videoId);

            var videoUrl = this.getLoadedVideoUrl();
            this.shareButton.setAttribute("href", "https://plus.google.com/share?url=" + videoUrl);
        },
        getLoadedVideoUrl: function () {
            return "http://www.youtube.com/watch?v=" + this.textBoxVideoId.value;
        },
        bindAsEventListener: function (context, fn) {
            return function (event) {
                return fn.call(context, (event || window.event));
            }
        },
        attachEvent: function (element, eventType, eventHandler) {
            if (document.attachEvent) {
                element.attachEvent("on" + eventType, eventHandler);
            } else if (document.addEventListener) {
                element.addEventListener(eventType, eventHandler, false);
            } else {
                element["on" + eventType] = eventHandler;
            }
        }
    });

    return {
        Player: Player
    };

})();