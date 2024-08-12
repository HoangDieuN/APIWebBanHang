var _formSanPham = {
    elmModal: "#modal",
    elmForm: "#form-sanpham",
    sanPham: new SanPham(),
    danhMucSanPham: new DanhMucSanPham(),
    validateRules: {},
    loadListSanPham: function () {
        if ($loadListSanPham) $loadListSanPham();
    },
    init: function () {
        let { sanPham } = this;
        this.validateRules = $.fn.cloneObject(sanPham.validateRules);
        //validate init
        this.validateInit();
        //page event
        this.pageEvents();
    },
    //page Events
    pageEvents: function () {
        let _this = _formSanPham;
        let { elmForm, elmModal } = _this;

        $(`${elmModal} .btn-save`).off().on("click", function () {
            _this.save();
        })
    },
    //validate init
    validateInit: function () {
        let _this = _formSanPham;
        let { elmForm, validateRules } = _this;
        $.fn.validateForm(`${elmForm} .form-info`, validateRules);
        //render required
        $.fn.renderRequired(validateRules.rules);
    },
    //validate form
    validateForm: function () {
        let _this = _formSanPham;
        let { elmForm, validateRules } = _this;
        let error = {
            isValid: true,
            message: "Vui lòng kiểm tra lại thông tin nhập"
        }
        let isValidForm = $(`${elmForm} .form-info`).valid();
        //validate upload file

        error.isValid = isValidForm;
        return error;
    },
    //save
    save: function () {
        debugger
        let _this = _formSanPham;
        let { sanPham, elmForm, elmModal } = _this;
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
            sanPham.save(formData, res => {
                $.fn.offLoading();
                if (res.result == "success") {
                    _this.loadListSanPham();
                    closeModal(elmModal);
                }
                $.fn.toastrMessage(res.message, "Thông báo", res.result);
            })
        } else {
            $.fn.toastrMessage(res.message, "Thông báo", "warning");
        }
    }
}
$(function () {
    _formSanPham.init();
})
