$(document).ready(function () {
    $("#RegisterForm").submit(function (event) { getRegisterData(event) });
})

function getRegisterData(event) {
    alert("hi");
    let Login = $("#Login").val();
    let Pass = $("#Pas").val();
    let Name = $("#Name").val();
    let FName = $("#FName").val();
    let Gender = $("#Male:checked").val() ? true : false;
    let user = new User(Login, Pass, Name, FName, Gender);
    if (Login && Pass && Name && FName) {
        SubmitUser(event, user);
    }
    else {
        event.preventDefault();
        alert("Есть незаполненные поля");
    }
}

function User(Login, Pass, Name, FName, Gender)
{
    this.Login = Login;
    this.Pass = Pass;
    this.Name = Name;
    this.FName = FName;
    this.Gender = Gender;
}
function SubmitUser(event, user) {
    let usernameRegex = /^[a-zA-Z0-9]+$/;
    if (!usernameRegex.test(Login) && !usernameRegex.test(Pas))
        event.preventDefault();
    else {
        $.ajax({
            url: '/api/UsersApi',
            type: 'POST',
            data: JSON.stringify(user),
            contentType: "application/json",            
            success: function (data) {
                alert("Регистрация успешна!");
            },
            error: function () {
                alert("Повторите попытку ввода");
            }
        });
    //}
}