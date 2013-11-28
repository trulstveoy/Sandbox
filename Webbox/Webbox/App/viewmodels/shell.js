define(['plugins/router', 'durandal/app', 'core/logger'], function (router, app, Logger) {
    return  {
        router: router,
        search: function() {
            //It's really easy to show a message box.
            //You can add custom options too. Also, it returns a promise for the user's response.
            app.showMessage('Search not yet implemented...');
        },
        activate: function () {
            var log = new Logger("shell.js");
            
            log.debug("Shell activaiting")

            router.map([
                { route: '', id: "simple", title: 'Simple', moduleId: 'viewmodels/simple', nav: true },
                { route: 'loadData', id: "loadData", title: 'LoadData', moduleId: 'viewmodels/loadData', nav: true },
                { route: 'usingComputed', id: "usingComputed", title: 'UsingComputed', moduleId: 'viewmodels/usingComputed', nav: true },
                { route: 'relayDemo', id: "relayDemo", title: 'RelayDemo', moduleId: 'viewmodels/relayDemo', nav: true },
                { route: 'composition', id: "composition", title: 'Composition', moduleId: 'viewmodels/composition/container', nav: true },
                { route: 'promise', id: "promise", title: 'Promise', moduleId: 'viewmodels/promise', nav: true },
                { route: 'queryDb', id: "queryDb", title: 'Query DB', moduleId: 'viewmodels/queryDb', nav: true },
            ]).buildNavigationModel();
            
            return router.activate();
        }
    };
});