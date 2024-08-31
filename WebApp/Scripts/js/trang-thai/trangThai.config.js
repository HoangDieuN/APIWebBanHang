class TrangThai {
    constructor() {
        this.validateRules = {
            rules: {
                TenTrangThai: {
                    required: !0
                },             
            },
            messages: {
                TenTrangThai: {
                    required: "Vui lòng nhập thông tin"
                },
            },
            ignore: []
        }
        this.endpoints = {
            fetchOptions: "/Admin/TrangThai/SelectTrangThai",
            formTrangThai: "/Admin/TrangThai/_FormTrangThai",
            save: "/Admin/TrangThai/UpdateStatus",

        }
    }

    //#region properties
    setTrangThai(status) {
        this.validateRules = status;
    }
    getTrangThai() {
        return this.validateRules;
    }
    //#endregion properties

    openFormTrangThai(idDonHang, callback) {
        debugger
        $.fn.offLoading();
        $.fn.postData(this.endpoints.formTrangThai, {
            datHangId: idDonHang
        }, (res) => {
            showModal({
                elm: "#modal",
                title: "CẬP NHẬT TRẠNG THÁI",
                content: res,
                size: "lg",
                button: modalButton.save
            })
        })
    }
    updateTrangThai(data, callback) {
        debugger
        let { endpoints } = this;
        $.fn.postFormData(this.endpoints.save, data, callback);
    }
    allOptions(callback) {
        let { endpoints } = this;
        $.fn.postData(endpoints.fetchOptions, {}, (res) => {
            if (callback) callback(res.data);
        });
    }
}