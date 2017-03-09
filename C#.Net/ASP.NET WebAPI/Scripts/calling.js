$(document).ready(function () {

    $('.content__group-submit').click(function () {
        var group = {
            Name : $('.content__group-name')[0],
            Src : $('.content__group-src')[0]
        };
        $.ajax({
            url: '/api/GroupApi/',
            type: 'POST',
            data: JSON.stringify(group),
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                alert('Данные отправлены');
            }
        });
    });

});
