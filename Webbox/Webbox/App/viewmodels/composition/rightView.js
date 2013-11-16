define(['plugins/router', 'core/logger'],
    function (router, logger) {
        var log = logger.get("rightview.js");
        
        var vm = {
            activate: activate,
            goBack: goBack,
            title: 'rightview',
            name: ko.observable(),
            update : update
          
        };

        return vm;
        
        function activate() {
            log.debug("composition/rightview activating");
            
        }
        
        function update(str) {
            vm.name(str);
        }

        function goBack(complete) {
            router.navigateBack();
        }
    });