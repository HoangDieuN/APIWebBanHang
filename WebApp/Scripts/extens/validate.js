//default message
jQuery.extend(jQuery.validator.messages, {
    required: "Vui lòng nhập thông tin",
    remote: "Please fix this field.",
    email: "Please enter a valid email address.",
    url: "Please enter a valid URL.",
    date: "Please enter a valid date.",
    dateISO: "Please enter a valid date (ISO).",
    number: "Please enter a valid number.",
    digits: "Please enter only digits.",
    creditcard: "Please enter a valid credit card number.",
    equalTo: "Please enter the same value again.",
    accept: "Please enter a value with a valid extension.",
    maxlength: jQuery.validator.format("Please enter no more than {0} characters."),
    minlength: jQuery.validator.format("Please enter at least {0} characters."),
    rangelength: jQuery.validator.format("Please enter a value between {0} and {1} characters long."),
    range: jQuery.validator.format("Please enter a value between {0} and {1}."),
    max: jQuery.validator.format("Please enter a value less than or equal to {0}."),
    min: jQuery.validator.format("Please enter a value greater than or equal to {0}.")
});


$.fn.renderRequired = (rules) => {
    if (rules) {
        for (var property in rules) {
            if (rules[property].required !== undefined && rules[property].required) {
                $("label[for='" + property + "'] span").html("*");
            }
            else {
                $("label[for='" + property + "'] span").html("");
            }
        }
    }
}

$.fn.validateForm = (elm, obj) => {
    debugger
    let config = {
        errorClass: "invalid-feedback animated fadeInUp",
        errorElement: "span",
        errorPlacement: function (e, a) {
            jQuery(a).closest("div").append(e);
        },
        highlight: function (e) {
            jQuery(e).closest("div").removeClass("is-invalid").addClass("is-invalid");
        },
        success: function (e) {
            jQuery(e).closest("div").removeClass("is-invalid"), jQuery(e).remove();
        },
    }
    if (obj) config = $.extend({}, config, obj);
    $(elm).validate(config);
    //select2
    $(".select2").on("select2:select select2:clear", function () {
        $(this).valid();
    })
}

$.fn.validateDestroy = (elm) => {
    $(elm).validate().destroy();
}

$.fn.requiredUploadFile = (names, files) => {
    let isValid = true;
    let _names = [];
    let _files = files ?? [];
    if (names) _names = [...names];
    $.map(_names, name => {
        let elmId = `${name}-error`;
        let elmErr = `<span id="${elmId}" class="invalid-feedback animated fadeInUp" style="display: inline;">Vui lòng nhập thông tin</span>`;
        let listFiles = _files.filter(x => x.FileKey == name);
        if (listFiles.length > 0) {
            $(`#${elmId}`).remove();
        }
        else {
            $(`#${elmId}`).remove();
            $(`#${name.toLowerCase()}`).append(elmErr);
            isValid = false;
        }
    })
    return isValid;
}

//#region rules
$.validator.methods.number = function (value, element) {
    return this.optional(element) || /(^[0-9]+$)|^([0-9]+([.,][0-9]+)?)$/.test(value);
}

$.validator.methods.greaterThan0 = function (value, element) {
    return value > 0;
}

$.validator.methods.select2 = function (value, element) {
    return value > 0;
}
//#endregion rules