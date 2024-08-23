var viewIndex = {
    elmTable: "#tbl-danhsach",
    elmTableToolbar: "#tbl-danhsach-toolbar",
    dmModule: new DMModule(),

    init: function () {
        debugger
        let { elmTable } = this;
        //table init

        this.dmModule.dataTableInit({
            elm: elmTable,
            url: this.dmModule.endpoints.fetchList,
            type: "index",
            callback: this.tableEvents
        })
        //page events
        this.pageEvents();
    },
    pageEvents: function () {
        debugger
        let _this = viewIndex;
        let { dmModule } = _this;

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
            dmModule.pvForm(0, (res) => {
                showModal({
                    elm: "#modal",
                    title: "Thêm mới module",
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
        let { dmModule, elmTable } = _this;
        //edit
        $(`${elmTable} .btn-edit`).off().on("click", function () {
            debugger
            let table = dmModule.getTable();
            let tr = $(this).closest("tr");
            let row = table.row(tr).data();
            if (row.Id) {
                dmModule.pvForm(row.Id, (res) => {
                    showModal({
                        elm: "#modal",
                        title: "CẬP NHẬT MODULE ",
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
            let table = dmModule.getTable();
            let tr = $(this).closest("tr");
            let row = table.row(tr).data();
            if (row.Id) {
                dmModule.delete({ ids: row.Id }, () => {
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
        let { dmModule } = _this;
        dmModule.table.ajax.reload();
    },

}

$(function () {
    viewIndex.init();
    window.$loadListModule = viewIndex.loadTable;
})
