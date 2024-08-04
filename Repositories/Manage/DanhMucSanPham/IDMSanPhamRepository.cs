using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IDMSanPhamRepository
    {
        Task<int> Creat(DanhMucSanPham requestModel);
        Task<int> Delete(DanhMucSanPhamRequest requestModel);
        Task<DanhMucSanPhamPaging> GetAll(DanhMucSanPhamRequest requestModel);
        Task<DanhMucSanPham> GetById(int id);
        Task<int> Update(DanhMucSanPham requestModel);
    }
}
