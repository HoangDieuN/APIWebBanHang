using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        public async Task<RolePaging> GetAllPaging(RoleRequest requestModel)
        {
            try
            {
                RolePaging pagedResult = new RolePaging();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Keywords", requestModel.Keywords);
                parameters.Add("@Start", requestModel.Start);
                parameters.Add("@Length", requestModel.Length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList("Role_GetAllPaging", parameters, read =>
                {
                    pagedResult.ListQuyen = read.Read<Role>().ToList();
                    pagedResult.Total = parameters.Get<int>("@Count");
                });
                return pagedResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleRepository Error: {ex.Message}");
                return new RolePaging();
            }
        }
        public async Task<Role> GetByUser(RoleRequest requestModel)
        {
            try
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("UserId", requestModel.UserId);
                var result = await _baseRepository.GetList<Role>("Role_GetByUser", parameter);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleRepository Error: {ex.Message}");
                return null;
            }
        }
        public async Task<Role> GetById(int id)
        {
            try
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", id);
                var result = await _baseRepository.GetList<Role>("Role_GetById", parameter);
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
                parameter.Add("UserId", requestModel.UserId);
                parameter.Add("RoleId", requestModel.RoleId);
                parameter.Add("UpdatedBy", requestModel.UpdatedBy);
                var result = await _baseRepository.GetValue<int>("UserRole_Update", parameter);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> DeleteUserRole(RoleRequest requestModel)
        {
            try
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("UserId", requestModel.UserId);
                var result = await _baseRepository.GetValue<int>("UserRole_Delete", parameter);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> CreatUserRole(Role requestModel)
        {
            try
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("UserId", requestModel.UserId);
                parameter.Add("RoleId", requestModel.RoleId);
                parameter.Add("CreatedBy", requestModel.CreatedBy);
                var result = await _baseRepository.GetValue<int>("User_CreatUserRole", parameter);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> CreateRole(Role requestModel)
        {
            try
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@RoleName", requestModel.RoleName);
                parameter.Add("@TenViet", requestModel.TenViet);
                parameter.Add("@CreatedBy", requestModel.CreatedBy);
                var result = await _baseRepository.GetValue<int>("Role_CreatRole", parameter);
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
