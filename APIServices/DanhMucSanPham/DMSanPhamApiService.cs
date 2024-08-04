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
        //public static string ApiUrlKhoaHoc = "https://localhost:44377/";
        //public static string ApiUrl = "https://localhost:5001/";
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
    }
}
