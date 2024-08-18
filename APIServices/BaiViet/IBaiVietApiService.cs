using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IBaiVietApiService
    {
        Task<int> Creat(BaiViet requestModel);
        Task<int> Delete(BaiVietRequest requestModel);
        Task<BaiVietPaging> GetAll(BaiVietRequest requestModel);
        Task<BaiViet> GetById(int id);
        Task<int> Update(BaiViet requestModel);
        Task<int> UpdateActive(BaiVietRequest requestModel);
    }
}
