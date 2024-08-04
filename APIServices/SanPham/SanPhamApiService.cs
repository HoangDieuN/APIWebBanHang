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
        //public static string ApiUrlKhoaHoc = "https://localhost:44377/";
        public static string ApiUrlKhoaHoc = "https://localhost:5001/";

        public async Task<SanPhamPaging> GetAll(SanPhamRequest requestModel)
        {
            try
            {
                SanPhamPaging result = new SanPhamPaging();
                Response response = await RestfulApi<Response>.PostAsync("api/san-pham/danh-sach", requestModel, ApiUrlKhoaHoc);
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
    }
}
