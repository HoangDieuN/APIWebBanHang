﻿$(function () {
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
//select phương thức quy dổi
$.fn.slPhuongThucQuyDoi = (elm) => {
    let results = [
        { id: 1, text: "Giờ nghiên cứu khoa học" },
        { id: 2, text: "Giờ giảng" },
        // { id: 3, text: "Tính sáng kiến cơ sở" },
    ];
    window.categories[OPT_DM_PHUONGTHUCQUYDOI] = results;
    $(elm).select2({
        placeholder: '--Lựa chọn--',
        width: "100%",
        allowClear: true,
        data: results
    })
}
//select toán tử so sánh
$.fn.slOperators = (elm) => {
    let results = [
        { id: "=", text: "Bằng" },
        { id: "<>", text: "Khác" },
        { id: "<", text: "Nhỏ hơn" },
        { id: ">", text: "Lớn hơn" },
        { id: "<=", text: "Nhỏ hơn hoặc bằng" },
        { id: ">=", text: "Lớn hơn hoặc bằng" }
    ];

    $(elm).select2({
        placeholder: '--Lựa chọn--',
        width: "100%",
        allowClear: true,
        data: results
    })
}
//select cán bộ paging
$.fn.slCanBo = (elm, params) => {
    $.fn.singleSelectPaging(elm, ACT_CANBO_SELECTLIST, params ? params : {});
}
//select khoa paging
$.fn.slKhoa = (elm) => {
    $.fn.singleSelectPaging(elm, ACT_KHOA_SELECTLIST, {});
}
//select lớp paging
$.fn.slLop = (elm, params) => {
    $.fn.singleSelectPaging(elm, ACT_LOP_SELECTLIST, params ? params : {});
}
//select sinh viên paging
$.fn.slSinhVien = (elm, params) => {
    $.fn.singleSelectPaging(elm, ACT_SINHVIEN_SELECTLIST, params ? params : {});
}
//select hội thảo paging
$.fn.slHoiThao = (elm, params) => {
    $.fn.singleSelectPaging(elm, ACT_HOITHAO_SELECTLIST, params ? params : {});
}
//#endregion select

//#region list options
//list vai trò bài báo
$.fn.optVaiTroBaiBao = (callback) => {
    $.fn.postData(ACT_DM_VAITROBAIBAO_SELECTLIST, {}, (res) => {
        window.categories[OPT_DM_VAITROBAIBAO] = res.data;
        if (callback) callback(res.data);
    });
}
//list loại bài báo
$.fn.optLoaiBaiBao = (callback) => {
    let data = window.categories[OPT_DM_LOAIBAIBAO];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_LOAIBAIBAO_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_LOAIBAIBAO] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list loại sách
$.fn.optLoaiSach = (callback) => {
    let data = window.categories[OPT_DM_LOAISACH];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_LOAISACH_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_LOAISACH] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list vai trò bài báo
$.fn.optVaiTroDeTai = (callback) => {
    let data = window.categories[OPT_DM_VAITRODETAI];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_VAITRODETAI_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_VAITRODETAI] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list vai trò bài báo
$.fn.optVaiTroSachTaiLieu = (callback) => {
    let data = window.categories[OPT_DM_VAITROSACHTAILIEU];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_VAITROSACHTAILIEU_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_VAITROSACHTAILIEU] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list lĩnh vực nghiên cứu
$.fn.optLinhVucNghienCuu = (callback) => {
    let data = window.categories[OPT_DM_LINHVUCNGHIENCUU];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_LINHVUCNGHIENCUU_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_LINHVUCNGHIENCUU] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list đơn vị quản lý
$.fn.optDonViQuanLy = (callback) => {
    let data = window.categories[OPT_DM_DONVIQUANLY];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_DONVIQUANLY_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_DONVIQUANLY] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list cơ quan quản lý
$.fn.optCoQuanQuanLy = (callback) => {
    let data = window.categories[OPT_DM_COQUANQUANLY];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_COQUANQUANLY_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_COQUANQUANLY] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list cấp đề tài
$.fn.optCapDeTai = (callback) => {
    let data = window.categories[OPT_DM_CAPQUANLY];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_CAPDETAI_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_CAPQUANLY] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list hình thức đề tài
$.fn.optHinhThucDeTai = (callback) => {
    let data = window.categories[OPT_DM_HINHTHUCDETAI];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_HINHTHUCDETAI_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_HINHTHUCDETAI] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list loại hình nghiên cứu
$.fn.optLoaiHinhNghienCuu = (callback) => {
    let data = window.categories[OPT_DM_LOAIHINHNGHIENCUU];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_LOAIHINHNGHIENCUU_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_LOAIHINHNGHIENCUU] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list loại hình nghiên cứu
$.fn.optXepLoai = (callback) => {
    let data = window.categories[OPT_DM_XEPLOAI];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_XEPLOAI_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_XEPLOAI] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list loại sản phẩm
$.fn.optLoaiSanPham = (callback) => {
    let data = window.categories[OPT_DM_LOAISANPHAM];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_LOAISANPHAM_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_LOAISANPHAM] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list loại sản phẩm tính giờ
$.fn.optLoaiSanPhamTinhGio = (callback) => {
    let data = window.categories[OPT_DM_LOAISANPHAMTINHGIO];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_LOAISANPHAM_SELECTLISTTINHGIO, {}, (res) => {
            window.categories[OPT_DM_LOAISANPHAMTINHGIO] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list quartile
$.fn.optQuartile = (callback) => {
    let data = window.categories[OPT_DM_QUARTILE];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_QUARTILE_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_QUARTILE] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list xếp hạng bài báo
$.fn.optXepHangBaiBao = (callback) => {
    let data = window.categories[OPT_DM_XEPHANGBAIBAO];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_XEPHANGBAIBAO_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_XEPHANGBAIBAO] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list loại sở hữu trí tuệ
$.fn.optLoaiSoHuuTriTue = (callback) => {
    let data = window.categories[OPT_DM_LOAISOHUUTRITUE];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_LOAISOHUUTRITUE_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_LOAISOHUUTRITUE] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list loại giải thưởng
$.fn.optLoaiGiaiThuong = (callback) => {
    let data = window.categories[OPT_DM_LOAIGIAITHUONG];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_LOAIGIAITHUONG_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_LOAIGIAITHUONG] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list tiêu chí sáng kiến cơ sở
$.fn.optTieuChiSangKien = (callback) => {
    let data = window.categories[OPT_DM_TIEUCHISANGKIEN];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_TIEUCHISANGKIEN_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_TIEUCHISANGKIEN] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list mức đánh giá cán bộ
$.fn.optMucDanhGiaCanBo = (callback) => {
    let data = window.categories[OPT_DM_MUCDANHGIACANBO];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_MUCDANHGIACANBO_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_MUCDANHGIACANBO] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list chức danh
$.fn.optChucDanh = (callback) => {
    let data = window.categories[OPT_DM_CHUCDANH];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_CHUCDANH_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_CHUCDANH] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list nhóm giải thưởng
$.fn.optNhomGiaiThuong = (callback) => {
    let data = window.categories[OPT_DM_NHOMGIAITHUONG];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_NHOMGIAITHUONG_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_NHOMGIAITHUONG] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list phạm vi
$.fn.optPhamViKyYeu = (callback) => {
    let data = window.categories[OPT_DM_PHAMVI];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_PHAMVI_SELECTLIST_KYYEU, {}, (res) => {
            window.categories[OPT_DM_PHAMVI] = res.data;
            if (callback) callback(res.data);
        });
    }
}
$.fn.optPhamViSeminarKH = (callback) => {
    let data = window.categories[OPT_DM_PHAMVI];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_PHAMVI_SELECTLIST_SEMINARKHOAHOC, {}, (res) => {
            window.categories[OPT_DM_PHAMVI] = res.data;
            if (callback) callback(res.data);
        });
    }
}
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
//list cấp hội đồng kh
$.fn.optCapHoiDongKhoaHoc = (callback) => {
    let data = window.categories[OPT_DM_CAPHOIDONGKHOAHOC];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_CAPHOIDONGKHOAHOC_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_CAPHOIDONGKHOAHOC] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list điểm công trình
$.fn.optDiemCongTrinh = (callback) => {
    let data = window.categories[OPT_DM_DIEMCONGTRINH];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_DIEMCONGTRINH_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_DIEMCONGTRINH] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list loại hội thảo
$.fn.optLoaiHoiThao = (callback) => {
    let data = window.categories[OPT_DM_LOAIHOITHAO];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_LOAIHOITHAO_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_LOAIHOITHAO] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list mục kê khai
$.fn.optMucKeKhai = (callback) => {
    let data = window.categories[OPT_DM_MUCKEKHAI];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_MUCKEKHAI_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_MUCKEKHAI] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//list vai trò đề tài sinh viên
$.fn.optVaiTroDeTaiSV = (callback) => {
    let data = window.categories[OPT_DM_VAITRODETAISV];
    if (data != null && data !== undefined && data.length > 0) {
        if (callback) callback(data);
    } else {
        $.fn.postData(ACT_DM_VAITRODETAISV_SELECTLIST, {}, (res) => {
            window.categories[OPT_DM_VAITRODETAISV] = res.data;
            if (callback) callback(res.data);
        });
    }
}
//#endregion list options