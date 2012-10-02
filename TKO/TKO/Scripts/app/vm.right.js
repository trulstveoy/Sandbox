/*global define */
/*jslint white: true */
define('vm.right',
    ['ko'],
    function(ko) {
        "use strict";

        var title = ko.observable("Right view"),
            getTemplate = ko.observable("rightTemplate"),
            setTemplate = function (templateName) {
                getTemplate(templateName);
            };

        return {
            title: title,
            getTemplate: getTemplate,
            setTemplate: setTemplate
        };
	});