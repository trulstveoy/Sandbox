/*global define, require */
(function () {
    "use strict";
    var root = this;

    function defineDependencies() {
        // These are already loaded via bundles. 
        // We define them and put them in the root object.
        define('jquery', [], function () { return root.jQuery; });
        define('ko', [], function () { return root.ko; });
        define('sammy', [], function () { return root.Sammy; });
    }
    
    function boot() {
        require(['bootstrapper'], function (bs) { bs.run(); });
    }
    
    defineDependencies();
    boot();
})();