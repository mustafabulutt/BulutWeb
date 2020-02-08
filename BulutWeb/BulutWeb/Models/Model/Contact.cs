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
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int  Id { get; set; }

        [DisplayName("Telefon ")]
        public string PhoneNumber { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Adres")]
        public string address { get; set; }

        [DisplayName("Embed url")]
        [AllowHtml]
        public string MapUrl { get; set; }
    }
}