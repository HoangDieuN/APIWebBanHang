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
    public class AttachedFileApiService :IAttachedFileApiService
    {
        public async Task<AttachedFilePaging> GetAll(AttachedFileRequest requestModel)
        {
            try
            {
                AttachedFilePaging result = new AttachedFilePaging();
                Response response = await RestfulApi<Response>.PostAsync("api/attached-file/danh-sach", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<AttachedFilePaging>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AttachedFileApiService Error: {ex.Message}");
                return new AttachedFilePaging();
            }
        }

        public async Task<int> Create(AttachedFile requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync("api/attached-file/create", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AttachedFileApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Delete(AttachedFile requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.DeleteAsync("api/attached-file/delete", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AttachedFileApiService Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<List<AttachedFile>> GetByGroupProduct(AttachedFileRequest requestModel)
        {
            try
            {
                List<AttachedFile> result = new List<AttachedFile>();
                Response response = await RestfulApi<Response>.PostAsync("api/attached-file/list-by-group-products", requestModel);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<List<AttachedFile>>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AttachedFileApiService Error: {ex.Message}");
                return new List<AttachedFile>();
            }
        }

        public async Task<AttachedFile> GetById(AttachedFile requestModel)
        {
            try
            {
                AttachedFile result = null;
                Response response = await RestfulApi<Response>.PostAsync("api/attached-file/danh-sach/id", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<AttachedFile>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AttachedFileApiService Error: {ex.Message}");
                return null;
            }
        }
    }
}
