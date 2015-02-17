using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChukkaDashB.Areas.Reports.Models
{
    public class ResortTableModel
    {
        public int index { get; set; }
        public string customID { get; set; }
        public string name { get; set; }
        public int adults { get; set; }
        public int children { get; set; }
        public int comp { get; set; }
        public int pax { get; set; }
        public string rep { get; set; }
    }
}