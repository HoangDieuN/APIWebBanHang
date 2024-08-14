using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Repositories;


namespace APIWebBanHang.Controllers
{
    [Route("api/attached-file")]
    [ApiController]
    public class AttachedFileController : ControllerBase
    {
        private readonly IAttachedFileRepository _attachedFileRepository;

        public AttachedFileController(IAttachedFileRepository attachedFileRepository)
        {
            _attachedFileRepository = attachedFileRepository ?? throw new ArgumentNullException(nameof(attachedFileRepository));
        }

        [Route("danh-sach")]
        [HttpPost]
        public async Task<object> GetAll(AttachedFileRequest requestModel)
        {
            Response res = new Response();
            try
            {
                AttachedFilePaging result = await _attachedFileRepository.GetAll(requestModel);
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

        [Route("list-by-group-products")]
        [HttpPost]
        public async Task<object> GetByGroupProduct(AttachedFileRequest requestModel)
        {
            Response res = new Response();
            try
            {
                List<AttachedFile> result = await _attachedFileRepository.GetByGroupProduct(requestModel);
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

        [Route("danh-sach/id")]
        [HttpPost]
        public async Task<object> GetById(AttachedFile requestModel)
        {
            Response res = new Response();
            try
            {
                AttachedFile result = await _attachedFileRepository.GetById(requestModel);
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

        [Route("create")]
        [HttpPost]
        public async Task<object> Create(AttachedFile requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _attachedFileRepository.Create(requestModel);
                res.code = result == 0 ? ResponseCode.UPDATE_ERROR : ResponseCode.SUCCESS;
                res.message = result == 0 ? ResponseDetail.UPDATE_ERRORDETAIL : ResponseDetail.SUCCESSDETAIL;
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
        public async Task<object> Delete(AttachedFile requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _attachedFileRepository.Delete(requestModel);
                res.code = result == 0 ? ResponseCode.UPDATE_ERROR : ResponseCode.SUCCESS;
                res.message = result == 0 ? ResponseDetail.UPDATE_ERRORDETAIL : ResponseDetail.SUCCESSDETAIL;
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
