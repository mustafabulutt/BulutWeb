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
    public class ReferanceController : Controller
    {
        private BulutDbContext db = new BulutDbContext();

        // GET: Referance
        public ActionResult Index()
        {
            return View(db.Referances.ToList());
        }

        // GET: Referance/Details/5
        

        // GET: Referance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Referance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Referances referances , HttpPostedFileBase Image)
        {
            if (Image!=null)
            {

          

            if (ModelState.IsValid)
            {
                WebImage img = new WebImage(Image.InputStream);
                FileInfo imginfo = new FileInfo(Image.FileName);
                string nm = Image.FileName + imginfo.Extension;
                img.Resize(600, 400);
                img.Save("~/Uploads/Referances/" + nm);

                string a = "/Uploads/Referances/" + nm;

                referances.Image = a;
                db.Referances.Add(referances);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            return View(referances);
        }

        // GET: Referance/Edit/5
       

        // GET: Referance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referances referances = db.Referances.Find(id);
            if (referances == null)
            {
                return HttpNotFound();
            }

            db.Referances.Remove(referances);
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
