/* Copied from John Resig's example in "Secrets of the JavaScript Ninja" 
 * (published by Manning), p. 145 (Listing 6.21 A subclassing method)
 */
(function () {

    var initializing = false,
    superPattern = /xyz/.test(function () { xyz; }) ? /\b_super\b/ : /.*/;

    Object.subClass = function (properties) {

        var _super = this.prototype;

        initializing = true;
        var proto = new this();
        initializing = false;

        for (var name in properties) {

            if (typeof properties[name] == "function" &&
                typeof _super[name] == "function" &&
                superPattern.test(properties[name])) {

                proto[name] = (function (name, fn) {
                    return function () {
                        var tmp = this._super;
                        this._super = _super[name];
                        var ret = fn.apply(this, arguments);
                        this._super = tmp;
                        return ret;
                    };
                })(name, properties[name]);
            } else {
                proto[name] = properties[name];
            }
        }

        function Class() {
            // All construction is actually done in the init method
            if (!initializing && this.init)
                this.init.apply(this, arguments);
        }

        Class.prototype = proto;
        Class.constructor = Class;
        Class.subClass = arguments.callee;
        return Class;
    };
})();