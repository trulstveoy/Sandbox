define(['plugins/router', 'core/logger'],
    function (router, Logger) {
        var log = new Logger('queryDb.js');

        var items = ko.observableArray();

        function loadData() {
            var url = "/api/movie";
            
            log.debug('sending ajax request');

            $.ajax({
                url: url,
                dataType: "json",
                success: function (result) {
                    ko.utils.arrayPushAll(items, result);
                }
            });
        }


        // Reveal the bindable properties and functions
        var vm = {
            activate: activate,
            goBack: goBack,
            title: 'loadData',

            items: items,

            loadData: loadData            
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