using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChukkaDash.Models
{

    public class PromoCustomerRelation
    {
        [Key]
        public int Id { get; set; }
        //public string CustomerID { get; set; }
        public string PromoCodes { get; set; }
        //public string channel { get; set; }
        //public string catigory { get; set; }
        //public string locaton { get; set; }
    }
}