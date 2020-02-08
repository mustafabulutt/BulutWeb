using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace BulutWeb.Models.Model
{
    [Table("SiteInformation")]
    public class SiteInformation
    {
        [DisplayName("Id")]
        [Key]
        public int Id { get; set; }

        [DisplayName("Logo")]
        public string Logo { get; set; }

        [DisplayName("Site Açıklama")]
        public string Description { get; set; }

        [DisplayName("Site Yazarı")]
        public string Author { get; set; }

        [DisplayName("Site İconu")]
        public string SiteIcon { get; set; }
    }
}