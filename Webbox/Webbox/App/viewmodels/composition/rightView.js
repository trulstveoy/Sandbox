define(['plugins/router', 'core/logger'],
    function (router, logger) {
        var log = logger.get("rightview.js");
        
        var vm = {
            activate: activate,
            goBack: goBack,
            title: 'rightview',
            message: ko.observable(),
            updateMessage : updateMessage
          
        };

        return vm;
        
        function activate() {
            log.debug("composition/rightview activating");
            
        }
        
        function updateMessage(message) {
            vm.message(message);
        }

        function goBack(complete) {
            router.navigateBack();
        }
    });