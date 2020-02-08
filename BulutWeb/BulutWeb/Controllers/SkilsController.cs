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
    public class SkilsController : Controller
    {
        private BulutDbContext db = new BulutDbContext();

        // GET: Skils
        public ActionResult Index()
        {
            return View(db.Skils.ToList());
        }

        // GET: Skils/Details/5
      

        // GET: Skils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,SkilLevel")] Skils skils)
        {
            if (ModelState.IsValid)
            {
                db.Skils.Add(skils);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skils);
        }

        // GET: Skils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skils skils = db.Skils.Find(id);
            if (skils == null)
            {
                return HttpNotFound();
            }
            return View(skils);
        }

        // POST: Skils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,SkilLevel")] Skils skils)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skils).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skils);
        }

        // GET: Skils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skils skils = db.Skils.Find(id);
            if (skils == null)
            {
                return HttpNotFound();
            }
            db.Skils.Remove(skils);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // POST: Skils/Delete/5
        

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
