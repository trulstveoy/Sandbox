﻿define(['plugins/router', 'durandal/app'], function (router, app) {
    return {
        router: router,
        search: function() {
            //It's really easy to show a message box.
            //You can add custom options too. Also, it returns a promise for the user's response.
            app.showMessage('Search not yet implemented...');
        },
        activate: function () {
            router.map([
                { route: '', id: "simple", title: 'Simple', moduleId: 'viewmodels/simple', nav: true },
                { route: 'loadData', id: "loadData", title: 'LoadData', moduleId: 'viewmodels/loadData', nav: true },
                { route: 'usingComputed', id: "usingComputed", title: 'UsingComputed', moduleId: 'viewmodels/usingComputed', nav: true },
            ]).buildNavigationModel();
            
            return router.activate();
        }
    };
});