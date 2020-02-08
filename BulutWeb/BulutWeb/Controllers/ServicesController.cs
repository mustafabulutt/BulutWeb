using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BulutWeb.Models.DBCONTEXT;
using BulutWeb.Models.Model;

namespace BulutWeb.Controllers
{
    public class ServicesController : Controller
    {
        private BulutDbContext db = new BulutDbContext();

        // GET: Services
        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }

        
       

        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create( Services services, HttpPostedFileBase Image)
        {
            if (Image!=null)
            {

           

            if (ModelState.IsValid)
            {
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo imginfo = new FileInfo(Image.FileName);
                    string nm = Image.FileName + imginfo.Extension;
                    img.Resize(600, 400);
                    img.Save("~/Uploads/Services/" + nm);

                    string a = "/Uploads/Services/" + nm;

                    services.Image = a;

                db.Services.Add(services);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            return View(services);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = db.Services.Find(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Services services,HttpPostedFileBase Image)
        {


            if (ModelState.IsValid)
            {
                var seedit = db.Services.Where(x => x.Id == id).FirstOrDefault();
                if (Image != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(seedit.Image)))
                    {
                        System.IO.File.Delete(Server.MapPath(seedit.Image));
                    }
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo imginfo = new FileInfo(Image.FileName);
                    string nm = Image.FileName + imginfo.Extension;
                    img.Resize(600, 400);
                    img.Save("~/Uploads/Services/" + nm);

                    seedit.Image = "/Uploads/Services/" + nm;
                }
                seedit.Id = services.Id;
                seedit.Title = services.Title;
                seedit.Description = services.Description;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(services);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = db.Services.Find(id);
            if (services == null)
            {
                return HttpNotFound();
            }

            if (System.IO.File.Exists(Server.MapPath(services.Image)))
            {
                System.IO.File.Delete(Server.MapPath(services.Image));
            }


            db.Services.Remove(services);
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
