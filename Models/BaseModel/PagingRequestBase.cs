using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PagingRequestBase
    {
        public int Start { get; set; }
        public int Length { get; set; }
    }
}
