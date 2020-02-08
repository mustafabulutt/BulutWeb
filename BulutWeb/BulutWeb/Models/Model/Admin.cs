using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BulutWeb.Models.Model
{
    [Table("Admin")]
    public class Admin
    {
        public Guid Id { get; set; }

        [DisplayName("İsim")]
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }
    }
}