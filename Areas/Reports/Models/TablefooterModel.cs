using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChukkaDashB.Areas.Reports.Models
{
    public class TablefooterModel
    {
        public int total_adult { get; set; }
        public int total_children { get; set; }
        public int total_comp { get; set; }
        public int total_pax { get; set; }
    }
}