using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IThongTinDatHangRepository
    {
        Task<int> Creat(ThongTinDatHang requestModel);
        Task<int> Delete(ThongTinDatHangRequest requestModel);
        Task<ThongTinDatHangPaging> GetAll(ThongTinDatHangRequest requestModel);
        Task<ThongTinDatHangPaging> GetAllByDatHangId(ThongTinDatHangRequest requestModel);
        Task<ThongTinDatHang> GetById(int id);
        Task<int> Update(ThongTinDatHang requestModel);
    }
}
