using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebsiteQuangBaMyNghe.Models;
using WebsiteQuangBaMyNghe.Models.EF;

namespace WebsiteQuangBaMyNghe.Areas.Admin.Controllers
{
    public class DiaPhuongController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/DiaPhuong
        public ActionResult Index(string Searchtext, int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                IEnumerable<DiaPhuong> items = db.DiaPhuongs.OrderByDescending(x => x.MaDiaPhuong);
                var pageSize = 10;
                if (page == null)
                {
                    page = 1;
                }
                if (!string.IsNullOrEmpty(Searchtext))
                {
                    items = items.Where(x => x.TenDiaPhuong.Contains(Searchtext));
                }
                var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                items = items.ToPagedList(pageIndex, pageSize);
                ViewBag.PageSize = pageSize;
                ViewBag.Page = page;
                return View(items);
            }
        }
        public ActionResult Add()
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                return View();
            }   
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DiaPhuong model)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.DiaPhuongs.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }    
        }
        public ActionResult Edit(string id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                var item = db.DiaPhuongs.Find(id);
                return View(item);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DiaPhuong model)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.DiaPhuongs.Attach(model);
                    db.Entry(model).Property(x => x.MaDiaPhuong).IsModified = true;
                    db.Entry(model).Property(x => x.TenDiaPhuong).IsModified = true;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                var item = db.DiaPhuongs.Find(id);
                if (item != null)
                {
                    db.DiaPhuongs.Remove(item);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            } 
        }
    }
}