using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IAccountRepository
    {
        //đăng kí hoặc tạo mới 1 user
        Task<int> Creat(User requestModel);
        Task<UserPaging> GetAll(UserRequest requestModel);
        Task<User> GetUserByUserId(int id);

        //for login
        Task<User> GetUserByUserName(LoginModel loginModel);
        Task<int> Update(User requestModel);
    }
}
