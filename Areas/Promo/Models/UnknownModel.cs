using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChukkaDashB.Areas.Promo.Models
{
    public class UnknownModel
    {
        public List<unknownDataModel> tabledata { get; set; }
    }

    public class unknownDataModel
    {
        public int index { get; set; }
        public string name { get; set; }
    }
}