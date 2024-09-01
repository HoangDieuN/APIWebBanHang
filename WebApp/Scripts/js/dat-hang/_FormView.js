var _formView = {
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
        let _this = _formView;
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
        let _this = _formView;
        let { trangThai, trangThaiSelect } = _this;
        //chọn trạng thái
        trangThai.allOptions(data => {
            let obj = { data };
            $.fn.initSelect2(trangThaiSelect.elm, obj);
        })
    },
    //save: function () {
    //    debugger
    //    let _this = _formView;
    //    let { datHang, trangThai, elmForm, elmModal } = _this;
    //    let data = $.fn.serializeObject($(`${elmForm} .form-info`));
    //    //form data
    //    let formData = new FormData();
    //    for (var prop in data) {
    //        formData.append(prop, data[prop] ?? "");
    //    }
    //    //check validate
    //    //let error = _this.validateForm(data);
    //    //if (error.isValid) {
    //    $.fn.loading();
    //    trangThai.updateTrangThai(formData, res => {
    //        $.fn.offLoading();
    //        if (res.result == "success") {
    //            _this.loadListDatHang();
    //            closeModal(elmModal);
    //        }
    //        $.fn.showAlert(res.message, 'success');
    //    })
    //    //} else {
    //    //    $.fn.showAlert(res.message, 'warning');
    //    //}
    //}

}

$(function () {
    _formView.init();
})