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
        Task<User> Login(LoginModel loginModel);
    }
}
