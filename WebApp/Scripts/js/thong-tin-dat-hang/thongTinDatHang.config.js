class ThongTinDatHang {
    constructor() {
        this.listThongTinDatHang = [];
        
        this.tableColumnsConfig = [
            {
                type: "listBySanPham",
                columns: () => [
                    { data: "Stt", title: "STT", name: "Stt", width: 25 },
                    { data: "TenSanPham", name: "TenSanPham", title: "Tên sản phẩm" },
                    { data: "Gia", name: "Gia", title: "Gía" },
                    { data: "Quantity", name: "Quantity", title: "Số lượng" },
                    {
                        data: "Id", title: "", name: "action", width: 50,
                        render: function () {
                            let strButton = "";
                            strButton += `<button type="button" class="btn btn-sm btn-outline-warning btn-icon waves-effect waves-light btn-edit" title="Sửa">
                                ${featherIcons.edit3}
                            </button>`;
                            strButton += `<button type="button" class="btn btn-sm btn-outline-danger btn-icon waves-effect waves-light btn-del" title="Xoá">
                                ${featherIcons.trash}
                            </button>`;
                            return `<div class="d-flex align-items-center gap-1">
                                ${strButton}
                            </div>`;
                        }
                    },
                ],
            },
            {
                type: "viewListBySanPham",
                columns: () => [
                    { data: "Stt", title: "STT", name: "Stt", width: 25 },
                    { data: "TenSanPham", name: "TenSanPham", title: "Tên sản phẩm" },
                    { data: "Gia", name: "Gia", title: "Gía" },
                    { data: "Quantity", name: "Quantity", title: "Số lượng" },
                    //{
                    //    data: "Id", title: "", name: "action", width: 50,
                    //    render: function () {
                    //        let strButton = "";
                    //        strButton += `<button type="button" class="btn btn-sm btn-outline-info btn-icon waves-effect waves-light btn-detail" title="Xem chi tiết">
                    //            ${featherIcons.eye}
                    //        </button>`;
                    //        return `<div class="d-flex align-items-center gap-1">
                    //            ${strButton}
                    //        </div>`;
                    //    }
                    //},
                ],
            }
        ];
        //endpoints
        this.endpoints = {
            fetchByDatHangId: "/ThongTinDatHang/ListThongTinDatHangByDatHangId",
        }
    }
    //#region properties
    getTable() { return this.table; }
    setTable(val) { this.table = val; }
    getKeywords() { return this.keywords; }
    setKeywords(val) { this.keywords = val; }
    getDatHang() { return this.datHangId; }
    setDatHang(val) { this.datHangId = val; }
    getListThongTinDatHang() { return this.listThongTinDatHang; }
    setListThongTinDatHang(val) { this.listThongTinDatHang = val; }
    //#endregion properties

    //#region methods

    //#region table
    dataTableInit({ elm, url, type, callback }) {
        //get columns
        let _tableColumnsConfig = this.tableColumnsConfig.find(x => x.type == type);
        let maxWidth = $(elm).closest(".table-responsive").width();
        let tableWidth = 0;
        let columns = _tableColumnsConfig.columns();
        $.map(columns, (col) => {
            tableWidth += parseInt(col.width ?? 0);
        });
        //config datatable
        let config = {
            serverSide: true,
            scrollY: "50vh",
            scrollX: true,
            scrollCollapse: true,
            ordering: false,
            autoWidth: tableWidth > maxWidth ? !0 : !1,
            fixedHeader: true,
            fixedColumns: {
                left: 0,
                right: 1
            },
            ajax: {
                url: url,
                type: "POST",
                data: (params) => {
                    params.Keywords = this.getKeywords();
                    params.DatHangId = this.getDatHang();
                }
            },
            columns: columns,
            drawCallback: () => {
                if (callback) callback();
            }
        }
        //init datatable
        let table = $.fn.initDataTable(elm, config);
        this.setTable(table);
    }

    dataTableClientInit({ elm, type, paging, callback }) {
        debugger
        let data = this.getListThongTinDatHang();
        //get columns
        let _tableColumnsConfig = this.tableColumnsConfig.find(x => x.type == type);
        let maxWidth = $(elm).closest(".table-responsive").width();
        let tableWidth = 0;
        let columns = _tableColumnsConfig.columns();
        $.map(columns, (col) => {
            tableWidth += parseInt(col.width ?? 0);
        });
        //config datatable
        let config = {
            scrollY: "50vh",
            scrollX: true,
            scrollCollapse: true,
            ordering: false,
            paging: paging ?? !1,
            info: paging ?? !1,
            autoWidth: tableWidth > maxWidth ? !0 : !1,
            fixedHeader: true,
            fixedColumns: {
                left: 0,
                right: 1
            },
            data,
            columns: columns,
            drawCallback: () => {
                if (callback) callback();
            }
        }
        //init datatable
        let table = $.fn.initDataTable(elm, config);
        this.setTable(table);
    }

    reloadClientTable() {
        let { listThongTinDatHang } = this;
        let _listTTDH = [...listThongTinDatHang];
        _listTTDH = $.map(_listTTDH, (item, index) => {
            item.STT = index + 1;
            return item;
        })
        this.table.clear();
        this.table.rows.add([..._listTTDH]);
        this.table.draw();
    }
    //#endregion table

    //#region actions

    fetchByDatHangId(data, callback) {
        debugger
        let { endpoints } = this;
        $.fn.postData(endpoints.fetchByDatHangId, {
            ...data,
            datHangId: this.getDatHang()
        }, callback);
    }
    //#endregion actions

    //#endregion methods
}