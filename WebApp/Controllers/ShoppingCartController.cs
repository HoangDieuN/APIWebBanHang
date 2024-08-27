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
        public ShoppingCartController(ISanPhamApiService sanPhamApiService,IAttachedFileApiService attachedFileApiService)
        {
            _sanPhamApiService = sanPhamApiService;
            _attachedFileApiService = attachedFileApiService;
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