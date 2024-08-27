using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; }
        public ShoppingCart()
        {
            this.Items = new List<ShoppingCartItem>();
        }

        public void AddToCart(ShoppingCartItem item, int Quantity)
        {
            var checkExits = Items.FirstOrDefault(x => x.SanPhamId == item.SanPhamId);
            if (checkExits != null)
            {
                checkExits.Quantity += Quantity;
                checkExits.TongTien = checkExits.GiaGoc * checkExits.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }

        public void Remove(int id)
        {
            var checkExits = Items.SingleOrDefault(x => x.SanPhamId == id);
            if (checkExits != null)
            {
                Items.Remove(checkExits);
            }
        }

        public void UpdateQuantity(int id, int quantity)
        {
            var checkExits = Items.SingleOrDefault(x => x.SanPhamId == id);
            if (checkExits != null)
            {
                checkExits.Quantity = quantity;
                checkExits.TongTien = checkExits.GiaGoc * checkExits.Quantity;
            }
        }

        public float GetTotalPrice()
        {
            return Items.Sum(x => x.TongTien);
        }
        public int GetTotalQuantity()
        {
            return Items.Sum(x => x.Quantity);
        }
        public void ClearCart()
        {
            Items.Clear();
        }

    }

    public class ShoppingCartItem
    {
        public int SanPhamId { get; set; }
        public string TenSanPham { get; set; }
        public string MaSanPham { get; set; }
        public string CategoryName { get; set; }
        public string ProductImg { get; set; }
        public int Quantity { get; set; }
        public float GiaGoc { get; set; }
        public float TongTien { get; set; }
        public string TenDanhMucSP {  get; set; }
    }
}
