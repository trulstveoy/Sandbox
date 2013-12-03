define(['plugins/router', 'core/logger'],
    function (router, Logger) {
        var log = new Logger('useMongo.js');

        var customerNames = ko.observableArray();

        function populate() {
            var url = "https://localhost:5002/api/mongo/populate";
            
            log.debug('sending populate ajax request');

            $.ajax({
                url: url,
                type: 'POST',
                dataType: "json"
            });
        }

        function getCustomerNames() {

            customerNames.removeAll();

            var url = "https://localhost:5002/api/mongo/getCustomerNames";
            
            log.debug('sending getCustomerNames ajax request');

            $.ajax({
                url: url,
                dataType: "json",
                success: function (result) {
                    ko.utils.arrayPushAll(customerNames, result);
                }
            });
        }
        
        var vm = {
            activate: activate,
            goBack: goBack,
            title: 'useMongo',
            customerNames: customerNames,
            populate: populate,
            getCustomerNames: getCustomerNames
        };

        return vm;
        
        function activate (id, querystring) {
            
        }

        function goBack(complete) {
            router.navigateBack();
        }
    });