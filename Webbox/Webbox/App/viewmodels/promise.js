define(['plugins/router', 'core/logger'],
    function (router, Logger) {
        var log = new Logger("promise.js");
        
        var items = ko.observableArray();

        var vm = {
            activate: activate,
            goBack: goBack,
            title: 'promise',
            waitSingle: waitSingle,
            waitMultiple: waitMultiple,
            waitValue: waitValue,
            waitMultiValue: waitMultiValue,
            items: items
        };

        return vm;
        
        function waitSingle() {
            wait(1000).then(function () {
                log.debug('wait single...');
                items.push('Waited 1000 ms');
            });
        }
        
        function waitMultiple() {
            $.when(wait(750), wait(750)).done(function () {
                log.debug('wait multiple...');
                items.push('Waited 750 ms for two');
            });
        }
        
        function waitValue() {
            load(1000, 'some value').then(function(val) {
                log.debug('wait value...');
                items.push(val);
            });
        }
        
        function waitMultiValue() {
            $.when(load(750, 'abc'), load(500, 'def')).done(function (val1, val2) {
                log.debug('wait multi value....');
                items.push(val1);
                items.push(val2);
            });
        }
        
        function wait(ms) {
            var deferred = $.Deferred();
            setTimeout(deferred.resolve, ms);
            return deferred.promise();
        }
        
        function load(ms, text) {
            var deferred = $.Deferred();

            setTimeout(function() {
                deferred.resolve(text);
            }, ms);

            return deferred.promise();
        }
        
        
        
        function activate (id, querystring) {
        }

        function goBack(complete) {
            router.navigateBack();
        }
    });