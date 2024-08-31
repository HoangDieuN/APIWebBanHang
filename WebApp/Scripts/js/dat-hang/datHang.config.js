class DatHang {
    constructor() {
        //validate rules
        this.validateRules = {
            rules: {
                MaDon: {
                    required: !0,
                    maxlength: 200
                },
                TenKhachHang: {
                    required: !0,
                    maxlength: 200
                },
                TongDon: {
                    required: !0
                },
                SoDT: {
                    required: !0,
                },
                DiaChi: {
                    required: !0
                },
                Quantity:{
                    required: !0
                }
            },
            messages: {
                MaDon: {
                    required: "Vui lòng nhập thông tin",
                    maxlength: "Không được vượt quá 200 ký tự"
                },
                TenKhachHang: {
                    required: "Vui lòng nhập thông tin",
                    maxlength: "Không được vượt quá 200 ký tự"
                },
                TongDon: {
                    required: "Vui lòng nhập thông tin",
                },
                SoDT: {
                    required: "Vui lòng nhập thông tin",
                },
                DiaChi: {
                    required: "Vui lòng nhập thông tin",
                },
                Quantity: {
                    required: "Vui lòng nhập thông tin",
                }
            },

        }
        //table columns
        this.tableColumnsConfig = [
            {
                type: "index",
                columns: () => [
                    { data: "Stt", title: "STT", name: "Stt", width: 15 },
                    { data: "MaDon", title: "Mã đơn", name: "MaDon", width: 200 },
                    { data: "TenKhachHang", title: "Tên khách hàng", name: "TenKhachHang", width: 100 },
                    { data: "SoDT", title: "Số điện thoại", name: "SoDT", width: 100 },
                    { data: "DiaChi", title: "Địa chỉ", name: "DiaChi", width: 150 },
                    {
                        data: "Id", title: "Thao tác", name: "action", width: 50,
                        render: function (data, type, row) {
                            let strButton = ``;
                            strButton += `<button type="button" class="btn btn-sm btn-outline-warning btn-icon waves-effect waves-light btn-edit" title="Cập nhật trang thái">
                            ${featherIcons.edit3}
                        </button>
                       `
                            strButton += `<button type="button" class="btn btn-sm btn-outline-danger btn-icon waves-effect waves-light btn-del" title="Xoá">
                            ${featherIcons.trash}
                        </button>`
                            strButton += `<button type="button" class="btn btn-sm btn-outline-info btn-icon waves-effect waves-light btn-view" title="Xem đơn hàng">
                            ${featherIcons.eye}
                        </button>`
                                ;

                            return `<div class="d-flex align-items-center gap-1">
                                ${strButton}
                            </div>`;
                        }
                    },
                ],
            },
        ];
        //endpoints
        this.endpoints = {
            fetchList: "/Admin/DatHang/ListDatHang",
            updateStatus:"/Admin/DatHang/UpdateStatus"
        }
    }
    //#region properties
    getTable = () => { return this.table; }
    setTable = (val) => { this.table = val; }
    getKeywords = () => this.keywords;
    setKeywords = val => { this.keywords = val; }
    //#endregion properties

    //#region methods
    dataTableInit = ({ elm, url, type, callback }) => {
        //get columns
        let tableColumnsConfig = this.tableColumnsConfig.find(x => x.type == type);
        let maxWidth = $(elm).closest(".table-responsive").width();
        let tableWidth = 0;
        let columns = tableColumnsConfig.columns();
        $.map(columns, (col) => {
            tableWidth += parseInt(col.width ?? 0);
        });
        //config datatable
        let table = $.fn.initDataTable(elm, {
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
                    params.keywords = this.getKeywords();
                }
            },
            columns,
            preDrawCallback: () => {
                $.fn.loading();
            },
            drawCallback: () => {
                if (callback) callback();
                $.fn.offLoading();
            }
        })
        this.setTable(table);
    }

    //pvForm(id, callback) {
    //    let { endpoints } = this;
    //    $.fn.loading();
    //    $.fn.getData(endpoints.pvForm(id), {}, res => {
    //        $.fn.offLoading();
    //        if (callback) callback(res);
    //    })
    //}
    //save(data, callback) {
    //    let { endpoints } = this;
    //    $.fn.loading();
    //    $.fn.postFormData(endpoints.save, data, callback);
    //}
    delete(data, callback) {
        let { endpoints } = this;
        $.fn.swalConfirm("Xoá!", "Bạn chắc chắn muốn xóa?", res => {
            if (res.value) {
                $.fn.loading();
                $.fn.postData(endpoints.delete, data, (res) => {
                    $.fn.offLoading();
                    if (callback) callback(res);
                });
            }
        })
    }
    //#region action

    //#end region action
    //#end region method
}

