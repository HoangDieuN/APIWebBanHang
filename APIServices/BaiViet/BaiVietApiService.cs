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
    public class BaiVietApiService :IBaiVietApiService
    {
        public async Task<BaiVietPaging> GetAll(BaiVietRequest requestModel)
        {
            try
            {
                BaiVietPaging result = new BaiVietPaging();
                Response response = await RestfulApi<Response>.PostAsync($"api/bai-viet/danh-sach", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<BaiVietPaging>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"BaiVietApiService Error: {ex.Message}");
                return new BaiVietPaging();
            }
        }
        public async Task<int> Creat(BaiViet requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync($"api/bai-viet/creat", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());

                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"BaiVietApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Update(BaiViet requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PutAsync($"api/bai-viet/update", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"BaiVietApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Delete(BaiVietRequest requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.DeleteAsync($"api/bai-viet/delete", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());

                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"BaiVietApiService Error: {ex.Message}");
                return 0;
            }

        }
        public async Task<BaiViet> GetById(int id)
        {
            try
            {
                BaiViet result = null;
                Response response = await RestfulApi<Response>.GetAsync($"api/bai-viet/danh-sach/{id}", null, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<BaiViet>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"BaiVietApiService Error: {ex.Message}");
                return null;
            }
        }
        public async Task<int> UpdateActive(BaiVietRequest requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PutAsync("api/bai-viet/update-active", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"BaiVietApiService Error: {ex.Message}");
                return 0;
            }
        }
    }
}
