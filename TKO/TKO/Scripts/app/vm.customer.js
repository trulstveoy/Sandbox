/*global define */
/*jslint white: true */
define('vm.customer',
    ['ko'],
    function(ko) {
        "use strict";

        var title = ko.observable("Customer"),
            templateName = ko.observable("customerTemplate"),
            age = ko.observable(67),
            decreaseLifespan = function() {
                age(42);
            };
            
        return {
            title: title,
            templateName: templateName,
            age: age,
            decreaseLifespan: decreaseLifespan
        };
	});