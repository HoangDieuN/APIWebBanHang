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
    public class DMSanPhamApiService :IDMSanPhamApiService
    {
        public async Task<int> Creat(DanhMucSanPham requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync($"/api/danh-muc-san-pham/creat", requestModel);
                if(response.code== ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());

                }
                return result;
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"DMSanPhamApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Update(DanhMucSanPham requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync($"/api/danh-muc-san-pham/creat", requestModel);
                if(response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"DMSanPhamApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<DanhMucSanPhamPaging> GetAll(DanhMucSanPhamRequest requestModel)
        {
            try
            {
                DanhMucSanPhamPaging result = new DanhMucSanPhamPaging();
                Response response = await RestfulApi<Response>.PostAsync("/api/danh-muc-san-pham/danh-sach", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<DanhMucSanPhamPaging>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMSanPhamApiService Error: {ex.Message}");
                return new DanhMucSanPhamPaging();
            }
        }
        public async Task<int> Delete(DanhMucSanPham requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync($"/api/danh-muc-san-pham/delete", requestModel);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());

                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMSanPhamApiService Error: {ex.Message}");
                return 0;
            }

        }
        public async Task<DanhMucSanPham> GetById(int id)
        {
            try
            {
                DanhMucSanPham result = null;
                Response response = await RestfulApi<Response>.GetAsync($"/api/danh-muc-san-pham/{id}", null);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<DanhMucSanPham>(response.result.ToString());
                }
                return result;
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"DMSanPhamApiService Error: {ex.Message}");
                return null;
            }
        }
    }
}
