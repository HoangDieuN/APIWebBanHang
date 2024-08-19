using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System;
using System.Threading.Tasks;

namespace APIWebBanHang.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AuthenticationController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }
        [Route("register")]
        [HttpPost]
        public async Task<object> Register(User requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _accountRepository.Creat(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = result;
                return res;
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + "-" + ex.Message;
                res.result = null;
            }
            return res;
        }
    
        [Route("login")]
        [HttpPost]
        public async Task<object> Login(LoginModel loginModel)
        {
            Response res = new Response();
            try
            {
                User result = await _accountRepository.GetUserByUserName(loginModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = result;
                return res;
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + "-" + ex.Message;
                res.result = null;
            }
            return res;
        }
        [Route("get-all")]
        [HttpPost]
        public async Task<object> GetAll(UserRequest requestModel)
        {
            Response res = new Response();
            try
            {
                UserPaging result = await _accountRepository.GetAll(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = result;
                return res;
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + "-" + ex.Message;
                res.result = null;
            }
            return res;
        }
        [Route("get-by-userid/{id}")]
        [HttpGet]
        public async Task<object> GetById(int id)
        {
            Response res = new Response();
            try
            {
                User result = await _accountRepository.GetUserByUserId(id);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = result;
                return res;
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + "-" + ex.Message;
                res.result = null;
            }
            return res;
        }
    }
}
