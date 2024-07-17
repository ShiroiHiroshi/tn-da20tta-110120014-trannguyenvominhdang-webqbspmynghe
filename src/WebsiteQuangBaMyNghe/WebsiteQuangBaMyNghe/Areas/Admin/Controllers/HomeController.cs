using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteQuangBaMyNghe.Models;

namespace WebsiteQuangBaMyNghe.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Home
        public ActionResult Index()
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
        public ActionResult AdminLogout()
        {
            if (Session["admin"] != null)
            {
                Session["admin"] = null;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}