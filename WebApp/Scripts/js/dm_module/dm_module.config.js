class DMModule {
    constructor() {
        this.endpoints = {
            fetchOptions: "/DMModule/SelectModule"
        }
    }

    //#region properties

    //#endregion properties

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