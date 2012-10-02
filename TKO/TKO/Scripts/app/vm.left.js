/*global define */
/*jslint white: true */
define('vm.left',
    ['ko'],
    function(ko) {
        "use strict";
    
        var title = ko.observable("Left view");

        return {
            title: title
        };
	});