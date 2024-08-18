using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BaiVietPaging :BasePaging
    {
        public List<BaiViet> ListBaiViet {  get; set; } = new List<BaiViet>();
    }
}
