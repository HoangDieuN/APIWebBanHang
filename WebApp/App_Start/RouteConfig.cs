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
            namespaces: new[] { "WebBanHangOnline.Controllers" }
            );

            //trang danh sách sản phẩm
            routes.MapRoute(
             name: "SanPham",
            url: "san-pham",
            defaults: new { controller = "SanPhams", action = "Index" },
            namespaces: new[] { "WebBanHangOnline.Controllers" }
            );
            //single page cho sản phẩm
            routes.MapRoute(
            name: "detailSanPham",
            url: "chi-tiet/{tensanpham}-p{id}",
            defaults: new { controller = "SanPhams", action = "SanPham_Detail"},
            namespaces: new[] { "WebBanHangOnline.Controllers" }
            );
            //giỏ hàng
            routes.MapRoute(
            name: "ShoppingCart",
            url: "gio-hang",
            defaults: new { controller = "ShoppingCart", action = "Index"},
            namespaces: new[] { "WebBanHangOnline.Controllers" }
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
