using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuangBaMyNghe.Models;
using PagedList;

namespace WebsiteQuangBaMyNghe.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/DonHang
        public ActionResult Index(int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                var items = db.DonHangs.OrderByDescending(x => x.NgayDatDH).ToList();
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
                var items = db.DonHangs.Find(id);
                return View(items);
            }    
        }
        public ActionResult Partial_SanPham(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                var items = db.ChiTietDonHangs.Where(x => x.MaDonHang == id).ToList();
                return PartialView(items);
            }
        }
        [HttpPost]
        public ActionResult UpdateTrangThai(int id, int trangthai)
        {
            var item = db.DonHangs.Find(id);
            if(item != null) 
            {
                db.DonHangs.Attach(item);
                item.TrangThaiDH = trangthai;
                db.Entry(item).Property(x=>x.TrangThaiDH).IsModified = true;
                db.SaveChanges();
                return Json(new {message= "Cập nhật thành công", Success =true});
            }
            return Json(new { message = "Cập nhật thất bại", Success = false });
        }
    }
}