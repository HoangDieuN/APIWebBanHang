using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DMModulePaging :BasePaging
    {
        public List<DMModule> ListModule { get; set; } = new List<DMModule>();
    }
}
