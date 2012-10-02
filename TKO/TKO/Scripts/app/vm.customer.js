/*global define */
/*jslint white: true */
define('vm.customer',
    ['ko'],
    function(ko) {
        "use strict";

        var title = ko.observable("Customer"),
            templateName = ko.observable("customerTemplate"),
            age = ko.observable(41);

        return {
            title: title,
            templateName: templateName,
            age: age
        };
	});