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
                }
            },
            message: {

            }
        }
        this.tableColumnsConfig = [
            {
                type: "index",
                columns: () => [
                    { data: "Stt", title: "STT", name: "Stt", width: 25 },
                    { data: "TenSanPham", title: "Tên sanr phẩm", name: "TenSanPham", width: 150 },
                    { data: "MoTa", title: "Mô tả", name: "MoTa", width: 100 },
                    { data: "GiaGoc", title: "Gía gốc", name: "GiaGoc", width: 100 },
                    { data: "TacGia", title: "Tác giả", name: "TacGia", width: 100 },
                    { data: "SoTacGia", title: "Số tác giả", name: "SoTacGia", width: 100 },
                    {
                        data: "Id", title: "Thao tác", name: "action", with: 80,
                        render: function (data, type, row) {
                            let strButton = ``;
                            strButton += `<button type="button" class="btn btn-sm btn-outline-warning btn-icon waves-effect waves-light btn-edit" title="Sửa">
                            ${featherIcons.edit3}   </button> <button type="button" class="btn btn-sm btn-outline-danger btn-icon waves-effect waves-light btn-del" title="Xoá">
                            ${featherIcons.trash}
                        </button>`;

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
            fetchList: "/SanPham/ListSanPham",
            save: "/SanPham/Save",
            delete: "/SanPham/Delete",
            fetchOptions:"/DMSanPham/SelectDanhMucSanPham",
        }

    }
    getTable = () => { return this.table; }
    setTable = (val) => { this.table = val; }
    getKeywords = () => { return this.keywords; }
    setKeywords = (val) => { this.table = val; }
    getNam = () => { return this.nam; }
    setNam = (val) => { this.nam = val; }
    getDanhMucSanPham = () => { return this.DanhMucId;}
    setDanhMucSanPham = (val) => { this.DanhMucId = val; }

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
                    params.nam = this.getNam();
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
}