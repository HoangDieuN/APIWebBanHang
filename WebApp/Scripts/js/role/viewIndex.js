var viewIndex = {
    elmTable: "#tbl-danhsach",
    elmTableToolbar: "#tbl-danhsach-toolbar",
    role: new Role(),
    init: function () {
        debugger
        let { elmTable } = this;
        //table init

        this.role.dataTableInit({
            elm: elmTable,
            url: this.role.endpoints.fetchList,
            type: "index",
            callback: this.tableEvents
        })
        //page events
        this.pageEvents();
    },
    pageEvents: function () {
        debugger
        let _this = viewIndex;
        let { role } = _this;
        //add
        $("#btn-add").on("click", function () {
            role.formThemMoiRole(0, (res) => {
                showModal({
                    elm: "#modal",
                    title: "Thêm mới quyền",
                    content: res,
                    size: "lg",
                    button: modalButton.save
                })
            });
        })
    },
    tableEvents: function () {
        let _this = viewIndex;
        let { danhMucSanPham, elmTable } = _this;
 
        //delete
        //$(`${elmTable} .btn-del`).off().on("click", function () {
        //    debugger
        //    let table = role.getTable();
        //    let tr = $(this).closest("tr");
        //    let row = table.row(tr).data();
        //    if (row.Id) {
        //        role.delete({ ids: row.Id }, () => {
        //            table.ajax.reload(null, false);
        //        });
        //    } else {
        //        $.fn.showAlert('Không tìm thấy thông tin đã chọn', 'warning');
        //    }
        //})
    },
    loadTable: function () {
        debugger
        let _this = viewIndex;
        let { role} = _this;
        role.table.ajax.reload();
    },
}
$(function () {
    viewIndex.init();
    window.$loadListRole = viewIndex.loadTable;
})
