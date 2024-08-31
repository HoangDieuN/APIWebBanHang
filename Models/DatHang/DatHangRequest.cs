using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DatHangRequest: BaseRequest
    {
        public string Ids { get; set; }
        public int Status { get; set; }
        public string PhanHoi { get; set; }
    }
}
