using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BulutWeb.Models.Model
{
    [Table("Comments")]
    public class Comments
    {
        [Key]
        public int CommentsId { get; set; }

        [DisplayName("İsim")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Yorum")]
        [Required]
        [AllowHtml]
        public string Comment { get; set; }

        [DisplayName("Onay")]
        public bool Confirmation { get; set; }




        public int BlogId { get; set; }

        public Blog blog { get; set; }


    }
}