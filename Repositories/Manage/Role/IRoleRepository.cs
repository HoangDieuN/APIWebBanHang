using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRoleRepository
    {
        Task<int> CreateRole(Role requestModel);
        Task<int> CreatUserRole(Role requestModel);
        Task<int> DeleteUserRole(RoleRequest requestModel);
        Task<List<Role>> GetAll();
        Task<RolePaging> GetAllPaging(RoleRequest requestModel);
        Task<Role> GetById(int id);
        Task<Role> GetByUser(RoleRequest requestModel);
        Task<int> UpdateImage(Role requestModel);
        Task<int> UpdateUserRole(Role requestModel);
    }
}
