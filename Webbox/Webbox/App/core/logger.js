define(function () {
    
    return function Logger(name) {
        
        var that = this;
        that.url = "/api/logging";
        that.name = name;
        
        return {
            debug: function (message) {
                that.message = message;
                $.ajax({
                    url: that.url,
                    type: "POST",
                    dataType: "json",
                    data: { 
                        name: 'app:' + that.name,
                        severity: "Debug",
                        message: that.message
                    }
                });
            }
        };
        
    };
});