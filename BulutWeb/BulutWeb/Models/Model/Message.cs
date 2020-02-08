using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BulutWeb.Models.Model
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("İsim")]
        public string Name { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Konu")]
        public string Subject { get; set; }

        [DisplayName("Mesaj")]
        public string Messages { get; set; }
    }
}