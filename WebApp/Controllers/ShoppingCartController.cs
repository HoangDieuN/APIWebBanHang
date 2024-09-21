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
        private readonly ITrangThaiApiService _trangThaiApiService;
        public ShoppingCartController(ISanPhamApiService sanPhamApiService, IAttachedFileApiService attachedFileApiService,
            IDatHangApiService datHangApiService, IThongTinDatHangApiService thongTinDatHangApiService, ITrangThaiApiService trangThaiApiService)
        {
            _sanPhamApiService = sanPhamApiService;
            _attachedFileApiService = attachedFileApiService;
            _datHangApiService = datHangApiService;
            _thongTinDatHangApiService = thongTinDatHangApiService;
            _trangThaiApiService = trangThaiApiService;
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
            var user = Session["User"] as User;
            return PartialView();
        }

        public ActionResult ResultVNPay()
        {
            if (Request.QueryString.Count > 0)
            {
                string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"]; 
                var vnpayData = Request.QueryString;
                VnPayLibrary vnpay = new VnPayLibrary();

                foreach (string s in vnpayData)
                {
                    //get all querystring data
                    if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                    {
                        vnpay.AddResponseData(s, vnpayData[s]);
                    }
                }
                string donHangCode = Convert.ToString(vnpay.GetResponseData("vnp_TxnRef"));
                long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
                string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
                string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");
                String vnp_SecureHash = Request.QueryString["vnp_SecureHash"];
                String TerminalID = Request.QueryString["vnp_TmnCode"];
                long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
                String bankCode = Request.QueryString["vnp_BankCode"];

                bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, vnp_HashSecret);
                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                    {
                        //Thanh toan thanh cong
                        ViewBag.InnerText = "Giao dịch được thực hiện thành công. Cảm ơn quý khách đã sử dụng dịch vụ";
                    }
                    else
                    {
            
                    }
                
                    ViewBag.ThanhToanThanhCong = "Số tiền thanh toán (VND):" + vnp_Amount.ToString();
                }
            }
                return View();
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
            var code = new { Success = false, Code = -1, Url = "" };
            if (ModelState.IsValid)
            {
                var user = Session["User"] as User;
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart != null && cart.Items.Any())
                {
                    //thêm mới đơn đặt hàng             
                    DatHang newDonHang = new DatHang();
                    // Nếu người dùng đã đăng nhập
                    if (user != null)
                    {
                        newDonHang.TenKhachHang = user.HoTen;
                        newDonHang.UserId = user.Id;
                        newDonHang.Email = user.Email;
                    }
                    else
                    {
                        newDonHang.TenKhachHang = requestModel.HoTen;
                        newDonHang.Email = requestModel.Email;
                    }
                    newDonHang.SoDT = requestModel.SoDT;
                    newDonHang.DiaChi = requestModel.DiaChi;
                    Guid newMa = Guid.NewGuid();
                    newDonHang.MaDon = newMa.ToString();

                    newDonHang.TongDon = cart.Items.Sum(x => (x.GiaGoc * x.Quantity));
                    newDonHang.Quantity = cart.Items.Count();
                    newDonHang.Status = (int)Enums.statusConst.inProgress;
                    newDonHang.CreatedDate = DateTime.Now;
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
                    //tạo session đơn hàng
                    if (resultdh > 0)
                    {
                        newDonHang.Id = resultdh;
                        SessionControl.AddNormalSession(CommonConstants.DonHang, newDonHang, 400);

                    }
                    //send mail cho khách hàng
                    var strSanPham = "";
                    var thanhtien = 0.0f;
                    var TongTien = 0.0f;
                    foreach (var sp in cart.Items)
                    {
                        strSanPham += "<tr>";
                        strSanPham += "<td>" + sp.TenSanPham + "</td>";
                        strSanPham += "<td>" + sp.Quantity + "</td>";
                        strSanPham += "<td>" + FomartNumber.FormatNumber(sp.TongTien, 0) + "</td>";
                        strSanPham += "</tr>";
                        thanhtien += sp.GiaGoc * sp.Quantity;
                    }
                    TongTien = thanhtien;
                    string contentCustomer = System.IO.File.ReadAllText(Server.MapPath("~/Content/templates/send2.html"));
                    contentCustomer = contentCustomer.Replace("{{MaDon}}", newDonHang.MaDon);
                    contentCustomer = contentCustomer.Replace("{{SanPham}}", strSanPham);
                    contentCustomer = contentCustomer.Replace("{{NgayDat}}", DateTime.Now.ToString("dd/MM/yyyy"));
                    contentCustomer = contentCustomer.Replace("{{TenKhachHang}}", newDonHang.TenKhachHang);
                    contentCustomer = contentCustomer.Replace("{{Phone}}", newDonHang.SoDT);
                    contentCustomer = contentCustomer.Replace("{{Email}}", newDonHang.Email);
                    contentCustomer = contentCustomer.Replace("{{DiaChiNhanHang}}", newDonHang.DiaChi);
                    contentCustomer = contentCustomer.Replace("{{ThanhTien}}", FomartNumber.FormatNumber(thanhtien, 0));
                    contentCustomer = contentCustomer.Replace("{{TongTien}}", FomartNumber.FormatNumber(TongTien, 0));
                    //EmailHelper2.SendMail("HD ShopOnline", "Đơn hàng #" + newDonHang.MaDon, contentCustomer.ToString(), newDonHang.Email);
                    cart.ClearCart();
                    code = new { Success = true, Code = 1, Url = "" };
                    if (requestModel.TypePayment == 2)
                    {
                        var url = UrlPayMent(requestModel.TypePaymentVN, newDonHang.MaDon);
                        code = new { Success = true, Code = 2, Url = url };
                        TrangThaiRequest requestTTOnlike = new TrangThaiRequest();
                        requestTTOnlike.DatHangId = resultdh;
                        requestTTOnlike.StatusId = 1;
                        int resultupdate = 0;
                        resultupdate = await _trangThaiApiService.UpdateTrangThai(requestTTOnlike);
                    }
                }
            }
            return Json(code);
        }
        #region Thanh toán VNPay
        public string UrlPayMent(int TypePaymentVN, string donHangCode)
        {
            var urlPayment = "";
            //Get Config Info
            string vnp_Returnurl = ConfigurationManager.AppSettings["vnp_Returnurl"];
            string vnp_Url = ConfigurationManager.AppSettings["vnp_Url"];
            string vnp_TmnCode = ConfigurationManager.AppSettings["vnp_TmnCode"];
            string vnp_HashSecret = ConfigurationManager.AppSettings["vnp_HashSecret"];

            //Get payment input
            DatHang order = (DatHang)Session["DonHang"];
            //Save order to db

            //Build URL for VNPAY
            VnPayLibrary vnpay = new VnPayLibrary();

            long price = (long)order.TongDon;
            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (price * 100).ToString());

            if (TypePaymentVN == 1)
            {
                vnpay.AddRequestData("vnp_BankCode", "VNPAYQR");
            }
            else if (TypePaymentVN == 2)
            {
                vnpay.AddRequestData("vnp_BankCode", "VNBANK");
            }
            else if (TypePaymentVN == 3)
            {
                vnpay.AddRequestData("vnp_BankCode", "INTCARD");
            }
            vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate?.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());
            vnpay.AddRequestData("vnp_Locale", "vn");
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + order.MaDon);
            vnpay.AddRequestData("vnp_OrderType", "other"); 
            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", order.MaDon.ToString()); 

            urlPayment = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);

            return urlPayment;
        }
        #endregion Thanh toán VNPay
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AddToCart(int id, int quantity)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };
            //Lấy sản phẩm
            SanPham checkProduct = await _sanPhamApiService.GetById(id);
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
                if (checkProduct.PhanTramGiam > 0)
                {
                    item.GiaGoc = checkProduct.PhanTramGiam;
                }
                else
                {
                    item.GiaGoc = checkProduct.GiaGoc;
                }
                item.TongTien = item.Quantity * item.GiaGoc;
                cart.AddToCart(item, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Thêm sản phẩm vào giỏ hàng thành công!", code = 1, Count = cart.Items.Count };
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