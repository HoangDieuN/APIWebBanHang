using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JsonResponse
    {
        public string type { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public int draw { get; set; }
        public string error { get; set; }
        public string icon { get; set; }
    }

    public class Response
    {
        public string code { get; set; }
        public string message { get; set; }
        public object result { get; set; }
        public int recordsTotal { get; set; }
        public string icon { get; set; }

    }

    public static class ResponseCode
    {
        //Reponse code tu api tra ve
        public const string SUCCESS = "0000";//Thành Công
        public const string ERROR = "0500";//Thành Công

        public const string SYSTEM_ERROR = "0001";//Lỗi hệ thống
        public const string Connect_ERROR = "0002";//Lỗi kết nối
        public const string LOGIN_ERROR = "0003";//Tài khoản hoặc mật khẩu không chính xác
        public const string UNKNOWN_ERROR = "0999";//Lỗi không xác định
        public const string UPDATE_ERROR = "0666";//Cập nhật không thành công
        public const string DATA_NOTDELETE = "0667";//Dữ liệu không thể xóa
        public const string INPUTDATA_ERROR = "0668";//Dữ liệu đầu vào không chính xác
        public const string OLDPASSWORD_ERROR = "0669";//Mật khẩu cũ không chính xác
        public const string USER_DELETED = "0700";//Tài khoản đã bị xóa
        public const string LISTMODEL_NULL = "0701";//Danh sách rỗng
        public const string DATA_NULL = "0702";//Không có dữ liệu
        public const string DATA_DUPLICATE = "0703";//Trùng lặp dữ liệu
        public const string ENOUGH_QUANTITY = "0704";//Đủ số lượng
        public const string GETTOKEN_FALSE = "0705";//Xác thực tài khoản thất bại
    }

    public static class ResponseDetail
    {
        //Reponse noi dung tu api tra ve
        public const string SUCCESSDETAIL = "Thành Công";

        public const string SYSTEM_ERRORDETAIL = "Lỗi hệ thống";
        public const string Connect_ERRORDETAIL = "Lỗi kết nối";
        public const string LOGIN_ERRORDETAIL = "Tài khoản hoặc mật khẩu không chính xác";
        public const string UNKNOWN_ERRORDETAIL = "Lỗi không xác định";
        public const string UPDATE_ERRORDETAIL = "Cập nhật không thành công";
        public const string DATA_NOTDELETEDETAIL = "Dữ liệu không thể xóa";
        public const string INPUTDATA_ERRORDETAIL = "Dữ liệu đầu vào không chính xác";
        public const string OLDPASSWORD_ERRORDETAIL = "Mật khẩu cũ không chính xác";
        public const string USER_DELETEDDETAIL = "Tài khoản đã bị xóa";
        public const string LISTMODEL_NULLDETAIL = "Danh sách rỗng";
        public const string DATA_NULLDETAIL = "Không có dữ liệu";
        public const string DATA_DUPLICATEDETAIL = "Trùng lặp dữ liệu";
        public const string ENOUGH_QUANTITYDETAIL = "Đủ số lượng";
        public const string GETTOKEN_FALSEDETAIL = "Xác thực tài khoản không thành công";//Xác thực tài khoản thất bại
    }


    public static class ResponseIcon
    {
        //Reponse code tu api tra ve
        public const string SUCCESS = "success";//Thành Công
        public const string ERROR = "error";//Thành Công

    }
}
