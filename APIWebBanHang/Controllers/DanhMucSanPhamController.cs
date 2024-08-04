using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebBanHang.Controllers
{
    [Route("api/danh-muc-san-pham")]
    [ApiController]
    public class DanhMucSanPhamController : ControllerBase
    {
        private readonly IDMSanPhamRepository _dMSanPhamRepository;
        public DanhMucSanPhamController(IDMSanPhamRepository dMSanPhamRepository)
        {
            _dMSanPhamRepository = dMSanPhamRepository;
        }

        [Route("danh-sach")]
        [HttpPost]
        public async Task<object> GetAll(DanhMucSanPhamRequest requestModel)
        {
            Response res = new Response();
            try
            {
                DanhMucSanPhamPaging result = await _dMSanPhamRepository.GetAll(requestModel);
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
                DanhMucSanPham result = await _dMSanPhamRepository.GetById(id);
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
        public async Task<object> Creat(DanhMucSanPham requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _dMSanPhamRepository.Creat(requestModel);
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
        public async Task<object> Update(DanhMucSanPham requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _dMSanPhamRepository.Update(requestModel);
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
        public async Task<object> Delete(DanhMucSanPhamRequest requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _dMSanPhamRepository.Delete(requestModel);
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
