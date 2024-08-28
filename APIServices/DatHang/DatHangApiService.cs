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
    public class DatHangApiService :IDatHangApiService
    {
        public async Task<int> Creat(DatHang requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync($"api/dat-hang/creat", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());

                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DatHangApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Update(DatHang requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PutAsync($"api/dat-hang/update", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DatHangApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<DatHangPaging> GetAll(DatHangRequest requestModel)
        {
            try
            {
                DatHangPaging result = new DatHangPaging();
                Response response = await RestfulApi<Response>.PostAsync("api/dat-hang/danh-sach", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<DatHangPaging>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DatHangApiService Error: {ex.Message}");
                return new DatHangPaging();
            }
        }
        public async Task<int> Delete(DatHang requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.DeleteAsync($"api/dat-hang/delete", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());

                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DatHangApiService Error: {ex.Message}");
                return 0;
            }

        }
        public async Task<DatHang> GetById(int id)
        {
            try
            {
                DatHang result = null;
                Response response = await RestfulApi<Response>.GetAsync($"api/dat-hang/danh-sach/{id}", null, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<DatHang>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DatHangApiService Error: {ex.Message}");
                return null;
            }
        }
    }
}
