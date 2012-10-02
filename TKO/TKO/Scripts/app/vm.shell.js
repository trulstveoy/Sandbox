/*global define */
/*jslint white: true */
define('vm.shell',
    ['ko', 'sammy', 'vm.customer', 'vm.product'],
    function(ko, sammy, customerVm, productVm) {
        "use strict";
    
        var title = ko.observable("Shell view"),
            leftViewModel = ko.observable(customerVm),
            rightViewModel = ko.observable(productVm),
            swapViews = function () {

                var temp1 = leftViewModel(),
                    temp2 = rightViewModel();
                leftViewModel(temp2);
                rightViewModel(temp1);
            };

        return {
            title: title,
            leftViewModel: leftViewModel,
            rightViewModel: rightViewModel,
            swapViews: swapViews
        };
	});