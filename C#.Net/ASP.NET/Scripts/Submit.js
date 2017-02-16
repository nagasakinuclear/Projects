$(function Submit(event) {
    var Name = $(".form_input_name").val();
    var Phone = $(".form_input_phone").val();
    var Desc = $(".form_input_description").val();
    var Error = $(".form_input_error");
    if(Name.length > 60 || Phone.length > 18 || Desc.length > 100)
    {
        event.preventDefault();
        Error.html("Вы допустили ошибки при вводе. Повторите еще раз")
        setTimeout(function () {
            Error.html("");
        }, 3000);
        return false;
    }
    return true;
});