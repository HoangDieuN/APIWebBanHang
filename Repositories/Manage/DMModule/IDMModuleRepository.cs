using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IDMModuleRepository
    {
        Task<int> Creat(DMModule requestModel);
        Task<int> Delete(DMModuleRequest requestModel);
        Task<DMModulePaging> GetAll(DMModuleRequest requestModel);
        Task<DMModule> GetById(int id);
        Task<int> Update(DMModule requestModel);
    }
}
