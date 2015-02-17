using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChukkaDash.Models
{
    public class Payments
    {
        [Key]
        public int Id { get; set; }
        public string TransNum { get; set; }
        public string Payment { get; set; }
        public string code { get; set; }
        public string Refid { get; set; }
        public string Price1 { get; set; }
        public string Price2 { get; set; }
        public string Price3 { get; set; }
        public string Price4 { get; set; }
        public string Price5 { get; set; }
        public string Price6 { get; set; }
        public string Price7 { get; set; }
        public string Price8 { get; set; }
        public string Price9 { get; set; }
        public string SubTotal { get; set; }
        public string Taxes { get; set; }
        public string Fees { get; set; }
        public string Total { get; set; }
        public string Paid { get; set; }
        public string Owning { get; set; }
    }
}
