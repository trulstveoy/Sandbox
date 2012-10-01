/*global define */
/*jslint white: true */
define('vm.right',
    ['ko'],
    function(ko) {
        "use strict";
    
        var title = ko.observable("Right view");

        return {
            title: title
        };
	});