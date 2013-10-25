//TODO: Inject dependencies
define(['plugins/router'],
    function (router) {


        // Internal properties and functions
        var number = ko.observable(0);
        var items = ko.observableArray();
       
        // Reveal the bindable properties and functions
        var vm = {
            activate: activate,
            goBack: goBack,
            title: 'simple',
            
            number: number,
            items: items,

            clickMe: function() {
                number(number() + 1);
                items.push(number());
            }
        };

        return vm;
        
        function activate (id, querystring) {
            //TODO: Initialize lookup data here.

            //TODO: Get the data for this viewmodel, return a promise.
        }

        function goBack(complete) {
            router.navigateBack();
        }
    });