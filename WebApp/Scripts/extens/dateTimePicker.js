var dpLocale = {
    "format": "DD/MM/YYYY",
    "separator": " - ",
    "applyLabel": "Áp dụng",
    "cancelLabel": "Hủy",
    "fromLabel": "Từ",
    "toLabel": "Đến",
    "customRangeLabel": "Tùy chỉnh",
    "weekLabel": "Tuần",
    "daysOfWeek": [
        "CN",
        "T2",
        "T3",
        "T4",
        "T5",
        "T6",
        "T7"
    ],
    "monthNames": [
        "Tháng 1",
        "Tháng 2",
        "Tháng 3",
        "Tháng 4",
        "Tháng 5",
        "Tháng 6",
        "Tháng 7",
        "Tháng 8",
        "Tháng 9",
        "Tháng 10",
        "Tháng 11",
        "Tháng 12"
    ],
    "firstDay": 1
}

//Chọn ngày tháng năm
$.fn.singleDatePicker = (elm, setting, callback) => {
    let config = {
        minDate: "01/01/1900",
        icons: {
            time: 'ri-time-line',
            date: 'ri-calendar-2-line',
            today: 'ri-gradienter-line',
            next: 'ri-arrow-right-s-line',
            previous: 'ri-arrow-left-s-line'
        },
        locale: moment.locale('vi'),
        showTodayButton: true,
        keepOpen: true,
        useCurrent: false,
        format: 'DD/MM/YYYY',
    }
    if(setting) config = $.extend({}, config, setting);
    $(elm).datetimepicker(config, callback);
}

//Chọn năm
$.fn.yearOnly = (elm, setting, callback) => {
    let config = {
        minDate: "01/01/1900",
        format: 'YYYY',
        useCurrent: false,
        showClear: true,
        icons: {
            clear: 'ri-calendar-2-line'
        },
    }
    if(setting) config = $.extend({}, config, setting);
    $(elm).datetimepicker(config);
}

//Chọn thời gian (định dạng 24h)
$.fn.timeOnly = (elm, setting, callback) => {
    let config = {
        format: 'HH:mm',
        icons: {
            up: 'ri-arrow-up-s-line',
            down: 'ri-arrow-down-s-line',
        },
    }
    if(setting) config = $.extend({}, config, setting);
    $(elm).datetimepicker(config);
}