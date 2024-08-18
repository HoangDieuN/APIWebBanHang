using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BaiVietRequest: BaseRequest
    {
        public string Ids { get; set; }
        public string PhanHoi { get; set; }
        public bool IsActive { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
