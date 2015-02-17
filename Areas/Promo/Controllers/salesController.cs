using ChukkaDashB.Areas.Promo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChukkaDashB.Areas.Promo.Controllers
{
    public class salesController : Controller
    {
        //
        // GET: /Promo/sales/

        public ActionResult Index()
        {
            PageModel m = new PageModel();
            m.nav = new PromoNavModel();
            m.nav.sales = "active";
            m.returnurl = "sales";

            new DataModel().sales(m);
            return View(m);
        }

    }
}
