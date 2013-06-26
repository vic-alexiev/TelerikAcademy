var dataRetrieval = (function () {

    /**
     * Select all images, turn them into list of 
     * @param element jQuery element
     **/
    var GalleryCrawler = Class.create({

        initialize: function (element) {
            this.element = element;
        },

        /**
         * extract images from the given element
         * @return image URLs and other information
         */
        getData: function () {

            var data = [];
            var self = this;
            this.element.find("img").each(function (i) {
                var img = jQuery(this);
                var item = {
                    "imageUrl": img.attr("src"),
                    "title": img.attr("title"),
                    "description": img.attr("title")
                };

                data.push(item);
            });

            return data;
        }
    });

    return {
        GalleryCrawler: GalleryCrawler
    };

})();