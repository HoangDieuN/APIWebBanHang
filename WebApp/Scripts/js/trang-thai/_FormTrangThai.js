﻿var _formTrangThai = {
    elmModal: "#modal",
    elmForm: "#form-trangthai",
    trangThai: new TrangThai(),
    datHang: new DatHang(),
    trangThaiSelect: { elm: "#form-trangthai #StatusId" },
    loadListDatHang: function () {
        if ($loadListDatHang) $loadListDatHang();
    },
    init: function () {
        let { datHang } = this;
        //page events
        this.pageEvents();
    },
    pageEvents: function () {
        let _this = _formTrangThai;
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
        let _this = _formTrangThai;
        let { trangThai, trangThaiSelect } = _this;
        //chọn trạng thái
        trangThai.allOptions(data => {
            let obj = { data };
            $.fn.initSelect2(trangThaiSelect.elm, obj);
        })
    },
    ////validate init
    //validateInit: function () {
    //    let _this = _formTrangThai;
    //    let { validateRules, elmForm } = _this;
    //    $.fn.validateForm(`${elmForm} .form-info`, validateRules);
    //    //render required
    //    $.fn.renderRequired(validateRules.trangThai);
    //},
    ////validate form
    //validateForm: function () {
    //    let _this = _formTrangThai;
    //    let { elmForm, validateRules, datHang } = _this;
    //    let error = {
    //        isValid: true,
    //        message: "Vui lòng kiểm tra lại thông tin nhập"
    //    }
    //    let isValidForm = $(`${elmForm} .form-info`).valid();
    //    //validate upload file
    //    let fileKeys = [];
    //    let _rules = datHang.validateRules.rules;
    //    for (var prop in _rules) {
    //        if (_rules[prop].file && _rules[prop].required) {
    //            fileKeys.push(prop);
    //        }
    //    }
    //    error.isValid = isValidForm
    //    return error;
    //},
    save: function () {
        debugger
        let _this = _formTrangThai;
        let { datHang, trangThai, elmForm, elmModal } = _this;
        let data = $.fn.serializeObject($(`${elmForm} .form-info`));
        //form data
        let formData = new FormData();
        for (var prop in data) {
            formData.append(prop, data[prop] ?? "");
        }
        //check validate
        //let error = _this.validateForm(data);
        //if (error.isValid) {
            $.fn.loading();
            trangThai.updateTrangThai(formData, res => {
                $.fn.offLoading();
                if (res.result == "success") {
                    _this.loadListDatHang();
                    closeModal(elmModal);
                }
                $.fn.showAlert(res.message, 'success');
            })
        //} else {
        //    $.fn.showAlert(res.message, 'warning');
        //}
    }

}

$(function () {
    _formTrangThai.init();
})