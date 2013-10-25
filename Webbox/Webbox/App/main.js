requirejs.config({
    paths: {
        "text": "../Scripts/text",
        "durandal": "../Scripts/durandal",
        "plugins": "../Scripts/durandal/plugins",
        "transitions": "../Scripts/durandal/transitions",
        "knockout": "../Scripts/knockout",
        "komapping": "../Scripts/knockout.mapping-latest"
    }
});

define('jquery', function() { return jQuery; });
define('knockout', ko);

define(["durandal/system", "durandal/app", "durandal/viewLocator", "komapping"],  function (system, app, viewLocator, komapping) {
    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    ko.mapping = komapping;

    app.title = "Webbox";

    app.configurePlugins({
        router: true,
        dialog: true,
        widget: true
    });

    app.start().then(function() {
        //Replace 'viewmodels' in the moduleId with 'views' to locate the view.
        //Look for partial views in a 'views' folder in the root.
        viewLocator.useConvention();

        //Show the app by setting the root view model for our application with a transition.
        app.setRoot("viewmodels/shell", "entrance");
    });
});