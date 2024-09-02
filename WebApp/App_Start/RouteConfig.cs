using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //router danh mục sản phẩm
            routes.MapRoute(
             name: "DMSanPham",
            url: "danh-muc-san-pham/{id}",
            defaults: new { controller = "DMSanPhams", action = "DanhSachSanPhamByDanhMucId" },
            namespaces: new[] { "WebApp.Controllers" }
            );

            //trang danh sách sản phẩm
            routes.MapRoute(
             name: "SanPham",
            url: "san-pham",
            defaults: new { controller = "SanPhams", action = "Index" },
            namespaces: new[] { "WebApp.Controllers" }
            );
            //single page cho sản phẩm
            routes.MapRoute(
            name: "detailSanPham",
            url: "chi-tiet/{tensanpham}-p{id}",
            defaults: new { controller = "SanPhams", action = "SanPham_Detail"},
            namespaces: new[] { "WebApp.Controllers" }
            );
            routes.MapRoute(
             name: "Contact",
             url: "lien-he",
             defaults: new { controller = "LienHe", action = "Index" },
             namespaces: new[] { "WebBanHangOnline.Controllers" }
            );
            //giới thiệu
            routes.MapRoute(
            name: "GioiThieu",
            url: "gioi-thieu",
            defaults: new { controller = "GioiThieu", action = "Index", alias = UrlParameter.Optional },
            namespaces: new[] { "WebBanHangOnline.Controllers" }
            );
            //chi tiết bài viết
            routes.MapRoute(
            name: "detailBaiViet",
            url: "chi-tiet/bai-viet-{id}",
            defaults: new { controller = "BaiViets", action = "BaiViet_Detail" },
            namespaces: new[] { "WebApp.Controllers" }
           );
            //thanh toán
            routes.MapRoute(
            name: "CheckOut",
            url: "thanh-toan",
            defaults: new { controller = "ShoppingCart", action = "CheckOut" },
            namespaces: new[] { "WebApp.Controllers" }
            );
            //giỏ hàng
            routes.MapRoute(
            name: "ShoppingCart",
            url: "gio-hang",
            defaults: new { controller = "ShoppingCart", action = "Index"},
            namespaces: new[] { "WebApp.Controllers" }
            );
            //bài viết
            routes.MapRoute(
            name: "BaiVietsList",
            url: "bai-viet",
            defaults: new { controller = "BaiViets", action = "Index"},
            namespaces: new[] { "WebApp.Controllers" }
            );
            routes.MapRoute(
            "Default",
            "{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            new[] { "WebApp.Controllers" }
);
        }
    }
}
