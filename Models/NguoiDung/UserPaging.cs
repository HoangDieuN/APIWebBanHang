using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserPaging : BasePaging
    {
        List<User> ListUser { get; set; } = new List<User>();
    }
}
