using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System.Threading.Tasks;
using System;

namespace APIWebBanHang.Controllers
{
    [Route("api/dat-hang")]
    [ApiController]
    public class DatHangController : ControllerBase
    {
        private readonly IDatHangRepository _datHangRepository;
        public DatHangController(IDatHangRepository datHangRepository)
        {
            _datHangRepository = datHangRepository;
        }

        [Route("danh-sach")]
        [HttpPost]
        public async Task<object> GetAll(DatHangRequest requestModel)
        {
            Response res = new Response();
            try
            {
                DatHangPaging result = await _datHangRepository.GetAll(requestModel);
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
                DatHang result = await _datHangRepository.GetById(id);
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
        public async Task<object> Creat(DatHang requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _datHangRepository.Creat(requestModel);
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
        [Route("update")]
        [HttpPut]
        public async Task<object> Update(DatHang requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _datHangRepository.Update(requestModel);
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

        [Route("update-status")]
        [HttpPut]
        public async Task<object> UpdateStatus(DatHangRequest requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _datHangRepository.UpdateStatus(requestModel);
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
        [Route("delete")]
        [HttpDelete]
        public async Task<object> Delete(DatHangRequest requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _datHangRepository.Delete(requestModel);
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
