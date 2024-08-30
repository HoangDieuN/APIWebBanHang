$(function () {
    debugger
    $.ajax({
        url: '/BaiViets/DanhSachBaiViet',
        type: 'GET',
        success: function (result) {
            $('#_partialDanhSachBaiViet').html(result);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
});