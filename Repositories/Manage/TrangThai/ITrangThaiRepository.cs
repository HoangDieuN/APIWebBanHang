using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ITrangThaiRepository
    {
        Task<TrangThaiPaging> GetAll(TrangThaiRequest requestModel);
        Task<TrangThai> GetByDatHangId(TrangThaiRequest requestModel);
        Task<int> UpdateTrangThaiDonHang(TrangThaiRequest requestModel);
    }
}
