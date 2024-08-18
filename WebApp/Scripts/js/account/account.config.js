class User {
    constructor() {
        //validate rules
        this.validateRules = {
            rules: {
                HoTen: {
                    required: !0,
                    maxlength: 200
                },
                UserName: {
                    required: !0,
                    maxlength: 200
                },
                Password: {
                    required: !0,
                    maxlength: 200
                },
                DiaChi: {
                    required: !0,
                    maxlength: 200
                },
                Email: {
                    required: !0,
                    maxlength: 200
                },
            },
            messages: {
                TenDanhMucSP: {
                    required: "Vui lòng nhập thông tin",
                    maxlength: "Không được vượt quá 200 ký tự"
                },
                MaDanhMucSP: {
                    required: "Vui lòng nhập thông tin",
                    maxlength: "Không được vượt quá 200 ký tự"
                },
                MoTa: {
                    required: "Vui lòng nhập thông tin",
                    maxlength: "Không được vượt quá 200 ký tự"
                },
            },

        }
        //table columns
        this.tableColumnsConfig = [
            {
                type: "index",
                columns: () => [
                    { data: "Stt", title: "STT", name: "Stt", width: 25 },
                    { data: "TenDanhMucSP", title: "Tên danh mục sản phẩm", name: "TenDanhMucSP", width: 150 },
                    { data: "MaDanhMucSP", title: "Mã danh mục", name: "MaDanhMucSP", width: 100 },
                    { data: "MoTa", title: "Mô tả", name: "MoTa", width: 100 },

                    {
                        data: "Id", title: "Thao tác", name: "action", width: 80,
                        render: function (data, type, row) {
                            let strButton = ``;
                            strButton += `<button type="button" class="btn btn-sm btn-outline-warning btn-icon waves-effect waves-light btn-edit" title="Sửa">
                            ${featherIcons.edit3}
                        </button>
                       `
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
        ];
        //endpoints
        this.endpoints = {
            fetchList: "/Admin/DMSanPham/ListDanhMucSanPham",
            pvForm: (id) => {
                let params = { id };
                const searchParams = new URLSearchParams(params);
                return `/Admin/DMSanPham/_FormDMSanPham?${searchParams.toString()}`;
            },
            save: "/Admin/DMSanPham/Save",
            delete: "/Admin/DMSanPham/Delete",
            fetchOptions: "DMSanPham/SelectDanhMucSanPham"
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

    pvForm(id, callback) {
        let { endpoints } = this;
        $.fn.loading();
        $.fn.getData(endpoints.pvForm(id), {}, res => {
            $.fn.offLoading();
            if (callback) callback(res);
        })
    }
    save(data, callback) {
        let { endpoints } = this;
        $.fn.loading();
        $.fn.postFormData(endpoints.save, data, callback);
    }
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
    allOptions(callback) {
        let { endpoints } = this;
        let data = window.categories[OPT_DM_SANPHAM];
        if (data != null && data !== undefined && data.length > 0) {
            if (callback) callback(data);
        } else {
            $.fn.postData(endpoints.fetchOptions, {}, (res) => {
                window.categories[OPT_DM_SANPHAM] = res.data;
                if (callback) callback(res.data);
            });
        }
    }

    //#region action

    //#end region action
    //#end region method
}

