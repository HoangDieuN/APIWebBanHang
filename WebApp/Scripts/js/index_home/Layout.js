$(function () {
    $.ajax({
        url: '/DMModule/MenuTop',
        type: 'GET',
        success: function (result) {
            $('#_partialMenuTop').html(result);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });

    $.ajax({
        url: '/DMSanPhams/MenuDMSanPham',
        type: 'GET',
        success: function (result) {
            $('#_partialViewDsDanhMucSanPham').html(result);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });

    $.ajax({
        url: '/DMSanPhams/MenuArrivalsDMSanPham',
        type: 'GET',
        success: function (result) {
            $('#_partialMenuArrvals').html(result);
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
    $.ajax({
        url: '/SanPhams/MenuSanPhamByMaDMSanPham',
        type: 'GET',
        success: function (result) {
            $('#_partialSanPhamByMaDMSanPham').html(result);
        },
        error: function (xhr, status, error) {
            alert.error(error);
        }
    });
    $.ajax({
        url: '/SanPhams/MenuSanPhamDangSale',
        type: 'GET',
        success: function (result) {
            $('#_partialViewDsSanPhamDangSale').html(result);
        },
        error: function (xhr, status, error) {
            alert.error(error);
        }
    });
    $.ajax({
        url: '/BaiViet/MenuBaiViet',
        type: 'GET',
        success: function (result) {
            $('#_partialViewDsBaiViet').html(result);
        },
        error: function (xhr, status, error) {
            alert.error(error);
        }
    });
});
