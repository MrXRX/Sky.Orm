var LoginIndex = {
    Init: function () {
        //»Ø³µµÇÂ¼
        document.onkeydown = function (e) {
            var ev = document.all ? window.event : e;
            if (ev.keyCode == 13) {
                LoginIndex.Login();
            }
        }

        $("#VerifyImg").click(function () {
            $(this).attr("src", $(this).data("src") + "?v=" + Math.random());
        })
        $("#login").click(function () {
            LoginIndex.Login();
        })
    },
    Login: function () {
        var data = $("#editForm").serialize();
        $.post("/login/adminlogin", data, function (data) {
            if (data.IsSuccess) {
                window.location.href = "/home/index";
            }
            else {
                alert(data.Message);
            }
        })
    }
}

$(function () {
    LoginIndex.Init();
})