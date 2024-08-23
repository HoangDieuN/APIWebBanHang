class DMModule {
    constructor() {
        //validate rules
        this.validateRules = {
            rules: {
                ModuleName: {
                    required: !0,
                    maxlength: 200
                },
                ModuleCode: {
                    required: !0,
                    maxlength: 200
                },
                MoTa: {
                    required: !0,
                    maxlength: 200
                },
                TenViet: {
                    required: !0,
                    maxlength: 200
                }
            },
            messages: {
                ModuleName: {
                    required: "Vui lòng nhập thông tin",
                    maxlength: "Không được vượt quá 200 ký tự"
                },
                ModuleCode: {
                    required: "Vui lòng nhập thông tin",
                    maxlength: "Không được vượt quá 200 ký tự"
                },
                MoTa: {
                    required: "Vui lòng nhập thông tin",
                    maxlength: "Không được vượt quá 200 ký tự"
                },
                TenViet: {
                    required: "Vui lòng nhập thông tin",
                    maxlength: "Không được vượt quá 200 ký tự"
                }
            },

        }
        //table columns
        this.tableColumnsConfig = [
            {
                type: "index",
                columns: () => [
                    { data: "Stt", title: "STT", name: "Stt", width: 25 },
                    { data: "TenViet", title: "Tên module", name: "TenViet", width: 150 },
                    { data: "ModuleName", title: "Mã module", name: "ModuleName", width: 100 },
                    { data: "ModuleCode", title: "Mã module code", name: "ModuleName", width: 100 },
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
        this.endpoints = {
            fetchList: "/Admin/DMModule/ListDMModule",
            pvForm: (id) => {
                let params = { id };
                const searchParams = new URLSearchParams(params);
                return `/Admin/DMModule/_FormDMModule?${searchParams.toString()}`;
            },
            save: "/Admin/DMModule/Save",
            delete: "/Admin/DMModule/Delete",
            fetchOptions: "/DMModule/SelectModule"
        }
    }
    //#region properties
    getTable = () => { return this.table; }
    setTable = (val) => { this.table = val; }
    getKeywords = () => this.keywords;
    setKeywords = val => { this.keywords = val; }
    //#endregion properties

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
    //#region methods

    //#region actions
    allOptions(callback) {
        let { endpoints } = this;
        $.fn.postData(endpoints.fetchOptions, {}, (res) => {
            if (callback) callback(res.data);
        });
    }
    //#endregion actions

    //#endregion methods
}