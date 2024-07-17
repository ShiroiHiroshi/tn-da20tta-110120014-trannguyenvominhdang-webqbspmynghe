using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuangBaMyNghe.Models;
using WebsiteQuangBaMyNghe.Models.EF;

namespace WebsiteQuangBaMyNghe.Areas.Admin.Controllers
{
    public class AnhSanPhamController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/AnhSanPham
        public ActionResult Index(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                ViewBag.MaSanPham = id;
                var items = db.AnhSanPhams.Where(x => x.MaSanPham == id).ToList();
                return View(items);
            }
        }
        [HttpPost]
        public ActionResult AddImage(int maSanPham, string url)
        {
            db.AnhSanPhams.Add(new AnhSanPham
            {
                MaSanPham = maSanPham,
                Image = url,
                IsDefault = false
            });
            db.SaveChanges();
            return Json(new { Success = true });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.AnhSanPhams.Find(id);
            db.AnhSanPhams.Remove(item);
            db.SaveChanges();
            return Json(new { success= true });
        }
    }
}