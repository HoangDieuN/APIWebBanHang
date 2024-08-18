using APIServices;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Utilities;
namespace WebApp.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountApiService _accountApiService;
        public AccountController(IAccountApiService accountApiService)
        {
            _accountApiService = accountApiService;
        }
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {         
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> LoginSubMit(LoginModel loginModel)
        {
            User user = await _accountApiService.Login(loginModel);
            if (user != null)
            {
                var token = Generate(user);

                return Json(new
                {
                    data = user,
                    result = "success",
                    message = "Đăng nhập  thành công"
                });
            }
            return Json(new
            {
                result = "error",
                message = "Có lỗi xảy ra"
            });
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(CommonConstants.JwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.HoTen),
                new Claim(ClaimTypes.Role, user.RoleName),
                new Claim(ClaimTypes.MobilePhone,user.SoDT),
            };
            var token = new JwtSecurityToken(CommonConstants.JwtIssuer,
              CommonConstants.JwtAudience,
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}