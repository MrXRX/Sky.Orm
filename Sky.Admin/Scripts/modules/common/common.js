var CommonJs = {
    Init: function () {
        $("#VerifyImg").click(function () {
            $(this).attr("src", $(this).data("src") + "?v=" + Math.random());
        });
    },
    VerifyImgCode: function (value) {
        //��֤ͼ����֤��
        $.get("/Login/GetVerifyCode", { code: value }, function (data) {
            if (data != null && data.IsSuccess) {

            }
            else {

            }
        })
    }
}



$(function () {
    CommonJs.Init();
})