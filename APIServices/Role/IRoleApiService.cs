using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IRoleApiService
    {
        Task<int> CreatUserRole(Role requestModel);
        Task<List<Role>> GetAll();
        Task<Role> GetByUser(RoleRequest requestModel);
        Task<int> UpdateImage(Role requestModel);
        Task<int> UpdateUserRole(Role requestModel);
    }
}
