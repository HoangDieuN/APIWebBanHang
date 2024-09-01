var pvDanhSachSanPham= {
    elmMain: "#pv-thanhvien-sp",
    elmTable: "#tbl-thanhvien",
    thongTinDatHang: new ThongTinDatHang(),
    getListThongTinDatHang: function () { return pvDanhSachSanPham.thongTinDatHang.getListThongTinDatHang(); },
    init: function () {
        //init table
        this.thongTinDatHang.setDatHangId(datHangId);

        this.thongTinDatHang.getByDatHangId({}, res => {
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
                type: "listBySanPham",
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
    pvDanhSachTheoSanPham.init();
    window.$getListThanhVien = pvDanhSachTheoSanPham.getListThongTinDatHang;
})