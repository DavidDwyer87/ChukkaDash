using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChukkaDashB.Areas.Reports.Models
{
    public class DetailsModel
    {
        public int index { get; set; }
        public string transNum { get; set; }
        public string date { get; set; }
        public int adult { get; set; }
        public int children { get; set; }
        public int comp { get; set; }
        public int pax { get; set; }
        public string tourname { get; set; }
        public string salerep { get; set; }
        public string hotelname { get; set; }
        public string promocode { get; set; }
    }
}