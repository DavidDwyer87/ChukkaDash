using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChukkaDashB.Areas.DashBoard.Models
{
    public class resortModel
    {
        public int _resort { get; set; }
        public int _hotel { get; set; }
        public int _intlgrp { get; set; }

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

        public string week { get; set; }
        public string month { get; set; }
        public string year { get; set; }
    }
}