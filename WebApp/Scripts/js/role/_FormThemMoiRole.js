var _formRole = {
    elmModal: "#modal",
    elmForm: "#form-themmoirole",
    role: new Role(),
    validateRules: {},
    loadListQuyen: function () {
        if ($loadListQuyen) $loadListQuyen();
    },
    init: function () {
        let { role } = this;
        this.validateRules = $.fn.cloneObject(role.validateRules);
        //validate init
        this.validateInit();
        //page event
        this.pageEvents();
    },
    //page Events
    pageEvents: function () {
        let _this = _formRole;
        let { elmForm, elmModal } = _this;

        $(`${elmModal} .btn-save`).off().on("click", function () {
            _this.save();
        })
    },
    //validate init
    validateInit: function () {
        let _this = _formRole;
        let { elmForm, validateRules } = _this;
        $.fn.validateForm(`${elmForm} .form-info`, validateRules);
        //render required
        $.fn.renderRequired(validateRules.rules);
    },
    //validate form
    validateForm: function () {
        let _this = _formRole;
        let { elmForm, validateRules } = _this;
        let error = {
            isValid: true,
            message: "Vui lòng kiểm tra lại thông tin nhập"
        }
        let isValidForm = $(`${elmForm} .form-info`).valid();
        error.isValid = isValidForm;
        return error;
    },
    //save
    save: function () {
        debugger
        let _this = _formRole;
        let { role, elmForm, elmModal } = _this;
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
            role.creatRole(formData, res => {
                $.fn.offLoading();
                if (res.result == "success") {
                    _this.loadListQuyen();
                    closeModal(elmModal);
                }
                $.fn.showAlert(res.message, 'success');
            })
        } else {
            $.fn.showAlert(res.message, 'warning');
        }
    }
}
$(function () {
    _formRole.init();
})
