using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface ISanPhamApiService
    {
        Task<int> Creat(SanPham requestModel);
        Task<int> Delete(SanPham requestModel);
        Task<SanPhamPaging> GetAll(SanPhamRequest requestModel);
        Task<SanPham> GetById(int id);
        Task<int> Update(SanPham requestModel);
    }
}
