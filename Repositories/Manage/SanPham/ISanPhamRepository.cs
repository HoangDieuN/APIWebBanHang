using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISanPhamRepository
    {
        Task<int> Creat(SanPham requestModel);
        Task<int> Delete(SanPhamRequest requestModel);
        Task<SanPhamPaging> GetAll(SanPhamRequest requestModel);
        Task<SanPham> GetById(int id);
        Task<int> Update(SanPham requestModel);
    }
}
