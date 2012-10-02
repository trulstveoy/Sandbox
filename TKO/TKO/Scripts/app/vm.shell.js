/*global define */
/*jslint white: true */
define('vm.shell',
    ['ko', 'sammy', 'vm.left', 'vm.right'],
    function(ko, sammy, leftVm, rightVm) {
        "use strict";
    
        var title = ko.observable("Shell view"),
            leftViewModel = leftVm,
            rightViewModel = rightVm,
            swapViews = function () {
                var name1 = leftViewModel.getTemplate(),
                    name2 = rightViewModel.getTemplate();

                leftViewModel.setTemplate(name2);
                rightViewModel.setTemplate(name1);
                    
            };

        return {
            title: title,
            leftViewModel: leftViewModel,
            rightViewModel: rightViewModel,
            swapViews: swapViews
        };
	});