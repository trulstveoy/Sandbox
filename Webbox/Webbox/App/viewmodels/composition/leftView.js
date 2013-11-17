define(['plugins/router', 'core/logger'],
    function (router, Logger) {
        var log = new Logger("leftview.js");

        var updateMessage;
        var isVisible = ko.observable(true);

        var vm = {
            activate: activate,
            deactivate: deactivate,
            goBack: goBack,
            title: 'leftview',
            click: click,
            showHide: showHide,
            isVisible: isVisible
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
        
        function showHide() {
            isVisible(!isVisible());
        }

        function goBack(complete) {
            router.navigateBack();
        }
    });