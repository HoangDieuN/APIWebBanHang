using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class ThongTinDatHangPaging :BasePaging
    {
        public List<ThongTinDatHang> ListThongTinDatHang { get; set; } = new List<ThongTinDatHang>();
    }
}
