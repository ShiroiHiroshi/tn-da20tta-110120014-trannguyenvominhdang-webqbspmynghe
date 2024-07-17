using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuangBaMyNghe.Models;

namespace WebsiteQuangBaMyNghe.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext(); 
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuDanhMucSanPham()
        {
            var items = db.DanhMucs.ToList();
            return PartialView("_MenuDanhMucSanPham", items);
        }
        public ActionResult MenuSanPham()
        {
            var items = db.DanhMucs.ToList();
            return PartialView("_MenuSanPham", items);
        }
        public ActionResult MenuLeft(int? id)
        {
            if(id!= null)
            {
                ViewBag.CateId = id;
            }
            var items = db.DanhMucs.ToList();
            return PartialView("_MenuLeft", items);
        }
        public ActionResult MenuDiaPhuong(int? id)
        {
            if (id != null)
            {
                ViewBag.DiaPhuongId = id;
            }
            var items = db.DiaPhuongs.ToList();
            return PartialView("_MenuDiaPhuong", items);
        }
    }
}