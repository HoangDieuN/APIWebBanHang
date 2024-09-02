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
    public class DMModuleApiService :IDMModuleApiService
    {
        public async Task<int> Creat(DMModule requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync($"api/dm_module/creat", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());

                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMModuleApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Update(DMModule requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PutAsync($"api/dm_module/update", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMModuleApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> UpdateActive(DMModuleRequest requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PutAsync("api/dm_module/update-active", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMModuleApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<DMModulePaging> GetAll(DMModuleRequest requestModel)
        {
            try
            {
                DMModulePaging result = new DMModulePaging();
                Response response = await RestfulApi<Response>.PostAsync("api/dm_module/danh-sach", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<DMModulePaging>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMModuleApiService Error: {ex.Message}");
                return new DMModulePaging();
            }
        }
        public async Task<DMModulePaging> GetAllActive(DMModuleRequest requestModel)
        {
            try
            {
                DMModulePaging result = new DMModulePaging();
                Response response = await RestfulApi<Response>.PostAsync("api/dm_module/danh-sach-active", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<DMModulePaging>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMModuleApiService Error: {ex.Message}");
                return new DMModulePaging();
            }
        }
        public async Task<int> Delete(DMModuleRequest requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.DeleteAsync($"api/dm_module/delete", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());

                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMModuleApiService Error: {ex.Message}");
                return 0;
            }

        }
        public async Task<DMModule> GetById(int id)
        {
            try
            {
                DMModule result = null;
                Response response = await RestfulApi<Response>.GetAsync($"api/dm_module/danh-sach/{id}", null, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<DMModule>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMModuleApiService Error: {ex.Message}");
                return null;
            }
        }
    }
}
