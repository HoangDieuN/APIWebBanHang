var _formModule = {
    elmModal: "#modal",
    elmForm: "#form-dmmodule",
    dmModule: new DMModule(),
    validateRules: {},
    loadListModule: function () {
        if ($loadListModule) $loadListModule();
    },
    init: function () {
        let { dmModule } = this;
        this.validateRules = $.fn.cloneObject(dmModule.validateRules);
        //validate init
        this.validateInit();
        //page event
        this.pageEvents();
    },
    //page Events
    pageEvents: function () {
        let _this = _formModule;
        let { elmForm, elmModal } = _this;

        $(`${elmModal} .btn-save`).off().on("click", function () {
            _this.save();
        })
    },
    //validate init
    validateInit: function () {
        let _this = _formModule;
        let { elmForm, validateRules } = _this;
        $.fn.validateForm(`${elmForm} .form-info`, validateRules);
        //render required
        $.fn.renderRequired(validateRules.rules);
    },
    //validate form
    validateForm: function () {
        let _this = _formModule;
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
        let _this = _formModule;
        let { dmModule, elmForm, elmModal } = _this;
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
            dmModule.save(formData, res => {
                $.fn.offLoading();
                if (res.result == "success") {
                    _this.loadListModule();
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
    _formModule.init();
})
