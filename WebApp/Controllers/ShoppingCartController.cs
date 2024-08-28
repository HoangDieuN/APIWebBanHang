using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Controllers
{
    public class ShoppingCartController : BaseController
    {
        private readonly ISanPhamApiService _sanPhamApiService;
        private readonly IAttachedFileApiService _attachedFileApiService;
        private readonly IDatHangApiService _datHangApiService;
        private readonly IThongTinDatHangApiService _thongTinDatHangApiService;
        public ShoppingCartController(ISanPhamApiService sanPhamApiService,IAttachedFileApiService attachedFileApiService,
            IDatHangApiService datHangApiService, IThongTinDatHangApiService thongTinDatHangApiService)
        {
            _sanPhamApiService = sanPhamApiService;
            _attachedFileApiService = attachedFileApiService;
            _datHangApiService = datHangApiService;
            _thongTinDatHangApiService = thongTinDatHangApiService;
        }
        //Xem giỏ hàng
        public ActionResult Index()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }
        //hiển thị số lượng sản phẩm 
        [AllowAnonymous]
        public ActionResult ShowCount()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                return Json(new { Count = cart.Items.Count }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Count = 0 }, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public ActionResult Partial_CheckOut()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult CheckOut()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult CheckOutSuccess()
        {       
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CheckOut(DatHangViewModel requestModel)
        {
            var code = new { Success = false, Code = -1 };
            if (ModelState.IsValid)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart != null && cart.Items.Any())
                {
                    //thêm mới đơn đặt hàng
                    DatHang newDonHang = new DatHang();
                    newDonHang.TenKhachHang = requestModel.HoTen;
                    Guid newMa = Guid.NewGuid();
                    newDonHang.MaDon = newMa.ToString();
                    newDonHang.SoDT = requestModel.SoDT;
                    newDonHang.DiaChi = requestModel.DiaChi;
                    newDonHang.Email = requestModel.Email;
                    newDonHang.TongDon = cart.Items.Sum(x => (x.GiaGoc * x.Quantity));
                    newDonHang.Quantity = cart.Items.Count();
                    newDonHang.Status = (int)Enums.statusConst.inProgress;
                    int resultdh = 0;
                    resultdh = await _datHangApiService.Creat(newDonHang);

                    //thêm mới thông tin đơn đặt hàng               
                    foreach (var item in cart.Items)
                    {
                        ThongTinDatHang newThongTinDatHang = new ThongTinDatHang();
                        newThongTinDatHang.DatHangId = resultdh;
                        newThongTinDatHang.SanPhamId = item.SanPhamId;
                        newThongTinDatHang.Gia = item.GiaGoc;
                        newThongTinDatHang.Quantity = item.Quantity;
                        int resultttdh = 0;
                        resultttdh = await _thongTinDatHangApiService.Creat(newThongTinDatHang);
                    }
                   
                    cart.ClearCart();
                    return RedirectToAction("CheckOutSuccess");
                }
            }
            return Json(code);
        } 

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AddToCart(int id, int quantity)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };
            //Lấy sản phẩm
            SanPham checkProduct =  await _sanPhamApiService.GetById(id);
            //Lấy ảnh sản phẩm
            AttachedFileRequest anhRequest = new AttachedFileRequest();
            anhRequest.ProductIds = id.ToString();
            anhRequest.FileGroupCode = ModuleConstants.SanPhamCode;
            List<AttachedFile> anhSanPham = await _attachedFileApiService.GetByGroupProduct(anhRequest);
            if (checkProduct != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart == null)
                {
                    cart = new ShoppingCart();
                }
                ShoppingCartItem item = new ShoppingCartItem
                {
                    SanPhamId = checkProduct.Id,
                    TenSanPham = checkProduct.TenSanPham,
                    TenDanhMucSP = checkProduct.TenDanhMucSP,
                    MaSanPham = checkProduct.MaSanPham,
                    Quantity = quantity
                };

                item.ProductImg = anhSanPham.FirstOrDefault().FilePath;

                item.GiaGoc = checkProduct.GiaGoc;
                item.TongTien = item.Quantity * item.GiaGoc;
                cart.AddToCart(item, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Thêm sản phẩm vào giở hàng thành công!", code = 1, Count = cart.Items.Count };
            }
            return Json(code);
        }
        [AllowAnonymous]
        public ActionResult Partial_Item_ThanhToan()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult Partial_Item_Cart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Update(int id, int quantity)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.UpdateQuantity(id, quantity);
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };

            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                var checkProduct = cart.Items.FirstOrDefault(x => x.SanPhamId == id);
                if (checkProduct != null)
                {
                    cart.Remove(id);
                    code = new { Success = true, msg = "", code = 1, Count = cart.Items.Count };
                }
            }
            return Json(code);
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult DeleteAll()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.ClearCart();
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
    }
}