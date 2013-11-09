define(function () {
    var that = this;
    that.url = "/api/logging";

    return {
        get: function (name) {
            that.name = name;
            return {
                debug: function (message) {
                    that.message = message;
                    $.ajax({
                        url: url,
                        type: "POST",
                        dataType: "json",
                        data: {
                            name: that.name,
                            severity: "Debug",
                            message: that.message
                        }
                    });
                }
            };
        }
    };
});