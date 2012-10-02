/*global define */
/*jslint white: true */
define('vm.left',
    ['ko'],
    function(ko) {
        "use strict";
    
        var leftTitle = ko.observable("Left view");

        return {
            leftTitle: leftTitle
        };
	});