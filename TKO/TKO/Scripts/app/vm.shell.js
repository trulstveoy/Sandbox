﻿/*global define */
/*jslint white: true */
define('vm.shell',
    ['ko', 'sammy'],
    function(ko) {
        "use strict";
    
        var title = ko.observable("Shell view");

        return {
            title: title
        };
	});