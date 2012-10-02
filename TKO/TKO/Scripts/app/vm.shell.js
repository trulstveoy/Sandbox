/*global define */
/*jslint white: true */
define('vm.shell',
    ['ko', 'sammy', 'vm.customer', 'vm.product'],
    function(ko, sammy, customerVm, productVm) {
        "use strict";
        
        var title = ko.observable("Shell view"),
            announcement = ko.observable("Eat burger, live happy"),
            leftViewModel = ko.observable(customerVm),
            rightViewModel = ko.observable(productVm),
            swapViews = function () {
                var temp1 = leftViewModel(),
                    temp2 = rightViewModel();
                leftViewModel(temp2);
                rightViewModel(temp1);
            };
        
        productVm.observeCalories(function (calories) {

            if (calories > 3200) {
                announcement("Eat burger, die happy");
            }
            else {
                announcement("Eat burger, die hungry");
            }
        });

        return {
            title: title,
            announcement: announcement,
            leftViewModel: leftViewModel,
            rightViewModel: rightViewModel,
            swapViews: swapViews
            
        };
	});