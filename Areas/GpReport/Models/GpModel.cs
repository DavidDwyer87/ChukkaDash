using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChukkaDashB.Areas.GpReport.Models
{
    public class GpModel
    {
        public string week { get; set; }
        public string month { get; set; }
        public string year { get; set; }

        //report controls
        public string datefrom { get; set; }
        public string dateto { get; set; }

        public string filterVal { get; set; }
        public string filterVals { get; set; }

        public List<TableData> data { get; set; }
        public TotalData total { get; set; }
    }
}