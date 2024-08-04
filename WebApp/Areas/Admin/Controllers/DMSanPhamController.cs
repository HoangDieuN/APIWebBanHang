using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class DMSanPhamController : Controller
    {
        private readonly IDMSanPhamApiService _dMSanPhamApiService;
        public DMSanPhamController(IDMSanPhamApiService dMSanPhamApiService)
        {
            _dMSanPhamApiService = dMSanPhamApiService;
        }
        // GET: Admin/DMSanPham
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ListDanhMucSanPham(DanhMucSanPhamRequest requestModel)
        {
            //call api
            DanhMucSanPhamPaging model = await _dMSanPhamApiService.GetAll(requestModel);

            return Json(new
            {
                data = model.ListDanhMucSanPham,
                recordsTotal = model.Total,
                recordsFiltered = model.Total,
                draw = requestModel.Draw == 0 ? 1 : requestModel.Draw,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }
        [HttpGet]
        public async Task<ActionResult> _FormDMSanPham(int id)
        {
            DanhMucSanPham model = new DanhMucSanPham();
            if (id > 0)
            {
                DanhMucSanPham result = await _dMSanPhamApiService.GetById(id);
                if (result != null)
                {
                    model = result;
                }
            }
            return PartialView(model);
        }
        [HttpPost]
        public async Task<ActionResult> Save(DanhMucSanPham requestModel)
        {
            try {
                int result = 0;
                if(requestModel.Id > 0)
                {
                    result = await _dMSanPhamApiService.Update(requestModel);
                }
                else
                {
                    result = await _dMSanPhamApiService.Creat(requestModel);
                }
                if(result > 0)
                {
                    return Json(new { result = "success", message = "Lưu thông tin thành công" });
                }
                return Json(new { result = "error", message = "Lưu thông tin thất bại" });

            }
            catch (Exception ex)
            {
                return Json(new { result = "error", message = "Có lỗi xảy ra" + ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult> Delete(DanhMucSanPham requestModel)
        {
            try
            {
                int result = await _dMSanPhamApiService.Delete(requestModel);
                if(result > 0)
                {
                    return Json(new { result = "success", message = "Xóa thành công" });
                }
                return Json(new { result = "error", message = "Xóa thất bại" });

            }
            catch (Exception ex)
            {
                return Json(new { result = "error", message = "Có lỗi xảy ra" + ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult> SelectDanhMucSanPham(DanhMucSanPhamRequest requestModel)
        {
            DanhMucSanPhamPaging model = await _dMSanPhamApiService.GetAll(requestModel);
            List<object> options = new List<object>();
            foreach(var item in model.ListDanhMucSanPham)
            {
                options.Add(new
                {
                    id = item.Id,
                    text = item.TenDanhMucSP,
                    data =item
                });
            }
            return Json(new
            {
                data = options,
                recordsTotal = model.ListDanhMucSanPham.Count,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }
    }
}