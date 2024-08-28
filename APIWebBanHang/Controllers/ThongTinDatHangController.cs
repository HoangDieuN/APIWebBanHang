using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System.Threading.Tasks;
using System;

namespace APIWebBanHang.Controllers
{
    [Route("api/thong-tin-dat-hang")]
    [ApiController]
    public class ThongTinDatHangController : ControllerBase
    {
        private readonly IThongTinDatHangRepository _thongTinDatHangRepository;
        public ThongTinDatHangController(IThongTinDatHangRepository thongTinDatHangRepository)
        {
            _thongTinDatHangRepository = thongTinDatHangRepository;
        }

        [Route("danh-sach")]
        [HttpPost]
        public async Task<object> GetAll(ThongTinDatHangRequest requestModel)
        {
            Response res = new Response();
            try
            {
                ThongTinDatHangPaging result = await _thongTinDatHangRepository.GetAll(requestModel);
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
                ThongTinDatHang result = await _thongTinDatHangRepository.GetById(id);
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
        public async Task<object> Creat(ThongTinDatHang requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _thongTinDatHangRepository.Creat(requestModel);
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
        public async Task<object> Update(ThongTinDatHang requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _thongTinDatHangRepository.Update(requestModel);
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
        public async Task<object> Delete(ThongTinDatHangRequest requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _thongTinDatHangRepository.Delete(requestModel);
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
