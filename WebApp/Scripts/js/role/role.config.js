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
        this.endpoints = {
            fetchOptions: "/Admin/Role/SelectRole",
            save: "/Admin/Role/SaveUserRole",
        }
    }

    //#region properties
    setRules(rules) {
        this.validateRules = rules;
    }
    getRules() {
        return this.validateRules;
    }
    //#endregion properties

    openFormRole(idCB, callback) {
        debugger
        $.fn.offLoading();
        $.fn.postData(ACT_ROLE_FORM, {
            userID: idCB
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

    saveUserRole(data, callback) {
        debugger
        let { endpoints } = this;
        $.fn.postFormData(endpoints.save, data, callback);
    }
    allOptions(callback) {
        let { endpoints } = this;
        $.fn.postData(endpoints.fetchOptions, {}, (res) => {
            if (callback) callback(res.data);
        });
    }
}

