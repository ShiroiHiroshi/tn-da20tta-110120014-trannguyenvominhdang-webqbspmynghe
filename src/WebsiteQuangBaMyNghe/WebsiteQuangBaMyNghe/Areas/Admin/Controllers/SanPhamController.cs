using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebsiteQuangBaMyNghe.Models;
using WebsiteQuangBaMyNghe.Models.EF;

namespace WebsiteQuangBaMyNghe.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/SanPham
        public ActionResult Index(string Searchtext, int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                IEnumerable<SanPham> items = db.SanPhams.OrderByDescending(x => x.MaSanPham);
                var pageSize = 10;
                if (page == null)
                {
                    page = 1;
                }
                if (!string.IsNullOrEmpty(Searchtext))
                {
                    items = items.Where(x => x.TenSanPham.Contains(Searchtext));
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
                ViewBag.DanhMuc = new SelectList(db.DanhMucs.ToList(), "MaDanhMuc", "TenDanhMuc");
                ViewBag.DiaPhuong = new SelectList(db.DiaPhuongs.ToList(), "MaDiaPhuong", "TenDiaPhuong");
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SanPham model, List<string> Images, List<int> rDefault)
        {
            if (ModelState.IsValid)
            {
                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        if (i + 1 == rDefault[0])
                        {
                            model.Image = Images[i];
                            model.AnhSanPhams.Add(new AnhSanPham
                            {
                                MaSanPham = model.MaSanPham,
                                Image = Images[i],
                                IsDefault = true
                            });
                        }
                        else
                        {
                            model.AnhSanPhams.Add(new AnhSanPham
                            {
                                MaSanPham = model.MaSanPham,
                                Image = Images[i],
                                IsDefault = false
                            });
                        }
                    }
                }
                model.Alias = WebsiteQuangBaMyNghe.Models.Common.Filter.FilterChar(model.TenSanPham);
                db.SanPhams.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DanhMuc = new SelectList(db.DanhMucs.ToList(), "MaDanhMuc", "TenDanhMuc");
            ViewBag.DiaPhuong = new SelectList(db.DiaPhuongs.ToList(), "MaDiaPhuong", "TenDiaPhuong");
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            if (Session["admin"] == null)
            {
                return RedirectToRoute("AdminLogin");
            }
            else
            {
                ViewBag.DanhMuc = new SelectList(db.DanhMucs.ToList(), "MaDanhMuc", "TenDanhMuc");
                ViewBag.DiaPhuong = new SelectList(db.DiaPhuongs.ToList(), "MaDiaPhuong", "TenDiaPhuong");
                var item = db.SanPhams.Find(id);
                return View(item);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanPham model)
        {
            if(ModelState.IsValid)
            {
                db.SanPhams.Attach(model);
                model.Alias = WebsiteQuangBaMyNghe.Models.Common.Filter.FilterChar(model.TenSanPham);
                db.Entry(model).Property(x => x.SoLuong).IsModified = true;
                db.Entry(model).Property(x => x.TenSanPham).IsModified = true;
                db.Entry(model).Property(x => x.MoTaSanPham).IsModified = true;
                db.Entry(model).Property(x => x.ThongTinSanPham).IsModified = true;
                db.Entry(model).Property(x => x.IsActive).IsModified = true;
                db.Entry(model).Property(x => x.IsHot).IsModified = true;
                db.Entry(model).Property(x => x.IsSale).IsModified = true;
                db.Entry(model).Property(x => x.Gia).IsModified = true;
                db.Entry(model).Property(x => x.GiaKhuyenMai).IsModified = true;
                db.Entry(model).Property(x => x.MaDiaPhuong).IsModified = true;
                db.Entry(model).Property(x => x.MaDanhMuc).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DanhMuc = new SelectList(db.DanhMucs.ToList(), "MaDanhMuc", "TenDanhMuc");
            ViewBag.DiaPhuong = new SelectList(db.DiaPhuongs.ToList(), "MaDiaPhuong", "TenDiaPhuong");
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.SanPhams.Find(id);
            if (item != null)
            {
                var checkImg = item.AnhSanPhams.Where(x => x.MaSanPham == item.MaSanPham);
                if (checkImg != null)
                {
                    foreach (var img in checkImg)
                    {
                        db.AnhSanPhams.Remove(img);
                        db.SaveChanges();
                    }
                }
                db.SanPhams.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.SanPhams.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isAcive = item.IsActive });
            }

            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsSale(int id)
        {
            var item = db.SanPhams.Find(id);
            if (item != null)
            {
                item.IsSale = !item.IsSale;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, IsSale = item.IsSale });
            }
            return Json(new { success = false });
        }
    }
}