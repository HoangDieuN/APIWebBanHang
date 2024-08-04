class CommonUploadFile {
    constructor({ listFiles, viewConfig, key, elmForm }) {
        this.listFiles = listFiles ? listFiles : [];
        this.viewConfig = viewConfig ? viewConfig : [];
        this.fileKey = key;
        this.elmForm = elmForm;
        this.acceptDefault = "application/msword,application/vnd.openxmlformats-officedocument.wordprocessingml.document,application/pdf,image/png,image/jpeg";
    }
    //#region properties
    getFileGroup() {
        return this.fileGroup;
    }
    setFileGroup(id) {
        this.fileGroup = id;
    }
    getProductID() {
        return this.productId;
    }
    setProductID(id) {
        this.productId = id;
    }
    getFileKey() {
        return this.fileKey;
    }
    setFileKey(fileKey) {
        this.fileKey = fileKey;
    }
    getListFiles() {
        return this.listFiles;
    }
    setListFiles(list) {
        this.listFiles = [...this.listFiles, ...list];
    }
    getViewConfig() {
        return this.viewConfig;
    }
    setViewConfig(viewConfig) {
        this.viewConfig = viewConfig;
    }
    getIsView() {
        return this.isView;
    }
    setIsView(isView) {
        this.isView = isView;
    }
    getIsPreview() {
        return this.isPreview;
    }
    setIsPreview(isPreview) {
        this.isPreview = isPreview;
    }
    getFileSelected() {
        return this.fileSelected;
    }
    setFileSelected(file) {
        this.fileSelected = file;
    }
    //#endregion properties

    //#region methods
    //get list file by group and product id
    getListByGroupProduct(group, products, callback) {
        $.fn.postData(ACT_FILEMANAGE_LISTBYGROUPPRODUCT, {
            fileGroupCode: group,
            productIds: products
        }, res => {
            if (res.result == "success") {
                this.setListFiles(res.data ? res.data : []);
            }
            if (callback) callback(res);
        })
    }
    //add file upload
    addFile(files) {
        let arr = this.listFiles;
        for (var i = 0; i < files.length; i++) {
            let id = self.crypto.randomUUID();
            // let check = false;
            // while (check == false) {
            //     if (arr.find(x => x.Id == id)) {
            //         id = $.fn.generateID();
            //     } else {
            //         check = true;
            //     }
            // }
            files[i].Id = id;
            files[i].TempCode = this.getProductID();
            files[i].ProductID = this.getProductID();
            files[i].FileKey = this.getFileKey();
            files[i].FileName = files[i].name;
            files[i].FileType = files[i].type;
            files[i].FileSize = files[i].size;
            files[i].IsUploaded = 0;
            arr.push(files[i]);
        }
    }
    //add file upload
    removeFile(id) {
        let arr = this.listFiles.filter(x => x.Id != id);
        this.setListFiles(arr);
    }
    //view list files
    viewListFiles() {
        let _this = this;
        let str = '';
        //list files to view
        let listFiles = this.getListFiles().filter(x => (x.ProductID == this.getProductID()) && x.FileKey == this.getFileKey());
        //list file extensions for view
        let arrViewExt = ['.doc', '.docx', '.pdf', 'png', 'jpg'];
        listFiles.map((item, index) => {
            str += `<tr data-id="${item.Id}">
                <td class="text-center">${index + 1}</td>
                <td>${item.FileName}</td>
                <td class="text-center">
                    <div class="action-button">
                        ${item.FilePath != null && item.FilePath != "" ?
                    `<a href="javascript:void(0);" class="btn btn-sm px-2 light btn-outline-info btn-download">
                                <svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1">
                                    <path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4"></path>
                                    <polyline points="7 10 12 15 17 10"></polyline>
                                    <line x1="12" y1="15" x2="12" y2="3"></line>
                                </svg>
                            </a>`
                    :
                    ""
                }
                        ${item.FilePath != null && item.FilePath != "" && _this.isPreview == 1 && arrViewExt.filter(x => item.FileName.includes(x)).length ?
                    `<a href="javascript:void(0);" class="btn btn-outline-info btn-sm light px-2 btn-preview">
                                <svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1">
                                    <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path>
                                    <circle cx="12" cy="12" r="3"></circle>
                                </svg>
                            </a>`
                    :
                    ""
                }
                        ${_this.isView == 0 ?
                    `<a href="javascript:void(0);" class="btn btn-sm px-2 light btn-outline-danger btn-del-file">
                            <svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><polyline points="3 6 5 6 21 6"></polyline><path d="M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2"></path></svg>
                            </a>`
                    :
                    ""
                }
                    </div>
                </td>
            </tr>`
        })
        if (listFiles && listFiles.length == 0) {
            str += '<tr><td class="text-center" colSpan="4">Không có tệp tin</td></tr>';
        }
        $("#modal-file #tbl-list-files tbody").html(str);
        this.initEvent();
    }
    //init event
    initEvent() {
        let _this = this;
        let { elmForm } = _this;
        $(`#modal-file #tbl-list-files .btn-download`).off().on("click", function () {
            let id = $(this).closest("tr").data("id");
            let listFiles = _this.getListFiles();
            if (listFiles && listFiles.length > 0) {
                let file = listFiles.find(x => x.Id == id);
                if (file) {
                    $.fn.downloadFile({ id, filePath: file.FilePath });
                }
            }
        })

        $(`#modal-file #tbl-list-files .btn-del-file`).off().on("click", function () {
            let listFiles = _this.getListFiles();
            let id = $(this).closest("tr").data("id");
            let file = listFiles.find(x => x.Id == id);
            if (file) {
                if (file.IsUploaded == 1)
                    _this.delete(id);
                else
                    _this.removeFile(id);
            }
            _this.viewListFiles();
        })

        $(".btn-preview").off().on('click', function () {
            let id = $(this).closest("tr").data("id");
            let listFiles = _this.getListFiles();
            if (listFiles && listFiles.length > 0) {
                let file = listFiles.find(x => x.Id == id);
                if (file) {
                    _this.setFileSelected(file);
                    _this.openPreviewFile();
                } else {
                    $.fn.toastrMessage("Không tìm thấy tệp tin", "Thông báo", "error");
                }
            }
        })

        $(`${elmForm ?? ""} .viewFile`).off().on("click", function (e) {
            debugger
            e.preventDefault();
            let arr = $(this).attr("name").split("-");
            let viewConfig = _this.getViewConfig().find(x => x.key == arr[1]);
            _this.setIsView(viewConfig != null && viewConfig.isView != null ? viewConfig.isView : 0);
            _this.setIsPreview(viewConfig != null && viewConfig.isPreview != null ? viewConfig.isPreview : 0);
            _this.setFileKey(arr[1]);
            _this.setProductID(arr[2]);
            _this.openViewListFiles();
        })
    }
    //open view list file
    openViewListFiles(callback) {
        $.fn.loading();
        $.fn.postData(ACT_FILEMANAGE_VIEWLISTFILES, {}, res => {
            showModal({
                elm: "#modal-file",
                title: "DANH SÁCH TỆP TIN",
                content: res,
                size: "lg"
            });
            this.viewListFiles();
            if (callback) callback();
            $.fn.offLoading();
        })
    }
    //preview file
    openPreviewFile(callback) {
        $.fn.loading();
        $.fn.postData(ACT_FILEMANAGE_VIEWPREVIEWFILE, {}, res => {
            $.fn.showPreviewFileModal({
                title: "XEM TỆP TIN",
                bodyContent: res,
                dialogClass: "xl",
                buttonSave: !1
            });
            if (callback) callback();
            $.fn.offLoading();
        })
    }

    render({ name, product, type, isMultiple, isView, accept }) {
        let { acceptDefault } = this;
        let str = "";
        let listFiles = this.getListFiles();
        switch (type) {
            case 'inputGroupAppend':
                str += `<div class="input-group-append">
                            <input type="file" class="form-control d-none uploadFile" id="file-${name}-${product}" name="file-${name}" ${isMultiple == 1 ? "multiple" : ""} accept="${accept ?? acceptDefault}" />
                            <label for="file-${name}-${product}" class="input-group-text form-control btn btn-sm btn-outline-info"><span><i class="ri-upload-2-line align-bottom"></i></span></label>
                        </div>
                        ${listFiles && listFiles.find(x => x.FileKey == name && (x.ProductID == product)) != null ?
                        `<div class="input-group-append">
                                <button class="form-control btn btn-outline-info btn-sm viewFile" name="file-${name}-${product}">
                                    <svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1">
                                        <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path>
                                        <circle cx="12" cy="12" r="3"></circle>
                                    </svg>
                                </button>
                            </div>`
                        :
                        ""
                    }`
                break;
            case 'titleButton':
                str += `${isView != 1 ?
                    `<input type="file" ${isMultiple == 1 ? "multiple" : ""} class="form-control d-none uploadFile" id="file-${name}-${product}" name="file-${name}" accept="${accept ?? acceptDefault}" />
                            <label for="file-${name}-${product}">
                                <span class="btn btn-sm btn-outline-info">
                                    <i class="ri-upload-2-line align-bottom"></i> Chọn tệp
                                </span>
                            </label>`
                    :
                    ""
                    }
                        ${listFiles && listFiles.find(x => x.FileKey == name && (x.ProductID == product)) != null ?
                        ` <a href="javascript:void(0);" class="btn btn-outline-info btn-sm light viewFile" name="file-${name}-${product}">
                                    <svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1">
                                        <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path>
                                        <circle cx="12" cy="12" r="3"></circle>
                                    </svg>
                                </a>`
                        :
                        ""
                    }`
                break;
        }
        return str;
    }

    //delete file
    delete(id, callback) {
        let _this = this;
        $.fn.swalConfirm("Bạn chắc chắn muốn xóa?", "Tệp tin sẽ bị xóa hoàn toàn", res => {
            if (res.value) {
                $.fn.postData(ACT_FILEMANAGE_DELETE, {
                    id
                }, res => {
                    _this.removeFile(id);
                    if (res.result == "success") {
                        if (callback) callback();
                    }
                    _this.viewListFiles();
                    $.fn.toastrMessage(res.message, "Thông báo", res.result);
                })
            }
        })
    }
    //#endregion methods
}