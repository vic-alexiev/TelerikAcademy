(function ($) {
    $.fn.treeView = function () {

        $(this.selector + " li").prepend("<span class='handle'></span>");

        $(this.selector + " li:has(ul)").children(":first-child")
            .addClass("collapsed").click(function () {
                $(this).toggleClass("collapsed expanded")
                    .siblings("ul").toggle();
            });

        return this;
    };
})(jQuery);