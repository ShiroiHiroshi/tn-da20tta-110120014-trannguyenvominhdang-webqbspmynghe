using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuangBaMyNghe.Models;
using WebsiteQuangBaMyNghe.Models.EF;

namespace WebsiteQuangBaMyNghe.Controllers
{
    public class BinhLuanController : Controller
    {
        // GET: BinhLuan
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _BinhLuan(int MaSanPham)
        {
            ViewBag.MaSanPham = MaSanPham;
            var user = Session["user"] as WebsiteQuangBaMyNghe.Models.EF.KhachHang;
            var items = new BinhLuan();
            if(user != null)
            {
                items.Ma_KH = user.Ma_KH;
            }    
            return PartialView(items);
        }
        [HttpPost]
        public ActionResult PostBinhLuan(BinhLuan req)
        {
            if (Session["user"] == null)
            {
                return RedirectToRoute("UserLogin");
            }
            else
            {
                var user = Session["user"] as WebsiteQuangBaMyNghe.Models.EF.KhachHang;
                if (ModelState.IsValid)
                {
                    req.Ma_KH = user.Ma_KH;
                    req.NgayTao = DateTime.Now;
                    db.BinhLuans.Add(req);
                    db.SaveChanges();
                    return Json(new { Success = true });
                }
                return Json(new { Success = false });
            }
        }
        public ActionResult _Load_Review(int MaSanPham)
        {
            var items = db.BinhLuans.Where(x=>x.MaSanPham== MaSanPham).OrderByDescending(x=>x.MaBL).ToList();
            ViewBag.Count= items.Count;
            return PartialView(items);
        }
    }
}