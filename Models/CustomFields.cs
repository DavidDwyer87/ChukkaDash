using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChukkaDash.Models
{
    public class CustomFields
    {
        [Key]
        public int Id{get;set;}
        public string TransNum { get; set; }
        public string HotelName { get; set; }
        public string RoomNum { get; set; }
        public string PickupTime { get; set; }
        public string RepListing { get; set; }
        public string voucherNum { get; set; }
        public string ReceiptNum { get; set; }
        public string newRep { get; set; }
        public string Comments { get; set; }
        public string Driver { get; set; }
        public string Ship { get; set; }
        public string PickupPlace { get; set; }

    }
}
