
$("#btnSearch").click(function () {
    GetMovie();
});

function GetMovie() {


    const item = {
        Title: $("#txtMovieTitle").val(),
    };

    if (item.Title.length <= 0) {
        return false;
    }

    $.ajax({
        type: "POST",
        accepts: "application/json",
        url: "/api/GetMovie?Title=" + item.Title,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (data) {
            if (data.statu == 0) {
                $("#divMovie_Detail").attr("style", "display:none");
                $("#divMovie_Error").removeAttr("style");
                $("#hdMovie_Error").html(data.description);
            }
            else {
                $("#divMovie_Error").attr("style", "display:none");
                $("#divMovie_Detail").removeAttr("style");
                $("#imgMovieDetail_Poster").attr("src", data.movie.poster);
                $("#lblMovieDetail_Title").html(data.movie.title);
                $("#lblMovieDetail_Year").html(data.movie.year);
                $("#lblMovieDetail_Rated").html(data.movie.rated);
                $("#lblMovieDetail_Rating").html(data.movie.rating);
                $("#lblMovieDetail_Votes").html(data.movie.votes);
                $("#lblMovieDetail_Released").html(data.movie.released);
                $("#lblMovieDetail_Runtime").html(data.movie.runtime);
                $("#lblMovieDetail_Director").html(data.movie.director);
                $("#lblMovieDetail_Language").html(data.movie.language);
                $("#lblMovieDetail_Country").html(data.movie.country);
                $("#lblMovieDetail_Awards").html(data.movie.awards);
                $("#lblMovieDetail_Writer").html(data.movie.writer);
                $("#lblMovieDetail_Actors").html(data.movie.actors);
                $("#lblMovieDetail_Plot").html(data.movie.plot);
            }
        }
    });
}

function SignIn() {

    $("#divSigIn_warning").html("");
    const item = {
        UserName: $("#txtLogin_UserName").val(),
        Password: $("#txtLogin_Password").val(),
    };

    $.ajax({
        type: "GET",
        accepts: "application/json",
        url: "/api/Login/Login?UserName=" + item.UserName + "&Password=" + item.Password,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (data) {
            if (data == 1) {
                $("#divRight_MyProfile").removeAttr("style");
                $("#divRight_SignIn").attr("style", "display:none");

                $("#hMyProfile_Name").html(item.UserName);
            }
            else {
                $("#divRight_MyProfile").attr("style", "display:none");
                $("#divRight_SignIn").removeAttr("style");
                $("#divSigIn_warning").html("User Name or Password is wrong!");
            }
        }
    });
}

$(document).ready(function () {
    LoginControl();
});

function LoginControl() {

    $.ajax({
        type: "GET",
        accepts: "application/json",
        url: "/api/Login/LoginControl",
        contentType: "application/json; charset=utf-8",
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (data) {

            if (data == "0") {
                $("#divRight_SignIn").removeAttr("style");
            }
            else {
                $("#divRight_MyProfile").removeAttr("style");
                $("#hMyProfile_Name").html(data);
            }
        }
    });
}

function Logout() {

    $.ajax({
        type: "GET",
        accepts: "application/json",
        url: "/api/Login/Logout",
        contentType: "application/json; charset=utf-8",
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Something went wrong!");
            alert(errorThrown);
        },
        success: function () {

            $("#divRight_MyProfile").attr("style", "display:none");
            $("#divRight_SignIn").removeAttr("style");
        }
    });
}