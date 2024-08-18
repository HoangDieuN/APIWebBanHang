var viewIndex = {
    elmTable: "#tbl-danhsach",
    elmTableToolbar: "#tbl-danhsach-toolbar",
    baiViet: new BaiViet(),
    keywordsFilter: { elm: "#txt-keywords" },
    init: function () {
        let { elmTable} = this;
        //table init
        this.baiViet.dataTableInit({
            elm: elmTable,
            url: this.baiViet.endpoints.fetchList,
            type: "all",
            callback: this.tableEvents
        })
        //page events
        this.pageEvents();
    },
    pageEvents: function () {
        let _this = viewIndex;
        let { baiViet, elmTableToolbar } = _this;

        $("#form-filter .select2").on("select2:select select2:clear", function () {
            let name = $(this).attr("id");
            let value = $(this).val();
            _this.handleSelectChange(name, value);
        })
        //seach
        $("#btn-search").on("click", function () {
            _this.loadTable();
        })
        //add
        $("#btn-add").off().on("click", function () {
            baiViet.pvForm(0, (res) => {
                showModal({
                    elm: "#modal",
                    title: "THÊM MỚI BÀI VIẾT",
                    content: res,
                    size: "xl",
                    button: modalButton.save
                })
            });
        })
        //hiển thị
        $("#btn-active").off().on("click", function () {
            debugger
            let table = baiViet.getTable();
            let listIds = table.selectedIds();
            if (listIds && listIds.length > 0) {
                let ids = listIds.join(",");
                $.fn.swalTextArea("Xác nhận!", "Lý do hiển thị:", "", cf => {
                    if (cf.value) {
                        $.fn.loading();
                        baiViet.updateActive({
                            ids,
                            isactive: activeConst.isactive,
                            phanHoi: cf.value
                        }, res => {
                            $.fn.offLoading();
                            if (res.result == "success") {
                                table.ajax.reload(null, false);
                            }
                            $.fn.showAlert(res.message, 'success');
                        })
                    }
                })
            }
            else {
                $.fn.showAlert(res.message, 'warning');
            }
        })
        //từ chối
        $(`${elmTableToolbar} #btn-deny`).off().on("click", function () {
            _this.deny();
        })
        //select init
        _this.selectInit();
    },
    tableEvents: function () {
        let _this = viewIndex;
        let { baiViet, elmTable } = _this;

        $(`${elmTable} .select-checkbox`).off().on("change", function () {
            let tr = $(this).closest("tr");
            if ($(this).is(":checked"))
                $(tr).addClass("selected");
            else
                $(tr).removeClass("selected");
        })
        //edit
        $(`${elmTable} .btn-edit`).off().on("click", function () {
            let table = baiViet.getTable();
            let tr = $(this).closest("tr");
            let row = table.row(tr).data();
            if (row.Id) {
                baiViet.pvForm(row.Id, (res) => {
                    showModal({
                        elm: "#modal",
                        title: "CẬP NHẬT BÀI VIẾT",
                        content: res,
                        size: "xl",
                        button: modalButton.save
                    })
                });
            } else {
                $.fn.toastrMessage("Không tìm thấy thông tin đã chọn", "Thông báo", "warning");
            }
        })
        //delete
        $(`${elmTable} .btn-del`).off().on("click", function () {
            let table = baiViet.getTable();
            let tr = $(this).closest("tr");
            let row = table.row(tr).data();
            if (row.Id) {
                baiViet.delete({ ids: row.Id }, () => {
                    table.ajax.reload(null, false);
                });
            } else {
                $.fn.toastrMessage("Không tìm thấy thông tin đã chọn", "Thông báo", "warning");
            }
        })

    },
    selectInit: function () {
        let _this = viewIndex;    
    },
    handleSelectChange: function (name, value) {
        let _this = viewIndex;
    },
    loadTable: function () {
        let _this = viewIndex;
        let { baiViet, keywordsFilter } = _this;
        baiViet.setKeywords($(keywordsFilter.elm).val());
        baiViet.table.ajax.reload();
    },
    deny: function () {
        let _this = viewIndex;
        let { baiViet } = _this;
        let table = baiViet.getTable();
        let selected = table.selectedIds();
        if (selected.length == 0) {
            $.fn.toastrMessage("Vui lòng chọn mục không duyệt", "Thông báo", "warning");
            return;
        }
        let ids = selected.join(",");
        $.fn.swalTextArea("Không hiển thị!", "Lý do:", "", cf => {
            if (cf.value) {
                $.fn.loading();
                baiViet.updateActive({
                    ids,
                    isactive: activeConst.notactive,
                    phanHoi: cf.value }, res => {
                    $.fn.offLoading();
                    if (res.result == "success") {
                        _this.loadTable();
                    }
                    $.fn.toastrMessage(res.message, "Thông báo", res.result);
                });
            }
        })
    }
}

$(function () {
    viewIndex.init();
    window.$loadListBaiViet = viewIndex.loadTable;
})