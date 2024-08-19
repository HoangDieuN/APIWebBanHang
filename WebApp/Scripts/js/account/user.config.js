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
                RoleId: {
                    required: !0,
                    maxlength: 200
                },
                RoleName: {
                    required: !0,
                }
            },
            messages: {
                HoTen: {
                    required: "Vui lòng nhập thông tin",
                    maxlength: "Không được vượt quá 200 ký tự"
                },
                UserName: {
                    required: "Vui lòng nhập thông tin",
                    maxlength: "Không được vượt quá 200 ký tự"
                },
                Password: {
                    required: "Vui lòng nhập thông tin",
                    maxlength: "Không được vượt quá 200 ký tự"
                },
                DiaChi: {
                    required: "Vui lòng nhập thông tin",
                    maxlength: "Không được vượt quá 200 ký tự"
                },
                Email: {
                    required: "Vui lòng nhập thông tin",
                    maxlength: "Không được vượt quá 200 ký tự"
                },

                RoleId: {
                    required: "Vui lòng nhập thông tin"
                }
            },

        }
        //table columns
        this.tableColumnsConfig = [
            {
                type: "index",
                columns: () => [
                    { data: "Stt", title: "STT", name: "Stt", width: 25 },
                    { data: "HoTen", title: "Họ tên", name: "HoTen", width: 150 },
                    { data: "UserName", title: "Tên tài khoản", name: "UserName", width: 100 },
                    { data: "DiaChi", title: "Địa chỉ", name: "DiaChi", width: 100 },
                    { data: "Email", title: "Email", name: "Email", width: 100 },
                    { data: "TenViet", title: "Tên quyền tv", name: "TenViet", width: 100 },
                    { data: "RoleName", title: "Tên quyền", name: "RoleName", width: 100 },
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
                        </button> `
                            strButton +=`<button type="button" class="btn btn-sm btn-outline-info btn-icon waves-effect waves-light btn-role" title="Phân vai trò">
                                            <svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1">
                                                <path d="M17 21v-2a4 4 0 0 0-4-4H5a4 4 0 0 0-4 4v2"></path>
                                                <circle cx="9" cy="7" r="4"></circle>
                                                <path d="M23 21v-2a4 4 0 0 0-3-3.87"></path>
                                                <path d="M16 3.13a4 4 0 0 1 0 7.75"></path>
                                            </svg>
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
            fetchList: "/Admin/Account/ListTaiKhoan",
            pvForm: (id) => {
                let params = {id};
                const searchParams = new URLSearchParams(params);
                return `/Admin/Account/_FormAccount?${searchParams.toString()}`;
            },
            save: "/Admin/Account/Save",
            delete: "/Admin/Account/Delete",
            fetchOptions: "Admin/Role/SelectRole"
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
        let data = window.categories[OPT_Role];
        if (data != null && data !== undefined && data.length > 0) {
            if (callback) callback(data);
        } else {
            $.fn.postData(endpoints.fetchOptions, {}, (res) => {
                window.categories[OPT_Role] = res.data;
                if (callback) callback(res.data);
            });
        }
    }

    //#region action

    //#end region action
    //#end region method
}

