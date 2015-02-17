using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChukkaDashB.Areas.Promo.Models
{
    public class PageModel
    {
        public PromoNavModel nav { get; set; }
        public Dictionary<string, List<TableScafoiding>> pagedata { get; set; }
        public string channel { get; set; }
        public string returnurl { get; set; }
    }
}