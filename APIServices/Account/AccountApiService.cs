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
    public class AccountApiService :IAccountApiService
    {
        public async Task<User> Login(LoginModel loginModel)
        {
            try
            {
                User result = null;
                Response response = await RestfulApi<Response>.PostAsync($"api/user/login",loginModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<User>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AccountApiService Error: {ex.Message}");
                return null;
            }
        }
        public async Task<UserPaging> GetAll(UserRequest requestModel)
        {
            try
            {
                UserPaging result = new UserPaging();
                Response response = await RestfulApi<Response>.PostAsync($"api/user/get-all", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<UserPaging>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AccountApiService Error: {ex.Message}");
                return new UserPaging();
            }
        }
        public async Task<User> GetById(int id)
        {
            try
            {
                User result = null;
                Response response = await RestfulApi<Response>.GetAsync($"api/user/get-by-userid/{id}",null, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<User>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AccountApiService Error: {ex.Message}");
                return null;
            }
        }
        public async Task<int> Creat(User user)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync($"api/user/register", user, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AccountApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Update(User user)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.PostAsync($"api/user/update", user, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AccountApiService Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Delete(UserRequest requestModel)
        {
            try
            {
                int result = 0;
                Response response = await RestfulApi<Response>.DeleteAsync($"api/user/delete", requestModel, CommonConstants.ApiUrl);
                if (response.code == ResponseCode.SUCCESS)
                {
                    result = JsonConvert.DeserializeObject<int>(response.result.ToString());
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AccountApiService Error: {ex.Message}");
                return 0;
            }
        }
    }
    
}
