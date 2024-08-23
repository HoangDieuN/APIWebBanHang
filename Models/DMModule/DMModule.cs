using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DMModule : BaseModels
    {      
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public string TenViet { get; set; }
        public string MoTa {  get; set; }
    }
}
