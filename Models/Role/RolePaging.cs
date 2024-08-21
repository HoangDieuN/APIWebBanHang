using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RolePaging : BasePaging
    {
        public List<Role> ListQuyen { get; set; } = new List<Role>();
    }
}
