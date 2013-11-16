define(['plugins/router', 'core/logger', 'viewmodels/composition/leftview', 'viewmodels/composition/rightview'],
    function (router, logger, leftview, rightview) {
        var log = logger.get('container.js');
       
        var vm = {
            activate: activate,
            deactivate: deactivate,
            goBack: goBack,
            title: 'composition',
            leftview: leftview,
            rightview: rightview
       
        };
        
        return vm;
        
        function activate() {
            log.debug('composition/container activating');

            var communicator = function() {
                rightview.update("foobar");
            };
            
            return $.when(
               leftview.activate(communicator),
               rightview.activate()
           ).then(function () {
               log.debug('the do shit');
           });
            
        }
        
        function deactivate() {
            log.debug('composition/container deactivating');
        }

        function goBack(complete) {
            router.navigateBack();
        }
    });