/*global define */
/*jslint white: true */
define('bootstrapper',
    ['jquery', 'ko', 'vm.shell'],
    function ($, ko, viewModel) {
        "use strict";

        var run = function () {
            debugger;
            var test = viewModel.name;
            //enable shell
            ko.applyBindings(viewModel, $("#shell-view")[0]);
        };

        return {
            run: run
        };
    });