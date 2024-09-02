var pvDanhSachSanPham= {
    elmMain: "#pv-listsanpham",
    elmTable: "#tbl-sanpham",
    thongTinDatHang: new ThongTinDatHang(),
    getListThongTinDatHang: function () {
        debugger
        return pvDanhSachSanPham.thongTinDatHang.getListThongTinDatHang();
    },
    init: function () {
        debugger
        //init table
        this.thongTinDatHang.setDatHang(datHangId);

        this.thongTinDatHang.fetchByDatHangId({}, res => {
            let _data = []; debugger
            if (res.result == "success") {
                _data = [...res.data];
                _data = $.map([...res.data], item => {
                    item.key = self.crypto.randomUUID();
                    return item;
                });
                this.thongTinDatHang.setListThongTinDatHang(_data);
            }
            this.thongTinDatHang.dataTableClientInit({
                elm: this.elmTable,
                type: "viewListBySanPham",
                callback: this.tableEvents
            });
        })
        //page events
        this.pageEvents();
    },
    pageEvents: function () {
        let _this = pvDanhSachSanPham;
        let { elmMain, thongTinDatHang } = _this;
    },
    loadTable: function () {
        debugger
        let _this = pvDanhSachSanPham;
        let { thongTinDatHang } = _this;
        thongTinDatHang.reloadClientTable();
    },
    tableEvents: function () {
        let _this = pvDanhSachSanPham;
        let { elmTable, thongTinDatHang} = _this;    
    },
}

$(function () {
    debugger
    pvDanhSachSanPham.init();
    window.$getListThongTinDatHang = pvDanhSachSanPham.getListThongTinDatHang;
})