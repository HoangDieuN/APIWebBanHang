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
    }
}
