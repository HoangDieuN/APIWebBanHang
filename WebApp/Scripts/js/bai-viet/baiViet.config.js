class BaiViet {
    constructor() {
        this.validateRules = {
            rules: {
                TenBaiViet: {
                    required: !0,
                },
                MoTa: {
                    required: !0,
                },
                ThongTin: {
                    required: !0,
                },
                NoiDung: {
                    required: !0,
                },
                IsActive: {
                    required: !0,
                }
            },
            messages: {
            }
        };
        this.tableColumnsConfig = [
            //all
            {
                type: "all",
                columns: (role) => [
                    {
                        data: "Id", name: "SelectBox", title: "", width: 5,
                        render: (data) => {
                            return `<div class="form-check form-check-secondary d-flex align-items-center">
                                    <input class="form-check-input select-checkbox" type="checkbox" id="check_${data}">
                                    <label class="form-check-label" for="check_${data}"></label>
                                </div>`;
                        }
                    },
                    { data: "TenBaiViet", name: "TenBaiViet", title: "Tên bài viết", width:150},                
                    { data: "MoTa", name: "MoTa", title: "MoTa",width: 150 },
                    { data: "ThongTin", name: "ThongTin", title: "Thông tin",width: 150 },
                    {
                        data: "IsActive",
                        name: "IsActive",
                        title: "Trạng thái",
                        width: 50,
                        render: (data) => {
                            let str = "";
                            if (data) {
                                str += `<span class="badge bg-success">Hiển thị</span>`;
                            } else {
                                str += `<span class="badge bg-warning">Không hiển thị</span>`;
                            }
                            return str;
                        }
                    },

                    {
                        data: "Id", title: "Thao tác", name: "action", width: 80,
                        render: function (data, type, row) {
                            let strButton = ``;                 
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
                ]
            },
        ];
        this.endpoints = {
            fetchList: "/Admin/BaiViet/ListBaiViet",
            save: "/Admin/BaiViet/Save",
            delete: "/Admin/BaiViet/Delete",
            pvForm: (id) => {
                let params = { id };
                const searchParams = new URLSearchParams(params);
                return `/Admin/BaiViet/_FormBaiViet?${searchParams.toString()}`;
            },
            updateActive: "/Admin/BaiViet/UpdateActive",
        }
    }

    //#region properties
    getTable = () => { return this.table; }
    setTable = (val) => { this.table = val; }
    getKeywords = () => this.keywords;
    setKeywords = val => { this.keywords = val; }
    //#endregion properties

    //#region methods

    //#region table
    dataTableInit({ elm, url, type, callback }) {
        //get columns
        let tableColumnsConfig = this.tableColumnsConfig.find(x => x.type == type);
        let maxWidth = $(elm).closest(".table-responsive").width();
        let tableWidth = 0;
        $.map(tableColumnsConfig.columns, (col) => {
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
                url,
                type: "POST",
                data: (params) => {
                    params.keywords = this.getKeywords();           
                }
            },
            columns: tableColumnsConfig.columns(),
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
    //#endregion table

    //#region actions
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

    updateActive(data, callback) {
        let { endpoints } = this;
        $.fn.postData(endpoints.updateActive, data, callback);
    }
    //#endregion actions

    //#endregion methods
}