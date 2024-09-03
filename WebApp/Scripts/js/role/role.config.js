class Role {
    constructor() {
        this.validateRules = {
            rules: {             
                RoleName: {
                    required: !0
                },
                UserName: {
                    required: !0
                },
                UserId: {
                    required: !0
                },
                TenViet: {
                    required: !0
                }
            },
            messages: {            
                RoleName: {
                    required: "Vui lòng nhập thông tin"
                },
                UserId: {
                    required: "Vui lòng nhập thông tin"
                },
                UserName: {
                    required: "Vui lòng nhập thông tin"
                },
                TenViet: {
                    required: "Vui lòng nhập thông tin"
                }
            },
            ignore: []
        }
        this.tableColumnsConfig = [
            {
                type: "index",
                columns: () => [
                    { data: "Stt", title: "STT", name: "Stt", width: 25 },
                    { data: "RoleName", title: "Tên quyền", name: "RoleName", width: 150 },
                    { data: "TenViet", title: "Tên tiếng việt", name: "TenViet", width: 100 },                
                ],
            },
        ];
        this.endpoints = {
            fetchOptions: "/Admin/Role/SelectRole",
            save: "/Admin/Role/SaveUserRole",
            fetchList: "/Role/ListQuyen",
            create: "/Admin/Role/CreateRole",
            formRole: "/Admin/Role/_FormRole",
            formThemMoiRole: (id) => {
                let params = { id };
                const searchParams = new URLSearchParams(params);
                return `/Admin/Role/_FormThemMoiRole?${searchParams.toString()}`;
            },
        }
    }
    //#region properties
    getTable = () => { return this.table; }
    setTable = (val) => { this.table = val; }
    getKeywords = () => this.keywords;
    setKeywords = val => { this.keywords = val; }
    //#endregion properties

    //#region methods
  
    //#region properties
    setRules(rules) {
        this.validateRules = rules;
    }
    getRules() {
        return this.validateRules;
    }
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
    openFormRole(id, callback) {
        debugger
        $.fn.offLoading();
        $.fn.postData(this.endpoints.formRole, {
            userId: id
        }, (res) => {
            showModal({
                elm: "#modal",
                title: "PHÂN QUYỀN",
                content: res,
                size: "lg",
                button: modalButton.save
            })
        })
    }
    formThemMoiRole(id, callback) {
        let { endpoints } = this;
        $.fn.loading();
        $.fn.getData(endpoints.formThemMoiRole(id), {}, res => {
            $.fn.offLoading();
            if (callback) callback(res);
        })
    }
    saveUserRole(data, callback) {
        debugger
        let { endpoints } = this;
        $.fn.postFormData(endpoints.save, data, callback);
    }
    creatRole(data, callback) {
        debugger
        let { endpoints } = this;
        $.fn.postFormData(endpoints.create, data, callback);
    }
    allOptions(callback) {
        let { endpoints } = this;
        $.fn.postData(endpoints.fetchOptions, {}, (res) => {
            if (callback) callback(res.data);
        });
    }
}

