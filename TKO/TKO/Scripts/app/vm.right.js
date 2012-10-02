/*global define */
/*jslint white: true */
define('vm.right',
    ['ko'],
    function(ko) {
        "use strict";
    
        var rightTitle = ko.observable("Right view");

        return {
            rightTitle: rightTitle
        };
	});