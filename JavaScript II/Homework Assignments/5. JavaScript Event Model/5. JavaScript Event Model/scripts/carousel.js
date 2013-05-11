/*
 * The original source code can be found at
 * http://diegolamonica.info/build-a-simple-semantically-valid-carousel-from-the-scratch-part-1/
 */
jQuery.fn.carouselPlugin = function (images, options) {

    var list = document.createElement("ul");

    for (var i = 0; i < images.length; i++) {
        var listItem = document.createElement("li");
        var image = document.createElement("img");
        image.src = images[i].name;
        image.setAttribute("title", images[i].title);
        listItem.appendChild(image);
        list.appendChild(listItem);
    }

    var base = this;
    base[0].appendChild(list);

    var defaultOptions = {
        maxSize: 120,
        midSize: 110,
        minSize: 80,
        maxOpacity: 1,
        midOpacity: 0.6,
        minOpacity: 0.3,
        speed: 1500
    }

    if (options == null) options = [];
    options = jQuery.extend(defaultOptions, options);
    var $currentVisibleItem = 0;
    var ul = jQuery('>ul', base);

    var $currentX =
        $nearX =
        $farX =
        $nearXR =
        $nearXL =
        $farXR =
        $farXL = 0;

    var $inProgress = false;
    function hideTheExceeding() {
        var
            $items = jQuery('>li', ul),
            $from = $currentVisibleItem - 2,
            $to = $currentVisibleItem + 2;

        for (var $i = 0; $i < $items.length; $i++) {
            if ($i < $from || $i > $to) {
                jQuery($items[$i]).hide();
                jQuery($items[$i]).removeClass('far before after');
            } else {
                jQuery($items[$i]).show();

                if ($i == $currentVisibleItem) {
                    jQuery($items[$i]).addClass('current');
                    jQuery($items[$i]).removeClass('near after before');
                    jQuery($items[$i]).css('opacity', options.maxOpacity);
                    jQuery('.label', base).animate({ opacity: 1 }).html(jQuery('img', $items[$i]).attr('title'));

                } else {
                    jQuery($items[$i]).removeClass('current after before');
                    if ($i == $currentVisibleItem + 1 || $i == $currentVisibleItem - 1) {
                        jQuery($items[$i]).removeClass('far');
                        jQuery($items[$i]).addClass('near');
                        jQuery($items[$i]).css('opacity', options.midOpacity);
                    } else {
                        jQuery($items[$i]).removeClass('near');
                        jQuery($items[$i]).addClass('far');
                        jQuery($items[$i]).css('opacity', options.minOpacity);
                    }
                    if ($i > $currentVisibleItem) {
                        jQuery($items[$i]).addClass('after');
                    } else {
                        jQuery($items[$i]).addClass('before');
                    }
                }
            }

        }
    }
    function locateElements() {
        // Center all items in the list
        jQuery('>li', ul).css({
            position: 'absolute',
            marginTop: ((jQuery(ul).innerHeight() - options.maxSize) / 2) + 'px'
        });
        /*
        * Elaborating the computed width of each visible item of the list... 
        */

        jQuery('>.far', ul).height(options.minSize);
        jQuery('>.near', ul).height(options.midSize);
        jQuery('>.current', ul).height(options.maxSize);
        jQuery('>.far', ul).width(options.minSize);
        jQuery('>.near', ul).width(options.midSize);
        jQuery('>.current', ul).width(options.maxSize);

        var
            $farWidth = jQuery('>.far', ul).outerWidth(),
            $nearWidth = jQuery('>.near', ul).outerWidth(),
            $currentWidth = jQuery('>.current', ul).outerWidth(),
            $availWidth = jQuery(ul).innerWidth(),

            /*
            ...to obtain the median of each position... 
            */
            $currentM = $availWidth / 2,
            $farMR = $availWidth - 10 - $farWidth / 2,
            $farML = 10 + $farWidth / 2,
            $nearMR = ($farMR - $currentM) / 2 + $currentM,
            $nearML = ($currentM - $farML) / 2 + $farML;
        /*
        ...and then the location of each item in the area
        */
        $currentX = $currentM - $currentWidth / 2;
        $nearXR = $nearMR - $nearWidth / 2;
        $nearXL = $nearML - $nearWidth / 2;
        $farXR = $farMR - $farWidth / 2;
        $farXL = $farML - $farWidth / 2;

        /*
         *	Adapt the spacing ensuring that the first adjacent elements of the block (near left and near right)
         *  will be located at least at one pixel far from the central element
         */
        if ($nearXL + $nearWidth + 1 > $currentX) $nearXL = $currentX - $nearWidth - 1;
        if ($nearXR < $currentX + $currentWidth + 1) $nearXR = $currentX + $currentWidth + 1;

        jQuery('>.current', ul).css('marginLeft', $currentX + 'px');
        jQuery('>.near.before', ul).css('marginLeft', $nearXL + 'px');
        jQuery('>.near.after', ul).css('marginLeft', $nearXR + 'px');
        jQuery('>.far.before', ul).css('marginLeft', $farXL + 'px');
        jQuery('>.far.after', ul).css('marginLeft', $farXR + 'px');
        $inProgress = false;
    }
    function moveTo($selector, $margin, $opacity, $w, $h, $last) {
        $inProgress = true;
        if ($last) {

            var $updateFunction = function () {
                hideTheExceeding();
                locateElements();
            }
        } else {
            updateFunction = null;
        }
        jQuery($selector, ul).animate({
            marginLeft: $margin,
            opacity: $opacity,
            width: $w,
            height: $h
        }, options.speed, $updateFunction);
    }
    function movePrev(event) {
        event.preventDefault();
        if ($inProgress) return;
        if ($currentVisibleItem == 0) return;
        $currentVisibleItem -= 1;
        var $nextItem = $currentVisibleItem - 2;

        jQuery('.label', base).animate({ opacity: 0 }, 500);

        moveTo('>.far.after', jQuery(ul).innerWidth() + options.minSize, 0.1, 0, 0, 0);
        moveTo('>.near.after', $farXR, options.minOpacity, options.minSize, options.minSize, false);
        moveTo('>.current', $nearXR, options.midOpacity, options.midSize, options.midSize, false);
        moveTo('>.near.before', $currentX, options.maxOpacity, options.maxSize, options.maxSize, ($nextItem == -2));
        moveTo('>.far.before', $nearXL, options.midOpacity, options.midSize, options.midSize, ($nextItem == -1));
        if ($nextItem >= 0) {

            var $nextToShow = '>li:nth-child(' + ($nextItem + 1) + ')';
            jQuery($nextToShow, ul).css({
                opacity: '0.1',
                display: 'block',
                marginLeft: '-' + options.minSize + 'px'
            });
            moveTo($nextToShow, $farXL, 0.5, options.minSize, options.minSize, true);
        }
    }

    function moveNext(event) {
        event.preventDefault();
        if ($inProgress) return;
        var $elements = jQuery('>li', ul).length;
        if ($elements < $currentVisibleItem + 2) return;
        $currentVisibleItem += 1;
        var $nextItem = $currentVisibleItem + 2;
        var $nextToShow = '>li:nth-child(' + ($nextItem + 1) + ')';
        jQuery($nextToShow, ul).css({
            opacity: '0.1',
            display: 'block',
            marginLeft: (jQuery(ul).innerWidth() + options.minSize) + 'px',
            width: 0,
            height: 0
        });

        jQuery('.label', base).animate({ opacity: 0 }, 500);

        moveTo('>.far.before', -options.minSize, 0, 0, 0, 0);
        moveTo('>.near.before', $farXL, options.minOpacity, options.minSize, options.minSize, false);
        moveTo('>.current', $nearXL, options.midOpacity, options.midSize, options.midSize, false);
        moveTo('>.near.after', $currentX, options.maxOpacity, options.maxSize, options.maxSize, $nextItem == $elements + 1);
        moveTo('>.far.after', $nearXR, options.midOpacity, options.midSize, options.midSize, $nextItem == $elements);
        moveTo($nextToShow, $farXR, options.minOpacity, options.minSize, options.minSize, true);

    }

    return this.each(function () {

        // Create Navigator
        jQuery(base).
            prepend('<a class="nav go-prev" href="#">Prev</a><a href="#" class="nav go-next">Next</a>');
        jQuery(base).
            prepend('<div class="label" />');
        jQuery(base).css('overflow', 'hidden');
        jQuery('.nav', base).css({
            height: jQuery(base).innerHeight() + 'px',
            display: 'block'

        });

        jQuery('>.nav.go-prev', base).css('float', 'left').click(movePrev);
        jQuery('>.nav.go-next', base).css('float', 'right').click(moveNext);
        jQuery('>ul', base).css({
            marginLeft: jQuery('>.nav', base).outerWidth() + 'px',
            width: (jQuery(base).innerWidth() - jQuery('>.nav', base).outerWidth() * 2) + 'px',
            padding: 0,
            height: jQuery(base).innerHeight() + 'px',
            display: 'block'
        });

        jQuery('>.label', base).css({

            position: 'absolute',
            width: jQuery('>ul', base).outerWidth() + 'px',
            marginTop: (jQuery('>ul', base).outerHeight()) + 'px',
            zIndex: '9999',
            marginLeft: jQuery('>.nav.go-prev', base).outerWidth() + 'px',
            textAlign: 'center'
        });

        hideTheExceeding();

        locateElements();
    });
}