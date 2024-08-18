$(function () {
    pageEventInit();
    validateInit();
});

pageEventInit = () => {
    $("#btnLogin").off().on("click", (e) => {
        debugger
        e.preventDefault();
        // Thông tin đăng nhập
        let obj = $.fn.serializeObject($("#form-login"));

        // Kiểm tra giá trị nhập vào
        if (!validateForm(obj)) {
            $.fn.showAlert('Vui lòng nhập thông tin hợp lệ', 'warning');  
            return;
        }
        // Đăng nhập
        $.fn.loading();
        $.fn.postData("/Admin/Account/LoginSubMit", obj, res => {
            if (res.result === "success") {
                location.href = "/Admin/Home/Index";
            }
            $.fn.showAlert(res.message, 'success');  
            $.fn.offLoading();
        });
    });

    $("#UserName").focus();
};

validateInit = () => {
    debugger
    let validateRules = {
        rules: {
            UserName: {
                required: !0
            },
            Password: {
                required: !0
            },
        },
        messages: {
            UserName: {
                required: "Vui lòng nhập thông tin"
            },
            Password: {
                required: "Vui lòng nhập thông tin"
            },
        }
    };
};

function validateForm(obj) {
    if (!obj.UserName || !obj.Password) {
        return false;
    }
    return true;
}
