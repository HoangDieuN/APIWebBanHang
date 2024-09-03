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
        Task<int> CreatRole(Role requestModel);
        Task<int> CreatUserRole(Role requestModel);
        Task<int> DeleteUserRole(RoleRequest requestModel);
        Task<List<Role>> GetAll();
        Task<RolePaging> GetAllPaging(RoleRequest roleRequest);
        Task<Role> GetById(int id);
        Task<Role> GetByUser(RoleRequest requestModel);
        Task<int> UpdateImage(Role requestModel);
        Task<int> UpdateUserRole(Role requestModel);
    }
}
