using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuangBaMyNghe.Models;
using WebsiteQuangBaMyNghe.Models.EF;

namespace WebsiteQuangBaMyNghe.Controllers
{
    public class KhachHangController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: KhachHang
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToRoute("UserLogin");
            }
            else
            {
                return View();
            }       
        }
    }
}