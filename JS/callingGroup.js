$(document).ready(function () {
    $(".content__sender")[0].click(function (e) {
        var action = $(e.target).attr("data-action");
        $.ajax({
            url: action == "all" ? "/api/GroupApiController" : "/api/GroupApiController/1",
            type: "GET",
            dataType: "json",
            success: function (data) {
                if (Array.isArray(data)) {
                    var message = "";
                    for (var i = 0; i < data.length; i++) {
                        message += "Item " + [i] + "\n"
                            + GetObjectString(data[i]) + "\n\n";
                    }
                    $("#results").text(message);
                } else {
                    $("#results").text(GetObjectString(data));
                }
            }
        });
        e.preventDefault();
    });
});