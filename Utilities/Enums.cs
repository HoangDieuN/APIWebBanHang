using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Enums
    {
        public enum AttachFileGroup
        {
            SanPham = 1,
            BaiViet = 2,
            QuyTrinh = 3
        }
        public enum statusConst{
            inProgress = 0,
            accept = 1,
            deny = 2,
            cancel = 3,
            editRequest = 4,
            draft = 9
        }
    }
}
