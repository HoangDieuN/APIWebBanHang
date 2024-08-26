$(function () {
    $.ajax({
        url: '/DMSanPhams/MenuLeft',
        type: 'GET',
        success: function (result) {
            $('#_partialMenuLeft').html(result);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
    $.ajax({
        url: '/SanPhams/DanhSachSanPham',
        type: 'GET',
        success: function (result) {
            $('#_partialDanhSachSanPham').html(result);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
});