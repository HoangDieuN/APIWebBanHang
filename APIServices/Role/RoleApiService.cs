    using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices
{
    public class RoleApiService : IRoleApiService
    {
        public async Task<List<Role>> GetAll()
        {
            try
            {
                List<Role> result = new List<Role>();
                Response response = await RestfulApi<Response>.PostAsync($"api/vai-tro/danh-sach", null);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<List<Role>>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleApiService Error: {ex.Message}");
                return new List<Role>();
            }
        }
        public async Task<RolePaging> GetAllPaging(RoleRequest roleRequest)
        {
            try
            {
                RolePaging result = new RolePaging();
                Response response = await RestfulApi<Response>.PostAsync($"api/vai-tro/danh-sach-paging", roleRequest);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<RolePaging>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleApiService Error: {ex.Message}");
                return new RolePaging();
            }
        }
        public async Task<Role> GetById(int id)
        {
            try
            {
                Role result = null;
                Response response = await RestfulApi<Response>.GetAsync($"api/vai-tro/danh-sach/{id}", null, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<Role>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleApiService Error: {ex.Message}");
                return null;
            }
        }
        public async Task<Role> GetByUser(RoleRequest requestModel)
        {
            try
            {
                Role result = null;
                Response response = await RestfulApi<Response>.PostAsync($"api/vai-tro/nguoi-dung", requestModel);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<Role>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleApiService Error: {ex.Message}");
                return null;
            }
        }
        public async Task<int> CreatUserRole(Role requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync($"api/vai-tro/creat-user-role", requestModel);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> UpdateUserRole(Role requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync($"api/vai-tro/update-user-role", requestModel);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> DeleteUserRole(RoleRequest requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.DeleteAsync($"api/vai-tro/delete", requestModel);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> UpdateImage(Role requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync($"api/vai-tro/update-image", requestModel);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"RoleApiService Error: {ex.Message}");
                return 0;
            }
        }
    }
}
