using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SanPhamRequest : BaseRequest
    {
        public string Ids { get; set; }
        public int Nam { get; set; }
        public int DanhMucId { get; set; }
        public string MaDMSanPham { get; set; }
    }
}
