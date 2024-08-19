using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IAccountApiService
    {
        Task<UserPaging> GetAll(UserRequest requestModel);
        Task<User> GetById(int id);
        Task<User> Login(LoginModel loginModel);
    }
}
