using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface ITrangThaiApiService
    {
        Task<TrangThaiPaging> GetAll(TrangThaiRequest requestModel);
        Task<TrangThai> GetByDatHangId(TrangThaiRequest requestModel);
        Task<int> UpdateTrangThai(TrangThaiRequest requestModel);
    }
}
