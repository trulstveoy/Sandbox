define(['plugins/router', 'core/logger', 'viewmodels/composition/leftview', 'viewmodels/composition/rightview'],
    function (router, Logger, leftview, rightview) {
        var log = new Logger('container.js');
       
        var vm = {
            activate: activate,
            deactivate: deactivate,
            goBack: goBack,
            title: 'composition',
            leftview: leftview,
            rightview: rightview,
            updateMessage: function(message) {
                rightview.updateMessage(message);
            },
            showHideLeft: function() {
                leftview.showHide();
            }
       
        };
        
        return vm;
        
        function activate() {
            log.debug('composition/container activating');
        }
        
        function deactivate() {
            log.debug('composition/container deactivating');
        }

        function goBack(complete) {
            router.navigateBack();
        }
    });