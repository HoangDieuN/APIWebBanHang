using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{ 
    public class UserRequest : BaseRequest
    {
       public string Ids { get; set; }
       public int UserId { get; set; }
       public string DeletedBy {  get; set; }

    }
}
