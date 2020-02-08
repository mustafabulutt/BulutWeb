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
    public class CommentController : Controller
    {
        private BulutDbContext db = new BulutDbContext();

        // GET: Comment
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.blog);
            return View(comments.ToList());
        }

   

      
        // GET: Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = db.Comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogId = new SelectList(db.Blog, "BlogId", "Title", comments.BlogId);
            var commentttt = db.Comments
                .Include(x=>x.blog)
                .Where(x => x.CommentsId == id).FirstOrDefault(); 
            return View(commentttt);
        }

        // POST: Comment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit( int id ,Comments comments)
        {
            
                var comm = db.Comments .Include(x=>x.blog) .Where(x => x.CommentsId == id).FirstOrDefault();

                comm.Confirmation = comments.Confirmation;
                db.SaveChanges();
                return RedirectToAction("Index");
         
            
           
        }

        // GET: Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comments comments = db.Comments.Find(id);
            if (comments == null)
            {
                return HttpNotFound();
            }

            db.Comments.Remove(comments);
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
