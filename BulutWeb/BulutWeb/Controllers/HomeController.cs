using BulutWeb.Models.DBCONTEXT;
using BulutWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BulutWeb.Controllers
{
    public class HomeController : Controller
    {
        BulutDbContext db = new BulutDbContext();
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
           

            return View();
        }

        public ActionResult Contact()
        {
            
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult CategoryDetails(int? id)
        {
            if (id==null)
            {
                Response.Redirect("Blog");
            }

            Category cat = db.Category.Find(id);

            if (cat==null)
            {
                return HttpNotFound();

            }

            var kategori = db.Blog
                .Include(x=>x.category)
                .Include(x=>x.comments)
                .Where(x => x.CategoryId == id).ToList();          


            var categoryname = db.Category.Where(x => x.CategoryId == id).FirstOrDefault();

            


            ViewBag.KategoriAdi = categoryname.Name;

            return View(kategori);
        }



        public JsonResult Messages(string name, string email, string subject, string messages)
        {

            if (name== "" || email =="" || subject =="" || messages =="")
            {
                return Json(new { result = 1 });
                
            }
            db.Message.Add(new Message { Name = name, Email = email, Subject = subject, Messages = messages });
            db.SaveChanges();
            return Json(new { result = 2, message = "Başarılı." });
        }

        public JsonResult Comments(string name,string email, string comment, int blogıd)
        {
            if (comment == "" || name == "" || email ==""  )
            {               
                return Json(new { result = 1 });
            }
            db.Comments.Add(new Comments { Name = name, Comment = comment, Email = email,BlogId =blogıd  });
            db.SaveChanges();
            return Json(false, JsonRequestBehavior.AllowGet);

        }



        public ActionResult Services()
        {
            return View();
        }

        public ActionResult BlogDetail(int? id)
        {
            if (id==null)
            {
                Response.Redirect("/Home/Blog");
            }
            Blog blog = db.Blog.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
      

            var detail = db.Blog
                .Include(x=>x.category)
                .Include(x=>x.comments)
                .Where(x => x.BlogId == id).FirstOrDefault();

            

            return View(detail);
        }


        #region PartialView

        public ActionResult LayoutLogoPartial()
        {
            return View(db.SiteInformation.FirstOrDefault());
        }



        public ActionResult LayoutHeadPartial()
        {

            return View(db.SiteInformation.FirstOrDefault()) ;
        }




        public ActionResult DetailsCommentsPartial(int? id)
        {
            var comments = db.Comments.Where(x => x.BlogId == id).ToList();
            var oke = comments.Where(x => x.Confirmation == true).ToList();
            return View(oke);
        }
     

        public ActionResult LatestBlogPartial()
        {
            var LatestBlogg = (from i in db.Blog
                               orderby i.BlogId descending /*blog listesinne ekelenen kayıtları orderbydesceding ile sondan başa doğru sıraladım ve anasayfada son eklenen postları gösterdim*/
                               select i).Take(4).ToList();

            return View(LatestBlogg);
        }


        public ActionResult BlogSCategoriePartial()
        {


            return View(db.Category.ToList()) ;
        }


        public ActionResult BlogPartial()
        {
            var blog = db.Blog
                .Include(x=>x.comments)
                .Include(x => x.category).ToList();

                
                


            return View(blog);
        }


        public ActionResult ContactPartial()
        {
            return View(db.Contact.FirstOrDefault()) ;
        }



        public ActionResult VideoPartial()
        {
            return View(db.Video.FirstOrDefault());
        }


        public ActionResult ServicesPartial2()
        {
            return View(db.Services.ToList());
        }




        public ActionResult SkilsPartial()
        {
            return View(db.Skils.ToList()) ;
        }
       
        public ActionResult ReferancePartial()
        {
            return View(db.Referances.ToList()) ;
        }

        public ActionResult AboutPartial()
        {
            return View(db.About.ToList()) ;
        }


        public ActionResult SliderPartial()
        {
            return View(db.Slider.ToList());
        }

        public ActionResult ServicesPartial()
        {
            var list = db.Services.ToList().Take(3);
                
                
            return View(list);
        }


        public ActionResult BlogHomePartial()
        {
            var BlogHome = (from i in db.Blog
                         orderby i.BlogId descending /*blog listesinne ekelenen kayıtları orderbydesceding ile sondan başa doğru sıraladım ve anasayfada son eklenen postları gösterdim*/
                         select i).ToList(); 
            return View(BlogHome);
        }


        #endregion
    }
}