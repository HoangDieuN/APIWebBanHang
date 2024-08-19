using APIServices;
using Microsoft.IdentityModel.Tokens;
using Models;
using Newtonsoft.Json;
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
        private readonly IAttachedFileApiService _attachedFileApiService;
        public AccountController(IAccountApiService accountApiService, IAttachedFileApiService attachedFileApiService)
        {
            _accountApiService = accountApiService;
            _attachedFileApiService = attachedFileApiService;
        }
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> ListTaiKhoan(UserRequest requestModel)
        {
            //call api
            UserPaging model = await _accountApiService.GetAll(requestModel);

            return Json(new
            {
                data = model.ListTaiKhoan,
                recordsTotal = model.Total,
                recordsFiltered = model.Total,
                draw = requestModel.Draw == 0 ? 1 : requestModel.Draw,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }
        [HttpGet]
        public async Task<ActionResult> _FormAccount(int id)
        {
            User user = new User();
            if (id > 0)
            {
                User result = await _accountApiService.GetById(id);
                if (result != null)
                {
                    user = result;
                }
            }
            return PartialView(user);
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
        [HttpPost]
        public async Task<ActionResult> Save(User requestModel)
        {
            try
            {
                int result = 0;
                //list  file đính kèm chưa lưu
                string jsonFiles = Request.Params["attachedFiles"] ?? "[]";
                List<AttachedFile> listFiles = JsonConvert.DeserializeObject<List<AttachedFile>>(jsonFiles, Common.JsonSettings);

                if (requestModel.Id > 0)
                {
                    //requestModel.UpdateBy = User.ID_cb;
                    //call api update người dùng
                    result = await _accountApiService.Update(requestModel);
                }
                else
                {
                    //requestModel.CreatedBy = User.ID_cb;
                    //call api insert người dùng
                    result = await _accountApiService.Creat(requestModel);

                }
                if (result > 0)
                {
                    #region file đính kèm
                    var files = Request.Files;

                    //list file cần lưu vào bảng attached file
                    List<AttachedFile> listAttachedFiles = new List<AttachedFile>();

                    int productId = requestModel.Id > 0 ? requestModel.Id : result;

                    if (listFiles != null && listFiles.Count > 0)
                    {
                        listFiles = listFiles.Where(x => x.IsUploaded != 1).ToList();

                        //add thông tin file cần lưu
                        if (listFiles.Count > 0)
                        {
                            //lưu file
                            foreach (var file in listFiles)
                            {
                                //get file theo key
                                var fileInQueue = files.GetMultiple($"{file.Id}").Where(x => x.FileName == file.FileName).FirstOrDefault();
                                string filePath = FileManageHelper.SaveFile(this, fileInQueue, ModuleConstants.Avatar);
                                //add file to list
                                listAttachedFiles.Add(new AttachedFile()
                                {
                                    FileGroupCode = ModuleConstants.Avatar,
                                    ProductID = productId,
                                    FileKey = file.FileKey,
                                    FileName = file.FileName,
                                    FileType = file.FileType,
                                    FileSize = file.FileSize,
                                    FilePath = filePath
                                });
                            }
                            //cập nhật vào bảng attached file
                            await _attachedFileApiService.Create(new AttachedFile()
                            {
                                ListAttachedFile = listAttachedFiles,
                                UpdatedBy = "HoangDieu"
                            });
                        }
                    }
                    #endregion file đính kèm
                    #region user role
                    #endregion user role
                    return Json(new { result = "success", message = "Lưu thông tin thành công" });
                }
                return Json(new { result = "error", message = "Lưu thông tin thất bại" });
            }
            catch (Exception ex)
            {
                return Json(new { result = "error", message = "Có lỗi xảy ra: " + ex.Message });
            }

        }
    }
}