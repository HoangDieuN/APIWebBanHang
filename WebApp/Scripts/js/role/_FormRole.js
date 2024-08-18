var _formRole = {
    elmModal: "#modal",
    elmForm: "#form-role",
    user: new User(),
    role: new Role(),
    roleSelect: { elm: "#form-role #TenViet" },
    loadLisTaiKhoan: function () {
        if ($loadLisTaiKhoan) $loadLisTaiKhoan();
    },
    init: function () {
        let { user } = this;
        //page events
        this.pageEvents();
    },
    pageEvents: function () {
        let _this = _formRole;
        let { elmForm, elmModal } = _this;
        $(`${elmModal} .btn-save`).off().on("click", function () {
            _this.save();
        })
        //input mask
        $.fn.allInputMask();
        //select init
        _this.selectInit();
    },
    selectInit: function () {
        debugger
        let _this = _formRole;
        let { role, roleSelect } = _this;
        //chọn quyền
        role.allOptions(data => {
            let obj = { data };
            $.fn.initSelect2(roleSelect.elm, obj);
        })
    },
    //validate init
    validateInit: function () {
        let _this = _formRole;
        let { validateRules, elmForm } = _this;
        $.fn.validateForm(`${elmForm} .form-info`, validateRules);
        //render required
        $.fn.renderRequired(validateRules.role);
    },
    //validate form
    validateForm: function () {
        let _this = _formRole;
        let { elmForm, validateRules, canBo } = _this;
        let error = {
            isValid: true,
            message: "Vui lòng kiểm tra lại thông tin nhập"
        }
        let isValidForm = $(`${elmForm} .form-info`).valid();
        //validate upload file
        let fileKeys = [];
        let _rules = user.validateRules.rules;
        for (var prop in _rules) {
            if (_rules[prop].file && _rules[prop].required) {
                fileKeys.push(prop);
            }
        }
        error.isValid = isValidForm
        return error;
    },
    save: function () {
        debugger
        let _this = _formRole;
        let { user, role, elmForm, elmModal } = _this;
        let data = $.fn.serializeObject($(`${elmForm} .form-info`));
        //form data
        let formData = new FormData();
        for (var prop in data) {
            formData.append(prop, data[prop] ?? "");
        }
        //check validate
        let error = _this.validateForm(data);
        if (error.isValid) {
            $.fn.loading();
            role.saveUserRole(formData, res => {
                $.fn.offLoading();
                if (res.result == "success") {
                    _this.loadLisTaiKhoan();
                    closeModal(elmModal);
                }
                $.fn.showAlert(res.message, 'success');
            })
        } else {
            $.fn.showAlert(res.message,'warning');
        }
    }

}

$(function () {
    _formRole.init();
})