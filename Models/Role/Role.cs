using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Role :BaseModels
    {
        public string RoleName { get; set; }
        public string TenViet { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int UserId {  get; set; }
        public int RoleId { get; set; }
        public string UserImage {  get; set; }
    }
}
