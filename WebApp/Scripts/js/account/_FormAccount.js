var _formAccount = {
    elmModal: "#modal",
    elmForm: "#form-taikhoan",
    user: new User(),
    role: new Role(),
    fileUpload: new CommonUploadFile({}),
    validateRules: {},
    viewFileConfig: [
        { key: "FileAnh", isView: 0 }
    ],
    roleSelect: { elm: "#form-taikhoan #RoleId" },
    loadLisTaiKhoan: function () {
        if ($loadLisTaiKhoan) $loadLisTaiKhoan();
    },
    init: function () {
        let { sanPham, viewFileConfig, fileUpload } = this;
        //config view file
        fileUpload.setViewConfig(viewFileConfig);
        //validate init
        this.validateRules = $.fn.cloneObject(sanPham.validateRules);
        this.validateInit();
        //page events
        this.pageEvents();
    },
    //page event
    pageEvents: function () {
        let _this = _formSanPham;
        let { elmForm, elmModal } = _this;

        $(`${elmModal} .btn-save`).off().on("click", function () {
            _this.save();
        })
        //input mask
        $.fn.allInputMask();
        //select year
        $.fn.yearOnly(`${elmForm} .year-inputmask`, {});
        //select init
        _this.selectInit();
        //file upload init
        _this.fileUploadInit();
    },
    //select init
    selectInit: function () {
        let _this = _formSanPham;
        let { danhMucSanPham, danhMucSanPhamSelect } = _this;
        //danh mục sản phẩm
        danhMucSanPham.allOptions((data) => {
            let obj = { data };
            $.fn.initSelect2(danhMucSanPhamSelect.elm, obj);
        })
    },
    fileUploadInit: function () {
        debugger
        let _this = _formSanPham;
        let { fileUpload, elmForm, viewFileConfig } = _this;
        //file upload
        let productId = $(`${elmForm} #Id`).val();
        fileUpload.getListByGroupProduct(moduleConst.sanPham, productId, () => {
            $.map(viewFileConfig, item => {
                let strHtml = fileUpload.render({
                    name: item.key,
                    product: productId,
                    type: "titleButton",
                    isView: item.isView
                });
                $(`#${item.key.toLowerCase()}`).html(strHtml);
            });
            _this.eventUploadFile();
        })
    },
    eventUploadFile: function () {
        let _this = _formSanPham;
        let { fileUpload, viewFileConfig } = _this;
        //init event
        fileUpload.initEvent();
        //upload change
        $(".uploadFile").off('change').on('change', function () {
            debugger
            let files = $(this).get(0).files;
            let arr = $(this).attr("id").split("-");
            fileUpload.setFileKey(arr[1]);
            fileUpload.setProductID(arr[2]);
            fileUpload.addFile(files);
            let _config = viewFileConfig.find(x => x.key == arr[1]);
            let strHtml = fileUpload.render({
                name: arr[1],
                product: arr[2],
                type: "titleButton",
                isView: _config ? _config.isView : 1
            });
            $("#" + arr[1].toLowerCase()).html(strHtml);
            _this.eventUploadFile();
        })
    },
    //validate init
    validateInit: function () {
        let _this = _formSanPham;
        let { validateRules, elmForm } = _this;
        $.fn.validateForm(`${elmForm} .form-info`, validateRules);
        //render required
        $.fn.renderRequired(validateRules.rules);
    },
    //validate form
    validateForm: function () {
        let _this = _formSanPham;
        let { elmForm, fileUpload, validateRules } = _this;
        let error = {
            isValid: true,
            message: "Vui lòng kiểm tra lại thông tin nhập"
        }
        let isValidForm = $(`${elmForm} .form-info`).valid();
        //validate upload file
        let fileKeys = [];
        let _rules = validateRules.rules;
        for (var prop in _rules) {
            if (_rules[prop].file && _rules[prop].required) {
                fileKeys.push(prop);
            }
        }
        let isValidFile = $.fn.requiredUploadFile(fileKeys, fileUpload.getListFiles());

        error.isValid = isValidForm && isValidFile;
        return error;
    },
    //save
    save: function () {
        debugger
        let _this = _formSanPham;
        let { sanPham, fileUpload, elmForm, elmModal } = _this;
        let data = $.fn.serializeObject($(`${elmForm} .form-info`));
        //form data
        let formData = new FormData();
        for (var prop in data) {
            formData.append(prop, data[prop] ?? "");
        }
        let attachedFiles = fileUpload.getListFiles();
        let _attachedFiles = attachedFiles.filter(x => x.IsUploaded != 1);
        if (_attachedFiles != null) {
            $.map(_attachedFiles, file => {
                formData.append(`${file.Id}`, file);
            })
        }
        formData.append("attachedFiles", JSON.stringify(attachedFiles));
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
                $.fn.showAlert(res.message, 'success');
            })
        } else {
            $.fn.showAlert(res.message, 'warning');
        }
    }
}

$(function () {
    _formSanPham.init();
})