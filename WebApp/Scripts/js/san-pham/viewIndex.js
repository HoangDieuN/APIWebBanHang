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
