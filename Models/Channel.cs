using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChukkaDash.Models
{
    public class Channel
    {
        [Key]
        public int Id { get; set; }
        public string Customer { get; set; }
        public string name { get; set; }
        public string channel { get; set; }
        public string catigory { get; set; }
        public string tag { get; set; }
    }
}