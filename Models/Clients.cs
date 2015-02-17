using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChukkaDash.Models
{
    public class Clients
    {
        [Key]
        public int id { get; set; }
        public string TransNum { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string Country { get; set; }
        public string phone { get; set; }
        public string Email { get; set; }
        public string Labels { get; set; }
        public string Status { get; set; }
        public string TourName { get; set; }
        public string Option { get; set; }        
    }
}
