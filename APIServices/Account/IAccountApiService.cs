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
        Task<int> Creat(User user);
        Task<int> Delete(UserRequest requestModel);
        Task<UserPaging> GetAll(UserRequest requestModel);
        Task<User> GetById(int id);
        Task<User> Login(LoginModel loginModel);
        Task<int> Update(User user);
    }
}
