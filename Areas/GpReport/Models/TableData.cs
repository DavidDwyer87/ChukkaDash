using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChukkaDashB.Areas.GpReport.Models
{
    public class TableData
    {
        public int index { get; set; }
        public string CustomerID { get; set; }
        public string name { get; set; }
        public int adult { get; set; }
        public int children { get; set; }
        public int Pax { get; set; }
    }
}