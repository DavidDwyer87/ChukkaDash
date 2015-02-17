using ChukkaDashB.Areas.Promo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChukkaDashB.Areas.Promo.Controllers
{
    public class cruiseController : Controller
    {
        //
        // GET: /Promo/cruise/

        public ActionResult Index()
        {
            PageModel m = new PageModel();
            m.nav = new PromoNavModel();
            m.nav.cruise = "active";
            m.channel = "cruise";
            m.returnurl = "cruise";

            new DataModel().cruise(m);
            return View(m);
        }

    }
}
