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
        _this.selectInit();

    },
    tableEvents: function () {
        let _this = viewIndex;
        let { danhMucSanPham, elmTable } = _this;    
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
