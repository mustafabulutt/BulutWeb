using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BulutWeb.Models.DBCONTEXT;
using BulutWeb.Models.Model;

namespace BulutWeb.Controllers
{
    public class UserController : Controller
    {
        private BulutDbContext db = new BulutDbContext();

        // GET: User
        public ActionResult Index()
        {
            return View(db.Admin.ToList());
        }

      

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Password")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                admin.Id = Guid.NewGuid();
                db.Admin.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: User/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Admin admin, string OldPass)
        {
            
            
            var pass = db.Admin.Find(admin.Id).Password.ToString();
            var admins = db.Admin.Where(x => x.Id == admin.Id).SingleOrDefault();
            
            if (pass == OldPass)
            {

            if (ModelState.IsValid)
            {
                    admins.Id = admin.Id;
                    admins.Name = admin.Name;
                    admins.Password = admin.Password;
                    admins.Email = admin.Email;

                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            if (pass != OldPass)
            {
                ViewBag.Hata = "Eski Şifre Hatalı";
            }
           
            return View(admin);
        }

        
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admin.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            
            db.Admin.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
