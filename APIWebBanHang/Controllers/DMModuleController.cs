using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System.Threading.Tasks;
using System;

namespace APIWebBanHang.Controllers
{
    [Route("api/dm_module")]
    [ApiController]
    public class DMModuleController : ControllerBase
    {
        private readonly IDMModuleRepository _dMModuleRepository;
        public DMModuleController(IDMModuleRepository dMModuleRepository)
        {
            _dMModuleRepository = dMModuleRepository;
        }

        [Route("danh-sach")]
        [HttpPost]
        public async Task<object> GetAll(DMModuleRequest requestModel)
        {
            Response res = new Response();
            try
            {
                DMModulePaging result = await _dMModuleRepository.GetAll(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = result;
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + "-" + ex.Message;
                res.result = null;
            }
            return res;
        }
        [Route("danh-sach-active")]
        [HttpPost]
        public async Task<object> GetAllActive(DMModuleRequest requestModel)
        {
            Response res = new Response();
            try
            {
                DMModulePaging result = await _dMModuleRepository.GetAllActive(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = result;
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + "-" + ex.Message;
                res.result = null;
            }
            return res;
        }

        [Route("danh-sach/{id}")]
        [HttpGet]
        public async Task<object> GetById(int id)
        {
            Response res = new Response();
            try
            {
                DMModule result = await _dMModuleRepository.GetById(id);
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

        [Route("creat")]
        [HttpPost]
        public async Task<object> Creat(DMModule requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _dMModuleRepository.Creat(requestModel);
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
        [Route("update-active")]
        [HttpPut]
        public async Task<object> UpdateStatus(DMModuleRequest requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _dMModuleRepository.UpdateActive(requestModel);
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
        [Route("update")]
        [HttpPut]
        public async Task<object> Update(DMModule requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _dMModuleRepository.Update(requestModel);
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
        [Route("delete")]
        [HttpDelete]
        public async Task<object> Delete(DMModuleRequest requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _dMModuleRepository.Delete(requestModel);
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
