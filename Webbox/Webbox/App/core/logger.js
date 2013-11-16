define(function () {
    
    var url = "/api/logging";

    return {
        get: function (name) {
            var that = this;
            that.name = name;
            return {
                debug: function (message) {
                    that.message = message;
                    $.ajax({
                        url: url,
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
        }
    };
});