using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIWebBanHang.Controllers
{
    [Route("api/vai-tro")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }
        [Route("danh-sach")]
        [HttpPost]
        public async Task<object> GetAll()
        {
            Response res = new Response();
            try
            {
                List<Role> result = await _roleRepository.GetAll();
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = result;
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;
            }
            return res;
        }

        [Route("nguoi-dung")]
        [HttpPost]
        public async Task<object> GetByUser(RoleRequest requestModel)
        {
            Response res = new Response();
            try
            {
                Role result = await _roleRepository.GetByUser(requestModel);
                res.code = result != null ? ResponseCode.SUCCESS : ResponseCode.DATA_NULL;
                res.message = result != null ? ResponseDetail.SUCCESSDETAIL : ResponseDetail.DATA_NULLDETAIL;
                res.result = result;
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;
            }
            return res;
        }
        [Route("creat-user-role")]
        [HttpPost]
        public async Task<object> CreatUserRole(Role requestModel)
        {
            Response res = new Response();
            try
            {
                
                int result = await _roleRepository.CreatUserRole(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = result;
                return res;
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;
            }
            return res;
        }
        [Route("update-user-role")]
        [HttpPost]
        public async Task<object> UpdateUserRole(Role requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _roleRepository.UpdateUserRole(requestModel);
                res.code = result > 0 ? ResponseCode.SUCCESS : ResponseCode.UPDATE_ERROR;
                res.message = result > 0 ? ResponseDetail.SUCCESSDETAIL : ResponseDetail.UPDATE_ERRORDETAIL;
                res.result = result;
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;
            }
            return res;
        }

        [Route("update-image")]
        [HttpPost]
        public async Task<object> UpdateImage(Role requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _roleRepository.UpdateImage(requestModel);
                res.code = result > 0 ? ResponseCode.SUCCESS : ResponseCode.UPDATE_ERROR;
                res.message = result > 0 ? ResponseDetail.SUCCESSDETAIL : ResponseDetail.UPDATE_ERRORDETAIL;
                res.result = result;
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;
            }
            return res;
        }
    }
}
