using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ThongTinDatHang :BaseModels
    {
        public int DatHangId {  get; set; }
        public int SanPhamId {  get; set; }
        public float Gia {  get; set; }
        public int Quantity {  get; set; }
        #region Extens
        public string TenSanPham { get; set; }
        #endregion Extens
    }
}
