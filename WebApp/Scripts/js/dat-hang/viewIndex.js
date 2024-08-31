var viewIndex = {
    elmTable: "#tbl-danhsach",
    elmTableToolbar: "#tbl-danhsach-toolbar",
    trangThai:new TrangThai(),
    datHang: new DatHang(),
    keywordsFilter: { elm: "#txt-keywords" },

    init: function () {
        debugger
        let { elmTable } = this;
        //table init

        this.datHang.dataTableInit({
            elm: elmTable,
            url: this.datHang.endpoints.fetchList,
            type: "index",
            callback: this.tableEvents
        })
        //page events
        this.pageEvents();
    },
    pageEvents: function () {
        debugger
        let _this = viewIndex;
        let { datHang} = _this;

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
       
        _this.selectInit();

    },
    tableEvents: function () {
        let _this = viewIndex;
        let { trangThai,datHang, elmTable } = _this;
        //cập nhật trạng thái
        $(`${elmTable} .btn-edit`).off().on("click", function () {
            debugger
            let table = datHang.getTable();
            let tr = $(this).closest("tr");
            let row = table.row(tr).data();
            if (row.Id) {
                trangThai.openFormTrangThai(row.Id, (res) => {
                    showModal({
                        elm: "#modal",
                        title: "CẬP NHẬT TRANG THÁI ĐƠN HÀNG",
                        content: res,
                        size: "lg",
                        button: modalButton.save
                    })
                });
            }
            else {
                $.fn.showAlert('Không tìm thấy thông tin đã chọn', 'warning');
            }
        })
        //delete
        $(`${elmTable} .btn-del`).off().on("click", function () {
            debugger
            let table = datHang.getTable();
            let tr = $(this).closest("tr");
            let row = table.row(tr).data();
            if (row.Id) {
                datHang.delete({ ids: row.Id }, () => {
                    table.ajax.reload(null, false);
                });
            } else {
                $.fn.showAlert('Không tìm thấy thông tin đã chọn', 'warning');
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
        debugger
        let _this = viewIndex;
        let { datHang, keywordsFilter } = _this;
        datHang.setKeywords($(keywordsFilter.elm).val());
        datHang.table.ajax.reload();
    },

}

$(function () {
    viewIndex.init();
    window.$loadListDatHang = viewIndex.loadTable;
})
