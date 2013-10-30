define(['plugins/router'],
    function (router) {
        // Internal properties and functions

        var items = ko.observableArray();
        var error = ko.observable();

        function loadData() {
            var url = "/api/relay";

            $.ajax({
                url: url,
                dataType: "json",
                success: function (result) {
                    ko.utils.arrayPushAll(items, result);
                },
                error: function (xhr, textStatus, errorThrown) {
                    console.error("failed");
                    error('errorThrown ' + errorThrown.toString());
                }
            });
        }


        // Reveal the bindable properties and functions
        var vm = {
            activate: activate,
            goBack: goBack,
            title: 'loadData',

            items: items,
            error: error,

            loadData: loadData
        };

        return vm;

        function activate(id, querystring) {
            //TODO: Initialize lookup data here.

            //TODO: Get the data for this viewmodel, return a promise.
        }

        function goBack(complete) {
            router.navigateBack();
        }
    });