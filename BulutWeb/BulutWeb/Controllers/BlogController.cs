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
    public class BlogController : Controller
    {
        private BulutDbContext db = new BulutDbContext();

        // GET: Blog
        public ActionResult Index()
        {
            var blog = db.Blog.Include(b => b.category);

            return View(blog.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name");
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create( Blog blog,HttpPostedFileBase Image)
        {
            if (Image!=null)
            {

                if (ModelState.IsValid)
                {
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo imginfo = new FileInfo(Image.FileName);
                    string nm = Image.FileName + imginfo.Extension;
                    img.Resize(600, 400);
                    img.Save("~/Uploads/BlogPost/" + nm);

                     string a = "/Uploads/BlogPost/" + nm;

                    blog.Image = a;
                    db.Blog.Add(blog);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }

            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", blog.CategoryId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Blog blog, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var bedit = db.Blog.Where(x => x.BlogId == id).FirstOrDefault();
                if (Image != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(bedit.Image)))
                    {
                        System.IO.File.Delete(Server.MapPath(bedit.Image));
                    }
                    WebImage img = new WebImage(Image.InputStream);
                    FileInfo imginfo = new FileInfo(Image.FileName);
                    string nm = Image.FileName + imginfo.Extension;
                    img.Resize(600, 400);
                    img.Save("~/Uploads/BlogPost/" + nm);

                    bedit.Image = "/Uploads/BlogPost/" + nm;
                }

                bedit.BlogId = blog.BlogId;
                bedit.CategoryId = blog.CategoryId;
                bedit.Content = blog.Content;
                bedit.Title = blog.Title;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", blog.CategoryId);
            return View(blog);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            if (System.IO.File.Exists(Server.MapPath(blog.Image)))
            {
                System.IO.File.Delete(Server.MapPath(blog.Image));
            }

            db.Blog.Remove(blog);
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
