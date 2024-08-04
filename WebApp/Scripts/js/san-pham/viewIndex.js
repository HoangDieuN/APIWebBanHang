var viewIndex = {
    elmTable: "#tbl-danhsach",
    elmTableToolbar: "#tbl-danhsach-toolbar",
    sanPham: new SanPham(),
    danhMucSanPham: new DanhMucSanPham(),
    namFilter: { elm: "#sl-namc" },
    keywordsFilter: { elm: "#txt-keywords" },
    danhMucSanPhamFilter: { elm: "#sl-danhmucsanpham" },

    init: function () {
        let { namFilter, keywordsFilter, danhMucSanPhamFilter, elmTable } = this;
        //table init
        this.sanPham.setDanhMucSanPham($(danhMucSanPhamFilter.elm).val());
        this.sanPham.dataTable({
            elm: elmTable,
            ulr: this.sanPham.endpoints.fetchList,
            type: "index",
            callback: this.tableEvents
        })
        //page envents
        this.pageEvents();
    },
    pageEvents: function () {
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
        //select init
        _this.selectInit();
        
    },
    tableEvents: function () {
        let _this = viewIndex;
        let { sanPham, elmTable } = _this;

    },
    //
    selectInit: function () {
        let _this = viewIndex;
        let { danhMucSanPham, danhMucSanPhamFilter, namFilter } = _this;
        //select nam
        $.fn.slNam(namFilter.elm);
        //select danh muc sp
        danhMucSanPham.allOptions((data) => {
            let obj = { data };
            $.fn.initSelect2(danhMucSanPhamFilter.elm, obj);
        })
    },
    handleSelectChange: function (name, value) {
        let _this = viewIndex;
        let { sanPham, danhMucSanPhamFilter } = _this;
        switch (name) {           
            case "sl-danhmucsanpham":
                _this.loadTable();
            case "sl-nam":
                _this.loadTable();
                break;
            default:
                break;
        }
    },
    loadTable: function () {
        debugger
        let _this = viewIndex;
        let { sanPham,danhMucSanPhamFilter, keywordsFilter,namFilter } = _this;
  
        sanPham.setKeywords($(keywordsFilter.elm).val());
        sanPham.setNam($(namFilter).val());
        sanPham.setDanhMucSanPham($(danhMucSanPhamFilter.elm).val());
        sanPham.table.ajax.reload();
    },
}
$(function () {
    viewIndex.init();
    window.$loadListSanPham = viewIndex.loadTable;
})