define(['plugins/router', 'core/logger'],
    function (router, logger) {
        var log = logger.get("leftview.js");
        var updateMessage;
        
        var vm = {
            activate: activate,
            deactivate: deactivate,
            goBack: goBack,
            title: 'leftview',
            click: click
       
        };

        return vm;
        
        function activate(value) {
            log.debug('composition/leftview activating');
            updateMessage = value;
        }
        
        function deactivate() {
            log.debug('composition/leftview deactivating');
        }
        
        function click() {
            log.debug('button clicked');
            updateMessage('buttons was clicked in left view');
        }

        function goBack(complete) {
            router.navigateBack();
        }
    });