using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class User : BaseModels 
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string HoTen {  get; set; }
        public int RoleId {  get; set; }
        public string RoleName { get; set; }
        public string SoDT { get; set; }
        public bool IsDisabled {  get; set; }
        public DateTime? DeletedDate { get; set; }
        public string TenViet { get; set; }

    }
}
