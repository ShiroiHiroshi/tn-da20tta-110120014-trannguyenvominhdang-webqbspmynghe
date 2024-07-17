using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebsiteQuangBaMyNghe.Models;
using WebsiteQuangBaMyNghe.Models.EF;

namespace WebsiteQuangBaMyNghe.Controllers
{
    public class GioHangController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: GioHang
        public List<GioHangSanPham> Items { get; set; }
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToRoute("UserLogin");
            }
            else
            {
                GioHang cart = (GioHang)Session["Cart"];
                if (cart != null && cart.Items.Any())
                {
                    ViewBag.CheckCart = cart;
                }
                return View();
            }
        }
        public ActionResult ShowCount()
        {
            GioHang cart = (GioHang)Session["Cart"];
            if (cart != null)
            {
                return Json(new { Count = cart.Items.Count }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Count = 0 }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Partial_Item_GioHang()
        {
            GioHang cart = (GioHang)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }
        public ActionResult CheckOut()
        {
            if (Session["user"] == null)
            {
                return RedirectToRoute("UserLogin");
            }
            else
            {
                GioHang cart = (GioHang)Session["Cart"];
                if (cart != null && cart.Items.Any())
                {
                    ViewBag.CheckCart = cart;
                }
                return View();
            }
        }
        public ActionResult CheckOutSuccess()
        {
            if (Session["user"] == null)
            {
                return RedirectToRoute("UserLogin");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(OrderViewModel req)
        {
            var user = Session["user"] as WebsiteQuangBaMyNghe.Models.EF.KhachHang;
            var code = new { Success = false, Code = -1 };
            if (ModelState.IsValid)
            {
                GioHang cart = (GioHang)Session["Cart"];
                if (cart != null)
                {
                    DonHang donHang = new DonHang();
                    donHang.Ma_KH = user.Ma_KH;
                    donHang.HoTen = req.TenKhachHang;
                    donHang.SoDienThoai = req.DienThoai;
                    donHang.DiaChi = req.DiaChi;
                    donHang.Email = req.Email;
                    cart.Items.ForEach(x => donHang.ChiTietDonHangs.Add(new ChiTietDonHang
                    {
                        MaSanPham = x.ProductId,
                        Soluong = x.Quantity,
                        Gia = x.Price
                    }));
                    donHang.ThanhTienDH = cart.Items.Sum(x => (x.Price * x.Quantity));
                    donHang.NgayDatDH = DateTime.Now;
                    donHang.SoLuong = cart.Items.Sum(x => (x.Quantity));
                    donHang.PhuongThucThanhToan = req.PhuongThucThanhToan;
                    donHang.TrangThaiDH = req.TrangThaiDH;
                    db.DonHangs.Add(donHang);
                    db.SaveChanges();
                    cart.ClearCart();
                    return RedirectToAction("CheckOutSuccess");
                }
             }
            return Json(code);
        }
        public ActionResult Partial_Item_ThanhToan()
        {
            GioHang cart = (GioHang)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }
        public ActionResult Partial_CheckOut()
        {
                return PartialView();
        }
        [HttpPost]
        public ActionResult AddToCart(int id, int quantity)
        {
            if (Session["user"] == null)
            {
                return RedirectToRoute("UserLogin");
            }
            else
            {
                var code = new { Success = false, msg = "", code = -1, Count = 0 };
                var db = new ApplicationDbContext();
                var checkProduct = db.SanPhams.FirstOrDefault(x => x.MaSanPham == id);
                if (checkProduct != null)
                {
                    GioHang cart = (GioHang)Session["Cart"];
                    if (cart == null)
                    {
                        cart = new GioHang();
                    }
                    GioHangSanPham item = new GioHangSanPham
                    {
                        ProductId = checkProduct.MaSanPham,
                        ProductName = checkProduct.TenSanPham,
                        CategoryName = checkProduct.DanhMuc.TenDanhMuc,
                        Alias = checkProduct.Alias,
                        Quantity = quantity
                    };
                    if (checkProduct.AnhSanPhams.FirstOrDefault(x => x.IsDefault) != null)
                    {
                        item.ProductImg = checkProduct.AnhSanPhams.FirstOrDefault(x => x.IsDefault).Image;
                    }
                    item.Price = checkProduct.Gia;
                    if (checkProduct.GiaKhuyenMai > 0)
                    {
                        item.Price = (decimal)checkProduct.GiaKhuyenMai;
                    }
                    item.TotalPrice = item.Quantity * item.Price;
                    cart.AddToCart(item, quantity);
                    Session["Cart"] = cart;
                    code = new { Success = true, msg = "Thêm sản phẩm vào giở hàng thành công!", code = 1, Count = cart.Items.Count };
                }
                return Json(code);
            }
        }

        [HttpPost]
        public ActionResult Update(int id, int quantity)
        {
            GioHang cart = (GioHang)Session["Cart"];
            if (cart != null)
            {
                cart.UpdateQuantity(id, quantity);
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var code = new { Success = false, msg = "", code = -1, Count = 0 };

            GioHang cart = (GioHang)Session["Cart"];
            if (cart != null)
            {
                var checkProduct = cart.Items.FirstOrDefault(x => x.ProductId == id);
                if (checkProduct != null)
                {
                    cart.Remove(id);
                    code = new { Success = true, msg = "", code = 1, Count = cart.Items.Count };
                }
            }
            return Json(code);
        }
        [HttpPost]
        public ActionResult DeleteAll()
        {
            GioHang cart = (GioHang)Session["Cart"];
            if (cart != null)
            {
                cart.ClearCart();
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
    }

}