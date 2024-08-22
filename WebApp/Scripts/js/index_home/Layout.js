$(function () {
    $.ajax({
        url: '/DMSanPham/MenuDMSanPham',
        type: 'GET',
        success: function (result) {
            $('#_partialViewDsDanhMucSanPham').html(result);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });

    $.ajax({
        url: '/DMSanPham/MenuArrivalsDMSanPham',
        type: 'GET',
        success: function (result) {
            $('#_partialMenuArrvals').html(result);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
    $.ajax({
        url: '/SanPham/MenuSanPhamByMaDMSanPham',
        type: 'GET',
        success: function (result) {
            $('#_partialSanPhamByMaDMSanPham').html(result);
        },
        error: function (xhr, status, error) {
            alert.error(error);
        }
    });
});
