using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DanhMucSanPham :BaseModels
    {
        public string TenDanhMucSP { get; set; }
        public string MaDanhMucSP { get; set; }
        public string MoTa { get; set; }
        public string GroupFile { get; set; }
        public bool IsActive { get; set; }
        public string Ids { get; set; }
    }
}
