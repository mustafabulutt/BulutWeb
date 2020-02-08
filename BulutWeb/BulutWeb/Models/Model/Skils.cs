using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BulutWeb.Models.Model
{
    [Table("Skils")]
    public class Skils
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Başlık")]
        [StringLength(15)]
        public string Title { get; set; }

        [DisplayName("Yetenek Seviyesi")]
        public int SkilLevel { get; set; }
    }
}