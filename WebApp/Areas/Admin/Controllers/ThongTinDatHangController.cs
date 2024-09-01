using APIServices;
using Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    public class ThongTinDatHangController : Controller
    {
        private readonly IThongTinDatHangApiService _thongTinDatHangApiService;
        public ThongTinDatHangController(IThongTinDatHangApiService thongTinDatHangApiService)
        {
            _thongTinDatHangApiService = thongTinDatHangApiService;
        }
        // GET: Admin/ThongTinDatHang
        public ActionResult Index()
        {
            return View();
        }
        #region PartialViews
        public PartialViewResult PvDanhSachTheoSanPham(ThongTinDatHangRequest requestModel)
        {
            ViewBag.DatHangId = requestModel.DatHangId;
            return PartialView();
        }
        #endregion PartialViews
        #region Action
        [HttpPost]
        public async Task<ActionResult> ListThongTinDatHangByDatHangId(ThongTinDatHangRequest requestModel)
        {
            //lấy danh sách thành viên không thuộc sản phẩm
            List<ThongTinDatHang> model = await _thongTinDatHangApiService.GetByDatHangId(requestModel);
            return Json(new
            {
                data = model,
                recordsTotal = model.Count,
                recordsFiltered = model.Count,
                result = "success",
                message = "Tải dữ liệu thành công"
            });
        }
        #endregion Action


    }
}