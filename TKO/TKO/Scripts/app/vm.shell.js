/*global define */
/*jslint white: true */
define('vm.shell',
    ['ko', 'sammy', 'vm.left', 'vm.right'],
    function(ko, sammy, leftVm, rightVm) {
        "use strict";
    
        var title = ko.observable("Shell view"),
            leftViewModel = leftVm,
            rightViewModel = rightVm;

        return {
            title: title,
            leftViewModel: leftViewModel,
            rightViewModel: rightViewModel
        };
	});