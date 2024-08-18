$(function () {
    if (window.categories == null)
        window.categories = {};
})

//#region select
//select năm
$.fn.slNamHanhChinh = (elm) => {
    let results = [];
    let d = new Date();
    for (var i = d.getFullYear(); i >= 2000; i--) {
        results.push({
            id: i,
            text: i
        })
    }
    $(elm).select2({
        placeholder: '--Lựa chọn--',
        width: "100%",
        allowClear: true,
        data: results
    })
}
//select năm học
$.fn.slNamHoc = (elm) => {
    let results = [];
    let d = new Date();
    for (var i = d.getFullYear(); i >= 2000; i--) {
        results.push({
            id: i + '-' + (i + 1),
            text: i + '-' + (i + 1)
        })
    }
    $(elm).select2({
        placeholder: '--Lựa chọn--',
        width: "100%",
        allowClear: true,
        data: results
    })
}
//select học kỳ
$.fn.slHocKy = (elm) => {
    let results = [];
    for (var i = 1; i <= 2; i++) {
        results.push({
            id: i,
            text: 'Học kỳ ' + i
        })
    }
    $(elm).select2({
        placeholder: '--Lựa chọn--',
        width: "100%",
        allowClear: true,
        data: results
    })
}


//#endregion select

//#region list options

//list loại file
$.fn.optAttachFileGroup = (callback) => {
    let data = window.categories[OPT_DM_ATTACHFILEGROUP];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_ATTACHFILEGROUP_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_ATTACHFILEGROUP] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//#endregion list options