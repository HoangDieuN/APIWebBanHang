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
    [Route("api/san-pham")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamRepository _sanPhamRepository;
        public SanPhamController(ISanPhamRepository sanPhamRepository)
        {
            _sanPhamRepository = sanPhamRepository ?? throw new ArgumentNullException(nameof(sanPhamRepository));
        }

        [Route("danh-sach")]
        [HttpPost]
        public async Task<object> GetAll(SanPhamRequest requestModel)
        {
            Response res = new Response();
            try
            {
                SanPhamPaging result = await _sanPhamRepository.GetAll(requestModel);
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
                SanPham result = await _sanPhamRepository.GetById(id);
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
        public async Task<object> Creat(SanPham requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _sanPhamRepository.Creat(requestModel);
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
        public async Task<object> Update(SanPham requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _sanPhamRepository.Update(requestModel);
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
        public async Task<object> Delete(SanPhamRequest requestModel)
        {
            Response res = new Response();
            try
            {
                int result = await _sanPhamRepository.Delete(requestModel);
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
