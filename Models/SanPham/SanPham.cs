using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SanPham : BaseModels
    {
        public string TenSanPham { get; set; }
        public string MaSanPham { get; set; }
        public int DanhMucId { get; set; }
        public int Nam { get; set; }
        public string MoTa { get; set; }
        public string ThongTin { get; set; }
        public float GiaGoc { get; set; }
        public bool IsSale { get; set; }
        public float PhanTramGiam { get; set; }
        public string GroupFile { get; set; }
        public bool IsActive { get; set; }
        public string LinkAnh { get; set; }
        public string Ids { get; set; }
        #region extent properties
        public string TenDanhMucSP { get; set; }
        public string MaDanhMucSP { get; set; }
        #endregion

    }
}
