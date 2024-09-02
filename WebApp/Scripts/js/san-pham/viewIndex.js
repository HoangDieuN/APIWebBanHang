var viewIndex = {
    elmTable: "#tbl-danhsach",
    elmTableToolbar: "#tbl-danhsach-toolbar",
    sanPham: new SanPham(),
    danhMucSanPham: new DanhMucSanPham(),
    namFilter: { elm: "#sl-nam" },
    danhMucSanPhamFilter: { elm: "#sl-danhmucsanpham" },
    keywordsFilter: { elm: "#txt-keywords" },
   
    init: function () {
        debugger
        let { elmTable, danhMucSanPhamFilter } = this;
        this.sanPham.setDanhMucSanPham($(danhMucSanPhamFilter.elm).val());

        //table init
        this.sanPham.dataTableInit({
            elm: elmTable,
            url: this.sanPham.endpoints.fetchList,
            type: "index",
            callback: this.tableEvents
        })
        //page events
        this.pageEvents();
    },
    pageEvents: function () {
        debugger
        let _this = viewIndex;
        let { sanPham } = _this;

        $("#form-filter .select2").on("select2:select select2:clear", function () {
            let name = $(this).attr("id");
            let value = $(this).val();
            _this.handleSelectChange(name, value);
        })
        //seach
        $("#btn-search").on("click", function () {
            _this.loadTable();
        })
        $("#form-filter").on("submit", function (e) {
            e.preventDefault();
            _this.loadTable();
        })
        //add
        $("#btn-add").on("click", function () {
            sanPham.pvForm(0, (res) => {
                showModal({
                    elm: "#modal",
                    title: "Thêm mới sản phẩm",
                    content: res,
                    size: "xl",
                    button: modalButton.save
                })
            });
        })
        _this.selectInit();
    },
    tableEvents: function () {
        let _this = viewIndex;
        let { sanPham, elmTable } = _this;
        //edit
        $(`${elmTable} .btn-edit`).off().on("click", function () {
            debugger
            let table = sanPham.getTable();
            let tr = $(this).closest("tr");
            let row = table.row(tr).data();
            if (row.Id) {
                sanPham.pvForm(row.Id, (res) => {
                    showModal({
                        elm: "#modal",
                        title: "CẬP NHẬT SẢN PHẨM",
                        content: res,
                        size: "xl",
                        button: modalButton.save
                    })
                });
            } else {
                $.fn.toastrMessage("Không tìm thấy thông tin đã chọn", "Thông báo", "warning");
            }
        })
        //hiển thị sản phẩm
        $(`${elmTable} .btn-active`).off().on("click", function () {
            debugger
            let table = sanPham.getTable();
            let tr = $(this).closest("tr");
            let row = table.row(tr).data();
            if (row.Id) {
                $.fn.swalTextArea("Xác nhận!", "Lý do hiển thị:", "", cf => {
                    if (cf.value) {
                        $.fn.loading();
                        sanPham.updateActive({
                            ids:row.Id,
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
            } else {
                $.fn.toastrMessage("Không tìm thấy thông tin đã chọn", "Thông báo", "warning");
            }
        })
        // tắt hiển thị sản phẩm
        $(`${elmTable} .btn-unactive`).off().on("click", function () {
            debugger
            let table = sanPham.getTable();
            let tr = $(this).closest("tr");
            let row = table.row(tr).data();
            if (row.Id) {
                $.fn.swalTextArea("Xác nhận!", "Lý do không hiển thị:", "", cf => {
                    if (cf.value) {
                        $.fn.loading();
                        sanPham.updateActive({
                            ids: row.Id,
                            isactive: activeConst.notactive,
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
            } else {
                $.fn.toastrMessage("Không tìm thấy thông tin đã chọn", "Thông báo", "warning");
            }
        })
        //delete
        $(`${elmTable} .btn-del`).off().on("click", function () {
            let table = sanPham.getTable();
            let tr = $(this).closest("tr");
            let row = table.row(tr).data();
            if (row.Id) {
                sanPham.delete({ ids: row.Id }, () => {
                    table.ajax.reload(null, false);
                });
            } else {
                $.fn.toastrMessage("Không tìm thấy thông tin đã chọn", "Thông báo", "warning");
            }
        })
    },
    selectInit: function () {
        let _this = viewIndex;
        let { danhMucSanPham, danhMucSanPhamFilter, namFilter } = _this;
        //select nam
        $.fn.slNamHanhChinh(namFilter.elm);
        //select danh mục sản phẩm
        danhMucSanPham.allOptions((data) => {
            let obj = { data };
            $.fn.initSelect2(danhMucSanPhamFilter.elm, obj);
        })
    },
    handleSelectChange: function (name, value) {
        let _this = viewIndex;
        switch (name) {
            case "sl-nam":
                _this.loadTable();
            case "sl-danhmucsanpham":      
                _this.loadTable();          
            default:
                break;
        }
    },
    loadTable: function () {
        debugger
        let _this = viewIndex;
        let { sanPham, keywordsFilter, danhMucSanPhamFilter,namFilter} = _this;
        sanPham.setKeywords($(keywordsFilter.elm).val());
        sanPham.setDanhMucSanPham($(danhMucSanPhamFilter.elm).val());
        sanPham.setNam($(namFilter.elm).val());
        sanPham.table.ajax.reload();
    },

}

$(function () {
    viewIndex.init();
    window.$loadListSanPham = viewIndex.loadTable;
})
