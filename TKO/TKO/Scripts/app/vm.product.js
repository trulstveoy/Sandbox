/*global define */
/*jslint white: true */
define('vm.product',
    ['ko'],
    function(ko) {
        "use strict";

        var title = ko.observable("Product"),
            templateName = ko.observable("productTemplate"),
            calories = ko.observable(3200);

        return {
            title: title,
            templateName: templateName,
            calories: calories
        };
	});