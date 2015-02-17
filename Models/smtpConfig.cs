using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChukkaDash.Models
{
    public class smtpConfig
    {
        [Key]
        public int Id { get; set; }
        public string hostname { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int port { get; set; }
    }
}