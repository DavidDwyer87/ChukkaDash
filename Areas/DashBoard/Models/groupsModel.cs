using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChukkaDashB.Areas.DashBoard.Models
{
    public class groupsModel
    {
        public int local { get; set; }
        public int national { get; set; }

        public int resort_target { get; set; }
        public int cruise_target { get; set; }
        public int sales_target { get; set; }
        public int direct_target { get; set; }
        public int groups_target { get; set; }

        public string resort { get; set; }
        public string cruise { get; set; }
        public string sales { get; set; }
        public string direct { get; set; }
        public string groups { get; set; }
    }
}