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
    [Table("Video")]
    public class Video
    {
        [Key]
        public int Id { get; set; }


        [DisplayName("Video Url")]
        [AllowHtml]
        public string Url { get; set; }
    }
}