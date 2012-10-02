/*global define */
/*jslint white: true */
define('vm.product',
    ['ko'],
    function(ko) {
        "use strict";

        var title = ko.observable("Product"),
            templateName = ko.observable("productTemplate"),
            calories = ko.observable(3200),
            onObserveCalories,
            observeCalories = function(onObserveCaloriesParam) {
                onObserveCalories = onObserveCaloriesParam;
            };

        calories.subscribe(function (newValue) {
            if (onObserveCalories) {
                onObserveCalories(newValue);
            }
        });

        return {
            title: title,
            templateName: templateName,
            calories: calories,
            observeCalories: observeCalories
        };
	});