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
    public class TrangThaiApiService :ITrangThaiApiService
    {
        public async Task<TrangThaiPaging> GetAll(TrangThaiRequest requestModel)
        {
            try
            {
                TrangThaiPaging result = new TrangThaiPaging();
                Response response = await RestfulApi<Response>.PostAsync("api/trang-thai/danh-sach", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<TrangThaiPaging>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"TrangThaiApiService Error: {ex.Message}");
                return new TrangThaiPaging();
            }
        }
        public async Task<TrangThai> GetByDatHangId(TrangThaiRequest requestModel)
        {
            try
            {
                TrangThai result = null;
                Response response = await RestfulApi<Response>.PostAsync("api/trang-thai/get-tt-don-hang", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<TrangThai>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"TrangThaiApiService Error: {ex.Message}");
                return null;
            }
        }
        public async Task<int> UpdateTrangThai(TrangThaiRequest requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync($"api/trang-thai/update-trang-thai", requestModel);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"TrangThaiApiService Error: {ex.Message}");
                return 0;
            }
        }
    }
}
