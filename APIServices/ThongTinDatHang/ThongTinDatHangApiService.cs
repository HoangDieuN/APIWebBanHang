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
    public class ThongTinDatHangApiService :IThongTinDatHangApiService
    {
        public async Task<int> Creat(ThongTinDatHang requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync($"api/thong-tin-dat-hang/creat", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());

                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ThongTinDatHangApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Update(ThongTinDatHang requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PutAsync($"api/thong-tin-dat-hang/update", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ThongTinDatHangApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<ThongTinDatHangPaging> GetAll(ThongTinDatHangRequest requestModel)
        {
            try
            {
                ThongTinDatHangPaging result = new ThongTinDatHangPaging();
                Response response = await RestfulApi<Response>.PostAsync("api/thong-tin-dat-hang/danh-sach", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<ThongTinDatHangPaging>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ThongTinDatHangApiService Error: {ex.Message}");
                return new ThongTinDatHangPaging();
            }
        }
        public async Task<int> Delete(ThongTinDatHang requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.DeleteAsync($"api/thong-tin-dat-hang/delete", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());

                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ThongTinDatHangApiService Error: {ex.Message}");
                return 0;
            }

        }
        public async Task<ThongTinDatHang> GetById(int id)
        {
            try
            {
                ThongTinDatHang result = null;
                Response response = await RestfulApi<Response>.GetAsync($"api/thong-tin-dat-hang/danh-sach/{id}", null, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<ThongTinDatHang>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ThongTinDatHangApiService Error: {ex.Message}");
                return null;
            }
        }
    }
}
