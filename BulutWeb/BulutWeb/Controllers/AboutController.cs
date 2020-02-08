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
using Microsoft.Crm.Sdk.Messages;

namespace BulutWeb.Controllers
{
    public class AboutController : Controller
    {
        private BulutDbContext db = new BulutDbContext();

        // GET: About
        public ActionResult Index()
        {
            return View(db.About.ToList());
        }

      
       

      
        // GET: About/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = db.About.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        // POST: About/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, About about,HttpPostedFileBase ResimUrl)
        {
            if (ModelState.IsValid)
            {
                var ab = db.About.Where(x => x.Id == id).SingleOrDefault();
                if (ResimUrl != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(ab.Image)))
                    {
                        System.IO.File.Delete(Server.MapPath(ab.Image));
                    }
                    WebImage img = new WebImage(ResimUrl.InputStream);
                    FileInfo imginfo = new FileInfo(ResimUrl.FileName);
                    string nm = ResimUrl.FileName + imginfo.Extension;
                    img.Resize(600, 400);
                    img.Save("~/Uploads/AboutImage/" + nm);

                    ab.Image = "/Uploads/AboutImage/" + nm;
                }
                ab.Description = about.Description;
                ab.Title = about.Title;
                ab.ImageInformation = about.ImageInformation;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
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
