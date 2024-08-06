var viewIndex = {
    elmTable: "#tbl-danhsach",
    elmTableToolbar: "#tbl-danhsach-toolbar",
    danhMucSanPham: new DanhMucSanPham(),
    keywordsFilter: { elm: "#txt-keywords" },

    init: function () {
        debugger
        let { elmTable } = this;
        //table init

        this.danhMucSanPham.dataTableInit({
            elm: elmTable,
            url: this.danhMucSanPham.endpoints.fetchList,
            type: "index",
            callback: this.tableEvents
        })
        //page events
        this.pageEvents();
    },
    pageEvents: function () {
        debugger
        let _this = viewIndex;
        let { danhMucSanPham } = _this;

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
            danhMucSanPham.pvForm(0, (res) => {
                showModal({
                    elm: "#modal",
                    title: "Thêm mới danh mục sản phẩm",
                    content: res,
                    size: "lg",
                    button:modalButton.save
                })
            });
        })
        

        _this.selectInit();

    },
    tableEvents: function () {
        let _this = viewIndex;
        let { danhMucSanPham, elmTable } = _this;
        $(`${elmTable} .btn-edit`).off().on("click", function () {
            debugger
            let table = danhMucSanPham.getTable();
            let tr = $(this).closest("tr");
            let row = table.row(tr).data();
            if (row.Id) {
                danhMucSanPham.pvForm(row.Id, (res) => {
                    showModal({
                        elm: "#modal",
                        title: "CẬP NHẬT DANH MỤC SẢN PHẨM",
                        content: res,
                        size: "lg",
                        button: modalButton.save
                    })
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
        debugger
        let _this = viewIndex;
        let { danhMucSanPham, keywordsFilter } = _this;
        danhMucSanPham.setKeywords($(keywordsFilter.elm).val());
        danhMucSanPham.table.ajax.reload();
    },
   
}

$(function () {
    viewIndex.init();
    window.$loadListDanhMucSanPham = viewIndex.loadTable;
})
