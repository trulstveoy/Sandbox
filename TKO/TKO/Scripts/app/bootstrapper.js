/*global define */
/*jslint white: true */
define('bootstrapper',
    ['jquery', 'ko', 'vm.shell'],
    function ($, ko, shellViewModel) {
        "use strict";

        var run = function () {
            //enable shell
            ko.applyBindings(shellViewModel, $("#shell-view")[0]);
        };

        return {
            run: run
        };
    });