using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuangBaMyNghe.Models;

namespace WebsiteQuangBaMyNghe.Controllers
{
    public class SanPhamController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: SanPham
        public ActionResult Index()
        {
            var items = db.SanPhams.ToList();
            var diaPhuongList = db.DiaPhuongs.Select(dp => dp.TenDiaPhuong).ToList(); // Lấy danh sách tên địa phương từ cơ sở dữ liệu
            ViewBag.DiaPhuongList = diaPhuongList;
            return View(items);
        }
        public ActionResult Detail(string alias, int id)
        {
            var item = db.SanPhams.Find(id);
            var countBL= db.BinhLuans.Where(x=>x.MaSanPham == id).Count();
            ViewBag.CountBL = countBL;
            return View(item);
        }
        //public ActionResult DanhMucSanPham(string alias, int? id)
        //{
        //    var items = db.SanPhams.ToList();
        //    var diaPhuongList = db.DiaPhuongs.Select(dp => dp.TenDiaPhuong).ToList(); // Lấy danh sách tên địa phương từ cơ sở dữ liệu
        //    ViewBag.DiaPhuongList = diaPhuongList;
        //    if (id > 0)
        //    {
        //        items = items.Where(x => x.MaDanhMuc == id).ToList();
        //    }
        //    var cate = db.DanhMucs.Find(id);
        //    if (cate != null)
        //    {
        //        ViewBag.CateName = cate.TenDanhMuc;
        //    }
        //    ViewBag.CateId = id;
        //    return View(items);
        //}
        public ActionResult DanhMucSanPham(string alias, int? id, string diaPhuong)
        {
            var items = db.SanPhams.AsQueryable();

            if (id > 0)
            {
                items = items.Where(x => x.MaDanhMuc == id);
            }

            if (!string.IsNullOrEmpty(diaPhuong))
            {
                items = items.Where(sp => sp.DiaPhuong.TenDiaPhuong == diaPhuong);
            }

            var diaPhuongList = db.DiaPhuongs.Select(dp => dp.TenDiaPhuong).ToList();
            ViewBag.DiaPhuongList = diaPhuongList;

            var cate = db.DanhMucs.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.TenDanhMuc;
            }
            ViewBag.CateId = id;
            ViewBag.SelectedDiaPhuong = diaPhuong;

            return View(items.ToList());
        }
        public ActionResult Partial_FilterDanhMuc()
        {
            var items = db.SanPhams.Where(x=> x.IsActive).Take(12).ToList();
            return PartialView(items);
        }
        public ActionResult Partial_FilterSanPhamSale()
        {
            var items = db.SanPhams.Where(x => x.IsSale).Take(12).ToList();
            return PartialView(items);
        }
        public ActionResult FilterByDiaPhuong(string diaPhuong)
        {
            var items = db.SanPhams.Where(sp => sp.DiaPhuong.TenDiaPhuong == diaPhuong).ToList();
            ViewBag.SelectedDiaPhuong = diaPhuong;
            var diaPhuongList = db.DiaPhuongs.Select(dp => dp.TenDiaPhuong).ToList();
            ViewBag.DiaPhuongList = diaPhuongList;
            return View("Index", items);
        }
        //public ActionResult FilterProductsByDiaPhuong(string diaPhuongs)
        //{
        //    var diaPhuongIds = diaPhuongs.Split(',').ToList();
        //    var products = db.SanPhams.Where(p => diaPhuongIds.Contains(p.MaDiaPhuong)).Take(12).ToList();

        //    return PartialView("_ProductGrid", products);
        //}
        public ActionResult FilterByDanhMucAndDiaPhuong(int? id, string diaPhuong)
        {
            var items = db.SanPhams.AsQueryable();

            if (id > 0)
            {
                items = items.Where(x => x.MaDanhMuc == id);
            }

            if (!string.IsNullOrEmpty(diaPhuong))
            {
                items = items.Where(sp => sp.DiaPhuong.TenDiaPhuong == diaPhuong);
            }

            var diaPhuongList = db.DiaPhuongs.Select(dp => dp.TenDiaPhuong).ToList();
            ViewBag.DiaPhuongList = diaPhuongList;
            ViewBag.SelectedDiaPhuong = diaPhuong;

            var cate = db.DanhMucs.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.TenDanhMuc;
            }
            ViewBag.CateId = id;

            return View("DanhMucSanPham", items.ToList());
        }
    }
}