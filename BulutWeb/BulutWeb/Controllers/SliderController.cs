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
    public class SliderController : Controller
    {
        private BulutDbContext db = new BulutDbContext();

        // GET: Slider
        public ActionResult Index()
        {
            return View(db.Slider.ToList());
        }

        // GET: Slider/Details/5
       

        // GET: Slider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Slider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create( Slider slider,HttpPostedFileBase Image)
        {
            if (Image!=null)
            {

            

            if (ModelState.IsValid)
            {
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo imginfo = new FileInfo(Image.FileName);
                    string nm = Image.FileName + imginfo.Extension;
                    img.Resize(600, 400,false,true);
                    
                    
                    img.Save("~/Uploads/Slider/" + nm);

                    string a = "/Uploads/Slider/" + nm;

                    slider.Image = a;

                db.Slider.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            return View(slider);
        }

        // GET: Slider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Slider slider, HttpPostedFileBase Image)
        {

            if (ModelState.IsValid)
            {
                var Sledit = db.Slider.Where(x => x.Id == id).FirstOrDefault();
                if (Image != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(Sledit.Image)))
                    {
                        System.IO.File.Delete(Server.MapPath(Sledit.Image));
                    }
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo imginfo = new FileInfo(Image.FileName);
                    string nm = Image.FileName + imginfo.Extension;
                    img.Resize(600, 400);
                    img.Save("~/Uploads/Slider/" + nm);

                    Sledit.Image = "/Uploads/Slider/" + nm;
                }
                Sledit.Id = slider.Id;
                Sledit.Description = slider.Description;
               

                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return View(slider);
        }

        // GET: Slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }

            if (System.IO.File.Exists(Server.MapPath(slider.Image)))
            {
                System.IO.File.Delete(Server.MapPath(slider.Image));
            }


            db.Slider.Remove(slider);
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
