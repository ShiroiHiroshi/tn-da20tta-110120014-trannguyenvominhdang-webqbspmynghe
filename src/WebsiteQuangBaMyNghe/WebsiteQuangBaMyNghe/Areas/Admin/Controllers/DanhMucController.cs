using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using WebsiteQuangBaMyNghe.Models;
using WebsiteQuangBaMyNghe.Models.EF;
using WebsiteQuangBaMyNghe.Models.Common;

namespace WebsiteQuangBaMyNghe.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/DanhMuc
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                var items = db.DanhMucs;
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
        public ActionResult Add(DanhMuc model)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    model.Alias = WebsiteQuangBaMyNghe.Models.Common.Filter.FilterChar(model.TenDanhMuc);
                    db.DanhMucs.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }    
        }
        public ActionResult Edit(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                var item = db.DanhMucs.Find(id);
                return View(item);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DanhMuc model)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.DanhMucs.Attach(model);
                    model.Alias = WebsiteQuangBaMyNghe.Models.Common.Filter.FilterChar(model.TenDanhMuc);
                    db.Entry(model).Property(x => x.TenDanhMuc).IsModified = true;
                    db.Entry(model).Property(x => x.MoTaDanhMuc).IsModified = true;
                    db.Entry(model).Property(x => x.Icon).IsModified = true;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                var item = db.DanhMucs.Find(id);
                if (item != null)
                {
                    db.DanhMucs.Remove(item);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
                return Json(new { success = false });
            }
        }
    }
}