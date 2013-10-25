define(['plugins/router'],
    function (router) {
        var that = this;

        var items = ko.observableArray();
        

        function loadData() {
            
        }
       
        // Reveal the bindable properties and functions
        var vm = {
            activate: activate,
            goBack: goBack,
            title: 'usingComputed',
            items: ko.observableArray([1,2,3,4,5,6]),
            loadData: function() {
                var url = "/api/data";

                $.ajax({
                    url: url,
                    dataType: "json",
                    success: function (result) {
                        for (var i = 0; i < result.length; i++) {
                            vm.items.push(ko.observable(result[i]));
                        }

                        //ko.utils.arrayPushAll(items, result);
                    }
                });
            },
        };
        
        vm.chunks = ko.computed(function () {
            return ko.observableArray(vm.items());
        });

        return vm;
        
        function activate (id, querystring) {
            //TODO: Initialize lookup data here.

            //TODO: Get the data for this viewmodel, return a promise.
        }

        function goBack(complete) {
            router.navigateBack();
        }
    });