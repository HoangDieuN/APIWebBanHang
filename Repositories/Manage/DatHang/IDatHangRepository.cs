using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IDatHangRepository
    {
        Task<int> Creat(DatHang requestModel);
        Task<int> Delete(DatHangRequest requestModel);
        Task<DatHangPaging> GetAll(DatHangRequest requestModel);
        Task<DatHang> GetById(int id);
        Task<int> Update(DatHang requestModel);
    }
}
