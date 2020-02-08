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
    [Table("About")]
    public class About
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Resim")]
        public string Image { get; set; }

        [DisplayName("Resim Bilgisi")]
        public string ImageInformation { get; set; }

        [DisplayName("Başlık")]
        public string Title { get; set; }

        [DisplayName("Açıklama")]
        [AllowHtml]
        public string Description { get; set; }
    }
}