using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IDatHangApiService
    {
        Task<int> Creat(DatHang requestModel);
        Task<int> Delete(DatHang requestModel);
        Task<DatHangPaging> GetAll(DatHangRequest requestModel);
        Task<DatHang> GetById(int id);
        Task<int> Update(DatHang requestModel);
        Task<int> UpdateStatus(DatHangRequest requestModel);
    }
}
