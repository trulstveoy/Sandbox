/*global define */
/*jslint white: true */
define('vm.shell',
    ['ko', 'sammy'],
    function(ko) {
        "use strict";
        
        var name = ko.observable("test");

        return {
			name: name  
        };
	});