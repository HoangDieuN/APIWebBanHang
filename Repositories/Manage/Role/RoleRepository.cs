using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Repositories
{
    public class RoleRepository :IRoleRepository
    {
        private readonly IBaseRepository _baseRepository;
        public RoleRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<List<Role>> GetAll()
        {
            try
            {
                var result = await _baseRepository.GetList<Role>("Role_GetAll");
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleRepository Error: {ex.Message}");
                return new List<Role>();
            }
        }

        public async Task<Role> GetByUser(RoleRequest requestModel)
        {
            try
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("UserID", requestModel.UserId);
                var result = await _baseRepository.GetList<Role>("Role_GetByUser", parameter);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleRepository Error: {ex.Message}");
                return null;
            }
        }

        public async Task<int> UpdateUserRole(Role requestModel)
        {
            try
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("UserID", requestModel.UserId);
                parameter.Add("RoleCode", requestModel.RoleId);
                var result = await _baseRepository.GetValue<int>("UserRole_Update", parameter);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleRepository Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> UpdateImage(Role requestModel)
        {
            try
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("UserID", requestModel.UserId);
                parameter.Add("UserImage", requestModel.UserImage);
                var result = await _baseRepository.GetValue<int>("UpdateImage", parameter);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleRepository Error: {ex.Message}");
                return 0;
            }
        }
    }
}
