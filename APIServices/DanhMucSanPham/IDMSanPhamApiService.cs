using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IDMSanPhamApiService
    {
        Task<int> Creat(DanhMucSanPham requestModel);
        Task<int> Delete(DanhMucSanPham requestModel);
        Task<DanhMucSanPhamPaging> GetAll(DanhMucSanPhamRequest requestModel);
        Task<DanhMucSanPham> GetById(int id);
        Task<int> Update(DanhMucSanPham requestModel);
    }
}
