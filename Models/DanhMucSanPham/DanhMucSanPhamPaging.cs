using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DanhMucSanPhamPaging : BasePaging
    {
        public List<DanhMucSanPham> ListDanhMucSanPham { get; set; } = new List<DanhMucSanPham>();
    }
}
