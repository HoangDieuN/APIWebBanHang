using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System;
using System.Threading.Tasks;

namespace APIWebBanHang.Controllers
{
    [Route("api/bai-viet")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        private readonly IBaiVietRepository _baiVietRepository;
        public BaiVietController(IBaiVietRepository baiVietRepository)
        {
            _baiVietRepository = baiVietRepository ?? throw new ArgumentNullException(nameof(baiVietRepository));
        }


        [Route("danh-sach")]
        [HttpPost]
        public async Task<object> GetAll(BaiVietRequest requestModel)
        {
            Response res = new Response();
            try
            {
                BaiVietPaging result = await _baiVietRepository.GetAll(requestModel);
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
                BaiViet result = await _baiVietRepository.GetById(id);
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
        public async Task<object> Creat(BaiViet requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _baiVietRepository.Creat(requestModel);
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
        public async Task<object> Update(BaiViet requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _baiVietRepository.Update(requestModel);
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
        public async Task<object> Delete(BaiVietRequest requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _baiVietRepository.Delete(requestModel);
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
        public async Task<object> UpdateStatus(BaiVietRequest requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _baiVietRepository.UpdateActive(requestModel);
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
