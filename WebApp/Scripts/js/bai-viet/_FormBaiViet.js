var _formBaiViet = {
    elmModal: "#modal",
    elmForm: "#form-baiviet",
    baiViet: new BaiViet(),
    fileUpload: new CommonUploadFile({}),
    validateRules: {},
    viewFileConfig: [
        { key: "FileAnh", isView: 0 }
    ],
    loadListBaiViet: function () {
        if ($loadListBaiViet) $loadListBaiViet();
    },
    init: function () {
        let { baiViet, viewFileConfig, fileUpload } = this;
        //config view file
        fileUpload.setViewConfig(viewFileConfig);
        //validate init
        this.validateRules = $.fn.cloneObject(baiViet.validateRules);
        this.validateInit();
        //page events
        this.pageEvents();
    },
    //page event
    pageEvents: function () {
        let _this = _formBaiViet;
        let { elmForm, elmModal } = _this;

        $(`${elmModal} .btn-save`).off().on("click", function () {
            _this.save();
        })
        //file upload init
        _this.fileUploadInit();
    },
    //select init
    selectInit: function () {
        let _this = _formBaiViet;
    },
    fileUploadInit: function () {
        debugger
        let _this = _formBaiViet;
        let { fileUpload, elmForm, viewFileConfig } = _this;
        //file upload
        let productId = $(`${elmForm} #Id`).val();
        fileUpload.getListByGroupProduct(moduleConst.baiViet, productId, () => {
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
        let _this = _formBaiViet;
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
        let _this = _formBaiViet;
        let { validateRules, elmForm } = _this;
        $.fn.validateForm(`${elmForm} .form-info`, validateRules);
        //render required
        $.fn.renderRequired(validateRules.rules);
    },
    //validate form
    validateForm: function () {
        let _this = _formBaiViet;
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
        let _this = _formBaiViet;
        let { baiViet, fileUpload, elmForm, elmModal } = _this;
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
            baiViet.save(formData, res => {
                $.fn.offLoading();
                if (res.result == "success") {
                    _this.loadListBaiViet();
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
    _formBaiViet.init();
})