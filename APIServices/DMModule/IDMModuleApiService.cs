using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IDMModuleApiService
    {
        Task<int> Creat(DMModule requestModel);
        Task<int> Delete(DMModuleRequest requestModel);
        Task<DMModulePaging> GetAll(DMModuleRequest requestModel);
        Task<DMModule> GetById(int id);
        Task<int> Update(DMModule requestModel);
    }
}
