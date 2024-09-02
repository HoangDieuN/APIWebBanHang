using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IThongTinDatHangApiService
    {
        Task<int> Creat(ThongTinDatHang requestModel);
        Task<int> Delete(ThongTinDatHang requestModel);
        Task<ThongTinDatHangPaging> GetAll(ThongTinDatHangRequest requestModel);
        Task<ThongTinDatHangPaging> GetByDatHangId(ThongTinDatHangRequest requestModel);
        Task<ThongTinDatHang> GetById(int id);
        Task<int> Update(ThongTinDatHang requestModel);
    }
}
