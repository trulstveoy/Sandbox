/*global define, require, requirejs */
/*jslint sloppy: true white: true */
(function () {
    var root = this; //omit use strict to make this work
    function defineDependencies() {
        define('jquery', [], function () { return root.jQuery; });
        define('ko', [], function () { return root.ko; });
        define('sammy', [], function () { return root.Sammy; });
    }
    
    function boot() {
        requirejs.config({
            baseUrl: 'Scripts/app'
        });

        requirejs(['bootstrapper'], function (bs) {
            bs.run();
        });
    }

    defineDependencies();
    boot();
}());