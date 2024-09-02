class SanPham {
    constructor() {
        this.validatRules = {
            rules: {
                TenSanPham: {
                    required: !0
                },
                MoTa: {
                    required: !0
                },
                DanhMucId: {
                    required: !0
                },
                TenDanhMucSP: {
                    required: !0
                },            
            },
            message: {
                TenSanPham: {
                    required: "Vui lòng nhập thông tin",
                },
                MoTa: {
                    required: "Vui lòng nhập thông tin",
                },
                DanhMucId: {
                    required: "Vui lòng nhập thông tin",
                },
                TenDanhMucSP: {
                    required: "Vui lòng nhập thông tin",
                },            
            }
        }
        this.tableColumnsConfig = [
            {
                type: "index",
                columns: () => [
                    { data: "Stt", title: "STT", name: "Stt", width: 25 },
                    { data: "TenSanPham", title: "Tên sản phẩm", name: "TenSanPham", width: 150 },
                    { data: "MoTa", title: "Mô tả", name: "MoTa", width: 250 },
                    { data: "GiaGoc", title: "Gía gốc", name: "GiaGoc", width: 100 },
                    { data: "TenDanhMucSP", title: "Tên danh mục", name: "TenDanhMucSP", width: 150 },
                    { data: "Nam", title: "Năm", name: "Nam", width: 50 },
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
                        data: "Id", title: "Thao tác", name: "action", with: 80,
                        render: function (data, type, row) {
                            let strButton = ``;
                            if (row.IsActive == false) {
                                strButton += `<button type="button" class="btn btn-sm btn-outline-warning btn-icon waves-effect waves-light btn-edit" title="Sửa">
                            ${featherIcons.edit3}   </button> 
                            <button type="button" class="btn btn-sm btn-outline-danger btn-icon waves-effect waves-light btn-del" title="Xoá">
                            ${featherIcons.trash}
                        </button> 
                        <button type="button" class="btn btn-sm btn-outline-success btn-icon waves-effect waves-light btn-active" title="Hiển thị">
                            ${featherIcons.playCircle}
                        </button>`
                                    ;
                            }
                            else {
                                strButton += `<button type="button" class="btn btn-sm btn-outline-warning btn-icon waves-effect waves-light btn-edit" title="Sửa">
                            ${featherIcons.edit3}   </button> 
                            <button type="button" class="btn btn-sm btn-outline-danger btn-icon waves-effect waves-light btn-del" title="Xoá">
                            ${featherIcons.trash}
                        </button> 
                        <button type="button" class="btn btn-sm btn-outline-success btn-icon waves-effect waves-light btn-unactive" title="Không hiển thị">
                            ${featherIcons.playCircle}
                        </button>`
                            }
                            return `<div class="d-flex align-items-center gap-1">
                             ${strButton}
                               </div>`;
                        }
                    }
                ],
            },
        ];
        //end points
        this.endpoints = {
            fetchList: "/Admin/SanPham/ListSanPham",
            save: "/Admin/SanPham/Save",
            delete: "/Admin/SanPham/Delete",
            updateActive:"/Admin/SanPham/UpdateActive",
            fetchOptions: "/Admin/DMSanPham/SelectDanhMucSanPham",
            pvForm: (id) => {
                let params = { id };
                const searchParams = new URLSearchParams(params);
                return `/Admin/SanPham/_FormSanPham?${searchParams.toString()}`;
            },
        }
    }
    getTable = () => { return this.table; }
    setTable = (val) => { this.table = val; }
    getKeywords = () => this.keywords;
    setKeywords = val => { this.keywords = val; }
    getNam = () => { return this.Nam; }
    setNam = (val) => { this.Nam = val; }
    getDanhMucSanPham = () => { return this.DanhMucId;}
    setDanhMucSanPham = (val) => { this.DanhMucId = val; }

    dataTableInit = ({ elm, url, type, callback }) => {
        debugger
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
                    params.Nam = this.getNam();
                    params.DanhMucId = this.getDanhMucSanPham();
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
    save(data, callback) {
        let { endpoints } = this;
        $.fn.postFormData(endpoints.save, data, callback);
    }
    pvForm(id, callback) {
        let { endpoints } = this;
        $.fn.loading();
        $.fn.getData(endpoints.pvForm(id), {}, res => {
            $.fn.offLoading();
            if (callback) callback(res);
        })
    }
    updateActive(data, callback) {
        let { endpoints } = this;
        $.fn.postData(endpoints.updateActive, data, callback);
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
}