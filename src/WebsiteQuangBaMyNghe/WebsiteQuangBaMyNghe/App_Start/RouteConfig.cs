using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebsiteQuangBaMyNghe
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "SanPham",
                url: "san-pham",
                defaults: new { controller = "SanPham", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "WebsiteQuangBaMyNghe.Controllers" }
            );
            routes.MapRoute(
                name: "AdminLogin",
                url: "admin-login",
                defaults: new { controller = "Home", action = "AdminLogin", alias = UrlParameter.Optional },
                namespaces: new[] { "WebsiteQuangBaMyNghe.Controllers" }
            );
            routes.MapRoute(
                name: "UserLogin",
                url: "user-login",
                defaults: new { controller = "Home", action = "UserLogin", alias = UrlParameter.Optional },
                namespaces: new[] { "WebsiteQuangBaMyNghe.Controllers" }
            );
            routes.MapRoute(
                name: "Logout",
                url: "user-logout",
                defaults: new { controller = "Home", action = "Logout", alias = UrlParameter.Optional },
                namespaces: new[] { "WebsiteQuangBaMyNghe.Controllers" }
            );
            routes.MapRoute(
                name: "AdLogout",
                url: "admin-logout",
                defaults: new { controller = "Home", action = "AdminLogout", alias = UrlParameter.Optional },
                namespaces: new[] { "WebsiteQuangBaMyNghe.Areas.Admin.Controllers" }
            );
            routes.MapRoute(
                name: "UserRegister",
                url: "user-register",
                defaults: new { controller = "Home", action = "UserRegister", alias = UrlParameter.Optional },
                namespaces: new[] { "WebsiteQuangBaMyNghe.Controllers" }
            );
            routes.MapRoute(
                name: "ThongTinSanPham",
                url: "chi-tiet/{alias}-p{id}",
                defaults: new { controller = "SanPham", action = "Detail", alias = UrlParameter.Optional },
                namespaces: new[] { "WebsiteQuangBaMyNghe.Controllers" }
            );
            routes.MapRoute(
                name: "DanhMucSanPham",
                url: "danh-muc-san-pham/{Alias}-{id}",
                defaults: new { controller = "SanPham", action = "DanhMucSanPham", alias = UrlParameter.Optional },
                namespaces: new[] { "WebsiteQuangBaMyNghe.Controllers" }
            );
            routes.MapRoute(
                name: "GioHang",
                url: "gio-hang",
                defaults: new { controller = "GioHang", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "WebsiteQuangBaMyNghe.Controllers" }
            );
            routes.MapRoute(
                name: "CheckOut",
                url: "thanh-toan",
                defaults: new { controller = "GioHang", action = "CheckOut", alias = UrlParameter.Optional },
                namespaces: new[] { "WebsiteQuangBaMyNghe.Controllers" }
            );
            routes.MapRoute(
                name: "LienHe",
                url: "lien-he",
                defaults: new { controller = "LienHe", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "WebsiteQuangBaMyNghe.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"WebsiteQuangBaMyNghe.Controllers"}
            );
        }
    }
}
