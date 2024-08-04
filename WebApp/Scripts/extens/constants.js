
//#region feather icons
const featherIcons = {
    edit3: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><path d="M12 20h9"></path><path d="M16.5 3.5a2.121 2.121 0 0 1 3 3L7 19l-4 1 1-4L16.5 3.5z"></path></svg>`,
    eye: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path><circle cx="12" cy="12" r="3"></circle></svg>`,
    trash: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><polyline points="3 6 5 6 21 6"></polyline><path d="M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2"></path></svg>`,
    playCircle: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><circle cx="12" cy="12" r="10"></circle><polygon points="10 8 16 12 10 16 10 8"></polygon></svg>`,
    stopCircle: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><circle cx="12" cy="12" r="10"></circle><rect x="9" y="9" width="6" height="6"></rect></svg>`,
    send: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><line x1="22" y1="2" x2="11" y2="13"></line><polygon points="22 2 15 22 11 13 2 9 22 2"></polygon></svg>`,
    moreVertical: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><circle cx="12" cy="12" r="1"></circle><circle cx="12" cy="5" r="1"></circle><circle cx="12" cy="19" r="1"></circle></svg>`,
    moreHorizontal: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><circle cx="12" cy="12" r="1"></circle><circle cx="19" cy="12" r="1"></circle><circle cx="5" cy="12" r="1"></circle></svg>`,
    activity: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><polyline points="22 12 18 12 15 21 9 3 6 12 2 12"></polyline></svg>`,
    clipboard: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><path d="M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2"></path><rect x="8" y="2" width="8" height="4" rx="1" ry="1"></rect></svg>`,
    rotateCCW: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><polyline points="1 4 1 10 7 10"></polyline><path d="M3.51 15a9 9 0 1 0 2.13-9.36L1 10"></path></svg>`,
    info: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><circle cx="12" cy="12" r="10"></circle><line x1="12" y1="16" x2="12" y2="12"></line><line x1="12" y1="8" x2="12.01" y2="8"></line></svg>`,
    xCircle: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><circle cx="12" cy="12" r="10"></circle><line x1="15" y1="9" x2="9" y2="15"></line><line x1="9" y1="9" x2="15" y2="15"></line></svg>`,
    plusCircle: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><circle cx="12" cy="12" r="10"></circle><line x1="12" y1="8" x2="12" y2="16"></line><line x1="8" y1="12" x2="16" y2="12"></line></svg>`,
    fileText: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z"></path><polyline points="14 2 14 8 20 8"></polyline><line x1="16" y1="13" x2="8" y2="13"></line><line x1="16" y1="17" x2="8" y2="17"></line><polyline points="10 9 9 9 8 9"></polyline></svg>`,
    plusCircle: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><circle cx="12" cy="12" r="10"></circle><line x1="12" y1="8" x2="12" y2="16"></line><line x1="8" y1="12" x2="16" y2="12"></line></svg>`,
    database: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><ellipse cx="12" cy="5" rx="9" ry="3"></ellipse><path d="M21 12c0 1.66-4 3-9 3s-9-1.34-9-3"></path><path d="M3 5v14c0 1.66 4 3 9 3s9-1.34 9-3V5"></path></svg>`,
    download: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4"></path><polyline points="7 10 12 15 17 10"></polyline><line x1="12" y1="15" x2="12" y2="3"></line></svg>`,
    upload: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4"></path><polyline points="17 8 12 3 7 8"></polyline><line x1="12" y1="3" x2="12" y2="15"></line></svg>`,
    mail: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><path d="M4 4h16c1.1 0 2 .9 2 2v12c0 1.1-.9 2-2 2H4c-1.1 0-2-.9-2-2V6c0-1.1.9-2 2-2z"></path><polyline points="22,6 12,13 2,6"></polyline></svg>`,
    helpCircle: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><circle cx="12" cy="12" r="10"></circle><path d="M9.09 9a3 3 0 0 1 5.83 1c0 2-3 3-3 3"></path><line x1="12" y1="17" x2="12.01" y2="17"></line></svg>`,
    lock: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><rect x="3" y="11" width="18" height="11" rx="2" ry="2"></rect><path d="M7 11V7a5 5 0 0 1 10 0v4"></path></svg>`,
    bookmark: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><path d="M19 21l-7-5-7 5V5a2 2 0 0 1 2-2h10a2 2 0 0 1 2 2z"></path></svg>`,
    help: `<svg xmlns="http://www.w3.org/2000/svg" width="15" height="15" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-activity"><path d="M9.09 9a3 3 0 0 1 5.83 1c0 2-3 3-3 3"></path><circle cx="12" cy="12" r="10"></circle><line x1="12" y1="17" x2="12" y2="17"></line></svg>`,
    clock: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><circle cx="12" cy="12" r="10"></circle><polyline points="12 6 12 12 16 14"></polyline></svg>`,
    messageSquare: `<svg viewBox="0 0 24 24" width="15" height="15" stroke="currentColor" stroke-width="2" fill="none" stroke-linecap="round" stroke-linejoin="round" class="css-i6dzq1"><path d="M21 15a2 2 0 0 1-2 2H7l-4 4V5a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2z"></path></svg>`
}
//#endregion feather icons
//#region constants action
const ACT_DM_COQUANQUANLY_SELECTLIST = "/DMCoQuanQuanLy/SelectCoQuanQuanLy";

const ACT_DM_CAPDETAI_SELECTLIST = "/DMCapDeTai/SelectCapDeTai";

const ACT_DM_HINHTHUCDETAI_SELECTLIST = "/DMHinhThucDeTai/SelectHinhThuc";

const ACT_DM_LOAIHINHNGHIENCUU_SELECTLIST = "/DMLoaiHinhNghienCuu/SelectLoaiHinh";

const ACT_DM_DONVIQUANLY_SELECTLIST = "/DMDonViQuanLy/SelectDonViQuanLy";

const ACT_DM_LINHVUCNGHIENCUU_SELECTLIST = "/DMLinhVucNghienCuu/SelectLinhVucNghienCuu";
const ACT_DM_LINHVUCNGHIENCUU_SAVE = "/DMLinhVucNghienCuu/Save";
const ACT_DM_LINHVUCNGHIENCUU_DELETE = "/DMLinhVucNghienCuu/Delete";
const ACT_DM_LINHVUCNGHIENCUU_LIST = "/DMLinhVucNghienCuu/ListLinhVucNghienCuu";
const ACT_DM_LINHVUCNGHIENCUU_PV = "/DMLinhVucNghienCuu/_LinhVucNghienCuu";
const ACT_DM_LINHVUCNGHIENCUU_FORM = "/DMLinhVucNghienCuu/_FormLinhVucNghienCuu";

const ACT_DM_VAITROBAIBAO_SELECTLIST = "/DMVaiTroBaiBao/SelectVaiTroBaiBao";
const ACT_DM_VAITROBAIBAO_SAVE = "/DMVaiTroBaiBao/Save";
const ACT_DM_VAITROBAIBAO_DELETE = "/DMVaiTroBaiBao/Delete";
const ACT_DM_VAITROBAIBAO_LIST = "/DMVaiTroBaiBao/ListVaiTroBaiBao";
const ACT_DM_VAITROBAIBAO_PV = "/DMVaiTroBaiBao/_VaiTroBaiBao";
const ACT_DM_VAITROBAIBAO_FORM = "/DMVaiTroBaiBao/_FormVaiTroBaiBao";

const ACT_DM_VAITRODETAI_SELECTLIST = "/DMVaiTroDeTai/SelectVaiTroDeTai";
const ACT_DM_VAITRODETAISV_SELECTLIST = "/DMVaiTroDeTaiSV/SelectVaiTroDeTai";

const ACT_DM_VAITROSACHTAILIEU_SELECTLIST = "/DMVaiTroSachTaiLieu/SelectVaiTro";

const ACT_DM_XEPLOAI_SELECTLIST = "/DMXepLoai/SelectXepLoai";

const ACT_DM_LOAISACH_SELECTLIST = "/DMLoaiSach/SelectLoaiSach";

const ACT_DM_LOAIBAIBAO_SELECTLIST = "/DMLoaiBaiBao/SelectLoaiBaiBao";

const ACT_DM_LOAISANPHAM_LIST = "/DMLoaiSanPham/ListLoaiSanPham";
const ACT_DM_LOAISANPHAM_LISTTINHGIO = "/DMLoaiSanPham/ListLoaiSanPhamTinhGio";
const ACT_DM_LOAISANPHAM_SELECTLIST = "/DMLoaiSanPham/SelectLoaiSanPham";
const ACT_DM_LOAISANPHAM_SELECTLISTTINHGIO = "/DMLoaiSanPham/SelectLoaiSanPhamTinhGio";
const ACT_DM_LOAISANPHAM_SAVE = "/DMLoaiSanPham/Save";

const ACT_DM_PHAMVI_SELECTLIST_KYYEU = "/DMPhamVi/SelectPhamViKyYeu";
const ACT_DM_PHAMVI_SELECTLIST_SEMINARKHOAHOC = "/DMPhamVi/SelectPhamViSeminarKH";

const ACT_DM_DIEMCONGTRINH_SELECTLIST = "/DMDiemCongTrinh/SelectDiemCongTrinh";

const ACT_DM_QUARTILE_SELECTLIST = "/DMQuartile/SelectQuartile";
const ACT_DM_QUARTILE_SAVE = "/DMQuartile/Save";
const ACT_DM_QUARTILE_DELETE = "/DMQuartile/Delete";
const ACT_DM_QUARTILE_LIST = "/DMQuartile/ListQuartile";
const ACT_DM_QUARTILE_PV = "/DMQuartile/_Quartile";
const ACT_DM_QUARTILE_FORM = "/DMQuartile/_FormQuartile";

const ACT_DM_CAPHOIDONGKHOAHOC_SELECTLIST = "/DMCapHoiDongKhoaHoc/SelectCapHoiDongKhoaHoc";
const ACT_DM_CAPHOIDONGKHOAHOC_SAVE = "/DMCapHoiDongKhoaHoc/Save";
const ACT_DM_CAPHOIDONGKHOAHOC_DELETE = "/DMCapHoiDongKhoaHoc/Delete";
const ACT_DM_CAPHOIDONGKHOAHOC_LIST = "/DMCapHoiDongKhoaHoc/ListCapHoiDongKhoaHoc";
const ACT_DM_CAPHOIDONGKHOAHOC_PV = "/DMCapHoiDongKhoaHoc/_CapHoiDongKhoaHoc";
const ACT_DM_CAPHOIDONGKHOAHOC_FORM = "/DMCapHoiDongKhoaHoc/_FormCapHoiDongKhoaHoc";

const ACT_DM_XEPHANGBAIBAO_SELECTLIST = "/DMXepHangBaiBao/SelectXepHangBaiBao";
const ACT_DM_XEPHANGBAIBAO_SAVE = "/DMXepHangBaiBao/Save";
const ACT_DM_XEPHANGBAIBAO_DELETE = "/DMXepHangBaiBao/Delete";
const ACT_DM_XEPHANGBAIBAO_LIST = "/DMXepHangBaiBao/ListXepHangBaiBao";
const ACT_DM_XEPHANGBAIBAO_PV = "/DMXepHangBaiBao/_XepHangBaiBao";
const ACT_DM_XEPHANGBAIBAO_FORM = "/DMXepHangBaiBao/_FormXepHangBaiBao";

const ACT_DM_LOAISOHUUTRITUE_SELECTLIST = "/DMLoaiSoHuuTriTue/SelectLoaiSoHuuTriTue";
const ACT_DM_LOAISOHUUTRITUE_SAVE = "/DMLoaiSoHuuTriTue/Save";
const ACT_DM_LOAISOHUUTRITUE_DELETE = "/DMLoaiSoHuuTriTue/Delete";
const ACT_DM_LOAISOHUUTRITUE_LIST = "/DMLoaiSoHuuTriTue/ListLoaiSoHuuTriTue";
const ACT_DM_LOAISOHUUTRITUE_PV = "/DMLoaiSoHuuTriTue/_LoaiSoHuuTriTue";
const ACT_DM_LOAISOHUUTRITUE_FORM = "/DMLoaiSoHuuTriTue/_FormLoaiSoHuuTriTue";

const ACT_DM_LOAIGIAITHUONG_SELECTLIST = "/DMLoaiGiaiThuong/SelectLoaiGiaiThuong";
const ACT_DM_LOAIGIAITHUONG_SAVE = "/DMLoaiGiaiThuong/Save";
const ACT_DM_LOAIGIAITHUONG_DELETE = "/DMLoaiGiaiThuong/Delete";
const ACT_DM_LOAIGIAITHUONG_LIST = "/DMLoaiGiaiThuong/ListLoaiGiaiThuong";
const ACT_DM_LOAIGIAITHUONG_PV = "/DMLoaiGiaiThuong/_LoaiGiaiThuong";
const ACT_DM_LOAIGIAITHUONG_FORM = "/DMLoaiGiaiThuong/_FormLoaiGiaiThuong";

const ACT_DM_TIEUCHISANGKIEN_SELECTLIST = "/DMTieuChiSangKien/SelectTieuChiSangKien";
const ACT_DM_TIEUCHISANGKIEN_SAVE = "/DMTieuChiSangKien/Save";
const ACT_DM_TIEUCHISANGKIEN_DELETE = "/DMTieuChiSangKien/Delete";
const ACT_DM_TIEUCHISANGKIEN_LIST = "/DMTieuChiSangKien/ListTieuChiSangKien";
const ACT_DM_TIEUCHISANGKIEN_PV = "/DMTieuChiSangKien/_TieuChiSangKien";
const ACT_DM_TIEUCHISANGKIEN_FORM = "/DMTieuChiSangKien/_FormTieuChiSangKien";

const ACT_DM_MUCDANHGIACANBO_SELECTLIST = "/DMMucDanhGiaCanBo/SelectMucDanhGiaCanBo";
const ACT_DM_MUCDANHGIACANBO_SAVE = "/DMMucDanhGiaCanBo/Save";
const ACT_DM_MUCDANHGIACANBO_DELETE = "/DMMucDanhGiaCanBo/Delete";
const ACT_DM_MUCDANHGIACANBO_LIST = "/DMMucDanhGiaCanBo/ListMucDanhGiaCanBo";
const ACT_DM_MUCDANHGIACANBO_PV = "/DMMucDanhGiaCanBo/_MucDanhGiaCanBo";
const ACT_DM_MUCDANHGIACANBO_FORM = "/DMMucDanhGiaCanBo/_FormMucDanhGiaCanBo";

const ACT_DM_MUCHOTROCHUCDANH_SELECTLIST = "/DMMucHoTroChucDanh/SelectMucHoTroChucDanh";
const ACT_DM_MUCHOTROCHUCDANH_SAVE = "/DMMucHoTroChucDanh/Save";
const ACT_DM_MUCHOTROCHUCDANH_DELETE = "/DMMucHoTroChucDanh/Delete";
const ACT_DM_MUCHOTROCHUCDANH_LIST = "/DMMucHoTroChucDanh/ListMucHoTroChucDanh";
const ACT_DM_MUCHOTROCHUCDANH_PV = "/DMMucHoTroChucDanh/_MucHoTroChucDanh";
const ACT_DM_MUCHOTROCHUCDANH_FORM = "/DMMucHoTroChucDanh/_FormMucHoTroChucDanh";

const ACT_DM_MUCHOTROBAIBAO_SELECTLIST = "/DMMucHoTroBaiBao/SelectMucHoTroBaiBao";
const ACT_DM_MUCHOTROBAIBAO_SAVE = "/DMMucHoTroBaiBao/Save";
const ACT_DM_MUCHOTROBAIBAO_DELETE = "/DMMucHoTroBaiBao/Delete";
const ACT_DM_MUCHOTROBAIBAO_LIST = "/DMMucHoTroBaiBao/ListMucHoTroBaiBao";
const ACT_DM_MUCHOTROBAIBAO_PV = "/DMMucHoTroBaiBao/_MucHoTroBaiBao";
const ACT_DM_MUCHOTROBAIBAO_FORM = "/DMMucHoTroBaiBao/_FormMucHoTroBaiBao";

const ACT_DM_CHUCDANH_SELECTLIST = "/DMChucDanh/SelectChucDanh";

const ACT_DM_NHOMGIAITHUONG_SELECTLIST = "/DMNhomGiaiThuong/SelectNhomGiaiThuong";

const ACT_DM_LOAIHOITHAO_SELECTLIST = "/DMLoaiHoiThao/SelectLoaiHoiThao";

const ACT_DM_ATTACHFILEGROUP_SELECTLIST = "/DMAttachFileGroup/SelectAttachFileGroup";

const ACT_DM_MUCKEKHAI_SELECTLIST = "/DMMucKeKhai/SelectMucKeKhai";

const ACT_DM_DIEMQUYDOIHDCD_SAVE = "/DMDiemQuyDoiHDCD/Save";
const ACT_DM_DIEMQUYDOIHDCD_DELETE = "/DMDiemQuyDoiHDCD/Delete";
const ACT_DM_DIEMQUYDOIHDCD_LIST = "/DMDiemQuyDoiHDCD/ListDiemQuyDoiHDCD";
const ACT_DM_DIEMQUYDOIHDCD_PV = "/DMDiemQuyDoiHDCD/_DiemQuyDoiHDCD";
const ACT_DM_DIEMQUYDOIHDCD_FORM = "/DMDiemQuyDoiHDCD/_FormDiemQuyDoiHDCD";

const ACT_QUYTRINH_SELECTLIST = "/QuyTrinh/SelectQuyTrinh";

const ACT_QUYTRINHDOITUONGBUOC_PV_THIETLAPBUOC = "/QuyTrinhDoiTuongBuoc/PvDsBuocThietLap";

const ACT_CANBO_SELECTLIST = "/CanBo/SelectCanBo";
const ACT_CANBO_LIST = "/CanBo/ListCanBo";

const ACT_LOP_SELECTLIST = "/Lop/SelectLop";

const ACT_KHOA_SELECTLIST = "/Khoa/SelectKhoa";

const ACT_ROLE_FORM = "/Role/_FormRole";
const ACT_ROLE_SELECTLIST = "/Role/SelectRole";
const ACT_ROLE_SAVE_USERROLE = "/Role/SaveUserRole";
const ACT_ROLE_UPDATEIMAGE = "/Role/UpdateImage";

const ACT_SINHVIEN_SELECTLIST = "/SinhVien/SelectSinhVien";

const ACT_BAIBAO_FORM = "/BaiBao/_FormBaiBao";
const ACT_BAIBAO_PV_QUOCTEPROFILE = "/BaiBao/_BaiBaoQuocTeProfile";
const ACT_BAIBAO_PV_TRONGNUOCPROFILE = "/BaiBao/_BaiBaoTrongNuocProfile";
const ACT_BAIBAO_INFO = "/BaiBao/_ChiTietBaiBao";
const ACT_BAIBAO_LISTBYLOAI = "/BaiBao/GetByLoaiBaiBao";

const ACT_BAOCAOHOINGHI_LIST = "/BaoCaoHoiNghi/GetAll";
const ACT_BAOCAOHOINGHI_FORM = "/BaoCaoHoiNghi/_FormBaoCaoHoiNghi";
const ACT_BAOCAOHOINGHI_INFO = "/BaoCaoHoiNghi/_ChiTietBaoCaoHoiNghi";
const ACT_BAOCAOHOINGHI_SAVE = "/BaoCaoHoiNghi/Save";
const ACT_BAOCAOHOINGHI_DELETE = "/BaoCaoHoiNghi/Delete";
const ACT_BAOCAOHOINGHI_PV = "/BaoCaoHoiNghi/_BaoCaoHoiNghi";

const ACT_SOHUUTRITUE_LIST = "/SoHuuTriTue/ListSoHuuTriTue";
const ACT_SOHUUTRITUE_FORM = "/SoHuuTriTue/_FormSoHuuTriTue";
const ACT_SOHUUTRITUE_INFO = "/SoHuuTriTue/_ChiTietSoHuuTriTue";
const ACT_SOHUUTRITUE_SAVE = "/SoHuuTriTue/Save";
const ACT_SOHUUTRITUE_DELETE = "/SoHuuTriTue/Delete";
const ACT_SOHUUTRITUE_PV = "/SoHuuTriTue/_SoHuuTriTue";

const ACT_HOIDONGKHOAHOC_LIST = "/HoiDongKhoaHoc/ListHoiDongKhoaHoc";
const ACT_HOIDONGKHOAHOC_FORM = "/HoiDongKhoaHoc/_FormHoiDongKhoaHoc";
const ACT_HOIDONGKHOAHOC_INFO = "/HoiDongKhoaHoc/_ChiTietHoiDongKhoaHoc";
const ACT_HOIDONGKHOAHOC_SAVE = "/HoiDongKhoaHoc/Save";
const ACT_HOIDONGKHOAHOC_DELETE = "/HoiDongKhoaHoc/Delete";
const ACT_HOIDONGKHOAHOC_PV = "/HoiDongKhoaHoc/_HoiDongKhoaHoc";

const ACT_SACHTAILIEU_FORM = "/SachTaiLieu/_FormSachTaiLieu";
const ACT_SACHTAILIEU_PV_PROFILE = "/SachTaiLieu/_SachTaiLieuProfile";
const ACT_SACHTAILIEU_INFO = "/SachTaiLieu/_ChiTietSachTaiLieu";
const ACT_SACHTAILIEU_LIST = "/SachTaiLieu/ListSachTaiLieu";
const ACT_SACHTAILIEU_CHECKDUPLICATE = "/SachTaiLieu/_CheckDuplicate";

const ACT_GIAITHUONG_LIST = "/GiaiThuong/ListGiaiThuong";
const ACT_GIAITHUONG_FORM = "/GiaiThuong/_FormGiaiThuong";
const ACT_GIAITHUONG_FORM_BYDETAI = "/GiaiThuong/_FormGiaiThuongByDeTai";
const ACT_GIAITHUONG_INFO = "/GiaiThuong/_ChiTietGiaiThuong";
const ACT_GIAITHUONG_SAVE = "/GiaiThuong/Save";
const ACT_GIAITHUONG_DELETE = "/GiaiThuong/Delete";
const ACT_GIAITHUONG_PV = "/GiaiThuong/_GiaiThuong";
const ACT_GIAITHUONG_PV_PROFILE = "/GiaiThuong/_GiaiThuongProfile";

const ACT_DEXUATDETAI_LIST = "/DeXuatDeTai/ListDeXuatDeTai";
const ACT_DEXUATDETAI_LISTDATHANG = "/DeXuatDeTai/ListDeTaiDatHang";
const ACT_DEXUATDETAI_FORM = "/DeXuatDeTai/_FormDeXuatDeTai";
const ACT_DEXUATDETAI_SAVE = "/DeXuatDeTai/Save";
const ACT_DEXUATDETAI_DELETE = "/DeXuatDeTai/Delete";
const ACT_DEXUATDETAI_UPDATESTATUS = "/DeXuatDeTai/UpdateStatus";
const ACT_DEXUATDETAI_UPDATEDATHANGSTATUS = "/DeXuatDeTai/UpdateDatHangStatus";
const ACT_DEXUATDETAI_ACCEPT = "/DeXuatDeTai/AcceptDeXuat";
const ACT_DEXUATDETAI_ACCEPTDATHANG = "/DeXuatDeTai/AcceptDatHang";

const ACT_HOIDONGDEXUATDETAI_FORM = "/HoiDongDeXuatDeTai/_FormHoiDongDeXuatDeTai";
const ACT_HOIDONGDEXUATDETAI_SAVE = "/HoiDongDeXuatDeTai/Save";

const ACT_HOIDONGTHUYETMINH_FORM = "/HoiDongThuyetMinh/_FormHoiDongThuyetMinh";
const ACT_HOIDONGTHUYETMINH_SAVE = "/HoiDongThuyetMinh/Save";

const ACT_HOIDONGDETAI_FORM = "/HoiDongDeTai/_FormHoiDongDeTai";
const ACT_HOIDONGDETAI_SAVE = "/HoiDongDeTai/Save";

const ACT_HOIDONG_FORM_SVHOIDONGDETAI = "/HoiDong/_FormSVHoiDongDeTai";
const ACT_HOIDONG_FORM_SVHOIDONGDANHGIA = "/HoiDong/_FormSVHoiDongDanhGia";
const ACT_HOIDONG_SAVE = "/HoiDong/Save";

const ACT_HOIDONGSANGKIEN_FORM = "/HoiDongSangKien/_FormHoiDongSangKien";
const ACT_HOIDONGSANGKIEN_SAVE = "/HoiDongSangKien/Save";

const ACT_THUYETMINH_LIST = "/ThuyetMinh/ListThuyetMinh";
const ACT_THUYETMINH_FORM = "/ThuyetMinh/_FormThuyetMinh";
const ACT_THUYETMINH_SAVE = "/ThuyetMinh/Save";
const ACT_THUYETMINH_DELETE = "/ThuyetMinh/Delete";
const ACT_THUYETMINH_UPDATESTATUS = "/ThuyetMinh/UpdateStatus";
const ACT_THUYETMINH_SELECTLIST = "/ThuyetMinh/SelectThuyetMinhByCanBo";
const ACT_THUYETMINH_GETBYID = "/ThuyetMinh/GetById";

const ACT_DETAI_LIST = "/DeTai/ListDeTai";
const ACT_DETAI_FORM = "/DeTai/_FormDeTai";
const ACT_DETAI_PV_DANGKYNGHIEMTHU = "/DeTai/_DangKyNghiemThu";
const ACT_DETAI_PV_PROFILE = "/DeTai/_DeTaiProfile";
const ACT_DETAI_INFO = "/DeTai/_ChiTietDeTai";
const ACT_DETAI_SAVE = "/DeTai/Save";
const ACT_DETAI_DELETE = "/DeTai/Delete";
const ACT_DETAI_UPDATESTATUS = "/DeTai/UpdateStatus";
const ACT_DETAI_SELECTLIST = "/DeTai/SelectDeTai";
const ACT_DETAI_CHECKDUPLICATE = "/DeTai/_CheckDuplicate";
const ACT_DETAI_DANGKYNGHIEMTHU = "/DeTai/DangKyNghiemThu";

const ACT_THANHVIENHOIDONG_LISTBYHOIDONG = "/ThanhVienHoiDong/ListByHoiDong";
const ACT_THANHVIENHOIDONG_SELECTNOTINHOIDONG = "/ThanhVienHoiDong/SelectNotInHoiDong";
const ACT_THANHVIENHOIDONG_SAVE = "/ThanhVienHoiDong/Save";
const ACT_THANHVIENHOIDONG_SAVEDANHGIA = "/ThanhVienHoiDong/SaveDanhGia";
const ACT_THANHVIENHOIDONG_PV_PHIEUCHAMDETAISV = "/ThanhVienHoiDong/_PhieuChamDeTaiSinhVien";

const ACT_GIONCKH_PHANBO = "/GioNCKH/_PhanBoThanhVien";
const ACT_GIONCKH_CONGTHUCTINH = "/GioNCKH/_CongThucTinh";
const ACT_GIONCKH_GETBYTHANHVIEN = "/GioNCKH/ListByThanhVien";
const ACT_GIONCKH_SAVEPHANBO = "/GioNCKH/SavePhanBo";
const ACT_GIONCKH_LIST = "/GioNCKH/ListGioNCKH";
const ACT_GIONCKH_LISTGIOGIANG = "/GioNCKH/ListGioGiang";
const ACT_GIONCKH_THONGTINGIONCKH = "/GioNCKH/_ThongTinGioNCKH";
const ACT_GIONCKH_UPDATESTATUSGIO = "/GioNCKH/UpdateTrangThaiTinhGio";
const ACT_GIONCKH_TINHGIO = "/GioNCKH/TinhGioNCKH";

const ACT_HOTROCHUCDANH_LIST = "/HoTroChucDanh/ListHoTroChucDanh";
const ACT_HOTROCHUCDANH_TINHHOTRO = "/HoTroChucDanh/TinhHoTroChucDanh";
const ACT_HOTROCHUCDANH_UPDATELOCK = "/HoTroChucDanh/UpdateLock";
const ACT_HOTROCHUCDANH_PV_HESOCONGTHEM = "/HoTroChucDanh/_HeSoCongThem";
const ACT_HOTROCHUCDANH_SAVE = "/HoTroChucDanh/Save";

const ACT_HOTROBAIBAO_LIST = "/HoTroBaiBao/ListHoTroBaiBao";
const ACT_HOTROBAIBAO_TINHHOTRO = "/HoTroBaiBao/TinhHoTroBaiBao";
const ACT_HOTROBAIBAO_UPDATELOCK = "/HoTroBaiBao/UpdateLock";
const ACT_HOTROBAIBAO_SAVE = "/HoTroBaiBao/Save";

const ACT_DIEMCONGTRINHKH_LISTBYCANBO = "/DiemCongTrinhKH/ListDiemCTKHByCanBo";
const ACT_DIEMCONGTRINHKH_INFO = "/DiemCongTrinhKH/_ThongTinDiemCongTrinhKH";
const ACT_DIEMCONGTRINHKH_TINHDIEM = "/DiemCongTrinhKH/TinhDiemCongTrinhKH";

const ACT_THANHVIENNCKH_INFO = "/ThanhVienNCKH/_ChiTietThanhVienNCKH";
const ACT_THANHVIENNCKH_USER = "/ThanhVienNCKH/LoginUser";

const ACT_QUYTRINHDOITUONG_FORM = "/QuyTrinhDoiTuong/PvFormQuyTrinhDoiTuong";
const ACT_QUYTRINHDOITUONG_FORMBYDOITUONG = "/QuyTrinhDoiTuong/PvFormByDoiTuong";
const ACT_QUYTRINHDOITUONG_CREATE = "/QuyTrinhDoiTuong/Create";
const ACT_QUYTRINHDOITUONG_UPDATE = "/QuyTrinhDoiTuong/Update";

const ACT_PHANBIEN_LISTBYSANPHAM = "/PhanBien/ListBySanPham";
const ACT_PHANBIEN_PV_DANHSACHPHANBIEN = "/PhanBien/_DanhSachPhanBien";
const ACT_PHANBIEN_PV_PHANBIEN = "/PhanBien/PvPhanBien";
const ACT_PHANBIEN_PV_FORMNHANXETTOMTAT = "/PhanBien/PvFormNhanXetTomTat";
const ACT_PHANBIEN_PV_FORMNHANXETTOANVAN = "/PhanBien/PvFormNhanXetToanVan";
const ACT_PHANBIEN_SAVE = "/PhanBien/Save";
const ACT_PHANBIEN_NHANXETTOMTAT = "/PhanBien/NhanXetTomTat";
const ACT_PHANBIEN_NHANXETTOANVAN = "/PhanBien/NhanXetToanVan";
const ACT_PHANBIEN_SENDEMAILTOPHANBIEN = "/PhanBien/SendEmailToPhanBien";
const ACT_PHANBIEN_DELETE = "/PhanBien/Delete";

const ACT_FILEMANAGE_DOWNLOAD = "/FileManage/DownloadFile";
const ACT_FILEMANAGE_VIEWLISTFILES = "/FileManage/_ViewListFiles";
const ACT_FILEMANAGE_VIEWPREVIEWFILE = "/FileManage/_PreviewFile";
const ACT_FILEMANAGE_PREVIEWFILE = "/FileManage/PreviewFile";
const ACT_FILEMANAGE_LIST = "/FileManage/ListAttachedFile";
const ACT_FILEMANAGE_LISTBYGROUPPRODUCT = "/FileManage/ListAttachedFileByGroupProduct";
const ACT_FILEMANAGE_UPLOADFILE = "/FileManage/UploadFile";
const ACT_FILEMANAGE_DELETE = "/FileManage/Delete";
const ACT_FILEMANAGE_FILEPATHDECODE = "/FileManage/FilePathDecode";

const ACT_REPORT_RPT_BAIBAO = "/Report/RptBaiBao";
const ACT_REPORT_EXP_BAIBAO = "/Report/ExpBaiBao";
const ACT_REPORT_RPT_BAOCAOHOINGHI = "/Report/RptBaoCaoHoiNghi";
const ACT_REPORT_EXP_BAOCAOHOINGHI = "/Report/ExpBaoCaoHoiNghi";
const ACT_REPORT_RPT_SACHTAILIEU = "/Report/RptSachTaiLieu";
const ACT_REPORT_EXP_SACHTAILIEU = "/Report/ExpSachTaiLieu";
const ACT_REPORT_RPT_DETAI = "/Report/RptDeTai";
const ACT_REPORT_EXP_DETAI = "/Report/ExpDeTai";
const ACT_REPORT_RPT_DETAISINHVIEN = "/Report/RptDeTaiSinhVien";
const ACT_REPORT_EXP_DETAISINHVIEN = "/Report/ExpDeTaiSinhVien";
const ACT_REPORT_RPT_GIAITHUONGCANBO = "/Report/RptGiaiThuongCanBo";
const ACT_REPORT_EXP_GIAITHUONGCANBO = "/Report/ExpGiaiThuongCanBo";
const ACT_REPORT_RPT_DEXUATDETAI = "/Report/RptDeXuatDeTai";
const ACT_REPORT_EXP_DEXUATDETAI = "/Report/ExpDeXuatDeTai";
const ACT_REPORT_RPT_DEXUATDETAISV = "/Report/RptDeXuatDeTaiSV";
const ACT_REPORT_EXP_DEXUATDETAISV = "/Report/ExpDeXuatDeTaiSV";
const ACT_REPORT_RPT_THUYETMINH = "/Report/RptThuyetMinh";
const ACT_REPORT_EXP_THUYETMINH = "/Report/ExpThuyetMinh";
const ACT_REPORT_RPT_TONGHOPNHIEMVUKHCN = "/Report/RptTongHopNhiemVuKHCN";
const ACT_REPORT_EXP_TONGHOPNHIEMVUKHCN = "/Report/ExpTongHopNhiemVuKHCN";
const ACT_REPORT_RPT_TONGHOPNHIEMVUKHCNQUYETTOAN = "/Report/RptTongHopNhiemVuKHCNQuyetToan";
const ACT_REPORT_EXP_TONGHOPNHIEMVUKHCNQUYETTOAN = "/Report/ExpTongHopNhiemVuKHCNQuyetToan";
const ACT_REPORT_RPT_TONGHOPNHIEMVUKHCNTAMUNG = "/Report/RptTongHopNhiemVuKHCNTamUng";
const ACT_REPORT_EXP_TONGHOPNHIEMVUKHCNTAMUNG = "/Report/ExpTongHopNhiemVuKHCNTamUng";
const ACT_REPORT_RPT_BAOCAOTIENDODETAI = "/Report/RptBaoCaoTienDoDeTai";
const ACT_REPORT_EXP_BAOCAOTIENDODETAI = "/Report/ExpBaoCaoTienDoDeTai";
const ACT_REPORT_RPT_GIONCKHCANHAN = "/Report/RptGioNCKHCaNhan";
const ACT_REPORT_EXP_GIONCKHCANHAN = "/Report/ExpGioNCKHCaNhan";
const ACT_REPORT_RPT_GIONCKHDONVI = "/Report/RptGioNCKHDonVi";
const ACT_REPORT_EXP_GIONCKHDONVI = "/Report/ExpGioNCKHDonVi";
const ACT_REPORT_RPT_SOHUUTRITUE = "/Report/RptSoHuuTriTue";
const ACT_REPORT_EXP_SOHUUTRITUE = "/Report/ExpSoHuuTriTue";
const ACT_REPORT_EXP_DANGKYSANGKIENCOSODONVI = "/Report/ExpDangKySangKienCoSoDonVi";

const ACT_LYLICH_QUATRINHHOATDONG = "/LyLichKhoaHoc/_QuaTrinhHoatDong";
const ACT_LYLICH_THONGTINCANHAN = "/LyLichKhoaHoc/_ThongTinCaNhan";
const ACT_LYLICH_SANPHAMNCKH = "/LyLichKhoaHoc/_SanPhamNCKH";
const ACT_LYLICH_SCIENCEPROFILE = "/LyLichKhoaHoc/ScienceProfile";
const ACT_LYLICH_NAFOSTED_EXPORT = "/LyLichKhoaHoc/ExportLyLichNafosted";
const ACT_LYLICH_VIN_EXPORT = "/LyLichKhoaHoc/ExportLyLichVIN";
const ACT_LYLICH_EXPORT = "/LyLichKhoaHoc/ExportLyLich";

const ACT_QUATRINHCONGTAC_PV = "/QuaTrinhCongTac/_QuaTrinhCongTac";
const ACT_QUATRINHCONGTAC_PV_PROFILE = "/QuaTrinhCongTac/_QuaTrinhCongTacProfile";
const ACT_QUATRINHCONGTAC_LISTBYCANBO = "/QuaTrinhCongTac/ListByCanBo";

const ACT_QUATRINHDAOTAO_PV = "/QuaTrinhDaoTao/_QuaTrinhDaoTao";
const ACT_QUATRINHDAOTAO_PV_PROFILE = "/QuaTrinhDaoTao/_QuaTrinhDaoTaoProfile";
const ACT_QUATRINHDAOTAO_LISTBYCANBO = "/QuaTrinhDaoTao/ListByCanBo";

const ACT_TRINHDONGOAINGU_PV = "/TrinhDoNgoaiNgu/_TrinhDoNgoaiNgu";
const ACT_TRINHDONGOAINGU_PV_PROFILE = "/TrinhDoNgoaiNgu/_TrinhDoNgoaiNguProfile";
const ACT_TRINHDONGOAINGU_LISTBYCANBO = "/TrinhDoNgoaiNgu/ListByCanBo";

const ACT_SV_DEXUATDETAI_LIST = "/SVDeXuatDeTai/ListDeXuatDeTai";
const ACT_SV_DEXUATDETAI_FORM = "/SVDeXuatDeTai/_FormDeXuatDeTai";
const ACT_SV_DEXUATDETAI_SAVE = "/SVDeXuatDeTai/Save";
const ACT_SV_DEXUATDETAI_DELETE = "/SVDeXuatDeTai/Delete";
const ACT_SV_DEXUATDETAI_UPDATESTATUS = "/SVDeXuatDeTai/UpdateStatus";
const ACT_SV_DEXUATDETAI_ACCEPT = "/SVDeXuatDeTai/AcceptDeXuat";

const ACT_SV_THUYETMINH_LIST = "/SVThuyetMinh/ListThuyetMinh";
const ACT_SV_THUYETMINH_FORM = "/SVThuyetMinh/_FormThuyetMinh";
const ACT_SV_THUYETMINH_SAVE = "/SVThuyetMinh/Save";
const ACT_SV_THUYETMINH_DELETE = "/SVThuyetMinh/Delete";
const ACT_SV_THUYETMINH_UPDATESTATUS = "/SVThuyetMinh/UpdateStatus";
const ACT_SV_THUYETMINH_GETBYID = "/SVThuyetMinh/GetById";

const ACT_SV_DETAI_LIST = "/SVDeTai/ListDeTai";
const ACT_SV_DETAI_LISTCHUYENCAP = "/SVDeTai/ListDeTaiChuyenCap";
const ACT_SV_DETAI_FORM = "/SVDeTai/_FormDeTai";
const ACT_SV_DETAI_SAVE = "/SVDeTai/Save";
const ACT_SV_DETAI_DELETE = "/SVDeTai/Delete";
const ACT_SV_DETAI_UPDATESTATUS = "/SVDeTai/UpdateStatus";
const ACT_SV_DETAI_UPDATECAPDETAI = "/SVDeTai/UpdateCapDeTai";

const ACT_SV_HOIDONGDEXUATDETAI_FORM = "/SVHoiDongDeXuatDeTai/_FormHoiDongDeXuatDeTai";
const ACT_SV_HOIDONGDEXUATDETAI_SAVE = "/SVHoiDongDeXuatDeTai/Save";

const ACT_SV_HOIDONGTHUYETMINH_FORM = "/SVHoiDongThuyetMinh/_FormHoiDongThuyetMinh";
const ACT_SV_HOIDONGTHUYETMINH_SAVE = "/SVHoiDongThuyetMinh/Save";

const ACT_SV_HOIDONGDETAI_FORM = "/SVHoiDongDeTai/_FormHoiDongDeTai";
const ACT_SV_HOIDONGDETAI_SAVE = "/SVHoiDongDeTai/Save";

const ACT_SANPHAMDETAI_FORM = "/SanPhamDeTai/_FormSanPhamDeTai";
const ACT_SANPHAMDETAI_SAVE = "/SanPhamDeTai/Save";

const ACT_BAOCAOTIENDO_FORM = "/BaoCaoTienDo/_FormBaoCaoTienDo";
const ACT_BAOCAOTIENDO_INFO = "/BaoCaoTienDo/_ThongTinBaoCaoTienDo";
const ACT_BAOCAOTIENDO_SAVE = "/BaoCaoTienDo/Save";
const ACT_BAOCAOTIENDO_DELETE = "/BaoCaoTienDo/Delete";
const ACT_BAOCAOTIENDO_LISTBYDETAI = "/BaoCaoTienDo/ListBaoCaoTienDo";

const ACT_KINHPHIDETAI_FORM = "/KinhPhiDeTai/_FormKinhPhiDeTai";
const ACT_KINHPHIDETAI_INFO = "/KinhPhiDeTai/_ThongTinKinhPhiDeTaiChiTiet";
const ACT_KINHPHIDETAI_SAVE = "/KinhPhiDeTai/Save";
const ACT_KINHPHIDETAI_DELETE = "/KinhPhiDeTai/Delete";
const ACT_KINHPHIDETAI_LISTBYDETAI = "/KinhPhiDeTai/ListKinhPhiDeTai";
const ACT_KINHPHIDETAICHITIET_LISTBYDETAI = "/KinhPhiDeTai/ListKinhPhiChiTietByDeTai";
const ACT_KINHPHIDETAICHITIET_LIST = "/KinhPhiDeTai/ListKinhPhiDeTaiChiTiet";

const ACT_DIEUCHINHDETAI_FORM = "/DieuChinhDeTai/_FormDieuChinhDeTai";
const ACT_DIEUCHINHDETAI_INFO = "/DieuChinhDeTai/_ThongTinDieuChinhDeTai";
const ACT_DIEUCHINHDETAI_SAVE = "/DieuChinhDeTai/Save";
const ACT_DIEUCHINHDETAI_DELETE = "/DieuChinhDeTai/Delete";
const ACT_DIEUCHINHDETAI_LISTBYDETAI = "/DieuChinhDeTai/ListDieuChinhDeTai";

const ACT_SVDIEUCHINHDETAI_FORM = "/SVDieuChinhDeTai/_FormSVDieuChinhDeTai";
const ACT_SVDIEUCHINHDETAI_INFO = "/SVDieuChinhDeTai/_ThongTinSVDieuChinhDeTai";
const ACT_SVDIEUCHINHDETAI_SAVE = "/SVDieuChinhDeTai/Save";
const ACT_SVDIEUCHINHDETAI_DELETE = "/SVDieuChinhDeTai/Delete";
const ACT_SVDIEUCHINHDETAI_LISTBYDETAI = "/SVDieuChinhDeTai/ListSVDieuChinhDeTai";

const ACT_SANGKIENCOSO_FORM = "/SangKienCoSo/_FormSangKienCoSo";
const ACT_SANGKIENCOSO_SAVE = "/SangKienCoSo/Save";
const ACT_SANGKIENCOSO_DELETE = "/SangKienCoSo/Delete";
const ACT_SANGKIENCOSO_LIST = "/SangKienCoSo/ListSangKienCoSo";
const ACT_SANGKIENCOSO_UPDATESTATUS = "/SangKienCoSo/UpdateStatus";
const ACT_SANGKIENCOSO_NOP = "/SangKienCoSo/NopSangKien";

const ACT_BAOLUUGIAHANDETAI_FORM = "/BaoLuuGiaHanDeTai/PVChiTiet";
const ACT_BAOLUUGIAHANDETAI_SAVE = "/BaoLuuGiaHanDeTai/Save";
const ACT_BAOLUUGIAHANDETAI_DELETE = "/BaoLuuGiaHanDeTai/Delete";
const ACT_BAOLUUGIAHANDETAI_LIST = "/BaoLuuGiaHanDeTai/DanhSach";
const ACT_BAOLUUGIAHANDETAI_UPDATESTATUS = "/BaoLuuGiaHanDeTai/UpdateStatus";

const ACT_THAMGIAHOITHAO_FORM = "/ThamGiaHoiThao/_FormDangKy";
const ACT_THAMGIAHOITHAO_FORMHOANTHIENTOANVAN = "/ThamGiaHoiThao/PvFormHoanThienToanVan";
const ACT_THAMGIAHOITHAO_FORMHOANTHIENHOSO = "/ThamGiaHoiThao/PvFormHoanThienHoSo";
const ACT_THAMGIAHOITHAO_SAVE = "/ThamGiaHoiThao/Save";
const ACT_THAMGIAHOITHAO_SAVEFILEHOANTHIEN = "/ThamGiaHoiThao/SaveFileHoanThien";
const ACT_THAMGIAHOITHAO_DELETE = "/ThamGiaHoiThao/Delete";
const ACT_THAMGIAHOITHAO_LIST = "/ThamGiaHoiThao/ListThamGiaHoiThao";
const ACT_THAMGIAHOITHAO_LISTBYEMAIL = "/ThamGiaHoiThao/ListThamGiaHoiThaoByEmail";
const ACT_THAMGIAHOITHAO_LISTBYEMAILPHANBIEN = "/ThamGiaHoiThao/ListThamGiaHoiThaoByEmailPhanBien";
const ACT_THAMGIAHOITHAO_LISTPHANBIENTOMTAT = "/ThamGiaHoiThao/ListPhanBienTomTat";
const ACT_THAMGIAHOITHAO_LISTPHANBIENTOANVAN = "/ThamGiaHoiThao/ListPhanBienToanVan";
const ACT_THAMGIAHOITHAO_LISTHOANTHIENTOANVAN = "/ThamGiaHoiThao/ListHoanThienToanVan";
const ACT_THAMGIAHOITHAO_LISTHOANTHIENHOSO = "/ThamGiaHoiThao/ListHoanThienHoSo";
const ACT_THAMGIAHOITHAO_UPDATESTATUS = "/ThamGiaHoiThao/UpdateStatus";
const ACT_THAMGIAHOITHAO_UPDATESTEP = "/ThamGiaHoiThao/UpdateStep";
const ACT_THAMGIAHOITHAO_NEXTSTEP = "/ThamGiaHoiThao/NextStep";
const ACT_THAMGIAHOITHAO_PREVIOUSSTEP = "/ThamGiaHoiThao/PreviousStep";
const ACT_THAMGIAHOITHAO_SENDHOANTHIENTOANVAN = "/ThamGiaHoiThao/SendHoanThienToanVan";
const ACT_THAMGIAHOITHAO_SENDKEHOACHHOITHAO = "/ThamGiaHoiThao/SendKeHoachHoiThao";

const ACT_XUATBANKYYEU_FORM = "/XuatBanKyYeu/_FormXuatBanKyYeu";
const ACT_XUATBANKYYEU_SAVE = "/XuatBanKyYeu/Save";
const ACT_XUATBANKYYEU_DELETE = "/XuatBanKyYeu/Delete";
const ACT_XUATBANKYYEU_LIST = "/XuatBanKyYeu/ListXuatBanKyYeu";
const ACT_XUATBANKYYEU_UPDATESTATUS = "/XuatBanKyYeu/UpdateStatus";

const ACT_HOITHAO_FORM = "/HoiThao/_FormHoiThao";
const ACT_HOITHAO_SAVE = "/HoiThao/Save";
const ACT_HOITHAO_DELETE = "/HoiThao/Delete";
const ACT_HOITHAO_LIST = "/HoiThao/ListHoiThao";
const ACT_HOITHAO_SELECTLIST = "/HoiThao/SelectHoiThao";
const ACT_HOITHAO_UPDATESTATUS = "/HoiThao/UpdateStatus";
const ACT_HOITHAO_UPDATEVIEW = "/HoiThao/UpdateView";
const ACT_HOITHAO_PHONGQLKHDUYET = "/HoiThao/UpdateView";
const ACT_HOITHAO_PV_DANHSACHPORTAL = "/HoiThao/_DanhSachHoiThaoPortal";

const ACT_DICHVUHOITHAO_SELECTLIST = "/DichVuHoiThao/SelectDichVuHoiThao";
const ACT_DICHVUHOITHAO_SAVE = "/DichVuHoiThao/Save";
const ACT_DICHVUHOITHAO_DELETE = "/DichVuHoiThao/Delete";
const ACT_DICHVUHOITHAO_LIST = "/DichVuHoiThao/ListDichVuHoiThao";
const ACT_DICHVUHOITHAO_PV = "/DichVuHoiThao/_DichVuHoiThao";
const ACT_DICHVUHOITHAO_FORM = "/DichVuHoiThao/_FormDichVuHoiThao";

const ACT_HOPDONGCHUYENGIAO_FORM = "/HopDongChuyenGiao/_FormHopDongChuyenGiao";
const ACT_HOPDONGCHUYENGIAO_SAVE = "/HopDongChuyenGiao/Save";
const ACT_HOPDONGCHUYENGIAO_DELETE = "/HopDongChuyenGiao/Delete";
const ACT_HOPDONGCHUYENGIAO_LIST = "/HopDongChuyenGiao/ListHopDongChuyenGiao";

const ACT_DOTKEKHAI_FORM = "/DotKeKhai/_FormDotKeKhai";
const ACT_DOTKEKHAI_SAVE = "/DotKeKhai/Save";
const ACT_DOTKEKHAI_DELETE = "/DotKeKhai/Delete";
const ACT_DOTKEKHAI_LIST = "/DotKeKhai/ListDotKeKhai";
const ACT_DOTKEKHAI_UPDATEACTIVE = "/DotKeKhai/UpdateActive";
const ACT_DOTKEKHAI_CHECKDOTKEKHAI = "/DotKeKhai/CheckDotKeKhai";

const ACT_SEMINARKHOAHOC_PV_FORM = "/SeminarKhoaHoc/PvFormSeminarKhoaHoc";
const ACT_SEMINARKHOAHOC_PV_INFO = "/SeminarKhoaHoc/PvChiTietSeminarKhoaHoc";
const ACT_SEMINARKHOAHOC_PV = "/SeminarKhoaHoc/PvSeminarKhoaHoc";
const ACT_SEMINARKHOAHOC_CREATE = "/SeminarKhoaHoc/Create";
const ACT_SEMINARKHOAHOC_UPDATE = "/SeminarKhoaHoc/Update";
const ACT_SEMINARKHOAHOC_DELETE = "/SeminarKhoaHoc/Delete";
const ACT_SEMINARKHOAHOC_CONFIRMINFO = "/SeminarKhoaHoc/ConfirmInfo";
const ACT_SEMINARKHOAHOC_LIST = "/SeminarKhoaHoc/ListSeminarKhoaHoc";

const ACT_TIEUCHITINHGIO_PV_BYLOAISP = "/TieuChiTinhGio/_TieuChiTinhGio";
const ACT_TIEUCHITINHGIO_PV_CACHTINHGIO = "/TieuChiTinhGio/_CachTinhGio";
const ACT_TIEUCHITINHGIO_FORM = "/TieuChiTinhGio/_FormTieuChiTinhGio";
const ACT_TIEUCHITINHGIO_SAVE = "/TieuChiTinhGio/Save";
const ACT_TIEUCHITINHGIO_DELETE = "/TieuChiTinhGio/Delete";
const ACT_TIEUCHITINHGIO_LIST = "/TieuChiTinhGio/ListTieuChiTinhGio";
const ACT_TIEUCHITINHGIO_PV_DSTIEUCHI = "/TieuChiTinhGio/_DanhSachTieuChiTinhGio";

const ACT_THANHQUYETTOAN_PV_GIAYTO = "/ThanhQuyetToan/_GiayToNop";
const ACT_THANHQUYETTOAN_UPDATESTEP = "/ThanhQuyetToan/UpdateStep";
const ACT_THANHQUYETTOAN_UPDATESTEPSTATUS = "/ThanhQuyetToan/UpdateStepStatus";
const ACT_THANHQUYETTOAN_FORM = "/ThanhQuyetToan/_FormThanhQuyetToan";
const ACT_THANHQUYETTOAN_PV = "/ThanhQuyetToan/_ChiTietThanhQuyetToan";
const ACT_THANHQUYETTOAN_SAVE = "/ThanhQuyetToan/Save";
const ACT_THANHQUYETTOAN_DELETE = "/ThanhQuyetToan/Delete";
const ACT_THANHQUYETTOAN_LIST = "/ThanhQuyetToan/ListThanhQuyetToan";
const ACT_THANHQUYETTOAN_LISTBYKINHPHI = "/ThanhQuyetToan/ListThanhQuyetToanByKinhPhi";

const ACT_DANGKYTHUCHIEN_FORM = "/DangKyThucHien/_FormDangKyThucHien";
const ACT_DANGKYTHUCHIEN_SAVE = "/DangKyThucHien/Save";
const ACT_DANGKYTHUCHIEN_DELETE = "/DangKyThucHien/Delete";
const ACT_DANGKYTHUCHIEN_UPDATESTATUS = "/DangKyThucHien/UpdateStatus";
const ACT_DANGKYTHUCHIEN_LIST = "/DangKyThucHien/ListDangKyThucHien";
const ACT_DANGKYTHUCHIEN_LISTDETAIDANGKY = "/DangKyThucHien/ListDeTaiDangKy";
const ACT_DANGKYTHUCHIEN_LISTDETAICHUADANGKY = "/DangKyThucHien/ListDeTaiChuaDangKy";
const ACT_DANGKYTHUCHIEN_PV = "/DangKyThucHien/_DangKyThucHien";
const ACT_DANGKYTHUCHIEN_PV_DETAICHUADANGKY = "/DangKyThucHien/_DanhSachDeTaiChuaDangKy";

const ACT_CONGTHUCTINHGIO_PV_DSCONGTHUC = "/CongThucTinhGio/_DanhSachCongThucTinhGio";
const ACT_CONGTHUCTINHGIO_FORM = "/CongThucTinhGio/_FormCongThucTinhGio";
const ACT_CONGTHUCTINHGIO_SAVE = "/CongThucTinhGio/Save";
const ACT_CONGTHUCTINHGIO_LIST_BYNHOMSP = "/CongThucTinhGio/ListCongThucByNhomSP";
const ACT_CONGTHUCTINHGIO_DELETE = "/CongThucTinhGio/Delete";

const ACT_SYSTEMLOG_LIST = "/SystemLog/ListSystemLog";
const ACT_SYSTEMLOG_INFO = "/SystemLog/_LogInfo";
//#endregion constants action

//#region constants page
const PAGE_LYLICHKHOAHOC = "/ly-lich-khoa-hoc";
//#endregion constants page

//#region constants key select list
const OPT_DM_VAITRO = "OPT_DM_VAITRO";
const OPT_DM_VAITROTHANHVIEN = "OPT_DM_VAITROTHANHVIEN";
const OPT_DM_VAITROBAIBAO = "OPT_DM_VAITROBAIBAO";
const OPT_DM_VAITRODETAI = "OPT_DM_VAITROBAIBAO";
const OPT_DM_LINHVUCNGHIENCUU = "OPT_DM_LINHVUCNGHIENCUU";
const OPT_DM_DONVIQUANLY = "OPT_DM_DONVIQUANLY";
const OPT_DM_COQUANQUANLY = "OPT_DM_COQUANQUANLY";
const OPT_DM_CAPQUANLY = "OPT_DM_CAPQUANLY";
const OPT_DM_HINHTHUCDETAI = "OPT_DM_HINHTHUCDETAI";
const OPT_DM_LOAIHINHNGHIENCUU = "OPT_DM_LOAIHINHNGHIENCUU";
const OPT_DM_XEPLOAI = "OPT_DM_XEPLOAI";
const OPT_DM_LOAISACH = "OPT_DM_LOAISACH";
const OPT_DM_THUYETMINH = "OPT_DM_THUYETMINH";
const OPT_DM_LOAISANPHAM = "OPT_DM_LOAISANPHAM";
const OPT_DM_LOAISANPHAMTINHGIO = "OPT_DM_LOAISANPHAMTINHGIO";
const OPT_DM_VAITROSACHTAILIEU = "OPT_DM_VAITROSACHTAILIEU";
const OPT_DM_QUARTILE = "OPT_DM_QUARTILE";
const OPT_DM_LOAIBAIBAO = "OPT_DM_LOAIBAIBAO";
const OPT_DM_XEPHANGBAIBAO = "OPT_DM_XEPHANGBAIBAO";
const OPT_DM_DETAI = "OPT_DM_DETAI";
const OPT_DM_LOAISOHUUTRITUE = "OPT_DM_LOAISOHUUTRITUE";
const OPT_DM_LOAIGIAITHUONG = "OPT_DM_LOAIGIAITHUONG";
const OPT_DM_PHUONGTHUCQUYDOI = "OPT_DM_PHUONGTHUCQUYDOI";
const OPT_DM_TIEUCHISANGKIEN = "OPT_DM_TIEUCHISANGKIEN";
const OPT_DM_MUCDANHGIACANBO = "OPT_DM_MUCDANHGIACANBO";
const OPT_DM_CHUCDANH = "OPT_DM_CHUCDANH";
const OPT_DM_NHOMGIAITHUONG = "OPT_DM_NHOMGIAITHUONG";
const OPT_DM_LOAIHOITHAO = "OPT_DM_LOAIHOITHAO";
const OPT_DM_PHAMVI = "OPT_DM_PHAMVI";
const OPT_DM_ATTACHFILEGROUP = "OPT_DM_ATTACHFILEGROUP";
const OPT_DM_CAPHOIDONGKHOAHOC = "OPT_DM_CAPHOIDONGKHOAHOC";
const OPT_DM_DIEMCONGTRINH = "OPT_DM_DIEMCONGTRINH";
const OPT_DM_MUCKEKHAI = "OPT_DM_MUCKEKHAI";
const OPT_DM_VAITRODETAISV = "OPT_DM_VAITRODETAISV";
//#endregion constants key select list

//#region constants key obj
const OBJ_SANPHAM = "OBJ_SANPHAM";
const OBJ_FILEUPLOADED = "OBJ_FILEUPLOADED";
//#endregion constants key obj

//#region constants status code
const STATUS_PROGRESS = 0;
const STATUS_ACCEPT = 1;
const STATUS_DENY = 2;
const STATUS_ACCEPT_KHOA = 3;
const STATUS_ACCEPT_PKHCN = 4;
const STATUS_ACCEPT_BGH = 5;
const STATUS_DELETED = 9;
const statusConst = {
    inProgress: 0,
    accept: 1,
    deny: 2,
    cancel: 3,
    editRequest: 4,
    draft: 9
}
//#endregion constants status code

//#region constants loai hoi dong
const HD_THAMDINHNOIDUNG = 1;
const HD_THAMDINHKINHPHI = 2;
const HD_NGHIEMTHUCOSO = 3;
const HD_NGHIEMTHUQUANLY = 4;
const HD_DANHGIADETAISVCACCAP = 5;
const HD_DANHGIADETAISVCHUYENCAP = 6;
//#endregion constants loai hoi dong

//#region constants loai san pham
const SP_BAIBAO = 1;
const SP_HOINGHIHOITHAO = 2;
const SP_SACHTAILIEU = 3;
const SP_HOSOTHAU = 4;
const SP_DETAI = 5;
const SP_HUONGDANSINHVIEN = 6;
const SP_GIAITHUONG = 7;
const SP_SOHUUTRITUE = 9;
const SP_DETAISINHVIEN = 12;
const SP_SANGKIENCOSO = 13;
const SP_THAMGIAHOITHAO = 14;
const SP_THUYETMINHSINHVIEN = 15;
//#endregion constants loai san pham

//#region constants loai chi phi
const LCP_CONGLAODONG = 1;
const LCP_CONGTAC = 2;
const LCP_DICHVUNGOAI = 3;
const LCP_GIANTIEP = 4;
const LCP_NGUYENVATLIEU = 5;
//#endregion constants loai chi phi

//#region constants loai file
const AF_BAIBAO = 1;
const AF_BAOCAOHOINGHI = 2;
const AF_SACHTAILIEU = 3;
const AF_DETAI = 4;
const AF_DETAISINHVIEN = 5;
const AF_GIAITHUONG = 6;
const AF_SOHUUTRITUE = 7;
const AF_QUATRINHTHANHTOAN = 9;
const AF_DEXUATDETAI = 10;
const AF_THUYETMINH = 11;
const AF_DEXUATDETAISINHVIEN = 12;
const AF_THUYETMINHSINHVIEN = 13;
const AF_HOIDONGDETAI = 14;
const AF_HOIDONGDEXUATDETAI = 15;
const AF_HOIDONGTHUYETMINH = 16;
const AF_HOIDONGDETAISINHVIEN = 17;
const AF_HOIDONGDEXUATDETAISINHVIEN = 18;
const AF_HOIDONGTHUYETMINHSINHVIEN = 19;
const AF_BAOCAOTIENDONHIEMVUKHCN = 20;
const AF_HOITHAO = 21;
const AF_HOPDONGCHUYENGIAO = 22;
const AF_HOSOTHANHTOAN = 23;
const AF_DANGKYTHUCHIEN = 24;
const AF_DANGKYNGHIEMTHUDETAI = 25;
const AF_SANPHAM = 26;
const AF_HOIDONGSANGKIEN = 27;
const AF_YEUCAUCHINHSUA = 28;
const AF_THAMGIAHOITHAO = 29;
const AF_PHANBIEN = 30;
const AF_XUATBANKYYEU = 31;
const AF_SEMINARKHOAHOC = 32;
const moduleConst = {
    baiBao: "BaiBao",
    baoCaoHoiNghi: "BaoCaoHoiNghi",
    hoiThaoThamGia: "HoiThaoThamGia",
    seminarKhoaHoc: "SeminarKhoaHoc",
    sangKienCoSo: "SangKienCoSo",
    soHuuTriTue: "SoHuuTriTue",
    sachTaiLieu: "SachTaiLieu",
    hoiDong: "HoiDong",
    hoiDongDoiTuong: "HoiDongDoiTuong",
    thanhVienHoiDong: "ThanhVienHoiDong",
    hopDongChuyenGiao: "HopDongChuyenGiao",
    deXuatDeTai: "DeXuatDeTai",
    thuyetMinhDeTai: "ThuyetMinhDeTai",
    deTai: "DeTai"
}
const phamViConst = {
    trongNuoc: "TRONGNUOC",
    quocTe: "QUOCTE"
}
//#endregion constants loai file

//#region constants muc ke khai
const MKK_BAIBAO = 1;
const MKK_BAOCAOHOINGHI = 2;
const MKK_SACH = 3;
const MKK_DETAI = 4;
const MKK_GIAITHUONG = 5;
const MKK_SOHUUTRITUE = 6;
const MKK_DEXUATDETAI = 7;
const MKK_THUYETMINH = 8;
const MKK_DEXUATDETAISINHVIEN = 9;
const MKK_THUYETMINHSINHVIEN = 10;
const MKK_DETAISINHVIEN = 11;
const MKK_SANGKIEN = 12;
const MKK_HOIDONGSOKHAOKHOASV = 13;
const MKK_HOIDONGTRUNGKHAOTRUONGSV = 14;
//#endregion constants muc ke khai

//#region constants quy trinh
const QT_HOINGHIHOITHAO = '10e17f15-a2f3-ed11-8bdb-005056b65f85';
//#endregion constants quy trinh

//#region constants quy trinh buoc
const QT_HNHT_DKTG = 'fed80b4a-caf4-ed11-8bdb-005056b65f85';
const QT_HNHT_PBTT1 = "3e6f609a-cbf4-ed11-8bdb-005056b65f85";
const QT_HNHT_PBTT2 = "435f91b1-2bf5-ed11-8bdb-005056b65f85";
const QT_HNHT_PBTV1 = "2f61195d-6cf5-ed11-8bdb-005056b65f85";
const QT_HNHT_PBTV2 = "3061195d-6cf5-ed11-8bdb-005056b65f85";
const QT_HNHT_TGHTTV = "81833e95-f9f5-ed11-8bdb-005056b65f85";
const QT_HNHT_TGHTHS = "ce4ec6a5-f9f5-ed11-8bdb-005056b65f85";
//#endregion constants quy trinh buoc

//roles
const roleConst = {
    quanTri: 1,
    giangVien: 2,
    donVi: 3,
    pKHCN: 4,
    banGiamHieu: 5
}

//loại hội đồng
const loaiHoiDongConst = {
    hdSangKien: "HDSANGKIEN"
}

//bước hội thảo tham gia
const buocHoiThaoThamGiaConst = {
    khoaDuyet: "bcht_khoaduyet",
    pQLKHDuyet: "bcht_pqlkhduyet",
    pTCHCDuyet: "bcht_ptchcduyet",
    hoanThanh: "bcht_hoanthanh",
}

//bước seminar
const buocSeminarConst = {
    khoaBmDuyet: "seminar_khoabmduyet",
    pQLKHDuyet: "seminar_pqlkhduyet",
    hoanThienHoSo: "seminar_hoanthienhoso",
}