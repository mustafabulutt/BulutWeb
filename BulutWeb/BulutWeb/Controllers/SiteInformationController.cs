using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
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
    public class SiteInformationController : Controller
    {
        private BulutDbContext db = new BulutDbContext();

        // GET: SiteInformation
        public ActionResult Index()
        {
            return View(db.SiteInformation.ToList());
        }


        public ActionResult Edit(int? id )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteInformation siteInformation = db.SiteInformation.Find(id);
            if (siteInformation == null)
            {
                return HttpNotFound();
            }
            return View(siteInformation);
        }

        // POST: SiteInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SiteInformation siteInformation, HttpPostedFileBase Logo, HttpPostedFileBase SiteIcon)
        {
            if (ModelState.IsValid)
            {

                var information = db.SiteInformation.Where(x => x.Id == id).FirstOrDefault();

                if (Logo != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(information.Logo)))
                    {
                        System.IO.File.Delete(Server.MapPath(information.Logo));
                    }
                    WebImage img = new WebImage(Logo.InputStream);
                    FileInfo imginfo = new FileInfo(Logo.FileName);
                    string nm = Logo.FileName + imginfo.Extension;
                    img.Resize(600, 400);
                    img.Save("~/Uploads/SiteInformation/" + nm);

                    information.Logo = "/Uploads/SiteInformation/" + nm;
                }

                if (SiteIcon != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(information.SiteIcon)))
                    {
                        System.IO.File.Delete(Server.MapPath(information.SiteIcon));
                    }
                    WebImage img = new WebImage(SiteIcon.InputStream);
                    FileInfo imginfo = new FileInfo(SiteIcon.FileName);
                    string nm = SiteIcon.FileName + imginfo.Extension;
                    img.Resize(600, 400);
                    img.Save("~/Uploads/SiteInformation/" + nm);

                    information.SiteIcon = "/Uploads/SiteInformation/" + nm;
                }

                information.Author = siteInformation.Author;
                information.Description = siteInformation.Description;
                information.Id = siteInformation.Id;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteInformation);
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
