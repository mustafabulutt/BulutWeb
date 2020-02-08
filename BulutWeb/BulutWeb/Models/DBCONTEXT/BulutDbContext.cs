using BulutWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BulutWeb.Models.DBCONTEXT
{
    public class BulutDbContext : DbContext
    {

     public BulutDbContext() : base("BulutDb")
     {

     }
        #region DbSet
        public DbSet<About> About { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Referances> Referances { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Skils> Skils { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<SiteInformation> SiteInformation { get; set; }

        #endregion
               
    }
}