using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChukkaDash.Models
{
    public class bookings
    {
        [Key]
        public int Id{get;set;}
        public string TransNum { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string BookedFor { get; set; }
        public string OwnedBy { get; set; }
        public int PAX { get; set; }
        public string OrderCode { get; set; }
        public string Status { get; set; }
    }
}
