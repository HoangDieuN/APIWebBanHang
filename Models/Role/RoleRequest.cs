using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RoleRequest :BaseRequest
    {
        public int UserId { get; set; }
        public int UserName { get; set; }
        public string Ids {  get; set; }

    }
}
