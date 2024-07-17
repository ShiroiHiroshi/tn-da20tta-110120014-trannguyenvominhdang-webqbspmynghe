using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuangBaMyNghe.Models;
using WebsiteQuangBaMyNghe.Models.EF;
using WebsiteQuangBaMyNghe.Common;
namespace WebsiteQuangBaMyNghe.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AdminLogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin Model)
        {
            var username = Model.TaiKhoan_AD;
            //var encryptedMd5Pas = Encryptor.EncryptMD5(Model.MatKhau_AD);
            //Model.MatKhau_AD = encryptedMd5Pas;
            var password = Model.MatKhau_AD;
            var usercheck = db.Admins.SingleOrDefault(x => x.TaiKhoan_AD.Equals(username) && x.MatKhau_AD.Equals(password));
            if (usercheck != null)
            {
                Session["admin"] = usercheck;
                return RedirectToAction("Index", "Admin/Home");
            }
            else
            {
                ViewBag.LoginFail = "Đăng nhập thất bại, vui lòng kiểm tra lại!";
                return View("AdminLogin");
            }
        }
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(KhachHang Model)
        {
            var TaiKhoan = Model.TaiKhoan_KH;
            var encryptedMd5Pas = Encryptor.EncryptMD5(Model.MatKhau_KH);
            Model.MatKhau_KH = encryptedMd5Pas;
            var MatKhau = Model.MatKhau_KH;
            var usercheck = db.KhachHangs.SingleOrDefault(x => x.TaiKhoan_KH.Equals(TaiKhoan) && x.MatKhau_KH.Equals(MatKhau));
            if (usercheck != null)
            {
                Session["user"] = usercheck;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginFail = "Đăng nhập thất bại, vui lòng kiểm tra lại!";
                return View("UserLogin");
            }
        }
        public ActionResult UserRegister()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserRegister(KhachHang model)
        {
            if (ModelState.IsValid)
            {
                var encryptedMd5Pas = Encryptor.EncryptMD5(model.MatKhau_KH);
                model.MatKhau_KH = encryptedMd5Pas;
                db.KhachHangs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            if (Session["user"] != null)
            {
                Session["user"] = null;
                GioHang cart = (GioHang)Session["Cart"];
                cart.ClearCart();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}