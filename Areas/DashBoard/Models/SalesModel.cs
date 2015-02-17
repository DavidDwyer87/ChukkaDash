using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChukkaDashB.Areas.DashBoard.Models
{
    public class SalesModel
    {
        public int pax { get; set; }
        public int tours { get; set; }

        public int traget { get; set; }

        public string resort { get; set; }
        public string cruise { get; set; }
        public string sales { get; set; }
        public string direct { get; set; }
        public string groups { get; set; }
    }
}