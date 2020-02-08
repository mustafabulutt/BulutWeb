using BulutWeb.Models.DBCONTEXT;
using BulutWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BulutWeb.Controllers
{
    public class AdminController : Controller
    {
        BulutDbContext db = new BulutDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Categorie= db.Category.Count();
            ViewBag.BlogPost = db.Blog.Count();
            ViewBag.Comments = db.Comments.Count();
            ViewBag.Messages = db.Message.Count();

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login = db.Admin.Where(x => x.Email == admin.Email).SingleOrDefault();
            if (login!=null)
            {
                if (login.Email==admin.Email && login.Password==admin.Password)
                {
                    Session["Adminıd"] = login.Id;
                    Session["Email"] = login.Email;
                    Session["Name"] = login.Name;
                    return RedirectToAction("Index", "Admin");
                }

            }
            ViewBag.uyari = "Kullanıcı adı ve şifrenizi kontrol edin";

            return View();
        }

        public ActionResult LogOut()
        {
            Session["Adminıd"] = null;
            Session["Email"] = null;
            Session["Name"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");

            
        }

    }
}