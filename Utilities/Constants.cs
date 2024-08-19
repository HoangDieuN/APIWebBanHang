using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Constants
    {
        #region Messages
        public static string MSG_ERR_INFO_NOT_FOUND = "Không tìm thấy thông tin";
        public static string MSG_ERR_SAVE_SUCCESS = "Lưu thông tin thành công";
        public static string MSG_ERR_SAVE_FAILED = "Lưu thông tin thất bại";
        public static string MSG_ERR_CREATE_SUCCESS = "Thêm mới thành công";
        public static string MSG_ERR_CREATE_FAILED = "Thêm mới thất bại";
        public static string MSG_ERR_UPDATE_SUCCESS = "Cập nhật thành công";
        public static string MSG_ERR_UPDATE_FAILED = "Cập nhật thất bại";
        public static string MSG_ERR_DELETE_SUCCESS = "Xóa thành công";
        public static string MSG_ERR_DELETE_FAILED = "Xóa thất bại";

        public static string MSG_LOGIN_SUCCESS = "Đăng nhập thành công";
        public static string MSG_LOGIN_FAILED = "Tài khoản hoặc mật khẩu đăng nhập không chính xác";
        #endregion Messages
        #region Path
        public static string UPLOAD_DIR = "~/FileUploaded/";
        public static string AVATAR_DIR = "~/FileUploaded/Avatar/";
        public static string TEMPLATE_DIR = "~/ExportTemplate/";
        #endregion Path
    }

    public class ModuleConstants
    {
        public const string SanPhamCode = "SanPham";
        public const string BaiVietCode = "BaiViet";
        public const string Avatar = "Avatar";

    }
}
