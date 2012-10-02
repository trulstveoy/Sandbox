/*global define */
/*jslint white: true */
define('vm.left',
    ['ko'],
    function(ko) {
        "use strict";

        var title = ko.observable("Left view"),
            getTemplate = ko.observable("leftTemplate"),
            setTemplate = function(templateName) {
                getTemplate(templateName);
            };

        return {
            title: title,
            getTemplate: getTemplate,
            setTemplate: setTemplate
        };
	});