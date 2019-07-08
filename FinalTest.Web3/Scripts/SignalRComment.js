(function () {

    var commentHub = $.connection.commentHub;
    $.connection.hub.start()
        .done(function () {
            $.connection.hub.logging = true;
            
            $("#click-me").on("click", function () { commentHub.server.announce("Connected!"); });

        })
        .fail(function () { alert("ERROR!"); });

    commentHub.client.announce = function (message) {
        writeToPage(message);


    }
    var writeToPage = function (message) {
        $("#welcome-message").append(message + "<br /");
    }
    $("#click-me").on("click", function () {
        commentHub.server.getServerDateTime()
            .done(function (data) {
                writeToPage(data);
            })
            .fail(function (e) {
                writeToPage(e);
            });
    })
})()