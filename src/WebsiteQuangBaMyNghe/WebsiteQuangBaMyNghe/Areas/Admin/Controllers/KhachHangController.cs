using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuangBaMyNghe.Models;

namespace WebsiteQuangBaMyNghe.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/KhachHang
        public ActionResult Index(int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                var items = db.KhachHangs.OrderBy(x => x.Ma_KH).ToList();
                if (page == null)
                {
                    page = 1;
                }
                var pageNumber = page ?? 1;
                var pageSize = 10;
                ViewBag.PageSize = pageSize;
                ViewBag.Page = pageNumber;
                return View(items.ToPagedList(pageNumber, pageSize));
            }
        }
        public ActionResult View(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                var items = db.KhachHangs.Find(id);
                return View(items);
            }
        }
    }
}