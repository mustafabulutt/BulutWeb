using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BulutWeb.Models.Model
{
    [Table("Referanslar")]
    public class Referances
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Resim")]
        public string Image { get; set; }
    }
}