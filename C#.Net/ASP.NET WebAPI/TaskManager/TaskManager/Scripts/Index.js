$(document).ready(function () {
    CheckingForAuth();  
    $("AutorizeForm").submit(function (event) {
        SubmitUser(event, $("#Login").val(), $("#Pas").val());
    });
});
function User(Login, Pas, Name, FName, Gender) {
    this.Login = Login;
    this.Pas = Pas;
    this.Gender = Gender;
    this.Name = Name;
    this.FName = FName;
}
function SubmitUser(event, Login, Pas) {
    //Only English and 0-9 in Login and Pas
    let usernameRegex = /^[a-zA-Z0-9]+$/;
    if (!usernameRegex.test(Login) && !usernameRegex.test(Pas))
        event.preventDefault();
    else {
        $.cookie('Login', Login);
        $.cookie('Pas', Pas);
        $.ajax({
            url: '/api/UsersApi',
            type: 'Get',
            data: JSON.stringify(Login + '.' + Pas),
            contentType: "application/json",
            success: function (user) {
                ReceiveUser(user);
            },
            error: function () {
                alert("Повторите попытку ввода");
            }
        });
    }
}
function ReceiveUser(user) {
    let decodedUser = JSON.parse(user);
    $("#AutorizeForm").css("display", "none");

}
function CheckingForAuth() {
    let Login = $.cookie('Login');
    let Pas = $.cookie('Pas');
    //If there is cookies on Login and Pass then paste them and make it yellow
    if (Login && Pas) {
        $('#Login').html(Login).css("background", "yellow");
        $('#Pas').html(Pas).css("background", "yellow");
    }
 }
