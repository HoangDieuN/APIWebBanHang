using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SanPhamPaging : BasePaging
    {
        public List<SanPham> ListSanPham { get; set; } = new List<SanPham>();

    }
}
