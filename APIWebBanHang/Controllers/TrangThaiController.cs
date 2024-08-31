using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;
using System;
using Repositories;

namespace APIWebBanHang.Controllers
{
    [Route("api/trang-thai")]
    [ApiController]
    public class TrangThaiController : ControllerBase
    {
        private readonly ITrangThaiRepository _trangThaiRepository;
        public TrangThaiController(ITrangThaiRepository trangThaiRepository)
        {
            _trangThaiRepository = trangThaiRepository;
        }
        [Route("danh-sach")]
        [HttpPost]
        public async Task<object> GetAll(TrangThaiRequest requestModel)
        {
            Response res = new Response();
            try
            {
                TrangThaiPaging result = await _trangThaiRepository.GetAll(requestModel);
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
        [Route("get-tt-don-hang")]
        [HttpPost]
        public async Task<object> GetTrangThaiByDatHangId(TrangThaiRequest requestModel)
        {
            Response res = new Response();
            try
            {
                TrangThai result = await _trangThaiRepository.GetByDatHangId(requestModel);
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
        [Route("update-trang-thai")]
        [HttpPost]
        public async Task<object> UpdateTrangThai(TrangThaiRequest requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _trangThaiRepository.UpdateTrangThaiDonHang(requestModel);
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
