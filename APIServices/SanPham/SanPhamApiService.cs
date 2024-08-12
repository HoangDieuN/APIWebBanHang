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
    public class SanPhamApiService : ISanPhamApiService
    {
        public async Task<SanPhamPaging> GetAll(SanPhamRequest requestModel)
        {
            try
            {
                SanPhamPaging result = new SanPhamPaging();
                Response response = await RestfulApi<Response>.PostAsync($"/api/san-pham/danh-sach", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<SanPhamPaging>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SanPhamApiService Error: {ex.Message}");
                return new SanPhamPaging();
            }
        }
        public async Task<int> Creat(SanPham requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync($"/api/san-pham/creat", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());

                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SanPhamApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Update(SanPham requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PutAsync($"/api/san-pham/update", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SanPhamApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Delete(SanPham requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.DeleteAsync($"/api/san-pham/delete", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());

                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SanPhamApiService Error: {ex.Message}");
                return 0;
            }

        }
        public async Task<SanPham> GetById(int id)
        {
            try
            {
                SanPham result = null;
                Response response = await RestfulApi<Response>.GetAsync($"/api/san-pham/danh-sach/{id}", null, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<SanPham>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMSanPhamApiService Error: {ex.Message}");
                return null;
            }
        }
    }
}
