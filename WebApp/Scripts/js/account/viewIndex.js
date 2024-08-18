var viewIndex = {
    elmTable: "#tbl-danhsach",
    elmTableToolbar: "#tbl-danhsach-toolbar",
    user: new User(),
    keywordsFilter: { elm: "#txt-keywords" },

    init: function () {
        debugger
        let { elmTable } = this;
        //table init

        this.user.dataTableInit({
            elm: elmTable,
            url: this.user.endpoints.fetchList,
            type: "index",
            callback: this.tableEvents
        })
        //page events
        this.pageEvents();
    },
    pageEvents: function () {
        debugger
        let _this = viewIndex;
        let { user } = _this;

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
            user.pvForm(0, (res) => {
                showModal({
                    elm: "#modal",
                    title: "Thêm mới tài khoản",
                    content: res,
                    size: "lg",
                    button: modalButton.save
                })
            });
        })
        _this.selectInit();

    },
    tableEvents: function () {
        let _this = viewIndex;
        let { user, elmTable } = _this;
        //edit
        $(`${elmTable} .btn-edit`).off().on("click", function () {
            debugger
            let table = user.getTable();
            let tr = $(this).closest("tr");
            let row = table.row(tr).data();
            if (row.Id) {
                user.pvForm(row.Id, (res) => {
                    showModal({
                        elm: "#modal",
                        title: "CẬP NHẬT TÀI KHOẢN NGƯỜI DÙNG",
                        content: res,
                        size: "lg",
                        button: modalButton.save
                    })
                });
            } else {
                $.fn.showAlert('Không tìm thấy thông tin đã chọn', 'warning');
            }
        })
        //delete
        $(`${elmTable} .btn-del`).off().on("click", function () {
            debugger
            let table = user.getTable();
            let tr = $(this).closest("tr");
            let row = table.row(tr).data();
            if (row.Id) {
                user.delete({ ids: row.Id }, () => {
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
        let { user, keywordsFilter } = _this;
        user.setKeywords($(keywordsFilter.elm).val());
        user.table.ajax.reload();
    },

}

$(function () {
    viewIndex.init();
    window.$loadListTaiKhoan = viewIndex.loadTable;
})
