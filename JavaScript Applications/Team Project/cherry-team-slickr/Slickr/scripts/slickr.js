var controls = (function () {

    var Slickr = Class.create({

        initialize: function (options) {

            this.element = null;
            this.options = jQuery.extend({
                slidePanelClassName: "slide-panel",
                navLeftClassName: "nav-left",
                navRightClassName: "nav-right",
                slideClassName: "slide-block", // class to determine the width of each slide,
                itemRenderer: this.itemRenderer,
                galleryRenderer: this.galleryRenderer,
                playerId: this.playerId,
                autoScrollDelay: this.autoScrollDelay
            }, options);

            // gallery data
            this.data = null;
            this.slidesCount = 0;
            this.slideWidth = null;

            // 1-based index
            this.currentSlide = -1;
            this.isAnimating = false;
            this.slidePanel = null;
            this.navLeft = null;
            this.navRight = null;

            this.player = jQuery("#" + this.options.playerId);

            // auto-scroll
            this.autoScrollInterval = null;
        },

        getData: function () {
            return this.data;
        },

        getCurrentSlide: function () {
            return this.currentSlide;
        },

        getSlidesCount: function () {
            return this.slidesCount;
        },

        getCurrentSlideData: function () {
            return this.data[this.currentSlide];
        },

        /**
         * @see render() function
         **/
        itemRenderer: function (itemData) {
            var padder = jQuery("<div></div>").addClass("slide-padder").addClass(this.options.slideClassName);
            var vAligner = jQuery("<div></div>").addClass("slide-valigner");
            var img = jQuery("<img />")
                .attr("src", itemData.imageUrl)
                .attr("alt", itemData.title);

            // this is a YouTube video thumbnail 
            if (itemData.mediaPlayerUrl) {
                var self = this;

                var link = jQuery("<a></a>")
                    .on("click", function click() {
                        self.player.show();
                        self.player.html("<object width = '640' height ='360'>" +
                            "<param name = 'allowFullScreen' value = 'true'/>" +
                            "<param name = 'movie' value =" + itemData.mediaPlayerUrl + "  />" +
                            "<param name = 'allowScriptAccess' value = 'always'/>" +
                            "<embed src = " + itemData.mediaPlayerUrl + " type = 'application/x-shockwave-flash' allowfullscreen='true' allowScriptAccess='always' width='640' height='360'></embed>" +
                            "</object>");
                    })
                    .attr("title", itemData.title)
                    .addClass("video")
                    .append(img);

                padder.append(vAligner.append(link));

            } else {
                padder.append(vAligner.append(img));
                this.player.hide();
            }

            return padder;
        },

        /**
         * @see render() function
         **/
        galleryRenderer: function (self) {
            var html =
            '<div class="' + self.options.slidePanelClassName + '" style="display:none"></div>' +
            '<a href="javascript:void(0)" class="' + self.options.navLeftClassName + '" style="display:none">Backward</a>' +
            '<a href="javascript:void(0)" class="' + self.options.navRightClassName + '" style="display:none">Forward</a>';

            return jQuery(html);
        },

        /**
         * @param data list tuples containing image information
         **/
        setData: function (data) {
            this.data = data;
            this.slidesCount = data.length;
            return this;
        },

        /**
         * render gallery to the targeted jQuery element
         * @param element jQuery element
         */
        render: function (element) {

            this.element = element;

            this.element.append(this.options.galleryRenderer.apply(this, [this]));

            var panel = element.find("." + this.options.slidePanelClassName);

            panel.empty();

            for (var i in this.data) {
                var slide = this.options.itemRenderer.apply(this, [this.data[i]]);
                panel.append(slide);
            }

            this.slidePanel = panel;
            this.slideWidth = panel.find("." + this.options.slideClassName).width();

            panel.width(this.slidesCount * this.slideWidth);
            panel.show();
            this.element.show();

            this.setupNav();

            this.scrollTo(0);
        },

        setupNav: function () {
            this.navLeft = this.element.find("." + this.options.navLeftClassName);
            this.navRight = this.element.find("." + this.options.navRightClassName);
            var self = this;

            this.navLeft.click(function () {
                if (self.currentSlide > 0) {
                    self.scrollTo(parseInt(self.currentSlide) - 1);
                }
            });

            this.navRight.click(function () {
                if (self.currentSlide < self.slidesCount) {
                    self.scrollTo(parseInt(self.currentSlide) + 1);
                }
            });
        },

        scrollToBeginning: function () {
            this.scrollTo(0);
        },

        scrollToEnd: function () {
            this.scrollTo(this.slidesCount - 1);
        },

        /**
         * Scroll to a slide. Index is 0 based.
         */
        scrollTo: function (index) {
            if (this.isAnimating) {
                return;
            }

            if (index < 0 || index >= this.slidesCount) {
                return;
            }

            if (index == this.currentSlide) {
                return;
            }

            this.isAnimating = true;
            this.slidePanel.show();
            var self = this;

            // hide navigations first, then show after animation is completed.
            this.navLeft.hide();
            this.navRight.hide();

            this.slidePanel.animate({
                left: (-(index * this.slideWidth)) + "px"
            }, "slow", function () {
                self.currentSlide = index;
                self.isAnimating = false;
                self.showHideNav();
                self.element.trigger('slickr.animation-completed');
            });
        },

        showHideNav: function () {

            if (this.currentSlide >= this.slidesCount - 1) {
                this.navLeft.show();
                this.navRight.hide();
            } else if (this.currentSlide <= 0) {
                this.navLeft.hide();
                this.navRight.show();
            } else {
                this.navLeft.show();
                this.navRight.show();
            }
        },

        autoScroll: function (enabled) {
            clearInterval(this.autoScrollInterval);

            if (!enabled)
                return;
            if (this.getSlidesCount <= 1)
                return;

            var self = this;
            this.autoScrollInterval = setInterval(function () {
                if (self.currentSlide >= self.slidesCount - 1)
                    self.scrollToBeginning();
                self.scrollTo(self.currentSlide + 1);
            }, this.options.autoScrollDelay);
        },

        getRepoData: function (searchString) {
            return {
                searchString: searchString
            };
        },

        repository: {

            save: function (repoName, repoData) {
                localStorage.setObject(repoName, repoData);
            },

            load: function (repoName) {
                return localStorage.getObject(repoName);
            }
        }
    });

    return {
        Slickr: Slickr
    };

})();