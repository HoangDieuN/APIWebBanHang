using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DatHang :BaseModels
    {
        public string MaDon {  get; set; }
        public string TenKhachHang {  get; set; }
        public string SoDT {  get; set; }
        public string DiaChi {  get; set; }
        public string Email { get; set; }
        public float TongDon { get; set; }
        public int Quantity {  get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
    }
}
