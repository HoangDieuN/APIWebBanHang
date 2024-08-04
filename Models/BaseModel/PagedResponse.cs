using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PagedResponse<T>
    {
        public List<T> ListItems { get; set; }
        public int TotalRecords { get; set; }
    }
}
