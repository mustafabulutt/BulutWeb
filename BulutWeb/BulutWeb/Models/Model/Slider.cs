using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BulutWeb.Models.Model
{
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Slider Resmi")]
        public string Image { get; set; }
        [DisplayName("Resim Açıklaması")]
        public string Description { get; set; }
    }
}